namespace GoogleImagesSearch
{
    partial class GoogleImagesSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleImagesSearchForm));
            this._editImageText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._btnSearchImage = new System.Windows.Forms.Button();
            this._lblStatus = new System.Windows.Forms.Label();
            this._webBrowserCtrl = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _editImageText
            // 
            this._editImageText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._editImageText.Location = new System.Drawing.Point(4, 23);
            this._editImageText.Multiline = true;
            this._editImageText.Name = "_editImageText";
            this._editImageText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._editImageText.Size = new System.Drawing.Size(768, 60);
            this._editImageText.TabIndex = 0;
            this._editImageText.Text = "wiadro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Search for image:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "First image found:";
            // 
            // _btnSearchImage
            // 
            this._btnSearchImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSearchImage.Location = new System.Drawing.Point(697, 527);
            this._btnSearchImage.Name = "_btnSearchImage";
            this._btnSearchImage.Size = new System.Drawing.Size(75, 23);
            this._btnSearchImage.TabIndex = 13;
            this._btnSearchImage.Text = "Search";
            this._btnSearchImage.UseVisualStyleBackColor = true;
            this._btnSearchImage.Click += new System.EventHandler(this._btnSearchImage_Click);
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.Location = new System.Drawing.Point(12, 537);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(16, 13);
            this._lblStatus.TabIndex = 11;
            this._lblStatus.Text = "   ";
            // 
            // _webBrowserCtrl
            // 
            this._webBrowserCtrl.IsWebBrowserContextMenuEnabled = false;
            this._webBrowserCtrl.Location = new System.Drawing.Point(623, 530);
            this._webBrowserCtrl.Name = "_webBrowserCtrl";
            this._webBrowserCtrl.Size = new System.Drawing.Size(68, 20);
            this._webBrowserCtrl.TabIndex = 12;
            this._webBrowserCtrl.Visible = false;
            this._webBrowserCtrl.WebBrowserShortcutsEnabled = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(768, 417);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // GoogleImagesSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._webBrowserCtrl);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this._btnSearchImage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._editImageText);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 600);
            this.MinimumSize = new System.Drawing.Size(360, 278);
            this.Name = "GoogleImagesSearchForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Google Images Search Demo © Julian Sychowski";
            this.Load += new System.EventHandler(this.GoogleImagesSearchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox _editImageText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button _btnSearchImage;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.WebBrowser _webBrowserCtrl;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}