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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSignatrue = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 0);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(80, 80);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
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
            // 
            // lblSignatrue
            // 
            this.lblSignatrue.AutoSize = true;
            this.lblSignatrue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblSignatrue.Location = new System.Drawing.Point(103, 22);
            this.lblSignatrue.Name = "lblSignatrue";
            this.lblSignatrue.Size = new System.Drawing.Size(59, 22);
            this.lblSignatrue.TabIndex = 2;
            this.lblSignatrue.Text = "label2";
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lbladdress.Location = new System.Drawing.Point(103, 44);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(59, 22);
            this.lbladdress.TabIndex = 3;
            this.lbladdress.Text = "label3";
            // 
            // UcFriends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.lblSignatrue);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picImage);
            this.Name = "UcFriends";
            this.Size = new System.Drawing.Size(279, 80);
            this.Load += new System.EventHandler(this.UcFriends_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSignatrue;
        private System.Windows.Forms.Label lbladdress;
    }
}
