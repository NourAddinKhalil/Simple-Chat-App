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
using System.Net.Sockets;
using System.Diagnostics;

namespace Network_Project
{
    public partial class Server_Form : Form
    {
        private Listener listener;
        private List<Client> clients;
        private int counter = 0;
        private List<Bitmap> images = new List<Bitmap>();
        private List<string> senders = new List<string>();
        private int ImgCount;
        public Server_Form()
        {
            InitializeComponent();
            this.FormClosing += Server_FormClosing;
            clients = new List<Client>();
            Directory.CreateDirectory(Application.StartupPath + $"\\Media");
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (clients.Count > 0)
            {
                clients.ForEach(client =>
                {
                    if (client != null)
                    {
                        client.Close();
                    }
                });
            }
            if (listener != null && listener.Running)
            {
                listener.Stop();
            }

            try
            {
                File.Delete(Application.StartupPath + $"\\Media");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListenerBtn_Click(object sender, EventArgs e)
        {
            ListenerBtn.Enabled = false;
            listener = new Listener();
            try
            {
                listener.Accepted += Listener_Accepted;
                listener.Start(1999);
                CloseBtn.Enabled = true;
                StatusLbl.Text = "Listening ..........";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                ListenerBtn.Enabled = true;
            }
        }

        private void Listener_Accepted(Socket sender)
        {
            var client = new Client(sender);
            client.DataRecieved += Client_DataRecieved;
            client.Disconnected += Client_Disconnected;
            client.OnSend += Client_OnSend;
            client.RecieveAsync();
            Invoke((MethodInvoker)delegate
            {//show message client connected
                ListViewItem item = new ListViewItem();
                item.Text = client.EndPoint.ToString();
                item.SubItems.Add(client.ID);
                item.SubItems.Add(DateTime.Now.ToString());
                item.SubItems.Add("No Key Send Yet");
                item.Tag = client;
                ClientsLstView.Items.Add(item);
                SendMediaBtn.Enabled =
                SendTextBtn.Enabled =
                CloseBtn.Enabled = true;
                SendMyKey(client);
            });
            clients.Add(client);
            StatusLbl.Text = $"{clients.Count} Connenctions";
        }

        private void Client_Disconnected(Client sender)
        {
            var client = clients.FirstOrDefault(x => x.ID == sender.ID);
            if (client == null) return;
            client.Close();
            Invoke((MethodInvoker)delegate
            {//show message client disconnected

                for (int i = 0; i < ClientsLstView.Items.Count; i++)
                {
                    var cl = ClientsLstView.Items[i].Tag as Client;
                    if(cl.ID==client.ID)
                    {
                        ClientsLstView.Items.RemoveAt(i);
                        break;
                    }
                }
                //DialogResult res = MessageBox.Show("Client Disconnected \n Do You Want To Clear Data ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if(res == DialogResult.Yes)
                //{

                //}
            });
            clients.Remove(client);
            client = null;
            if (clients.Count <= 0)
                StatusLbl.Text = "Listening ..........";
            else
                StatusLbl.Text = $"{clients.Count} Connenctions";
        }

        private void Client_DataRecieved(Client sender, Buffer_Recieve buffer_Recieve)
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
                        //this.SenderPublicKey = key;
                        for (int i = 0; i < ClientsLstView.Items.Count; i++)
                        {
                            var client = ClientsLstView.Items[i].Tag as Client;
                            if(client.ID == sender.ID)
                            {
                                ClientsLstView.Items[i].SubItems[3].Text = key;
                                break;
                            }
                        }
                    });
                    break;
                case SentDataType.StringType:
                    Invoke((MethodInvoker)delegate
                    {//Add message to any tool in form
                        string message = br.ReadString();
                        string decipheredMessage = listener.rsa.Decrypt(message);
                        MessageTxt.SelectedText = 
                        Environment.NewLine + $"{sender.ID} : " + decipheredMessage;
                        int size = Convert.ToInt32(DataRecievedSizeLbl.Text);
                        size += ((MemoryStream)br.BaseStream).ToArray().Length;
                        DataRecievedSizeLbl.Text = size.ToString();
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
                        senders.Add($"From {sender.ID}");
                        ImageAddLbl.Text = $"From {sender.ID}";
                        ImgCount = images.Count;
                        //Clipboard.SetImage(Image.FromStream(new MemoryStream(imagebyte)));
                        MessageTxt.SelectedText = 
                        Environment.NewLine + $"{sender.ID} : Sent Image" + Environment.NewLine ;
                        MessageTxt.Paste();
                        int size = Convert.ToInt32(DataRecievedSizeLbl.Text);
                        size += imagBytLength;
                        DataRecievedSizeLbl.Text = size.ToString();
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
                        Environment.NewLine + $"{ sender.ID} : Sent Media" + Environment.NewLine;
                        int size = Convert.ToInt32(DataRecievedSizeLbl.Text);
                        size += videoBytLength;
                        DataRecievedSizeLbl.Text = size.ToString();
                    });
                    break;
                case SentDataType.DocumentType:
                    Invoke((MethodInvoker)delegate
                    {
                        string extens = br.ReadString();
                        int fileBytLength = br.ReadInt32();
                        byte[] filebyte = br.ReadBytes(fileBytLength);
                        Directory.CreateDirectory(Application.StartupPath + $"\\Media");
                        string fileName = Application.StartupPath + $"\\Media\\Doc {sender.ID}{++counter}.{extens}";
                        BinaryWriter bw = new BinaryWriter(
                            new FileStream(fileName,
                            FileMode.Create));
                        bw.Write(filebyte);
                        bw.Close();
                        bw.Dispose();
                        MessageTxt.SelectedText = 
                        Environment.NewLine + $"{ sender.ID} : Sent Document" + Environment.NewLine;
                        int size = Convert.ToInt32(DataRecievedSizeLbl.Text);
                        size += fileBytLength;
                        DataRecievedSizeLbl.Text = size.ToString();
                    });
                    break;
                default:
                    break;
            }
            br.Close();
            br.Dispose();
        }

        private void Client_OnSend(Client sender, int length)
        {
            Invoke((MethodInvoker)delegate
            {//add to the tool how much data sent
                int size = Convert.ToInt32(DataSentSizeLbl.Text);
                size += length;
                DataSentSizeLbl.Text = size.ToString();
            });
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            CloseBtn.Enabled = false;
            if (clients.Count > 0)
            {
                clients.ForEach(client =>
                {
                    client.Close();
                });
                clients.Clear();
            }
            listener.Stop();
            ClientsLstView.Items.Clear();
            SendMediaBtn.Enabled =
            CloseBtn.Enabled =
            SendTextBtn.Enabled = false;
            ListenerBtn.Enabled = true;
            StatusLbl.Text = "Disconnected";
            DataSentSizeLbl.Text = "0";
            DataRecievedSizeLbl.Text = "0";
            MessageTxt.Clear();
        }

        private void SendTextBtn_Click(object sender, EventArgs e)
        {
            MessageTxt.SelectionColor = Color.Black;
            int clientCounts = ClientsLstView.SelectedItems.Count;
            if (clientCounts <= 0)
            {
                MessageBox.Show("Choose Client First");
                return;
            }
            if (string.IsNullOrEmpty(SendMessageTxt.Text.Trim()))
            {
                MessageBox.Show("Type Somthing First !!");
                return;
            }
            SendTextBtn.Enabled = false;
            for (int i = 0; i < clientCounts; i++)
            {
                var client = ClientsLstView.SelectedItems[i].Tag as Client;
                string pubKey = ClientsLstView.SelectedItems[i].SubItems[3].Text;
                //var client = clients.FirstOrDefault(x => x.ID == clientID);
                string cipherdMessage = listener.rsa.Encrypt(SendMessageTxt.Text.Trim(), pubKey);
                //MessageTxt.SelectedText = Environment.NewLine + $"Me : " + SendMessageTxt.Text.Trim();
                SendText(cipherdMessage, client);
            }
            MessageTxt.SelectedText = Environment.NewLine + $"Me : { SendMessageTxt.Text.Trim() } To {clientCounts} Clients";
            SendTextBtn.Enabled = true;
            SendMessageTxt.Clear();
        }

        private void SendMediaBtn_Click(object sender, EventArgs e)
        {
            int clientCounts = ClientsLstView.SelectedItems.Count;
            if (clientCounts <= 0)
            {
                MessageBox.Show("Choose Client First");
                return;
            }
            MessageTxt.SelectionColor = Color.Black;
            SendMediaBtn.Enabled = false;
            SentDataType type = 0;
            string typeString = "";
            for (int i = 0; i < clientCounts; i++)
            {
                var client = ClientsLstView.SelectedItems[i].Tag as Client;
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        string extension = open.FileName.Substring(open.FileName.LastIndexOf('.') + 1).ToLower();

                        if (MessageBox.Show(" Are You Sure You Want To Send The File ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
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
                            else //if (Extensions.document.Contains(extension))
                            {
                                typeString = "Document";
                                type = SentDataType.DocumentType;
                            }
                            if (type != 0)
                                SendMedia(open.FileName, type, extension, client);
                            else
                                MessageBox.Show("Unknown Extension");
                        }
                    }
                }
            }
            if (type != 0)
            {
                MessageTxt.SelectedText =
                    Environment.NewLine + $"Me : Sent {typeString} To {clientCounts} Clients" + Environment.NewLine;
                if (type == SentDataType.ImageType)
                    MessageTxt.Paste();
            }
            else
                MessageBox.Show("Unknown Extension");
            SendMediaBtn.Enabled = true;
        }

        private void SendText(string text, Client client)
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

        private void SendMedia(string path, SentDataType type, string extens , Client client)
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

        private void SendMyKey(Client client)
        {
            BinaryWriter bw = new BinaryWriter(new MemoryStream());
            bw.Write((int)SentDataType.publicKey);
            bw.Write(listener.rsa.GetKeyString());
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

        private void ClientsLstView_DoubleClick(object sender, EventArgs e)
        {
            if (ClientsLstView.Items.Count <= 0)
            {
                MessageBox.Show("NO Clients Connected Yet", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ClientsLstView.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Choose Client First", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("public Key IS :\n\n" + ClientsLstView.SelectedItems[0].SubItems[3].Text,
                $"Public Key For {ClientsLstView.SelectedItems[0].SubItems[1].Text}", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowMyKeysBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"My Public Key Is :\n{listener.rsa.GetKeyString()} \n\n My Privat Key is :\n {listener.rsa.GetKeyString(false)}\n",
                "Show Keys", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectAllBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ClientsLstView.Items.Count; i++)
            {
                ClientsLstView.Items[i].Selected = true;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SentImagePicBx.Image == null)
                return;
            using (SaveFileDialog  save = new SaveFileDialog() 
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
            ImageAddLbl.Text = senders[ImgCount];
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (images.Count <= 0)
                return;
            ImgCount++;
            if (ImgCount > images.Count - 1)
                ImgCount = images.Count - 1;
            SentImagePicBx.Image = images[ImgCount];
            ImageAddLbl.Text = senders[ImgCount];
        }
    }
}
