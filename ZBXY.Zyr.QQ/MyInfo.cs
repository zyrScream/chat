using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBXY.Zyr.QQ
{
    public class MyInfo
    {
        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
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
    }
}
