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
    public partial class FrmEdit : Form
    {
        private ZyrQQ _frm;

        public FrmEdit()
        {
            InitializeComponent();
        }

        public FrmEdit(ZyrQQ frm)
        {
            InitializeComponent();
           this. _frm = frm;
        }
        private void FrmEdit_Load(object sender, EventArgs e)
        {
            this.picImage.Tag = PublicConst.Me.Image;

            this.txtNickName.Text = PublicConst.Me.Nickname;
            this.txtSignature.Text = PublicConst.Me.Signature;
            int imageindex=Convert.ToInt32(PublicConst.Me.Image);
            this.picImage.Image = _frm.headImageindex.Images[imageindex];

            int count=0;
            this.panImage.Controls.Clear();
            foreach(Image image in _frm.headImageindex.Images)
            {
                PictureBox picBox=new PictureBox();
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                picBox.Size=new System.Drawing.Size(50, 50);
                if (count % 11 == 0)
                {
                    picBox.Left = 0;
                }
                else
                {
                    picBox.Left = picBox.Width*(count%11);
                }
                picBox.Top=picBox.Height*(count/11);
                picBox.Cursor = Cursors.Hand;
                picBox.Click += picBox_Click;
                picBox.Image=image;
                picBox.Tag = count;
                this.panImage.Controls.Add(picBox);
                count++;
            }
        }

        void picBox_Click(object sender, EventArgs e)
        {
            PictureBox curPic = (PictureBox)sender;
            this.picImage.Image = curPic.Image;
            this.picImage.Tag = curPic.Tag;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string nickname = this.txtNickName.Text;
            string signature = this.txtSignature.Text;

            int index=Convert.ToInt32(this.picImage.Tag);
            PublicConst.Me.Nickname = this.txtNickName.Text;
            PublicConst.Me.Signature=this.txtSignature.Text;
            PublicConst.Me.Image = index.ToString();
            //写回主窗口
            _frm.picLogin.Image=this.picImage.Image;
            _frm.lblName.Text =nickname;
            _frm.lblSignature.Text = signature;
            //写回文件

            string[] information={nickname,index.ToString(),signature};
            string path = Application.StartupPath + @"\" + "setting.ini";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            {
                foreach (string info in information)
                {
                    file.WriteLine(info);
                }
            }

            //通知其他成员
            UdpClient udpClient = new UdpClient();
            string Updatemessage = "UPDATE|" + PublicConst.Me.Nickname + "|" + PublicConst.Me.Image + "|" + PublicConst.Me.Signature;
            byte[] UpdatemessageByte = Encoding.Default.GetBytes(Updatemessage);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(UpdatemessageByte, UpdatemessageByte.Length, ipEndPoint);

            this.Dispose();
        }

        private void panImage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
