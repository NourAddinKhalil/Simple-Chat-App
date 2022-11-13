namespace Network_Project
{
    partial class Server_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server_Form));
            this.ListenerBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.MessageTxt = new System.Windows.Forms.RichTextBox();
            this.SendMediaBtn = new System.Windows.Forms.Button();
            this.SendTextBtn = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.label1 = new System.Windows.Forms.Label();
            this.ClientsLstView = new System.Windows.Forms.ListView();
            this.IpAddressClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TimeClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PublicKeyClmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SendMessageTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataSentSizeLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DataRecievedSizeLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpenRecievBtn = new System.Windows.Forms.Button();
            this.ShowMyKeysBtn = new System.Windows.Forms.Button();
            this.SelectAllBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SentImagePicBx = new System.Windows.Forms.PictureBox();
            this.ImageAddLbl = new System.Windows.Forms.Label();
            this.NextBtn = new System.Windows.Forms.Button();
            this.PreviousBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SentImagePicBx)).BeginInit();
            this.SuspendLayout();
            // 
            // ListenerBtn
            // 
            this.ListenerBtn.Location = new System.Drawing.Point(638, 343);
            this.ListenerBtn.Name = "ListenerBtn";
            this.ListenerBtn.Size = new System.Drawing.Size(241, 58);
            this.ListenerBtn.TabIndex = 0;
            this.ListenerBtn.Text = "Listen";
            this.ListenerBtn.UseVisualStyleBackColor = true;
            this.ListenerBtn.Click += new System.EventHandler(this.ListenerBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Enabled = false;
            this.CloseBtn.Location = new System.Drawing.Point(762, 407);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(241, 58);
            this.CloseBtn.TabIndex = 1;
            this.CloseBtn.Text = "Disconnect";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // MessageTxt
            // 
            this.MessageTxt.Location = new System.Drawing.Point(12, 38);
            this.MessageTxt.Name = "MessageTxt";
            this.MessageTxt.ReadOnly = true;
            this.MessageTxt.Size = new System.Drawing.Size(318, 363);
            this.MessageTxt.TabIndex = 3;
            this.MessageTxt.Text = "";
            // 
            // SendMediaBtn
            // 
            this.SendMediaBtn.Enabled = false;
            this.SendMediaBtn.Location = new System.Drawing.Point(886, 343);
            this.SendMediaBtn.Name = "SendMediaBtn";
            this.SendMediaBtn.Size = new System.Drawing.Size(117, 58);
            this.SendMediaBtn.TabIndex = 6;
            this.SendMediaBtn.Text = "Send Media";
            this.SendMediaBtn.UseVisualStyleBackColor = true;
            this.SendMediaBtn.Click += new System.EventHandler(this.SendMediaBtn_Click);
            // 
            // SendTextBtn
            // 
            this.SendTextBtn.Enabled = false;
            this.SendTextBtn.Location = new System.Drawing.Point(638, 407);
            this.SendTextBtn.Name = "SendTextBtn";
            this.SendTextBtn.Size = new System.Drawing.Size(117, 58);
            this.SendTextBtn.TabIndex = 5;
            this.SendTextBtn.Text = "Send Text";
            this.SendTextBtn.UseVisualStyleBackColor = true;
            this.SendTextBtn.Click += new System.EventHandler(this.SendTextBtn_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(638, 52);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(365, 285);
            this.axWindowsMediaPlayer1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Messages";
            // 
            // ClientsLstView
            // 
            this.ClientsLstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IpAddressClmn,
            this.IDClmn,
            this.TimeClmn,
            this.PublicKeyClmn});
            this.ClientsLstView.FullRowSelect = true;
            this.ClientsLstView.HideSelection = false;
            this.ClientsLstView.Location = new System.Drawing.Point(336, 38);
            this.ClientsLstView.Name = "ClientsLstView";
            this.ClientsLstView.Size = new System.Drawing.Size(295, 363);
            this.ClientsLstView.TabIndex = 10;
            this.ClientsLstView.UseCompatibleStateImageBehavior = false;
            this.ClientsLstView.View = System.Windows.Forms.View.Details;
            this.ClientsLstView.DoubleClick += new System.EventHandler(this.ClientsLstView_DoubleClick);
            // 
            // IpAddressClmn
            // 
            this.IpAddressClmn.Text = "IP Address";
            this.IpAddressClmn.Width = 101;
            // 
            // IDClmn
            // 
            this.IDClmn.Text = "ID";
            this.IDClmn.Width = 79;
            // 
            // TimeClmn
            // 
            this.TimeClmn.Text = "Connect Time";
            this.TimeClmn.Width = 137;
            // 
            // PublicKeyClmn
            // 
            this.PublicKeyClmn.Text = "Public Key";
            // 
            // SendMessageTxt
            // 
            this.SendMessageTxt.Location = new System.Drawing.Point(171, 407);
            this.SendMessageTxt.Multiline = true;
            this.SendMessageTxt.Name = "SendMessageTxt";
            this.SendMessageTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.SendMessageTxt.Size = new System.Drawing.Size(461, 58);
            this.SendMessageTxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Clients List";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(8, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Type Message :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(637, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Video";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.DataSentSizeLbl,
            this.toolStripStatusLabel3,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2,
            this.DataRecievedSizeLbl,
            this.toolStripStatusLabel4,
            this.StatusLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1233, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel1.Text = "Data Sent : ";
            // 
            // DataSentSizeLbl
            // 
            this.DataSentSizeLbl.Name = "DataSentSizeLbl";
            this.DataSentSizeLbl.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(90, 17);
            this.toolStripStatusLabel2.Text = "Data Recieved : ";
            // 
            // DataRecievedSizeLbl
            // 
            this.DataRecievedSizeLbl.Name = "DataRecievedSizeLbl";
            this.DataRecievedSizeLbl.Size = new System.Drawing.Size(13, 17);
            this.DataRecievedSizeLbl.Text = "0";
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
            this.StatusLbl.Margin = new System.Windows.Forms.Padding(400, 3, 0, 2);
            this.StatusLbl.Name = "StatusLbl";
            this.StatusLbl.Size = new System.Drawing.Size(10, 17);
            this.StatusLbl.Text = " ";
            // 
            // OpenRecievBtn
            // 
            this.OpenRecievBtn.Location = new System.Drawing.Point(816, 9);
            this.OpenRecievBtn.Name = "OpenRecievBtn";
            this.OpenRecievBtn.Size = new System.Drawing.Size(187, 37);
            this.OpenRecievBtn.TabIndex = 24;
            this.OpenRecievBtn.Text = "Open Recieve Folder";
            this.OpenRecievBtn.UseVisualStyleBackColor = true;
            this.OpenRecievBtn.Click += new System.EventHandler(this.OpenRecievBtn_Click);
            // 
            // ShowMyKeysBtn
            // 
            this.ShowMyKeysBtn.Location = new System.Drawing.Point(722, 9);
            this.ShowMyKeysBtn.Name = "ShowMyKeysBtn";
            this.ShowMyKeysBtn.Size = new System.Drawing.Size(88, 37);
            this.ShowMyKeysBtn.TabIndex = 25;
            this.ShowMyKeysBtn.Text = "Show My Keys";
            this.ShowMyKeysBtn.UseVisualStyleBackColor = true;
            this.ShowMyKeysBtn.Click += new System.EventHandler(this.ShowMyKeysBtn_Click);
            // 
            // SelectAllBtn
            // 
            this.SelectAllBtn.Location = new System.Drawing.Point(559, 7);
            this.SelectAllBtn.Name = "SelectAllBtn";
            this.SelectAllBtn.Size = new System.Drawing.Size(73, 25);
            this.SelectAllBtn.TabIndex = 26;
            this.SelectAllBtn.Text = "Select All";
            this.SelectAllBtn.UseVisualStyleBackColor = true;
            this.SelectAllBtn.Click += new System.EventHandler(this.SelectAllBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1009, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Images";
            // 
            // SentImagePicBx
            // 
            this.SentImagePicBx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SentImagePicBx.Location = new System.Drawing.Point(1009, 58);
            this.SentImagePicBx.Name = "SentImagePicBx";
            this.SentImagePicBx.Size = new System.Drawing.Size(212, 279);
            this.SentImagePicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SentImagePicBx.TabIndex = 28;
            this.SentImagePicBx.TabStop = false;
            // 
            // ImageAddLbl
            // 
            this.ImageAddLbl.AutoSize = true;
            this.ImageAddLbl.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ImageAddLbl.Location = new System.Drawing.Point(1009, 361);
            this.ImageAddLbl.Name = "ImageAddLbl";
            this.ImageAddLbl.Size = new System.Drawing.Size(12, 17);
            this.ImageAddLbl.TabIndex = 30;
            this.ImageAddLbl.Text = " ";
            // 
            // NextBtn
            // 
            this.NextBtn.Location = new System.Drawing.Point(1118, 407);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(103, 58);
            this.NextBtn.TabIndex = 32;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.Location = new System.Drawing.Point(1009, 407);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(103, 58);
            this.PreviousBtn.TabIndex = 31;
            this.PreviousBtn.Text = "Previous";
            this.PreviousBtn.UseVisualStyleBackColor = true;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(1118, 343);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(103, 58);
            this.SaveBtn.TabIndex = 33;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // Server_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 494);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.NextBtn);
            this.Controls.Add(this.PreviousBtn);
            this.Controls.Add(this.ImageAddLbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SentImagePicBx);
            this.Controls.Add(this.SelectAllBtn);
            this.Controls.Add(this.ShowMyKeysBtn);
            this.Controls.Add(this.OpenRecievBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SendMessageTxt);
            this.Controls.Add(this.ClientsLstView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.SendMediaBtn);
            this.Controls.Add(this.SendTextBtn);
            this.Controls.Add(this.MessageTxt);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.ListenerBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Server_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SentImagePicBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ListenerBtn;
        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.RichTextBox MessageTxt;
        private System.Windows.Forms.Button SendMediaBtn;
        private System.Windows.Forms.Button SendTextBtn;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView ClientsLstView;
        private System.Windows.Forms.ColumnHeader IpAddressClmn;
        private System.Windows.Forms.ColumnHeader IDClmn;
        private System.Windows.Forms.ColumnHeader TimeClmn;
        private System.Windows.Forms.TextBox SendMessageTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel DataSentSizeLbl;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel DataRecievedSizeLbl;
        private System.Windows.Forms.Button OpenRecievBtn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel StatusLbl;
        private System.Windows.Forms.ColumnHeader PublicKeyClmn;
        private System.Windows.Forms.Button ShowMyKeysBtn;
        private System.Windows.Forms.Button SelectAllBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox SentImagePicBx;
        private System.Windows.Forms.Label ImageAddLbl;
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button SaveBtn;
    }
}

