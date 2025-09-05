
namespace WaApp
{
    partial class FrmMain
    {
        /// <summary>
        /// 
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 

        /// <summary>
        /// 
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.krBtnConfig = new Krypton.Ribbon.KryptonRibbon();
            this.rbTabSet = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup1 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple1 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krgbBtnSet = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbBtnMessage = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupGallery1 = new Krypton.Ribbon.KryptonRibbonGroupGallery();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.rbTabContact = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup2 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple2 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krgbImport = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbImportContact = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbSendMsg = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupTriple6 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krBtnCheck = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.rbTabGroups = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup3 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple3 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krgbGroupMsg = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbScrapeMember = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.rbTabAutoBot = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup4 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple4 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krgbBotMessage = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbBot = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.rbTabAbout = new Krypton.Ribbon.KryptonRibbonTab();
            this.kryptonRibbonGroup5 = new Krypton.Ribbon.KryptonRibbonGroup();
            this.kryptonRibbonGroupTriple5 = new Krypton.Ribbon.KryptonRibbonGroupTriple();
            this.krgbAbout = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbHelp = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.krgbConactUs = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonNavigator1 = new Krypton.Navigator.KryptonNavigator();
            this.kryptonManager1 = new Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPalette1 = new Krypton.Toolkit.KryptonPalette(this.components);
            this.kryptonRibbonGroupButton4 = new Krypton.Ribbon.KryptonRibbonGroupButton();
            this.kryptonRibbonGroupButton5 = new Krypton.Ribbon.KryptonRibbonGroupButton();
            ((System.ComponentModel.ISupportInitialize)(this.krBtnConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // krBtnConfig
            // 
            this.krBtnConfig.AllowMinimizedChange = false;
            this.krBtnConfig.InDesignHelperMode = true;
            this.krBtnConfig.MinimizedMode = true;
            this.krBtnConfig.Name = "krBtnConfig";
            this.krBtnConfig.QATLocation = Krypton.Ribbon.QATLocation.Hidden;
            this.krBtnConfig.RibbonAppButton.AppButtonShowRecentDocs = false;
            this.krBtnConfig.RibbonAppButton.AppButtonVisible = false;
            this.krBtnConfig.RibbonTabs.AddRange(new Krypton.Ribbon.KryptonRibbonTab[] {
            this.rbTabSet,
            this.rbTabContact,
            this.rbTabGroups,
            this.rbTabAutoBot,
            this.rbTabAbout});
            this.krBtnConfig.SelectedContext = null;
            this.krBtnConfig.SelectedTab = this.rbTabSet;
            this.krBtnConfig.Size = new System.Drawing.Size(1333, 203);
            this.krBtnConfig.TabIndex = 0;
            // 
            // rbTabSet
            // 
            this.rbTabSet.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup1});
            this.rbTabSet.Text = "Setup";
            // 
            // kryptonRibbonGroup1
            // 
            this.kryptonRibbonGroup1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple1,
            this.kryptonRibbonGroupGallery1});
            this.kryptonRibbonGroup1.TextLine1 = " ";
            // 
            // kryptonRibbonGroupTriple1
            // 
            this.kryptonRibbonGroupTriple1.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krgbBtnSet,
            this.krgbBtnMessage});
            // 
            // krgbBtnSet
            // 
            this.krgbBtnSet.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbBtnSet.ImageLarge")));
            this.krgbBtnSet.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbBtnSet.ImageSmall")));
            this.krgbBtnSet.TextLine1 = "Config";
            this.krgbBtnSet.Click += new System.EventHandler(this.krgbBtnSet_Click);
            // 
            // krgbBtnMessage
            // 
            this.krgbBtnMessage.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbBtnMessage.ImageLarge")));
            this.krgbBtnMessage.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbBtnMessage.ImageSmall")));
            this.krgbBtnMessage.TextLine1 = "Message";
            this.krgbBtnMessage.Click += new System.EventHandler(this.krgbBtnMessage_Click);
            // 
            // kryptonRibbonGroupGallery1
            // 
            this.kryptonRibbonGroupGallery1.ImageList = this.imageList2;
            this.kryptonRibbonGroupGallery1.SelectedIndexChanged += new System.EventHandler(this.kryptonRibbonGroupGallery1_SelectedIndexChanged);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "flag_usa.png");
            this.imageList2.Images.SetKeyName(1, "flag_arab.png");
            this.imageList2.Images.SetKeyName(2, "flag_china.png");
            this.imageList2.Images.SetKeyName(3, "flag_spain.png");
            this.imageList2.Images.SetKeyName(4, "flag_belgium.png");
            this.imageList2.Images.SetKeyName(5, "flag_canada.png");
            this.imageList2.Images.SetKeyName(6, "flag_germany.png");
            this.imageList2.Images.SetKeyName(7, "flag_norway.png");
            this.imageList2.Images.SetKeyName(8, "flag_south_africa.png");
            this.imageList2.Images.SetKeyName(9, "flag_switzerland.png");
            this.imageList2.Images.SetKeyName(10, "flag_united_kingdom.png");
            this.imageList2.Images.SetKeyName(11, "flag_vietnam.png");
            this.imageList2.Images.SetKeyName(12, "flag_russia.png");
            this.imageList2.Images.SetKeyName(13, "flag_hk.png");
            this.imageList2.Images.SetKeyName(14, "flag_Italy.png");
            this.imageList2.Images.SetKeyName(15, "flag-Cambodia.png");
            // 
            // rbTabContact
            // 
            this.rbTabContact.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup2});
            this.rbTabContact.Text = "Contact";
            // 
            // kryptonRibbonGroup2
            // 
            this.kryptonRibbonGroup2.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple2,
            this.kryptonRibbonGroupTriple6});
            this.kryptonRibbonGroup2.TextLine1 = " ";
            // 
            // kryptonRibbonGroupTriple2
            // 
            this.kryptonRibbonGroupTriple2.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krgbImport,
            this.krgbImportContact,
            this.krgbSendMsg});
            // 
            // krgbImport
            // 
            this.krgbImport.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbImport.ImageLarge")));
            this.krgbImport.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbImport.ImageSmall")));
            this.krgbImport.TextLine1 = "Import Phone";
            this.krgbImport.Click += new System.EventHandler(this.krgbImport_Click);
            // 
            // krgbImportContact
            // 
            this.krgbImportContact.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbImportContact.ImageLarge")));
            this.krgbImportContact.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbImportContact.ImageSmall")));
            this.krgbImportContact.TextLine1 = "Import Contact";
            this.krgbImportContact.Click += new System.EventHandler(this.krgbImportContact_Click);
            // 
            // krgbSendMsg
            // 
            this.krgbSendMsg.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbSendMsg.ImageLarge")));
            this.krgbSendMsg.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbSendMsg.ImageSmall")));
            this.krgbSendMsg.TextLine1 = "Contact Send";
            this.krgbSendMsg.Click += new System.EventHandler(this.krgbSendMsg_Click);
            // 
            // kryptonRibbonGroupTriple6
            // 
            this.kryptonRibbonGroupTriple6.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krBtnCheck});
            // 
            // krBtnCheck
            // 
            this.krBtnCheck.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krBtnCheck.ImageLarge")));
            this.krBtnCheck.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krBtnCheck.ImageSmall")));
            this.krBtnCheck.TextLine1 = "Validate";
            this.krBtnCheck.Click += new System.EventHandler(this.krBtnCheck_Click);
            // 
            // rbTabGroups
            // 
            this.rbTabGroups.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup3});
            this.rbTabGroups.Text = "Groups";
            // 
            // kryptonRibbonGroup3
            // 
            this.kryptonRibbonGroup3.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple3});
            this.kryptonRibbonGroup3.TextLine1 = " ";
            // 
            // kryptonRibbonGroupTriple3
            // 
            this.kryptonRibbonGroupTriple3.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krgbGroupMsg,
            this.krgbScrapeMember});
            // 
            // krgbGroupMsg
            // 
            this.krgbGroupMsg.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbGroupMsg.ImageLarge")));
            this.krgbGroupMsg.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbGroupMsg.ImageSmall")));
            this.krgbGroupMsg.TextLine1 = "Group Send";
            this.krgbGroupMsg.Click += new System.EventHandler(this.krgbGroupMsg_Click);
            // 
            // krgbScrapeMember
            // 
            this.krgbScrapeMember.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbScrapeMember.ImageLarge")));
            this.krgbScrapeMember.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbScrapeMember.ImageSmall")));
            this.krgbScrapeMember.TextLine1 = "Scrape Member";
            this.krgbScrapeMember.Click += new System.EventHandler(this.krgbScrapeMember_Click);
            // 
            // rbTabAutoBot
            // 
            this.rbTabAutoBot.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup4});
            this.rbTabAutoBot.Text = "Auto Bot";
            this.rbTabAutoBot.Visible = false;
            // 
            // kryptonRibbonGroup4
            // 
            this.kryptonRibbonGroup4.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple4});
            this.kryptonRibbonGroup4.TextLine1 = " ";
            // 
            // kryptonRibbonGroupTriple4
            // 
            this.kryptonRibbonGroupTriple4.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krgbBotMessage,
            this.krgbBot});
            // 
            // krgbBotMessage
            // 
            this.krgbBotMessage.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbBotMessage.ImageLarge")));
            this.krgbBotMessage.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbBotMessage.ImageSmall")));
            this.krgbBotMessage.TextLine1 = "Reply Message";
            // 
            // krgbBot
            // 
            this.krgbBot.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbBot.ImageLarge")));
            this.krgbBot.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbBot.ImageSmall")));
            this.krgbBot.TextLine1 = "Bot ";
            this.krgbBot.Click += new System.EventHandler(this.krgbBot_Click);
            // 
            // rbTabAbout
            // 
            this.rbTabAbout.Groups.AddRange(new Krypton.Ribbon.KryptonRibbonGroup[] {
            this.kryptonRibbonGroup5});
            this.rbTabAbout.Text = "About";
            // 
            // kryptonRibbonGroup5
            // 
            this.kryptonRibbonGroup5.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupContainer[] {
            this.kryptonRibbonGroupTriple5});
            this.kryptonRibbonGroup5.TextLine1 = " ";
            // 
            // kryptonRibbonGroupTriple5
            // 
            this.kryptonRibbonGroupTriple5.Items.AddRange(new Krypton.Ribbon.KryptonRibbonGroupItem[] {
            this.krgbAbout,
            this.krgbHelp,
            this.krgbConactUs});
            // 
            // krgbAbout
            // 
            this.krgbAbout.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbAbout.ImageLarge")));
            this.krgbAbout.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbAbout.ImageSmall")));
            this.krgbAbout.TextLine1 = "About";
            this.krgbAbout.Click += new System.EventHandler(this.krgbAbout_Click);
            // 
            // krgbHelp
            // 
            this.krgbHelp.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbHelp.ImageLarge")));
            this.krgbHelp.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbHelp.ImageSmall")));
            this.krgbHelp.TextLine1 = "Help";
            this.krgbHelp.Click += new System.EventHandler(this.krgbHelp_Click);
            // 
            // krgbConactUs
            // 
            this.krgbConactUs.ImageLarge = ((System.Drawing.Image)(resources.GetObject("krgbConactUs.ImageLarge")));
            this.krgbConactUs.ImageSmall = ((System.Drawing.Image)(resources.GetObject("krgbConactUs.ImageSmall")));
            this.krgbConactUs.TextLine1 = "Contact Us";
            this.krgbConactUs.Click += new System.EventHandler(this.krgbConactUs_Click);
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.BarMinimumHeight = 30;
            this.kryptonNavigator1.Bar.ItemMaximumSize = new System.Drawing.Size(300, 200);
            this.kryptonNavigator1.Bar.ItemSizing = Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.kryptonNavigator1.Bar.TabStyle = Krypton.Toolkit.TabStyle.StandardProfile;
            this.kryptonNavigator1.Button.CloseButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Button.ContextButtonDisplay = Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 203);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Size = new System.Drawing.Size(1333, 798);
            this.kryptonNavigator1.TabIndex = 1;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // kryptonManager1
            // 
            this.kryptonManager1.GlobalPalette = this.kryptonPalette1;
            this.kryptonManager1.GlobalPaletteMode = Krypton.Toolkit.PaletteModeManager.Custom;
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = Krypton.Toolkit.PaletteMode.Office365Silver;
            this.kryptonPalette1.BaseRenderMode = Krypton.Toolkit.RendererMode.Sparkle;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.kryptonPalette1.ButtonStyles.ButtonCommon.OverrideDefault.Back.Color2 = System.Drawing.Color.YellowGreen;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateCommon.Back.Color2 = System.Drawing.Color.Green;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateDisabled.Back.Color1 = System.Drawing.Color.Silver;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateDisabled.Back.Color2 = System.Drawing.Color.Gray;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateTracking.Back.Color1 = System.Drawing.Color.Lime;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateTracking.Back.Color2 = System.Drawing.Color.Green;
            this.kryptonPalette1.ButtonStyles.ButtonCommon.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.ColorAlign = Krypton.Toolkit.PaletteRectangleAlign.Local;
            this.kryptonPalette1.FormStyles.FormCommon.StateActive.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.GlassNormalSimple;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.ForestGreen;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.LimeGreen;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.kryptonPalette1.HeaderStyles.HeaderSecondary.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette1.HeaderStyles.HeaderSecondary.StateCommon.Back.Color2 = System.Drawing.Color.Green;
            this.kryptonPalette1.Ribbon.RibbonTab.StateCommon.BackColor2 = System.Drawing.Color.LimeGreen;
            this.kryptonPalette1.Ribbon.RibbonTab.StateNormal.TextColor = System.Drawing.Color.DarkGreen;
            this.kryptonPalette1.Ribbon.RibbonTab.StateTracking.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.kryptonPalette1.TabStyles.TabCommon.StateCommon.Back.Color1 = System.Drawing.Color.LightGreen;
            // 
            // kryptonRibbonGroupButton4
            // 
            this.kryptonRibbonGroupButton4.TextLine1 = "About";
            // 
            // kryptonRibbonGroupButton5
            // 
            this.kryptonRibbonGroupButton5.TextLine1 = "Help";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 1001);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.krBtnConfig);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaSender - Whatsapp Bulk  Sender |Group Sender| Bot Reply";
            this.TextExtra = "V3.0.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.krBtnConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Ribbon.KryptonRibbonTab rbTabSet;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup1;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple1;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbBtnSet;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbBtnMessage;
        private Krypton.Ribbon.KryptonRibbon krBtnConfig;
        private Krypton.Ribbon.KryptonRibbonTab rbTabContact;
        private Krypton.Ribbon.KryptonRibbonTab rbTabGroups;
        private Krypton.Ribbon.KryptonRibbonTab rbTabAbout;
        private Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private Krypton.Toolkit.KryptonManager kryptonManager1;
        private Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private Krypton.Ribbon.KryptonRibbonGroupGallery kryptonRibbonGroupGallery1;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup2;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple2;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbImport;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup3;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple3;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbGroupMsg;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbScrapeMember;
        private System.Windows.Forms.ImageList imageList2;
        private Krypton.Ribbon.KryptonRibbonTab rbTabAutoBot;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbSendMsg;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup4;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple4;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbBotMessage;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbBot;
        private Krypton.Ribbon.KryptonRibbonGroup kryptonRibbonGroup5;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple5;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbAbout;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbHelp;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbConactUs;
        private Krypton.Ribbon.KryptonRibbonGroupButton krgbImportContact;
        private Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton4;
        private Krypton.Ribbon.KryptonRibbonGroupButton kryptonRibbonGroupButton5;
        private Krypton.Ribbon.KryptonRibbonGroupTriple kryptonRibbonGroupTriple6;
        private Krypton.Ribbon.KryptonRibbonGroupButton krBtnCheck;
    }
}

