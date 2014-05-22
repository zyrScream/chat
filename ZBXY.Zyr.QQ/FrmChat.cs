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
        }

        private void FrmChat_Load(object sender, EventArgs e)
        {
            this.Text = _friendInfo.Name;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string sendMessage = txtSend.Text;
            UdpClient udpClient = new UdpClient();
            string message = "TEXT|" + sendMessage;
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndPoint);
        }

    }
}
