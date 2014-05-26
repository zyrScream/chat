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


namespace ZBXY.Zyr.QQ
{
    public partial class FrmChat : Form
    {
        public FrmChat()
        {
            InitializeComponent();
        }

        private FriendsInfo _friendInfo;

        public FrmChat(FriendsInfo f)
        {
            InitializeComponent();
            _friendInfo = f;
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
                this.txtChat.Text += _friendInfo.Name+"："+System.DateTime.Now.ToShortTimeString()+"\r\n"+_friendInfo.Sendmessage[indexinMessage]+"\r\n";
            }
            _friendInfo.Sendmessage = null;
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
        }

        private void btnoQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
   

    }
}
