namespace TCPClientDemo
{
    partial class FormClient
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
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lst_OnlineUser = new System.Windows.Forms.ListBox();
            this.rtf_SendMessage = new System.Windows.Forms.TextBox();
            this.rtf_MessageInfo = new System.Windows.Forms.RichTextBox();
            this.rtf_StatusInfo = new System.Windows.Forms.RichTextBox();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(89, 13);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(274, 21);
            this.txt_UserName.TabIndex = 0;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(447, 10);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lst_OnlineUser
            // 
            this.lst_OnlineUser.FormattingEnabled = true;
            this.lst_OnlineUser.ItemHeight = 12;
            this.lst_OnlineUser.Location = new System.Drawing.Point(12, 59);
            this.lst_OnlineUser.Name = "lst_OnlineUser";
            this.lst_OnlineUser.Size = new System.Drawing.Size(105, 316);
            this.lst_OnlineUser.TabIndex = 2;
            // 
            // rtf_SendMessage
            // 
            this.rtf_SendMessage.Location = new System.Drawing.Point(45, 409);
            this.rtf_SendMessage.Name = "rtf_SendMessage";
            this.rtf_SendMessage.Size = new System.Drawing.Size(488, 21);
            this.rtf_SendMessage.TabIndex = 3;
            // 
            // rtf_MessageInfo
            // 
            this.rtf_MessageInfo.Location = new System.Drawing.Point(185, 59);
            this.rtf_MessageInfo.Name = "rtf_MessageInfo";
            this.rtf_MessageInfo.Size = new System.Drawing.Size(241, 316);
            this.rtf_MessageInfo.TabIndex = 4;
            this.rtf_MessageInfo.Text = "";
            // 
            // rtf_StatusInfo
            // 
            this.rtf_StatusInfo.Location = new System.Drawing.Point(485, 59);
            this.rtf_StatusInfo.Name = "rtf_StatusInfo";
            this.rtf_StatusInfo.Size = new System.Drawing.Size(168, 316);
            this.rtf_StatusInfo.TabIndex = 5;
            this.rtf_StatusInfo.Text = "";
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.Location = new System.Drawing.Point(552, 409);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(75, 23);
            this.btn_SendMessage.TabIndex = 6;
            this.btn_SendMessage.Text = "发送";
            this.btn_SendMessage.UseVisualStyleBackColor = true;
            this.btn_SendMessage.Click += new System.EventHandler(this.btn_SendMessage_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 455);
            this.Controls.Add(this.btn_SendMessage);
            this.Controls.Add(this.rtf_StatusInfo);
            this.Controls.Add(this.rtf_MessageInfo);
            this.Controls.Add(this.rtf_SendMessage);
            this.Controls.Add(this.lst_OnlineUser);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_UserName);
            this.Name = "FormClient";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.ListBox lst_OnlineUser;
        private System.Windows.Forms.TextBox rtf_SendMessage;
        private System.Windows.Forms.RichTextBox rtf_MessageInfo;
        private System.Windows.Forms.RichTextBox rtf_StatusInfo;
        private System.Windows.Forms.Button btn_SendMessage;
    }
}

