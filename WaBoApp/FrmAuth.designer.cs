namespace WaApp
{
    partial class FrmAuth
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.labMsg = new Krypton.Toolkit.KryptonLabel();
            this.btnClose = new Krypton.Toolkit.KryptonButton();
            this.btnAuth = new Krypton.Toolkit.KryptonButton();
            this.txtPurchaseCode = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.labMsg);
            this.kryptonPanel1.Controls.Add(this.btnClose);
            this.kryptonPanel1.Controls.Add(this.btnAuth);
            this.kryptonPanel1.Controls.Add(this.txtPurchaseCode);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(816, 557);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // labMsg
            // 
            this.labMsg.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.labMsg.Location = new System.Drawing.Point(240, 21);
            this.labMsg.Name = "labMsg";
            this.labMsg.Size = new System.Drawing.Size(57, 37);
            this.labMsg.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.labMsg.TabIndex = 6;
            this.labMsg.Values.Text = "Info";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(420, 435);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(143, 68);
            this.btnClose.TabIndex = 5;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAuth
            // 
            this.btnAuth.Location = new System.Drawing.Point(245, 435);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(143, 68);
            this.btnAuth.TabIndex = 4;
            this.btnAuth.Values.Text = "Auth";
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // txtPurchaseCode
            // 
            this.txtPurchaseCode.Location = new System.Drawing.Point(240, 78);
            this.txtPurchaseCode.Name = "txtPurchaseCode";
            this.txtPurchaseCode.Size = new System.Drawing.Size(480, 328);
            this.txtPurchaseCode.StateNormal.Content.Color1 = System.Drawing.Color.White;
            this.txtPurchaseCode.TabIndex = 3;
            this.txtPurchaseCode.Text = "";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(56, 78);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(178, 37);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Purchase code:";
            // 
            // FrmAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 557);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HeaderStyle = Krypton.Toolkit.HeaderStyle.Secondary;
            this.Name = "FrmAuth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auth";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAuth_FormClosed);
            this.Load += new System.EventHandler(this.FrmAuth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonRichTextBox txtPurchaseCode;
        private Krypton.Toolkit.KryptonButton btnClose;
        private Krypton.Toolkit.KryptonButton btnAuth;
        private Krypton.Toolkit.KryptonLabel labMsg;
    }
}