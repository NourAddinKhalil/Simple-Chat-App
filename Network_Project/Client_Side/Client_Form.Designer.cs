namespace Client_Side
{
    partial class Client_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Form));
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.DisConnectBtn = new System.Windows.Forms.Button();
            this.SendTextBtn = new System.Windows.Forms.Button();
            this.SendMediaBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SendMessageTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MessageTxt = new System.Windows.Forms.RichTextBox();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IPAddressTxt = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataSentSizeLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataRecievedLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenRecievBtn = new System.Windows.Forms.Button();
            this.ShowSenderPubKeyBtn = new System.Windows.Forms.Button();
            this.ShowMyKeysBtn = new System.Windows.Forms.Button();
            this.SentImagePicBx = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ImageAddLbl = new System.Windows.Forms.Label();
            this.PreviousBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SentImagePicBx)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(365, 343);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(151, 58);
            this.ConnectBtn.TabIndex = 0;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // DisConnectBtn
            // 
            this.DisConnectBtn.Enabled = false;
            this.DisConnectBtn.Location = new System.Drawing.Point(667, 343);
            this.DisConnectBtn.Name = "DisConnectBtn";
            this.DisConnectBtn.Size = new System.Drawing.Size(188, 58);
            this.DisConnectBtn.TabIndex = 1;
            this.DisConnectBtn.Text = "DisConnect";
            this.DisConnectBtn.UseVisualStyleBackColor = true;
            this.DisConnectBtn.Click += new System.EventHandler(this.DisConnectBtn_Click);
            // 
            // SendTextBtn
            // 
            this.SendTextBtn.Enabled = false;
            this.SendTextBtn.Location = new System.Drawing.Point(667, 407);
            this.SendTextBtn.Name = "SendTextBtn";
            this.SendTextBtn.Size = new System.Drawing.Size(188, 58);
            this.SendTextBtn.TabIndex = 2;
            this.SendTextBtn.Text = "Send Text";
            this.SendTextBtn.UseVisualStyleBackColor = true;
            this.SendTextBtn.Click += new System.EventHandler(this.SendTextBtn_Click);
            // 
            // SendMediaBtn
            // 
            this.SendMediaBtn.Enabled = false;
            this.SendMediaBtn.Location = new System.Drawing.Point(522, 343);
            this.SendMediaBtn.Name = "SendMediaBtn";
            this.SendMediaBtn.Size = new System.Drawing.Size(139, 58);
            this.SendMediaBtn.TabIndex = 3;
            this.SendMediaBtn.Text = "Send Media";
            this.SendMediaBtn.UseVisualStyleBackColor = true;
            this.SendMediaBtn.Click += new System.EventHandler(this.SendMediaBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 17;
            this.label3.Text = "Type Message :";
            // 
            // SendMessageTxt
            // 
            this.SendMessageTxt.Location = new System.Drawing.Point(171, 407);
            this.SendMessageTxt.Multiline = true;
            this.SendMessageTxt.Name = "SendMessageTxt";
            this.SendMessageTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SendMessageTxt.Size = new System.Drawing.Size(490, 58);
            this.SendMessageTxt.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Messages";
            // 
            // MessageTxt
            // 
            this.MessageTxt.Location = new System.Drawing.Point(12, 58);
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.ReadOnly = true;
            this.MessageTxt.Size = new System.Drawing.Size(347, 343);
            this.MessageTxt.TabIndex = 14;
            this.MessageTxt.Text = "";
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(366, 58);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(490, 279);
            this.axWindowsMediaPlayer1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(362, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Video";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "IP Address";
            // 
            // IPAddressTxt
            // 
            this.IPAddressTxt.Location = new System.Drawing.Point(77, 6);
            this.IPAddressTxt.Name = "IPAddressTxt";
            this.IPAddressTxt.Size = new System.Drawing.Size(124, 20);
            this.IPAddressTxt.TabIndex = 21;
            this.IPAddressTxt.Text = "127.0.0.1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.DataSentSizeLbl,
            this.toolStripStatusLabel3,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2,
            this.DataRecievedLbl,
            this.toolStripStatusLabel4,
            this.StatusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1205, 22);
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel1.Text = "Data Sent";
            // 
            // DataSentSizeLbl
            // 
            this.DataSentSizeLbl.Name = "DataSentSizeLbl";
            this.DataSentSizeLbl.Size = new System.Drawing.Size(13, 17);
            this.DataSentSizeLbl.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel3.Text = "Bytes";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Enabled = false;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel2.Text = "Data Recieved";
            // 
            // DataRecievedLbl
            // 
            this.DataRecievedLbl.Name = "DataRecievedLbl";
            this.DataRecievedLbl.Size = new System.Drawing.Size(13, 17);
            this.DataRecievedLbl.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(35, 17);
            this.toolStripStatusLabel4.Text = "Bytes";
            // 
            // StatusLbl
            // 
            this.StatusLbl.ForeColor = System.Drawing.Color.ForestGreen;
            this.StatusLbl.Margin = new System.Windows.Forms.Padding(250, 3, 0, 2);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(10, 17);
            this.StatusLbl.Text = " ";
            // 
            // OpenRecievBtn
            // 
            this.OpenRecievBtn.Location = new System.Drawing.Point(1005, 4);
            this.OpenRecievBtn.Name = "OpenRecievBtn";
            this.OpenRecievBtn.Size = new System.Drawing.Size(188, 37);
            this.OpenRecievBtn.TabIndex = 23;
            this.OpenRecievBtn.Text = "Open Recieve Folder";
            this.OpenRecievBtn.UseVisualStyleBackColor = true;
            this.OpenRecievBtn.Click += new System.EventHandler(this.OpenRecievBtn_Click);
            // 
            // ShowSenderPubKeyBtn
            // 
            this.ShowSenderPubKeyBtn.Location = new System.Drawing.Point(217, 4);
            this.ShowSenderPubKeyBtn.Name = "ShowSenderPubKeyBtn";
            this.ShowSenderPubKeyBtn.Size = new System.Drawing.Size(142, 22);
            this.ShowSenderPubKeyBtn.TabIndex = 24;
            this.ShowSenderPubKeyBtn.Text = "Show Server Public Key";
            this.ShowSenderPubKeyBtn.UseVisualStyleBackColor = true;
            this.ShowSenderPubKeyBtn.Click += new System.EventHandler(this.ShowSenderPubKeyBtn_Click);
            // 
            // ShowMyKeysBtn
            // 
            this.ShowMyKeysBtn.Location = new System.Drawing.Point(365, 4);
            this.ShowMyKeysBtn.Name = "ShowMyKeysBtn";
            this.ShowMyKeysBtn.Size = new System.Drawing.Size(98, 22);
            this.ShowMyKeysBtn.TabIndex = 25;
            this.ShowMyKeysBtn.Text = "Show My Keys";
            this.ShowMyKeysBtn.UseVisualStyleBackColor = true;
            this.ShowMyKeysBtn.Click += new System.EventHandler(this.ShowMyKeysBtn_Click);
            // 
            // SentImagePicBx
            // 
            this.SentImagePicBx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SentImagePicBx.Location = new System.Drawing.Point(871, 58);
            this.SentImagePicBx.Name = "SentImagePicBx";
            this.SentImagePicBx.Size = new System.Drawing.Size(322, 279);
            this.SentImagePicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SentImagePicBx.TabIndex = 26;
            this.SentImagePicBx.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(868, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Images";
            // 
            // ImageAddLbl
            // 
            this.ImageAddLbl.AutoSize = true;
            this.ImageAddLbl.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ImageAddLbl.Location = new System.Drawing.Point(879, 364);
            this.ImageAddLbl.Name = "ImageAddLbl";
            this.ImageAddLbl.Size = new System.Drawing.Size(12, 17);
            this.ImageAddLbl.TabIndex = 28;
            this.ImageAddLbl.Text = " ";
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.Location = new System.Drawing.Point(871, 407);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(154, 58);
            this.PreviousBtn.TabIndex = 29;
            this.PreviousBtn.Text = "Previous";
            this.PreviousBtn.UseVisualStyleBackColor = true;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(1043, 407);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(150, 58);
            this.NextBtn.TabIndex = 30;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(1043, 343);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(150, 58);
            this.SaveBtn.TabIndex = 31;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 499);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PreviousBtn);
            this.Controls.Add(this.ImageAddLbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SentImagePicBx);
            this.Controls.Add(this.ShowMyKeysBtn);
            this.Controls.Add(this.ShowSenderPubKeyBtn);
            this.Controls.Add(this.OpenRecievBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.IPAddressTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SendMessageTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.SendMediaBtn);
            this.Controls.Add(this.SendTextBtn);
            this.Controls.Add(this.DisConnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Client_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SentImagePicBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Button DisConnectBtn;
        private System.Windows.Forms.Button SendTextBtn;
        private System.Windows.Forms.Button SendMediaBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SendMessageTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox MessageTxt;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IPAddressTxt;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel DataSentSizeLbl;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel DataRecievedLbl;
        private System.Windows.Forms.Button OpenRecievBtn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel StatusLbl;
        private System.Windows.Forms.Button ShowSenderPubKeyBtn;
        private System.Windows.Forms.Button ShowMyKeysBtn;
        private System.Windows.Forms.PictureBox SentImagePicBx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ImageAddLbl;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}

