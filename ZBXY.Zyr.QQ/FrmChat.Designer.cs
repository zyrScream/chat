namespace ZBXY.Zyr.QQ
{
    partial class FrmChat
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
            this.components = new System.ComponentModel.Container();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnoQuit = new System.Windows.Forms.Button();
            this.btnRefuseMessage = new System.Windows.Forms.Button();
            this.btnReceiveMessage = new System.Windows.Forms.Button();
            this.btnShake = new System.Windows.Forms.Button();
            this.tShake = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(188, 437);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChat.Location = new System.Drawing.Point(12, 12);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtChat.Size = new System.Drawing.Size(251, 302);
            this.txtChat.TabIndex = 1;
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.txtSend.Location = new System.Drawing.Point(12, 340);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(251, 51);
            this.txtSend.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "输入文字：";
            // 
            // btnoQuit
            // 
            this.btnoQuit.Location = new System.Drawing.Point(95, 437);
            this.btnoQuit.Name = "btnoQuit";
            this.btnoQuit.Size = new System.Drawing.Size(75, 23);
            this.btnoQuit.TabIndex = 4;
            this.btnoQuit.Text = "取消";
            this.btnoQuit.UseVisualStyleBackColor = true;
            this.btnoQuit.Click += new System.EventHandler(this.btnoQuit_Click);
            // 
            // btnRefuseMessage
            // 
            this.btnRefuseMessage.Location = new System.Drawing.Point(14, 408);
            this.btnRefuseMessage.Name = "btnRefuseMessage";
            this.btnRefuseMessage.Size = new System.Drawing.Size(75, 23);
            this.btnRefuseMessage.TabIndex = 5;
            this.btnRefuseMessage.Text = "拒收信息";
            this.btnRefuseMessage.UseVisualStyleBackColor = true;
            this.btnRefuseMessage.Click += new System.EventHandler(this.btnRefuseMessage_Click);
            // 
            // btnReceiveMessage
            // 
            this.btnReceiveMessage.Location = new System.Drawing.Point(95, 408);
            this.btnReceiveMessage.Name = "btnReceiveMessage";
            this.btnReceiveMessage.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveMessage.TabIndex = 5;
            this.btnReceiveMessage.Text = "接受信息";
            this.btnReceiveMessage.UseVisualStyleBackColor = true;
            this.btnReceiveMessage.Click += new System.EventHandler(this.btnReceiveMessage_Click);
            // 
            // btnShake
            // 
            this.btnShake.Location = new System.Drawing.Point(188, 408);
            this.btnShake.Name = "btnShake";
            this.btnShake.Size = new System.Drawing.Size(75, 23);
            this.btnShake.TabIndex = 5;
            this.btnShake.Text = "抖动";
            this.btnShake.UseVisualStyleBackColor = true;
            this.btnShake.Click += new System.EventHandler(this.btnShake_Click);
            // 
            // tShake
            // 
            this.tShake.Interval = 200;
            this.tShake.Tick += new System.EventHandler(this.tShake_Tick);
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 463);
            this.Controls.Add(this.btnShake);
            this.Controls.Add(this.btnReceiveMessage);
            this.Controls.Add(this.btnRefuseMessage);
            this.Controls.Add(this.btnoQuit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.btnSend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmChat";
            this.Text = "FrmChat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChat_FormClosed);
            this.Load += new System.EventHandler(this.FrmChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        public  System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnoQuit;
        private System.Windows.Forms.Button btnRefuseMessage;
        private System.Windows.Forms.Button btnReceiveMessage;
        private System.Windows.Forms.Button btnShake;
        private System.Windows.Forms.Timer tShake;
    }
}