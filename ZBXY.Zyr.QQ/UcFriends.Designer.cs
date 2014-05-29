namespace ZBXY.Zyr.QQ
{
    partial class UcFriends
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignatrue = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSend = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShield = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDescription = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.cmLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(5, 5);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(80, 80);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            this.picImage.Click += new System.EventHandler(this.picImage_DoubleClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(103, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 22);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "label1";
            this.lblName.DoubleClick += new System.EventHandler(this.lblName_DoubleClick);
            // 
            // lblSignatrue
            // 
            this.lblSignatrue.AutoSize = true;
            this.lblSignatrue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblSignatrue.Location = new System.Drawing.Point(103, 41);
            this.lblSignatrue.Name = "lblSignatrue";
            this.lblSignatrue.Size = new System.Drawing.Size(59, 22);
            this.lblSignatrue.TabIndex = 2;
            this.lblSignatrue.Text = "label2";
            this.lblSignatrue.DoubleClick += new System.EventHandler(this.lblSignatrue_DoubleClick);
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lbladdress.Location = new System.Drawing.Point(103, 63);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(59, 22);
            this.lbladdress.TabIndex = 3;
            this.lbladdress.Text = "label3";
            this.lbladdress.DoubleClick += new System.EventHandler(this.lbladdress_DoubleClick);
            // 
            // timer
            // 
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescription.Location = new System.Drawing.Point(103, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(54, 22);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "(备注)";
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // cmLeft
            // 
            this.cmLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSend,
            this.tsmShield,
            this.tsmDescription});
            this.cmLeft.Name = "cmLeft";
            this.cmLeft.Size = new System.Drawing.Size(153, 92);
            // 
            // tsmSend
            // 
            this.tsmSend.Name = "tsmSend";
            this.tsmSend.Size = new System.Drawing.Size(152, 22);
            this.tsmSend.Text = "发送信息";
            this.tsmSend.Click += new System.EventHandler(this.tsmSend_Click);
            // 
            // tsmShield
            // 
            this.tsmShield.Name = "tsmShield";
            this.tsmShield.Size = new System.Drawing.Size(152, 22);
            this.tsmShield.Text = "屏蔽";
            this.tsmShield.Click += new System.EventHandler(this.tsmShield_Click);
            // 
            // tsmDescription
            // 
            this.tsmDescription.Name = "tsmDescription";
            this.tsmDescription.Size = new System.Drawing.Size(152, 22);
            this.tsmDescription.Text = "备注";
            this.tsmDescription.Click += new System.EventHandler(this.tsmDescription_Click);
            // 
            // UcFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.lblSignatrue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picImage);
            this.Name = "UcFriends";
            this.Size = new System.Drawing.Size(279, 90);
            this.Load += new System.EventHandler(this.UcFriends_Load);
            this.DoubleClick += new System.EventHandler(this.UcFriends_DoubleClick);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UcFriends_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.cmLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSignatrue;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Timer timer;
        public System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ContextMenuStrip cmLeft;
        private System.Windows.Forms.ToolStripMenuItem tsmSend;
        private System.Windows.Forms.ToolStripMenuItem tsmShield;
        private System.Windows.Forms.ToolStripMenuItem tsmDescription;
    }
}
