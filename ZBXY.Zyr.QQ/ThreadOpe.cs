using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace ZBXY.Zyr.QQ
{
    public class ThreadOpe
    {
        public delegate void addFriends(FriendsInfo friendInfo);
        //public delegate void deleteFriends(FriendsInfo friendInfo); 
        public delegate void createByfriendsInformationList(FriendsInfo friendinfo);
        public delegate void createfriendsInformationList();
        public delegate void delflash(UcFriends startTimer);
        public delegate void openShake(FriendsInfo friendinfo);
        public delegate void shake();
        private ZyrQQ _frm;

        public ThreadOpe()
        { }

        public ThreadOpe(ZyrQQ frm)
        {
            _frm = frm;
        }

        private IPAddress getMyip()
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily.ToString().ToUpper() == "INTERNETWORK")
                {
                    return ip;
                }
            }
            return null;
        }

        public void listening()
        {
            IPAddress myip = getMyip();
            if (myip == null)
            {
                Application.Exit();
                MessageBox.Show("亲~请确认网卡是否存在或已经损坏！");
            }

            UdpClient udpClient = new UdpClient(9527);
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Any,0);

            while (true)
            { 
                byte[] byteMessage=udpClient.Receive(ref ipEndpoint);
                string message=Encoding.Default.GetString(byteMessage);

                string[] splitMessage = message.Split('|');
                string head = splitMessage[0];


                if (ipEndpoint.Address.ToString()== myip.ToString())
                {
                    continue;
                }

                switch (head)
                {
                    #region LOGON

                    case "LOGON":
                        if(splitMessage.Length!=4)
                        {
                            continue;
                        }

                        string repath1 = Application.StartupPath + @"\屏蔽好友信息\" + ipEndpoint.Address.ToString() + ".ini";

                        if (!File.Exists(repath1))
                        {
                            using (FileStream myFs = new FileStream(repath1, FileMode.Create))
                            {
                                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                                {
                                    mySw.WriteLine("false");
                                }
                            }
                        }

                        string dpath1 = Application.StartupPath + @"\好友备注\" + ipEndpoint.Address.ToString() + ".ini";

                        if (!File.Exists(dpath1))
                        {
                            using (FileStream myFs = new FileStream(dpath1, FileMode.Create))
                            {
                                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                                {
                                    mySw.WriteLine("(备注)");
                                }
                            }
                        }
                        
                        FriendsInfo friendInfo= new FriendsInfo();
                        friendInfo.Name=splitMessage[1];
                        friendInfo.Image=splitMessage[2];
                        if (Convert.ToInt32(friendInfo.Image) > 110 || Convert.ToInt32(friendInfo.Image) < 0)
                        {
                            continue;
                        }
                        friendInfo.Signature=splitMessage[3];
                        friendInfo.IPaddress1 =ipEndpoint.Address.ToString();
                        object[] pars=new object[1];
                        pars[0]=friendInfo;

                        _frm.friendsInformationList.Add(friendInfo);//在list中加

                        _frm.Invoke(new addFriends(_frm.addFriends),pars);//我接受并显示对方的信息

                        

                        IPAddress ip = ipEndpoint.Address;//取地址 
                        //IPHostEntry ipH = Dns.GetHostEntry(Dns.GetHostName());
                        //string myip = ipH.AddressList[4].ToString();
                        //if(ip.ToString()==myip)
                        //{
                        //    continue;
                        //}

                        string backmessage = "ALSOON|"+PublicConst.Me.Nickname+"|"+PublicConst.Me.Image+"|"+PublicConst.Me.Signature;
                        byte[] backmessageByte = Encoding.Default.GetBytes(backmessage);
                        IPEndPoint ipEndPoint = new IPEndPoint(ip, 9527); 
                        udpClient.Send(backmessageByte,backmessageByte.Length,ipEndPoint);

                        

                        break;
                    #endregion

                    #region ALSOON
                    case "ALSOON":
                        if (splitMessage.Length != 4)
                        {
                            continue;
                        }

                         string repath2 = Application.StartupPath + @"\屏蔽好友信息\" + ipEndpoint.Address.ToString() + ".ini";

                         if (!File.Exists(repath2))
                         {
                             using (FileStream myFs = new FileStream(repath2, FileMode.Create))
                             {
                                 using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                                 {
                                     mySw.WriteLine("false");
                                 }
                             }
                         }

                        string dpath = Application.StartupPath + @"\好友备注\" + ipEndpoint.Address.ToString() + ".ini";
                        if (!File.Exists(dpath))
                        {
                            using (FileStream myFs = new FileStream(dpath, FileMode.Create))
                            {
                                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                                {
                                    mySw.WriteLine("(备注)");
                                }
                            }
                        }

                        FriendsInfo friendInfo1= new FriendsInfo();
                        friendInfo1.Name=splitMessage[1];
                        if (Convert.ToInt32(friendInfo1.Image) > 110 || Convert.ToInt32(friendInfo1.Image) < 0)
                        {
                            continue;
                        }
                        friendInfo1.Image=splitMessage[2];
                        friendInfo1.Signature=splitMessage[3];
                        friendInfo1.IPaddress1 = ipEndpoint.Address.ToString();
                        object[] pars1=new object[1];
                        pars1[0]=friendInfo1;
                        _frm.Invoke(new addFriends(_frm.addFriends),pars1);
                        _frm.friendsInformationList.Add(friendInfo1);

                       
                        break;
                    #endregion

                    #region LOGOUT
                    case "LOGOUT":
                        if (splitMessage.Length != 2)
                        {
                            continue;
                        }

                        //FriendsInfo friendInfo2 = new FriendsInfo();
                        //friendInfo2.IPaddress1 = ipEndpoint.Address.ToString();
                        //object[] pars2=new object[1];
                        //pars2[0]=friendInfo2;
                        //_frm.Invoke(new deleteFriends(_frm.deleteFriends),pars2);
                        FriendsInfo logoutFi = new FriendsInfo();
                        for (int i = 0; i < _frm.friendsInformationList.Count; i++)
                        { 
                            if(_frm.friendsInformationList[i].IPaddress1==ipEndpoint.Address.ToString())
                            {
                                logoutFi = _frm.friendsInformationList[i];
                                _frm.friendsInformationList.RemoveAt(i);
                            }
                        }
                        object[] logobj = new object[1];
                        logobj[0] = logoutFi;
                        _frm.Invoke(new createByfriendsInformationList(_frm.createByfriendsInformationList),logobj);

                        break;
                    #endregion

                    #region UPDATE

                    case "UPDATE":
                        if (splitMessage.Length != 4)
                        {
                            continue;
                        }

                        FriendsInfo FriendInfo = new FriendsInfo();
                        FriendInfo.Name = splitMessage[1];
                        FriendInfo.Image = splitMessage[2];
                        if (Convert.ToInt32(FriendInfo.Image) > 110 || Convert.ToInt32(FriendInfo.Image) < 0)
                        {
                            continue;
                        }
                        FriendInfo.Signature = splitMessage[3];
                        FriendInfo.IPaddress1 = ipEndpoint.Address.ToString();
                        
                        int count = 0;
                        foreach (UcFriends ucf in _frm.panelFriend.Controls)
                        {
                            if (ucf.IPaddress1 == ipEndpoint.Address.ToString())
                            {
                                ucf.Name = FriendInfo.Name;
                                ucf.Signatrue = FriendInfo.Signature;
                                ucf.Image = _frm.headImageindex.Images[Convert.ToInt32(FriendInfo.Image)];
                                ucf.IPaddress1 = FriendInfo.IPaddress1;
                                break;
                            }
                            count++;
                        }

                        break;

                   #endregion

                    #region TEXT
                    case "TEXT":
                        if (splitMessage.Length != 2)
                        {
                            continue;
                        }

                        string Sendmessage = splitMessage[1];
                        string name=null;
                        string refusemessage;
                        foreach (FriendsInfo frie in _frm.friendsInformationList)
                        {
                            if (frie.IPaddress1 == ipEndpoint.Address.ToString())
                            {
                                name=frie.Name;
                            }
                        }

                        string repath = Application.StartupPath + @"\屏蔽好友信息\" + ipEndpoint.Address.ToString() + ".ini";
                        using (StreamReader sr = new StreamReader(repath, Encoding.Default))
                        {
                            refusemessage = sr.ReadLine();
                        }

                        if (refusemessage == "true")
                        {
                            continue;
                        }
                        string filepath = Application.StartupPath + @"\好友聊天记录\"+ipEndpoint.Address.ToString()+".ini";
                        if (File.Exists(filepath))
                        {//文件存在
                            using (FileStream myFs = new FileStream(filepath, FileMode.Append))
                            {
                                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                                {
                                    mySw.WriteLine(name+":"+System.DateTime.Now.ToShortTimeString()+"\r\n"+Sendmessage);
                                }
                            }
                        }
                        else
                        {//文件不存在
                            using (FileStream myFs = new FileStream(filepath, FileMode.Create))
                            {
                                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                                {
                                    mySw.WriteLine(name + ":" + System.DateTime.Now.ToShortTimeString() + "\r\n" + Sendmessage);
                                }
                            }
                        }

                        for (int listindex = 0; listindex < _frm.friendsInformationList.Count; listindex++)
                        {
                            if (ipEndpoint.Address.ToString() == _frm.friendsInformationList[listindex].IPaddress1)
                            {
                                if (_frm.friendsInformationList[listindex].Ischat1 == true)
                                {
                                    _frm.friendsInformationList[listindex].Frmchat.txtChat.Text += _frm.friendsInformationList[listindex] .Name+":"+System.DateTime.Now.ToShortTimeString()+"\r\n"+ Sendmessage+"\r\n";
                                }
                                else 
                                {
                                    _frm.friendsInformationList[listindex].Sendmessage.Add(Sendmessage);
                                    _frm.ucChangecolor(ipEndpoint.Address.ToString());
                                    //UcFriends uc = (UcFriends)_frm.panelFriend.Controls[listindex];
                                    object[] ucpars=new object[1];
                                    ucpars[0] = _frm.panelFriend.Controls[listindex];
                                    _frm.Invoke(new delflash(_frm.startTimer),ucpars);                        
                                }
                            }
                        }

                            break;

                    #endregion

                    #region JOIN
                    case "JOIN":
                            if (!_frm.MyinChatroom)
                            {
                                continue;
                            }
                            if(splitMessage.Length!=4)
                            {
                                continue;
                            }
                            FriendsInfo cf = new FriendsInfo();
                            cf.Name = splitMessage[1];
                            cf.Image = splitMessage[2];
                            cf.Signature = splitMessage[3];
                            cf.IPaddress1 = ipEndpoint.Address.ToString();

                            _frm.ChatroomFriends.Add(cf);

                            object[] cpars=new object[1];
                            cpars[0]=cf;
                            _frm.frmchatroom.Invoke(new addFriends(_frm.frmchatroom.addFriends), cpars);

                            IPAddress chatIP = ipEndpoint.Address;
                            string chatbackmessage = "ALSOIN|"+PublicConst.Me.Nickname+"|"+PublicConst.Me.Image+"|"+PublicConst.Me.Signature;
                            byte[] chatbackmessageByte = Encoding.Default.GetBytes(chatbackmessage);
                            IPEndPoint chatipEndPoint = new IPEndPoint(chatIP, 9527); 
                            udpClient.Send(chatbackmessageByte,chatbackmessageByte.Length,chatipEndPoint);
                            break;
                    #endregion

                    #region ALSOIN
                    case "ALSOIN":
                             if(splitMessage.Length!=4)
                            {
                                continue;
                            }
                             if (!_frm.MyinChatroom)
                             {
                                 continue;
                             }
                            FriendsInfo acf = new FriendsInfo();
                            acf.Name = splitMessage[1];
                            acf.Image = splitMessage[2];
                            acf.Signature = splitMessage[3];
                            acf.IPaddress1 = ipEndpoint.Address.ToString();

                            _frm.ChatroomFriends.Add(acf);

                            object[] capars=new object[1];
                            capars[0]=acf;
                            _frm.frmchatroom.Invoke(new addFriends(_frm.frmchatroom.addFriends), capars);
                            break;
                        #endregion

                    #region LEAVE
                    case "LEAVE":
                            if (splitMessage.Length != 2)
                            {
                                continue;
                            }

                            if (!_frm.MyinChatroom)
                            {
                                continue;
                            }

                            for (int index = 0; index < _frm.ChatroomFriends.Count;index++ )
                            {
                                if (_frm.ChatroomFriends[index].IPaddress1 == ipEndpoint.Address.ToString())
                                {
                                    _frm.ChatroomFriends.RemoveAt(index);
                                    break;
                                }
                            }

                            _frm.frmchatroom.Invoke(new createfriendsInformationList(_frm.frmchatroom.createfriendsInformationList));
                            
                                break;
                    #endregion

                    #region CHATROOM
                    case "CHATROOM":
                                if (splitMessage.Length != 2)
                                {
                                    continue;
                                }
                                if (!_frm.MyinChatroom)
                                {
                                    continue;
                                }

                                string chatroomMemName=null;
                                foreach (FriendsInfo fris in _frm.ChatroomFriends)
                                {
                                    if (ipEndpoint.Address.ToString() == fris.IPaddress1)
                                    {
                                        chatroomMemName = fris.Name;
                                    }
                                }

                                _frm.frmchatroom.txtChat.Text +=chatroomMemName+":"+System.DateTime.Now.ToShortTimeString()+"\r\n"+ splitMessage[1]+"\r\n";

                                string path = Application.StartupPath + @"\聊天室聊天记录\" + "chatroom.ini";

                                using(FileStream fs=new FileStream(path,FileMode.Create))
                                    using (StreamWriter file = new StreamWriter(fs,Encoding.Default))
                                    {
                                        file.WriteLine(chatroomMemName + ":" + System.DateTime.Now.ToShortTimeString() + "\r\n" + splitMessage[1]);
                                    }
                                break;
                    #endregion

                    #region PUBLIC
                    case"PUBLIC":
                         if (splitMessage.Length != 2)
                        {
                            continue;
                        }

                        string PublicSendmessage = splitMessage[1];
                        for (int listindex = 0; listindex < _frm.friendsInformationList.Count; listindex++)
                        {
                            if (ipEndpoint.Address.ToString() == _frm.friendsInformationList[listindex].IPaddress1)
                            {
                                if (_frm.friendsInformationList[listindex].Ischat1 == true)
                                {
                                    _frm.friendsInformationList[listindex].Frmchat.txtChat.Text += _frm.friendsInformationList[listindex].Name + ":" + System.DateTime.Now.ToShortTimeString() + "\r\n" + PublicSendmessage + "\r\n";
                                }
                                else 
                                {
                                    _frm.friendsInformationList[listindex].Sendmessage.Add(PublicSendmessage);
                                    _frm.ucChangecolor(ipEndpoint.Address.ToString());
                                    //UcFriends uc = (UcFriends)_frm.panelFriend.Controls[listindex];
                                    object[] ucpars=new object[1];
                                    ucpars[0] = _frm.panelFriend.Controls[listindex];
                                    _frm.Invoke(new delflash(_frm.startTimer),ucpars);
                                    
                                }
                            }
                        }

                                break;
                    #endregion

                    #region
                    case "SHAKE":
                                if (splitMessage.Length != 2)
                                {
                                    continue;
                                }
                                foreach (FriendsInfo friend in _frm.friendsInformationList)
                                {
                                    if (friend.IPaddress1 == ipEndpoint.Address.ToString())
                                    {
                                        if (friend.Ischat1 == true)
                                        {
                                            friend.Frmchat.Invoke(new shake(friend.Frmchat.shake));
                                        }
                                        else
                                        { 
                                            object[] openShake=new object[1];
                                            openShake[0]=friend;
                                            _frm.Invoke(new openShake(_frm.openShake), openShake);
                                        }
                                    }
                                }
                                break;
                    #endregion
                    default:
                        break;
                }
            }
        }
    }
}
