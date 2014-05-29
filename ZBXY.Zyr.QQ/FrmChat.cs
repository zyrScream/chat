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
    public partial class FrmChat : Form
    {
        public FrmChat()
        {
            InitializeComponent();
        }

        private FriendsInfo _friendInfo;
        private ZyrQQ _zyrqq;

        public FrmChat(FriendsInfo f)
        {
            InitializeComponent();
            _friendInfo = f;
        }

        public FrmChat(FriendsInfo f,ZyrQQ zyrqq)
        {
            InitializeComponent();
            _friendInfo = f;
            _zyrqq = zyrqq;
        }

        private void FrmChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            _friendInfo.Ischat1 = false;
            _friendInfo.Frmchat = null;
        }

        private void FrmChat_Load(object sender, EventArgs e)
        {
            this.Text = _friendInfo.Name;
            for (int indexinMessage = 0; indexinMessage < _friendInfo.Sendmessage.Count; indexinMessage++)
            {
                this.txtChat.Text += _friendInfo.Name+":"+System.DateTime.Now.ToShortTimeString()+"\r\n"+_friendInfo.Sendmessage[indexinMessage]+"\r\n";
            }

            string path = Application.StartupPath + @"\好友聊天记录\" + _friendInfo.IPaddress1+".ini";
            if (!File.Exists(path))
            {
                return;
            }
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string message = sr.ReadLine();
                while (message != null)
                {
                    this.txtChat.Text += message + "\r\n";
                    message = sr.ReadLine();
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string sendMessage = this.txtSend.Text;
            UdpClient udpClient = new UdpClient();
            string message = "TEXT|" + sendMessage;
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(_friendInfo.IPaddress1), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndPoint);
            txtChat.Text += "我:" + System.DateTime.Now.ToShortTimeString() + "\r\n" + txtSend.Text+"\r\n";
            txtSend.Text = "";

            string filepath = Application.StartupPath + @"\好友聊天记录\" + _friendInfo.IPaddress1 +".ini";

            using (FileStream myFs = new FileStream(filepath, FileMode.Create))
            {
                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                {
                    mySw.WriteLine(txtChat.Text);
                }
            }
        }

        private void btnoQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefuseMessage_Click(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath + @"\屏蔽好友信息\" + _friendInfo.IPaddress1 + ".ini";

                using (FileStream myFs = new FileStream(filepath, FileMode.Create))
                {
                    using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                    {
                        mySw.WriteLine("true");
                    }
                }
        }

        private void btnReceiveMessage_Click(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath + @"\屏蔽好友信息\" + _friendInfo.IPaddress1 + ".ini";

            using (FileStream myFs = new FileStream(filepath, FileMode.Create))
            {
                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                {
                    mySw.WriteLine("false");
                }
            }
        }


        private int count,Sum = 0;
        private void tShake_Tick(object sender, EventArgs e)
        {
            if (Sum > 20)
            {
                return;
            }
            if (count == 0)
            {
                this.Left=100;
                this.Top = 100;
            }

            if (count == 1)
            {
                this.Left = 103;
                this.Top = 100;
            }

            if (count == 2)
            {
                this.Left = 103;
                this.Top = 103;
            }

            if (count == 3)
            {
                this.Left = 100;
                this.Top = 103;
            }
            count++;
            Sum++;
            if (count % 4 == 0)
            {
                count = 0;
            }
        }

        private void btnShake_Click(object sender, EventArgs e)
        {
            this.tShake.Enabled = true;

            string shakeIP = _friendInfo.IPaddress1;
            UdpClient udpClient = new UdpClient();
            string message = "SHAKE|";
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(shakeIP), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndPoint);
        }


        public void shake()
        {
            this.tShake.Enabled = true;
        }
    }
}
