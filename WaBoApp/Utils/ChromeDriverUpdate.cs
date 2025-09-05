using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WaApp.Models;

namespace WaApp.Utils
{
    public class ChromeDriverUpdate
    {
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://chromedriver.storage.googleapis.com/")
        };

        public async Task<Result> CheckUpate(Action<int> action)
        {

            var result = new Result();
            var chromeVersion = ChormeUtils.GetChromeVersion();
            if (string.IsNullOrEmpty(chromeVersion))
            {
                result.Message = $"Please install Google Chorme!";
                result.IsSuccess = false;
                return result;
            }
            chromeVersion = chromeVersion.Substring(0, chromeVersion.LastIndexOf('.'));
            var chromeDriverVersionResponse = await httpClient.GetAsync($"LATEST_RELEASE_{chromeVersion}");
            if (!chromeDriverVersionResponse.IsSuccessStatusCode)
            {
                if (chromeDriverVersionResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    result.Message = $"ChromeDriver version not found for Chrome version {chromeVersion}";
                }
                else
                {
                    result.Message = $"Get ChromeDriver version  failed! please check you network!";
                }
                result.IsSuccess = false;
                return result;
            }

            var zipName = "chromedriver_win32.zip";
            var driverName = "chromedriver.exe";
            var chromeDriverVersion = await chromeDriverVersionResponse.Content.ReadAsStringAsync();
            string targetPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            targetPath = Path.Combine(targetPath, driverName);
            var localVersion = await this.GetLocalVersion(targetPath);
            if (chromeDriverVersion == localVersion)
            {
                result.Message = $"You already have the latest ChromeDriver version!";
                result.IsSuccess = true;
                return result;
            }
            else
            {
                this.ShutdownChromeDriver(targetPath);
                return await DownLoadChromeDriverAsync(targetPath, driverName, chromeDriverVersion, zipName, action);
            }
        }


        private void ShutdownChromeDriver(string driverName)
        {
            var processes = Process.GetProcesses().Where(p => p.ProcessName == "chromedriver");

            foreach (var process in processes)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                }
            }
        }
        private async Task<string> GetLocalVersion(string targetPath)
        {
            if (File.Exists(targetPath))
            {
                using (var process = Process.Start(
                    new ProcessStartInfo
                    {
                        FileName = targetPath,
                        Arguments = "--version",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                    }

                ))
                {
                    string existingChromeDriverVersion = await process.StandardOutput.ReadToEndAsync();
                    string error = await process.StandardError.ReadToEndAsync();
                    process.WaitForExit();
                    existingChromeDriverVersion = existingChromeDriverVersion.Split(' ')[1];
                    return existingChromeDriverVersion;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        private async Task DownLoadChromeDriver(string targetPath, string driverName, string chromeDriverVersion, string zipName)
        {
            var driverZipResponse = await httpClient.GetAsync($"{chromeDriverVersion}/{zipName}");
            if (!driverZipResponse.IsSuccessStatusCode)
            {
                throw new Exception($"ChromeDriver download request failed reason phrase: {driverZipResponse.ReasonPhrase}");
            }

            using (var zipFileStream = await driverZipResponse.Content.ReadAsStreamAsync())
            using (var zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Read))
            using (var chromeDriverWriter = new FileStream(targetPath, FileMode.Create))
            {
                var entry = zipArchive.GetEntry(driverName);
                using (var chromeDriverStream = entry.Open())
                {
                    await chromeDriverStream.CopyToAsync(chromeDriverWriter);
                }
            }
        }

        private async Task<Result> DownLoadChromeDriverAsync(string targetPath, string driverName, string chromeDriverVersion,
            string zipName, Action<int> progress)
        {
            var driverZipResponse = await httpClient.GetAsync($"{chromeDriverVersion}/{zipName}");
            if (!driverZipResponse.IsSuccessStatusCode)
            {
                return new Result
                {
                    IsSuccess = false,
                    Message = $"ChromeDriver download request failed reason phrase: {driverZipResponse.ReasonPhrase}"
                };
            }

            var n = driverZipResponse.Content.Headers.ContentLength;
            var zipFileStream = await driverZipResponse.Content.ReadAsStreamAsync();

            using (zipFileStream)
            {
                byte[] buffer = new byte[8192];
                var readLength = 0;
                int length;
                while ((length = await zipFileStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    readLength += length;
                    var downloadProgress = (int)(((double)readLength) / n * 100);
                    progress(downloadProgress);
                    if (downloadProgress % 4 == 0)
                    {
                        await Task.Delay(1);
                    }
                }

                using (var zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Read))
                using (var chromeDriverWriter = new FileStream(targetPath, FileMode.Create))
                {
                    var entry = zipArchive.GetEntry(driverName);
                    using (var chromeDriverStream = entry.Open())
                    {
                        await chromeDriverStream.CopyToAsync(chromeDriverWriter);
                    }
                }
            }

            return new Result() { IsSuccess = true };


        }
    }
}
