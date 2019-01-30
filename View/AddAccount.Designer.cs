namespace WindowsFormsApp1.View
{
    partial class AddAccount
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
            this.Btn_Weike = new CCWin.SkinControl.SkinButton();
            this.LblPwd = new CCWin.SkinControl.SkinLabel();
            this.LblName = new CCWin.SkinControl.SkinLabel();
            this.TxtPwd = new CCWin.SkinControl.SkinTextBox();
            this.TxtName = new CCWin.SkinControl.SkinTextBox();
            this.LblType = new CCWin.SkinControl.SkinLabel();
            this.SelectType = new CCWin.SkinControl.SkinComboBox();
            this.SuspendLayout();
            // 
            // Btn_Weike
            // 
            this.Btn_Weike.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Weike.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_Weike.DownBack = null;
            this.Btn_Weike.Location = new System.Drawing.Point(168, 226);
            this.Btn_Weike.MouseBack = null;
            this.Btn_Weike.Name = "Btn_Weike";
            this.Btn_Weike.NormlBack = null;
            this.Btn_Weike.Size = new System.Drawing.Size(125, 28);
            this.Btn_Weike.TabIndex = 9;
            this.Btn_Weike.Text = "skinButton1";
            this.Btn_Weike.UseVisualStyleBackColor = false;
            this.Btn_Weike.Click += new System.EventHandler(this.Btn_Weike_Click);
            // 
            // LblPwd
            // 
            this.LblPwd.AutoSize = true;
            this.LblPwd.BackColor = System.Drawing.Color.Transparent;
            this.LblPwd.BorderColor = System.Drawing.Color.White;
            this.LblPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPwd.Location = new System.Drawing.Point(76, 172);
            this.LblPwd.Name = "LblPwd";
            this.LblPwd.Size = new System.Drawing.Size(85, 20);
            this.LblPwd.TabIndex = 8;
            this.LblPwd.Text = "skinLabel2";
            this.LblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.BorderColor = System.Drawing.Color.White;
            this.LblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblName.Location = new System.Drawing.Point(76, 120);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(85, 20);
            this.LblName.TabIndex = 7;
            this.LblName.Text = "skinLabel1";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.TxtPwd.Location = new System.Drawing.Point(168, 164);
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
            this.TxtPwd.TabIndex = 6;
            this.TxtPwd.Text = "skinTextBox1";
            this.TxtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtPwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtPwd.WaterText = "";
            this.TxtPwd.WordWrap = true;
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
            this.TxtName.Location = new System.Drawing.Point(168, 112);
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
            this.TxtName.TabIndex = 5;
            this.TxtName.Text = "skinTextBox1";
            this.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtName.WaterText = "";
            this.TxtName.WordWrap = true;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.BackColor = System.Drawing.Color.Transparent;
            this.LblType.BorderColor = System.Drawing.Color.White;
            this.LblType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblType.Location = new System.Drawing.Point(76, 71);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(85, 20);
            this.LblType.TabIndex = 10;
            this.LblType.Text = "skinLabel1";
            this.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectType
            // 
            this.SelectType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SelectType.FormattingEnabled = true;
            this.SelectType.Location = new System.Drawing.Point(167, 65);
            this.SelectType.Name = "SelectType";
            this.SelectType.Size = new System.Drawing.Size(186, 26);
            this.SelectType.TabIndex = 11;
            this.SelectType.WaterText = "";
            // 
            // AddAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 297);
            this.Controls.Add(this.SelectType);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.Btn_Weike);
            this.Controls.Add(this.LblPwd);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.TxtName);
            this.Name = "AddAccount";
            this.Text = "Add_Account";
            this.Load += new System.EventHandler(this.Add_Account_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton Btn_Weike;
        private CCWin.SkinControl.SkinLabel LblPwd;
        private CCWin.SkinControl.SkinLabel LblName;
        private CCWin.SkinControl.SkinTextBox TxtPwd;
        private CCWin.SkinControl.SkinTextBox TxtName;
        private CCWin.SkinControl.SkinLabel LblType;
        private CCWin.SkinControl.SkinComboBox SelectType;
    }
}