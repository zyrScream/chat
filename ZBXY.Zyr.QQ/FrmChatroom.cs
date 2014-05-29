using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ZBXY.Zyr.QQ
{
    public partial class FrmChatroom : Form
    {
        public FrmChatroom()
        {
            InitializeComponent();
        }

        private ZyrQQ _zyr;
        public FrmChatroom(ZyrQQ zyr)
        {
            InitializeComponent();
            _zyr = zyr;
        }

        private void FrmChatroom_FormClosed(object sender, FormClosedEventArgs e)
        {
            _zyr.MyinChatroom = false;

            _zyr.FrmchatisExist = false;

            _zyr.ChatroomFriends.Clear();

            UdpClient udpClient = new UdpClient();
            string message = "LEAVE|";
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndPoint);
        }

        public void addFriends(FriendsInfo friend)
        {
            UcFriends uf = new UcFriends();

            uf.Name = friend.Name;
            uf.Signatrue = friend.Signature;
            int headindex = Convert.ToInt16(friend.Image);
            uf.Image = _zyr.headImageindex.Images[headindex];
            uf.IPaddress1 = friend.IPaddress1;
            uf.Top =this.chatPanel.Controls.Count * uf.Height;
            uf.Left = 0;
            this.chatPanel.Controls.Add(uf);
        }

        public void createfriendsInformationList()
        {
            this.chatPanel.Controls.Clear();
            foreach (FriendsInfo f in _zyr.ChatroomFriends)
            {
                UcFriends ucf = new UcFriends();

                if (f.Sendmessage.Count > 0)
                {
                    ucf.BackColor = System.Drawing.Color.Red;
                }

                ucf.Name = f.Name;
                ucf.Image = this._zyr.headImageindex.Images[Convert.ToInt32(f.Image)];
                ucf.IPaddress1 = f.IPaddress1;
                ucf.Signatrue = f.Signature;

                ucf.Top = this.chatPanel.Controls.Count * ucf.Height;
                this.chatPanel.Controls.Add(ucf);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = this.txtMy.Text;

            if (msg == "")
            {
                return;
            }
            UdpClient udpClient = new UdpClient();
            string message = "CHATROOM|"+msg;
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndPoint);

            this.txtChat.Text += "我说:"+System.DateTime.Now.ToShortTimeString()+"\r\n"+this.txtMy.Text+"\r\n";

            string path = Application.StartupPath + @"\聊天室聊天记录\" + "chatroom.ini";

            using (FileStream fs = new FileStream(path, FileMode.Create))
            using (StreamWriter file = new StreamWriter(fs, Encoding.Default))
            {
                file.WriteLine(this.txtChat.Text);
            }

            this.txtMy.Text = "";
        }

        private void FrmChatroom_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\聊天室聊天记录\" + "chatroom.ini";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string message = sr.ReadLine();
                while (message != null)
                {
                    txtChat.Text += message+"\r\n";
                    message = sr.ReadLine();
                }
            }
        }
    }
}
