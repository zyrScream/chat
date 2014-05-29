using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZBXY.Zyr.QQ
{
    public partial class FrmLogout : Form
    {
        public FrmLogout()
        {
            InitializeComponent();
        }

        private ZyrQQ _zyrqq=new ZyrQQ();
        private FriendsInfo _fl = new FriendsInfo();
        public FrmLogout(ZyrQQ zyrqq,FriendsInfo fl)
        {
            InitializeComponent();
            _zyrqq = zyrqq;
            _fl = fl;  
        }

        private void FrmLogout_Load(object sender, EventArgs e)
        {
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.timer.Enabled = true;
            this.lblName.Text = _fl.Name;
            this.lblIP.Text = _fl.IPaddress1;
            this.picImage.Image = _zyrqq.headImageindex.Images[Convert.ToInt32(_fl.Image)];
        }

        private int time = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (time < 10)
            {
                time += 1;
            }
            else
            {
                this.timer.Enabled = false;
                this.Close();
            }
        }
    }
}
