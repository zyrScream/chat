using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBXY.Zyr.QQ
{
    public class FriendsInfo
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string signature;

        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private string IPaddress;

        public string IPaddress1
        {
            get { return IPaddress; }
            set { IPaddress = value; }
        }

        private bool Ischat;

        public bool Ischat1
        {
            get { return Ischat; }
            set { Ischat = value; }
        }

        private FrmChat frmchat=new FrmChat();

        public FrmChat Frmchat
        {
            get { return frmchat; }
            set { frmchat = value; }
        }

        private List<string> sendmessage=new List<string>();

        public List<string> Sendmessage
        {
            get { return sendmessage; }
            set { sendmessage = value; }
        }
    }
}
