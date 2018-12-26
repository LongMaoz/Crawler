namespace WindowsFormsApp1.View
{
    partial class LoginFrm
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
            this.TxtName = new CCWin.SkinControl.SkinTextBox();
            this.TxtPwd = new CCWin.SkinControl.SkinTextBox();
            this.LblName = new CCWin.SkinControl.SkinLabel();
            this.LblPwd = new CCWin.SkinControl.SkinLabel();
            this.Btn_Login = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.Color.Transparent;
            this.TxtName.DownBack = null;
            this.TxtName.Icon = null;
            this.TxtName.IconIsButton = false;
            this.TxtName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxtName.IsPasswordChat = '\0';
            this.TxtName.IsSystemPasswordChar = false;
            this.TxtName.Lines = new string[] {
        "skinTextBox1"};
            this.TxtName.Location = new System.Drawing.Point(225, 124);
            this.TxtName.Margin = new System.Windows.Forms.Padding(0);
            this.TxtName.MaxLength = 32767;
            this.TxtName.MinimumSize = new System.Drawing.Size(28, 28);
            this.TxtName.MouseBack = null;
            this.TxtName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxtName.Multiline = false;
            this.TxtName.Name = "TxtName";
            this.TxtName.NormlBack = null;
            this.TxtName.Padding = new System.Windows.Forms.Padding(5);
            this.TxtName.ReadOnly = false;
            this.TxtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtName.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.TxtName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxtName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TxtName.SkinTxt.Name = "BaseText";
            this.TxtName.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.TxtName.SkinTxt.TabIndex = 0;
            this.TxtName.SkinTxt.Text = "skinTextBox1";
            this.TxtName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtName.SkinTxt.WaterText = "";
            this.TxtName.TabIndex = 0;
            this.TxtName.Text = "skinTextBox1";
            this.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtName.WaterText = "";
            this.TxtName.WordWrap = true;
            // 
            // TxtPwd
            // 
            this.TxtPwd.BackColor = System.Drawing.Color.Transparent;
            this.TxtPwd.DownBack = null;
            this.TxtPwd.Icon = null;
            this.TxtPwd.IconIsButton = false;
            this.TxtPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxtPwd.IsPasswordChat = '●';
            this.TxtPwd.IsSystemPasswordChar = true;
            this.TxtPwd.Lines = new string[] {
        "skinTextBox1"};
            this.TxtPwd.Location = new System.Drawing.Point(225, 176);
            this.TxtPwd.Margin = new System.Windows.Forms.Padding(0);
            this.TxtPwd.MaxLength = 32767;
            this.TxtPwd.MinimumSize = new System.Drawing.Size(28, 28);
            this.TxtPwd.MouseBack = null;
            this.TxtPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxtPwd.Multiline = false;
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.NormlBack = null;
            this.TxtPwd.Padding = new System.Windows.Forms.Padding(5);
            this.TxtPwd.ReadOnly = false;
            this.TxtPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtPwd.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.TxtPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxtPwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TxtPwd.SkinTxt.Name = "BaseText";
            this.TxtPwd.SkinTxt.PasswordChar = '●';
            this.TxtPwd.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.TxtPwd.SkinTxt.TabIndex = 0;
            this.TxtPwd.SkinTxt.Text = "skinTextBox1";
            this.TxtPwd.SkinTxt.UseSystemPasswordChar = true;
            this.TxtPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtPwd.SkinTxt.WaterText = "";
            this.TxtPwd.TabIndex = 1;
            this.TxtPwd.Text = "skinTextBox1";
            this.TxtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtPwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtPwd.WaterText = "";
            this.TxtPwd.WordWrap = true;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.BorderColor = System.Drawing.Color.White;
            this.LblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblName.Location = new System.Drawing.Point(133, 132);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(85, 20);
            this.LblName.TabIndex = 2;
            this.LblName.Text = "skinLabel1";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblPwd
            // 
            this.LblPwd.AutoSize = true;
            this.LblPwd.BackColor = System.Drawing.Color.Transparent;
            this.LblPwd.BorderColor = System.Drawing.Color.White;
            this.LblPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPwd.Location = new System.Drawing.Point(133, 184);
            this.LblPwd.Name = "LblPwd";
            this.LblPwd.Size = new System.Drawing.Size(85, 20);
            this.LblPwd.TabIndex = 3;
            this.LblPwd.Text = "skinLabel2";
            this.LblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Login.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_Login.DownBack = null;
            this.Btn_Login.Location = new System.Drawing.Point(206, 238);
            this.Btn_Login.MouseBack = null;
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.NormlBack = null;
            this.Btn_Login.Size = new System.Drawing.Size(125, 28);
            this.Btn_Login.TabIndex = 4;
            this.Btn_Login.Text = "skinButton1";
            this.Btn_Login.UseVisualStyleBackColor = false;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 292);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.LblPwd);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.TxtName);
            this.MaximizeBox = false;
            this.Name = "LoginFrm";
            this.Text = "登录维客";
            this.Load += new System.EventHandler(this.LoginFrn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox TxtName;
        private CCWin.SkinControl.SkinTextBox TxtPwd;
        private CCWin.SkinControl.SkinLabel LblName;
        private CCWin.SkinControl.SkinLabel LblPwd;
        private CCWin.SkinControl.SkinButton Btn_Login;
    }
}