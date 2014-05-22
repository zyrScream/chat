using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBXY.Zyr.QQ
{
    public partial class UcFriends : UserControl
    {
        public delegate void delShangji(Object o, EventArgs e);
        public event delShangji shangji;
        public UcFriends()
        {
            InitializeComponent();
        }

        private Image image;

        public Image Image
        {
            get { return image; }
            set
            { 
                image = value;
                this.picImage.Image = value;
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set 
            { 
                name = value;
                lblName.Text = value;
            }
        }

        private string signatrue;

        public string Signatrue
        {
            get { return signatrue; }
            set
            {
                signatrue = value;
                lblSignatrue.Text = value;
            }
        }

        private string IPaddress;

        public string IPaddress1
        {
            get { return IPaddress; }
            set
            { 
                IPaddress = value;
                lbladdress.Text = value;
            }
        }

        private void UcFriends_Load(object sender, EventArgs e)
        {

        }

        private void UcFriends_DoubleClick(object sender, EventArgs e)
        {
            this.shangji(sender, e);
        }

        private void picImage_DoubleClick(object sender, EventArgs e)
        {
            this.shangji(this, e);
        }

        private void lblName_DoubleClick(object sender, EventArgs e)
        {
            this.shangji(this, e);
        }

        private void lblSignatrue_DoubleClick(object sender, EventArgs e)
        {
            this.shangji(this, e);
        }

        private void lbladdress_DoubleClick(object sender, EventArgs e)
        {
            this.shangji(this, e);
        }



    }
}
