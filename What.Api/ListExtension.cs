using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace What.Api
{
    public static class ListExtension
    {
        public static IWebElement LastNew(this IEnumerable<IWebElement> source)
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                var styleStr = item.GetAttribute("style");
                if (!string.IsNullOrEmpty(styleStr))
                {
                    var tranYStr = styleStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? string.Empty;
                    var match = Regex.Match(tranYStr, @"(\d)+", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        var num = match.Groups.Cast<Group>()?.FirstOrDefault()?.Value;
                        list.Add(Convert.ToInt32(num));
                    }
                }
            }
            var max = list.Max();
            var index = list.FindIndex(s => s == max);
            return source.ElementAt(index);
        }


        public static IWebElement FirstNew(this IEnumerable<IWebElement> source)
        {
            var list = new List<int>();
            foreach (var item in source)
            {
                var styleStr = item.GetAttribute("style");
                if (!string.IsNullOrEmpty(styleStr))
                {
                    var tranYStr = styleStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? string.Empty;
                    var match = Regex.Match(tranYStr, @"(\d)+", RegexOptions.IgnoreCase);
                    if (match.Success)
                    {
                        var num = match.Groups.Cast<Group>()?.FirstOrDefault()?.Value;
                        list.Add(Convert.ToInt32(num));
                    }
                }
            }
            var min = list.Min();
            var index = list.FindIndex(s => s == min);
            return source.ElementAt(index);
        }
    }

    

}
