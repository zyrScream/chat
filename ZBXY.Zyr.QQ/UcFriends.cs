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

        public void startFlash()
        {
            this.timer.Enabled = true;
        }

        public void stopFlash()
        {
            this.timer.Enabled = false;
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

        private int locationFlag=0;
        private void timer_Tick(object sender, EventArgs e)
        {
         
            if (locationFlag == 0)
            {
                this.picImage.Left = 6;
                this.picImage.Top = 5;
            }

            if (locationFlag == 1)
            {
                this.picImage.Left = 5;
                this.picImage.Top = 6;
            }

            if (locationFlag == 2)
            {
                this.picImage.Left = 4;
                this.picImage.Top = 5;
            }

            if (locationFlag == 3)
            {
                this.picImage.Left = 5;
                this.picImage.Top = 4;
            }
            locationFlag++;
            if (locationFlag == 4)
            {
                locationFlag = 0;
            }
        }



    }
}
