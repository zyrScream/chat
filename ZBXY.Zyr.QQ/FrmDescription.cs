using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZBXY.Zyr.QQ
{
    public partial class FrmDescription : Form
    {

        public delegate void changdescription();

        public FrmDescription()
        {
            InitializeComponent();
        }

        private UcFriends _ucf;
        public FrmDescription(UcFriends ucf)
        {
            InitializeComponent();
            _ucf = ucf;
        }

        
        private void FrmDescription_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _ucf.Description = txtDescription.Text;
            _ucf.Invoke(new changdescription(_ucf.changdescription));

            string dpath = Application.StartupPath + @"\好友备注\" + _ucf.IPaddress1 + ".ini";

            using (FileStream myFs = new FileStream(dpath, FileMode.Create))
            {
                using (StreamWriter mySw = new StreamWriter(myFs, Encoding.Default))
                {
                    mySw.WriteLine(txtDescription.Text);
                }
            }

            this.txtDescription.Text = "";
        }
    }
}
