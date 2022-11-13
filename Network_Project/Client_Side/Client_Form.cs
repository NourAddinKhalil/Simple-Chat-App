using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Network_Project.Server_Side_Classes;
using System.Diagnostics;
namespace Client_Side
{
    public partial class Client_Form : Form
    {
        private Client_Side_Classes.Client client;
        private static int counter = 0;
        string SenderPublicKey;
        private List<Bitmap> images = new List<Bitmap>();
        private int ImgCount = 0;
        public Client_Form()
        {
            InitializeComponent();
            client = new Client_Side_Classes.Client();
            client.OnConnected += Client_OnConnected;
            client.OnDisConnected += Client_OnDisConnected;
            client.OnSend += Client_OnSend;
            client.DataRecieved += Client_DataRecieved;
            client.OnConnectExecption += Client_OnConnectExecption;
            this.FormClosing += Client_Form_FormClosing;
            Directory.CreateDirectory(Application.StartupPath + $"\\Media");
        }

        private void Client_OnConnectExecption()
        {
            Invoke((MethodInvoker)delegate
            {
                ConnectBtn.Enabled = true;
                SendMediaBtn.Enabled =
                SendTextBtn.Enabled =
                DisConnectBtn.Enabled = false;
                StatusLbl.Text = "Fail To Connect";
            });
        }

        private void Client_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
            try
            {
                File.Delete(Application.StartupPath + $"\\Media");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Client_OnSend(Client_Side_Classes.Client sender, int length)
        {
            Invoke((MethodInvoker)delegate
            {//add to the tool how much data sent
                int size = Convert.ToInt32(DataSentSizeLbl.Text);
                DataSentSizeLbl.Text = (size + length).ToString();
            });
        }

        private void Client_DataRecieved(Client_Side_Classes.Client sender, Buffer_Recieve buffer_Recieve)
        {
            BinaryReader br = new BinaryReader(buffer_Recieve.memory);
            SentDataType header = (SentDataType)br.ReadInt32();
            Invoke((MethodInvoker)delegate
            {
                MessageTxt.SelectionColor = Color.Blue;
            });
            switch (header)
            {
                case SentDataType.publicKey:
                    Invoke((MethodInvoker)delegate
                    {
                        string key = br.ReadString();
                        this.SenderPublicKey = key;
                    });
                    break;
                case SentDataType.StringType:
                    Invoke((MethodInvoker)delegate
                    {//Add message to any tool in form
                        string message = br.ReadString();
                        string decipheredMessage = client.rsa.Decrypt(message);
                        MessageTxt.SelectedText = Environment.NewLine + $"Server : " + decipheredMessage;
                        int size = Convert.ToInt32(DataRecievedLbl.Text);
                        size += ((MemoryStream)br.BaseStream).ToArray().Length;
                        DataRecievedLbl.Text = size.ToString();
                    });
                    break;
                case SentDataType.ImageType:
                    Invoke((MethodInvoker)delegate
                    {//show message client connected
                        string extens = br.ReadString();
                        int imagBytLength = br.ReadInt32();
                        byte[] imagebyte = br.ReadBytes(imagBytLength);
                        //Directory.CreateDirectory(Application.StartupPath + $"\\Media");
                        //string fileName = Application.StartupPath + $"\\Media\\Image {sender.ID}{++counter}.{extens}";
                        //BinaryWriter bw = new BinaryWriter(
                        //    new FileStream(fileName,
                        //    FileMode.Create));
                        //bw.Write(imagebyte);
                        //bw.Close();
                        //bw.Dispose();
                        //add image to picture box
                        images.Add(new Bitmap(Image.FromStream(new MemoryStream(imagebyte))));
                        SentImagePicBx.Image = Image.FromStream(new MemoryStream(imagebyte));
                        ImageAddLbl.Text = $"From Server";
                        ImgCount = images.Count;
                        //Clipboard.SetImage(Image.FromStream(new MemoryStream(imagebyte)));
                        MessageTxt.SelectedText = 
                        Environment.NewLine + $"Server : Sent Image" + Environment.NewLine;
                        //MessageTxt.Paste();
                        int size = Convert.ToInt32(DataRecievedLbl.Text);
                        size += imagBytLength;
                        DataRecievedLbl.Text = size.ToString();
                        imagebyte = null;
                    });
                    break;
                case SentDataType.MusicType:
                case SentDataType.VideoType:
                    Invoke((MethodInvoker)delegate
                    {//show message client connected
                        string extens = br.ReadString();
                        int videoBytLength = br.ReadInt32();
                        byte[] videobyte = br.ReadBytes(videoBytLength);
                        Directory.CreateDirectory(Application.StartupPath + $"\\Media");
                        string fileName = Application.StartupPath + $"\\Media\\Media {sender.ID}{++counter}.{extens}";
                        BinaryWriter bw = new BinaryWriter(
                            new FileStream(fileName,
                            FileMode.Create));
                        bw.Write(videobyte);
                        bw.Close();
                        bw.Dispose();
                        axWindowsMediaPlayer1.URL = fileName;
                        MessageTxt.SelectedText = 
                        Environment.NewLine + $"Server : Sent Media" + Environment.NewLine;
                        int size = Convert.ToInt32(DataRecievedLbl.Text);
                        size += videoBytLength;
                        DataRecievedLbl.Text = size.ToString();
                    });
                    break;
                case SentDataType.DocumentType:
                    Invoke((MethodInvoker)delegate
                    {
                        string extens = br.ReadString();
                        int fileBytLength = br.ReadInt32();
                        byte[] filebyte = br.ReadBytes(fileBytLength);
                        Directory.CreateDirectory(Application.StartupPath + $"\\Media");
                        string fileName = Application.StartupPath + $"\\Media\\Doc{sender.ID}{++counter}.{extens}";
                        BinaryWriter bw = new BinaryWriter(
                            new FileStream(fileName,
                            FileMode.Create));
                        bw.Write(filebyte);
                        bw.Close();
                        bw.Dispose();
                        //axWindowsMediaPlayer1.URL = fileName;
                        MessageTxt.SelectedText = 
                        Environment.NewLine + $"Server : Sent Document" + Environment.NewLine;
                        int size = Convert.ToInt32(DataRecievedLbl.Text);
                        size += fileBytLength;
                        DataRecievedLbl.Text = size.ToString();
                    });
                    break;
                default:
                    break;
            }
            br.Close();
            br.Dispose();
        }

        private void Client_OnDisConnected(Client_Side_Classes.Client sender)
        {
            //MessageBox.Show("DisConnected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Invoke((MethodInvoker)delegate
            {
                SendMediaBtn.Enabled =
                SendTextBtn.Enabled =
                DisConnectBtn.Enabled = false;
                ConnectBtn.Enabled = true;
                StatusLbl.Text = "Disconnected";
                DataSentSizeLbl.Text = "0";
                DataRecievedLbl.Text = "0";
                MessageTxt.Clear();
            });
        }

        private void Client_OnConnected(Client_Side_Classes.Client sender, bool connected)
        {
            if (connected)
            {
                MessageBox.Show("Connected", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                client.RecieveAsync();
                Invoke((MethodInvoker)delegate
                {
                    SendMediaBtn.Enabled =
                    SendTextBtn.Enabled =
                    DisConnectBtn.Enabled = true;
                    ConnectBtn.Enabled = false;
                    StatusLbl.Text = "Connected";
                });
                SendMyKey();
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if(!client.Connected)
            {
                ConnectBtn.Enabled = false;
                try
                {
                    StatusLbl.Text = "Connecting .......";
                    client.Conncet(IPAddressTxt.Text.Trim(), 1999);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ConnectBtn.Enabled = true;
                }
            }
        }

        private void DisConnectBtn_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void SendTextBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SendMessageTxt.Text.Trim()))
            {
                MessageBox.Show("Type Somthing First !!");
                return;
            }
            MessageTxt.SelectionColor = Color.Black;
            SendTextBtn.Enabled = false;
            MessageTxt.SelectedText = Environment.NewLine + $"Me : " + SendMessageTxt.Text.Trim();
            string cipheredText = client.rsa.Encrypt(SendMessageTxt.Text.Trim(), this.SenderPublicKey);
            SendText(cipheredText);
            SendTextBtn.Enabled = true;
            SendMessageTxt.Clear();
        }

        private void SendMediaBtn_Click(object sender, EventArgs e)
        {
            MessageTxt.SelectionColor = Color.Black;
            SendMediaBtn.Enabled = false;
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string extension = open.FileName.Substring(open.FileName.LastIndexOf('.') + 1).ToLower();

                    if (MessageBox.Show(" Are You Sure You Want To Send The File ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SentDataType type = 0;
                        string typeString = "";
                        if (Extensions.images.Contains(extension))
                        {
                            Clipboard.SetImage(Image.FromFile(open.FileName));
                            typeString = "Image";
                            type = SentDataType.ImageType;
                        }
                        else if (Extensions.videos.Contains(extension))
                        {
                            typeString = "Video";
                            type = SentDataType.VideoType;
                        }
                        else if (Extensions.music.Contains(extension))
                        {
                            typeString = "Music";
                            type = SentDataType.MusicType;
                        }
                        else //(Extensions.document.Contains(extension))
                        {
                            typeString = "Document";
                            type = SentDataType.DocumentType;
                        }
                        if (type != 0)
                        {
                            MessageTxt.SelectedText = 
                                Environment.NewLine + $"Me : Sent {typeString} " + Environment.NewLine;
                            if (type == SentDataType.ImageType)
                                MessageTxt.Paste();
                            SendMedia(open.FileName, type, extension);
                        }
                        else
                            MessageBox.Show("Unknown Extension");
                    }
                }
            }
            SendMediaBtn.Enabled = true;
        }

        private void SendText(string text)
        {
            BinaryWriter bw = new BinaryWriter(new MemoryStream());
            bw.Write((int)SentDataType.StringType);
            bw.Write(text);
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            bw.BaseStream.Dispose();
            client.SendData(data, 0, data.Length);
            data = null;
        }

        private void SendMedia(string path , SentDataType type , string extens )
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            byte[] data = File.ReadAllBytes(path);
            bw.Write((int)type);
            bw.Write(extens);
            bw.Write((int)data.Length);
            bw.Write(data);
            bw.Close();
            data = ms.ToArray();
            ms.Dispose();
            bw.Dispose();
            client.SendData(data, 0, data.Length);
        }

        private void SendMyKey()
        {
            BinaryWriter bw = new BinaryWriter(new MemoryStream());
            bw.Write((int)SentDataType.publicKey);
            bw.Write(client.rsa.GetKeyString());
            bw.Close();
            byte[] data = ((MemoryStream)bw.BaseStream).ToArray();
            bw.BaseStream.Dispose();
            client.SendData(data, 0, data.Length);
            data = null;
        }

        private void OpenRecievBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Application.StartupPath + @"\Media");
        }

        private void ShowSenderPubKeyBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SenderPublicKey))
                MessageBox.Show("NO Connection Yet !!!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show($"Server Public Key Is :\n{SenderPublicKey}", "Server Public Key", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowMyKeysBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"My Public Key Is :\n{client.rsa.GetKeyString()} \n\n My Privat Key is :\n {client.rsa.GetKeyString(false)}\n",
                "Show Keys", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SentImagePicBx.Image == null)
                return;
            using (SaveFileDialog save = new SaveFileDialog()
            {
                Filter = "JPG|*.jpg|BMP|*.bmp|PNG|*.png|GIF|*.gif|JPEG|*.jpeg",
                InitialDirectory = Application.StartupPath + $"\\Media",
            })
            {
                if (save.ShowDialog() == DialogResult.OK)
                {
                    SentImagePicBx.Image.Save(save.FileName);
                    MessageBox.Show("You Have Saved The Image Seccessfully", "Seccessfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            if (images.Count <= 0)
                return;
            ImgCount--;
            if (ImgCount < 0)
                ImgCount = 0;
            SentImagePicBx.Image = images[ImgCount];
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (images.Count <= 0)
                return;
            ImgCount++;
            if (ImgCount > images.Count - 1)
                ImgCount = images.Count - 1;
            SentImagePicBx.Image = images[ImgCount];
        }
    }
}
