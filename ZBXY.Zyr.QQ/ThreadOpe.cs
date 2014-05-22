using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ZBXY.Zyr.QQ
{
    public class ThreadOpe
    {
        public delegate void addFriends(FriendsInfo friendInfo);
        //public delegate void deleteFriends(FriendsInfo friendInfo); 
        public delegate void createByfriendsInformationList();
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
                    

                        for (int i = 0; i < _frm.friendsInformationList.Count; i++)
                        { 
                            if(_frm.friendsInformationList[i].IPaddress1==ipEndpoint.Address.ToString())
                            {
                                _frm.friendsInformationList.RemoveAt(i);
                            }
                        }

                        _frm.Invoke(new createByfriendsInformationList(_frm.createByfriendsInformationList));

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

                    case"TEXT":
                        if (splitMessage.Length != 2)
                        {
                            continue;
                        }
                        string Sendmessage = splitMessage[1];

                        break;

                    default:
                        break;
                }
            }
        }
    }
}
