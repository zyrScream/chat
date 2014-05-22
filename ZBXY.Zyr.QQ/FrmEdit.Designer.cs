namespace ZBXY.Zyr.QQ
{
    partial class FrmEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panImage = new System.Windows.Forms.Panel();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblNickname = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panImage
            // 
            this.panImage.AutoScroll = true;
            this.panImage.Location = new System.Drawing.Point(0, 0);
            this.panImage.Name = "panImage";
            this.panImage.Size = new System.Drawing.Size(575, 258);
            this.panImage.TabIndex = 0;
            this.panImage.Paint += new System.Windows.Forms.PaintEventHandler(this.panImage_Paint);
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(181, 276);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(100, 21);
            this.txtNickName.TabIndex = 1;
            // 
            // txtSignature
            // 
            this.txtSignature.Location = new System.Drawing.Point(181, 310);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(200, 21);
            this.txtSignature.TabIndex = 1;
            // 
            // picImage
            // 
            this.picImage.Location = new System.Drawing.Point(0, 264);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(80, 80);
            this.picImage.TabIndex = 2;
            this.picImage.TabStop = false;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(113, 313);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(41, 12);
            this.lblSignature.TabIndex = 3;
            this.lblSignature.Text = "签名：";
            // 
            // lblNickname
            // 
            this.lblNickname.AutoSize = true;
            this.lblNickname.Location = new System.Drawing.Point(113, 279);
            this.lblNickname.Name = "lblNickname";
            this.lblNickname.Size = new System.Drawing.Size(41, 12);
            this.lblNickname.TabIndex = 3;
            this.lblNickname.Text = "昵称：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(478, 310);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 348);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblNickname);
            this.Controls.Add(this.lblSignature);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtSignature);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.panImage);
            this.Name = "FrmEdit";
            this.Text = "FrmEdit";
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panImage;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblNickname;
        private System.Windows.Forms.Button btnOk;
    }
}