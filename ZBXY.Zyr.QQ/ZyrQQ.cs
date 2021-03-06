﻿using System;
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
using System.Threading;
using System.IO;
using System.Timers;

namespace ZBXY.Zyr.QQ
{
    public partial class ZyrQQ : Form
    {
        public List<FriendsInfo> friendsInformationList=new List<FriendsInfo>();
        public List<FriendsInfo> ChatroomFriends = new List<FriendsInfo>();
        public bool MyinChatroom;
        public bool FrmchatisExist;
        public FrmChatroom frmchatroom=new FrmChatroom();

        public ZyrQQ()
        {
            InitializeComponent();
        }

        public void ucChangecolor(string ip)
        {
            int num=0;
            while (num < panelFriend.Controls.Count)
            {
                UcFriends uf = (UcFriends)panelFriend.Controls[num];
                if (uf.IPaddress1 == ip)
                {
                    uf.BackColor = System.Drawing.Color.Red;
                }
                num++;
            }
        }

        public void startTimer(UcFriends uc)
        {
            uc.startFlash();
        }

        public void addFriends(FriendsInfo friend)
        {
            UcFriends uf = new UcFriends();

            uf.Name = friend.Name;
            uf.Signatrue = friend.Signature;
            int headindex = Convert.ToInt16(friend.Image);
            uf.Image = this.headImageindex.Images[headindex];
            uf.IPaddress1 = friend.IPaddress1;
            uf.Top = this.panelFriend.Controls.Count * uf.Height;
            uf.Left = 0;
            //uf.Description = ucDescription;

            string description;
            string dpath = Application.StartupPath + @"\好友备注\" + uf.IPaddress1+ ".ini";
            using (StreamReader sr = new StreamReader(dpath, Encoding.Default))
            {
                description = sr.ReadLine();
            }

            uf.Description = description;
            this.panelFriend.Controls.Add(uf);
            uf.shangji += uf_shangji;
        }

        void uf_shangji(object o, EventArgs e)
        {
            UcFriends ucf = (UcFriends)o;
            ucf.BackColor = System.Drawing.SystemColors.Control;
            ucf.stopFlash();
            int i = 0;
            for (i = 0; i < friendsInformationList.Count; i++)
            {
                if (friendsInformationList[i].IPaddress1 == ucf.IPaddress1)
                {
                    this.combFriend.Items.Add(friendsInformationList[i].Name);
                    break;
                }
            }

            FrmChat frmchat = new FrmChat(friendsInformationList[i],this);
            if (friendsInformationList[i].Ischat1)
            {
                return;
            }
            
            friendsInformationList[i].Frmchat = frmchat;
            friendsInformationList[i].Frmchat.Show();
            friendsInformationList[i].Ischat1 = true;
        }

        public void createByfriendsInformationList(FriendsInfo fi)
        {
            FrmLogout fl = new FrmLogout(this,fi);
            fl.Show();

            this.panelFriend.Controls.Clear();
            foreach (FriendsInfo f in friendsInformationList)
            {
                UcFriends ucf = new UcFriends();

                if (f.Sendmessage.Count > 0)
                {
                    ucf.BackColor = System.Drawing.Color.Red;
                }

                ucf.Name = f.Name;
                ucf.Image = this.headImageindex.Images[Convert.ToInt32(f.Image)];
                ucf.IPaddress1 = f.IPaddress1;
                ucf.Signatrue = f.Signature;
                //ucf.Description = ucDescription;
                string description;
                string dpath = Application.StartupPath + @"\好友备注\" + f.IPaddress1+ ".ini";
                using (StreamReader sr = new StreamReader(dpath, Encoding.Default))
                {
                    description = sr.ReadLine();
                }
                ucf.Description = description;
                ucf.Top = this.panelFriend.Controls.Count * ucf.Height;
                this.panelFriend.Controls.Add(ucf);
                ucf.shangji += uf_shangji;
            }
        }

        //public void deleteFriends(FriendsInfo friend)
        //{

        //    foreach (UcFriends uf in this.panelFriend.Controls)
        //    {
        //        if (friend.IPaddress1.ToString() == uf.IPaddress1.ToString())
        //        {
        //            this.panelFriend.Controls.Remove(uf);
        //        }
        //    }
        //}


        private MyInfo getMyinfo()
        {
            MyInfo myinfo = new MyInfo();
            string path = Application.StartupPath + @"\" + "setting.ini";

            myinfo.Nickname = System.Environment.MachineName;
            myinfo.Signature = "暂无";
            myinfo.Image = "0";

            if (!File.Exists(path))
            {
                return myinfo;
            }

            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string Nickname = sr.ReadLine();
                string Image = sr.ReadLine();
                string Signature = sr.ReadLine();

                if (Nickname != "")
                {
                    myinfo.Nickname = Nickname;
                }
                if (Image != "")
                {
                    myinfo.Image = Image;
                }
                int imageindex = Convert.ToInt32(Image);
                if (imageindex < 0 || imageindex > this.headImageindex.Images.Count)
                {
                    myinfo.Image = "0";
                }
                if (Signature != "")
                {
                    myinfo.Signature = Signature;
                }

            }
            return myinfo;
        }

        private void ZyrQQ_Load(object sender, EventArgs e)
        {
            PublicConst.Me = getMyinfo();

            this.lblName.Text = PublicConst.Me.Nickname;
            this.lblSignature.Text = PublicConst.Me.Signature;
            int imageindex=Int32.Parse(PublicConst.Me.Image);
            this.picLogin.Image = this.headImageindex.Images[imageindex];

            //安全性
            ZyrQQ.CheckForIllegalCrossThreadCalls=false;
            ThreadOpe threadOpe=new ThreadOpe(this);
            ThreadStart threadStart = new ThreadStart(threadOpe.listening);
            Thread thread = new Thread(threadStart);
            thread.IsBackground = true;
            thread.Start();
            Thread.Sleep(200);

            UdpClient udpClient = new UdpClient();
            string message = "LOGON|"+PublicConst.Me.Nickname+"|"+PublicConst.Me.Image+"|"+PublicConst.Me.Signature;
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(messageByte,messageByte.Length,ipEndPoint);
        }

        private void ZyrQQ_FormClosing(object sender, FormClosingEventArgs e)
        {
            UdpClient udpClient = new UdpClient();
            string message = "LOGOUT|";
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndpoint);
        }

        private void picLogin_DoubleClick(object sender, EventArgs e)
        {
            FrmEdit frmedit = new FrmEdit(this);
            frmedit.Show();
        }
        
        private void btnJoinChatroom_Click(object sender, EventArgs e)
        {
            if (FrmchatisExist)
            {
                return; 
            }
            if (MyinChatroom)
            {
                return;
            }
            MyinChatroom = true;

            UdpClient udpClient = new UdpClient();
            string message = "JOIN|" + PublicConst.Me.Nickname + "|" + PublicConst.Me.Image + "|" + PublicConst.Me.Signature;
            byte[] messageByte = Encoding.Default.GetBytes(message);
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udpClient.Send(messageByte, messageByte.Length, ipEndpoint);

            FrmChatroom Frmchatroom = new FrmChatroom(this);
            frmchatroom = Frmchatroom;
            frmchatroom.Show();

            FrmchatisExist = true;

        }

        private void btnBroadcast_Click(object sender, EventArgs e)
        {
            FrmBoradcast fb = new FrmBoradcast();
            fb.Show();
        }

        public void openShake(FriendsInfo fi)
        {
            //fi.Frmchat.shake();
            FrmChat frmchat = new FrmChat(fi, this);
            frmchat.shake();
            frmchat.Show();
        }
    }
}
