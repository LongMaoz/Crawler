namespace WindowsFormsApp1.View
{
    partial class AddCompany
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
            this.Btn_AddComapny = new CCWin.SkinControl.SkinButton();
            this.LblPwd = new CCWin.SkinControl.SkinLabel();
            this.LblName = new CCWin.SkinControl.SkinLabel();
            this.TxtPwd = new CCWin.SkinControl.SkinTextBox();
            this.TxtName = new CCWin.SkinControl.SkinTextBox();
            this.SelectCompany = new CCWin.SkinControl.SkinComboBox();
            this.LblCompany = new CCWin.SkinControl.SkinLabel();
            this.LbltempName = new CCWin.SkinControl.SkinLabel();
            this.TxttempName = new CCWin.SkinControl.SkinTextBox();
            this.SelectBranch = new CCWin.SkinControl.SkinComboBox();
            this.LblBranch = new CCWin.SkinControl.SkinLabel();
            this.Btn_SelectCompany = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // Btn_AddComapny
            // 
            this.Btn_AddComapny.BackColor = System.Drawing.Color.Transparent;
            this.Btn_AddComapny.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_AddComapny.DownBack = null;
            this.Btn_AddComapny.Location = new System.Drawing.Point(169, 272);
            this.Btn_AddComapny.MouseBack = null;
            this.Btn_AddComapny.Name = "Btn_AddComapny";
            this.Btn_AddComapny.NormlBack = null;
            this.Btn_AddComapny.Size = new System.Drawing.Size(125, 28);
            this.Btn_AddComapny.TabIndex = 14;
            this.Btn_AddComapny.Text = "skinButton1";
            this.Btn_AddComapny.UseVisualStyleBackColor = false;
            this.Btn_AddComapny.Click += new System.EventHandler(this.Btn_AddComapny_Click);
            // 
            // LblPwd
            // 
            this.LblPwd.AutoSize = true;
            this.LblPwd.BackColor = System.Drawing.Color.Transparent;
            this.LblPwd.BorderColor = System.Drawing.Color.White;
            this.LblPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPwd.Location = new System.Drawing.Point(78, 229);
            this.LblPwd.Name = "LblPwd";
            this.LblPwd.Size = new System.Drawing.Size(85, 20);
            this.LblPwd.TabIndex = 13;
            this.LblPwd.Text = "skinLabel2";
            this.LblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.BorderColor = System.Drawing.Color.White;
            this.LblName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblName.Location = new System.Drawing.Point(78, 188);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(85, 20);
            this.LblName.TabIndex = 12;
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
            this.TxtPwd.Location = new System.Drawing.Point(169, 224);
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
            this.TxtPwd.TabIndex = 11;
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
            this.TxtName.Location = new System.Drawing.Point(169, 183);
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
            this.TxtName.TabIndex = 10;
            this.TxtName.Text = "skinTextBox1";
            this.TxtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtName.WaterText = "";
            this.TxtName.WordWrap = true;
            // 
            // SelectCompany
            // 
            this.SelectCompany.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SelectCompany.FormattingEnabled = true;
            this.SelectCompany.Location = new System.Drawing.Point(169, 63);
            this.SelectCompany.Name = "SelectCompany";
            this.SelectCompany.Size = new System.Drawing.Size(185, 26);
            this.SelectCompany.TabIndex = 18;
            this.SelectCompany.WaterText = "";
            this.SelectCompany.SelectedIndexChanged += new System.EventHandler(this.SelectCompany_SelectedIndexChanged);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.BackColor = System.Drawing.Color.Transparent;
            this.LblCompany.BorderColor = System.Drawing.Color.White;
            this.LblCompany.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblCompany.Location = new System.Drawing.Point(78, 66);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(85, 20);
            this.LblCompany.TabIndex = 17;
            this.LblCompany.Text = "skinLabel2";
            this.LblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbltempName
            // 
            this.LbltempName.AutoSize = true;
            this.LbltempName.BackColor = System.Drawing.Color.Transparent;
            this.LbltempName.BorderColor = System.Drawing.Color.White;
            this.LbltempName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbltempName.Location = new System.Drawing.Point(78, 147);
            this.LbltempName.Name = "LbltempName";
            this.LbltempName.Size = new System.Drawing.Size(85, 20);
            this.LbltempName.TabIndex = 19;
            this.LbltempName.Text = "skinLabel2";
            this.LbltempName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxttempName
            // 
            this.TxttempName.BackColor = System.Drawing.Color.Transparent;
            this.TxttempName.DownBack = null;
            this.TxttempName.Icon = null;
            this.TxttempName.IconIsButton = false;
            this.TxttempName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxttempName.IsPasswordChat = '\0';
            this.TxttempName.IsSystemPasswordChar = false;
            this.TxttempName.Lines = new string[] {
        "skinTextBox1"};
            this.TxttempName.Location = new System.Drawing.Point(169, 142);
            this.TxttempName.Margin = new System.Windows.Forms.Padding(0);
            this.TxttempName.MaxLength = 32767;
            this.TxttempName.MinimumSize = new System.Drawing.Size(28, 28);
            this.TxttempName.MouseBack = null;
            this.TxttempName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxttempName.Multiline = false;
            this.TxttempName.Name = "TxttempName";
            this.TxttempName.NormlBack = null;
            this.TxttempName.Padding = new System.Windows.Forms.Padding(5);
            this.TxttempName.ReadOnly = false;
            this.TxttempName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxttempName.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.TxttempName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxttempName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxttempName.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxttempName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TxttempName.SkinTxt.Name = "BaseText";
            this.TxttempName.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.TxttempName.SkinTxt.TabIndex = 0;
            this.TxttempName.SkinTxt.Text = "skinTextBox1";
            this.TxttempName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxttempName.SkinTxt.WaterText = "";
            this.TxttempName.TabIndex = 20;
            this.TxttempName.Text = "skinTextBox1";
            this.TxttempName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxttempName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxttempName.WaterText = "";
            this.TxttempName.WordWrap = true;
            // 
            // SelectBranch
            // 
            this.SelectBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.SelectBranch.FormattingEnabled = true;
            this.SelectBranch.Location = new System.Drawing.Point(169, 102);
            this.SelectBranch.Name = "SelectBranch";
            this.SelectBranch.Size = new System.Drawing.Size(185, 26);
            this.SelectBranch.TabIndex = 22;
            this.SelectBranch.WaterText = "";
            // 
            // LblBranch
            // 
            this.LblBranch.AutoSize = true;
            this.LblBranch.BackColor = System.Drawing.Color.Transparent;
            this.LblBranch.BorderColor = System.Drawing.Color.White;
            this.LblBranch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblBranch.Location = new System.Drawing.Point(78, 105);
            this.LblBranch.Name = "LblBranch";
            this.LblBranch.Size = new System.Drawing.Size(85, 20);
            this.LblBranch.TabIndex = 21;
            this.LblBranch.Text = "skinLabel2";
            this.LblBranch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_SelectCompany
            // 
            this.Btn_SelectCompany.BackColor = System.Drawing.Color.Transparent;
            this.Btn_SelectCompany.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_SelectCompany.DownBack = null;
            this.Btn_SelectCompany.Location = new System.Drawing.Point(361, 63);
            this.Btn_SelectCompany.MouseBack = null;
            this.Btn_SelectCompany.Name = "Btn_SelectCompany";
            this.Btn_SelectCompany.NormlBack = null;
            this.Btn_SelectCompany.Size = new System.Drawing.Size(86, 26);
            this.Btn_SelectCompany.TabIndex = 23;
            this.Btn_SelectCompany.Text = "skinButton1";
            this.Btn_SelectCompany.UseVisualStyleBackColor = false;
            this.Btn_SelectCompany.Click += new System.EventHandler(this.Btn_SelectCompany_Click);
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 321);
            this.Controls.Add(this.Btn_SelectCompany);
            this.Controls.Add(this.SelectBranch);
            this.Controls.Add(this.LblBranch);
            this.Controls.Add(this.TxttempName);
            this.Controls.Add(this.LbltempName);
            this.Controls.Add(this.SelectCompany);
            this.Controls.Add(this.LblCompany);
            this.Controls.Add(this.Btn_AddComapny);
            this.Controls.Add(this.LblPwd);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtPwd);
            this.Controls.Add(this.TxtName);
            this.Name = "AddCompany";
            this.Text = "Add_Company";
            this.Load += new System.EventHandler(this.Add_Company_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton Btn_AddComapny;
        private CCWin.SkinControl.SkinLabel LblPwd;
        private CCWin.SkinControl.SkinLabel LblName;
        private CCWin.SkinControl.SkinTextBox TxtPwd;
        private CCWin.SkinControl.SkinTextBox TxtName;
        private CCWin.SkinControl.SkinComboBox SelectCompany;
        private CCWin.SkinControl.SkinLabel LblCompany;
        private CCWin.SkinControl.SkinLabel LbltempName;
        private CCWin.SkinControl.SkinTextBox TxttempName;
        private CCWin.SkinControl.SkinComboBox SelectBranch;
        private CCWin.SkinControl.SkinLabel LblBranch;
        private CCWin.SkinControl.SkinButton Btn_SelectCompany;
    }
}