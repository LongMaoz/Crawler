namespace WindowsFormsApp1.View
{
    partial class LoginList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_AddAccount = new CCWin.SkinControl.SkinButton();
            this.Dgv_Account = new CCWin.SkinControl.SkinDataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnLogin = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Btn_AllRemove = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Account)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_AddAccount
            // 
            this.Btn_AddAccount.BackColor = System.Drawing.Color.Transparent;
            this.Btn_AddAccount.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_AddAccount.DownBack = null;
            this.Btn_AddAccount.Location = new System.Drawing.Point(681, 43);
            this.Btn_AddAccount.MouseBack = null;
            this.Btn_AddAccount.Name = "Btn_AddAccount";
            this.Btn_AddAccount.NormlBack = null;
            this.Btn_AddAccount.Size = new System.Drawing.Size(112, 34);
            this.Btn_AddAccount.TabIndex = 1;
            this.Btn_AddAccount.Text = "skinButton1";
            this.Btn_AddAccount.UseVisualStyleBackColor = false;
            this.Btn_AddAccount.Click += new System.EventHandler(this.Btn_AddAccount_Click);
            // 
            // Dgv_Account
            // 
            this.Dgv_Account.AllowUserToAddRows = false;
            this.Dgv_Account.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Dgv_Account.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Account.BackgroundColor = System.Drawing.SystemColors.Window;
            this.Dgv_Account.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_Account.ColumnFont = null;
            this.Dgv_Account.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Account.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Account.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Account.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.UserType,
            this.UserPwd,
            this.BtnLogin,
            this.BtnRemove});
            this.Dgv_Account.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Account.DefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_Account.EnableHeadersVisualStyles = false;
            this.Dgv_Account.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Dgv_Account.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Account.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.Dgv_Account.Location = new System.Drawing.Point(7, 83);
            this.Dgv_Account.Name = "Dgv_Account";
            this.Dgv_Account.ReadOnly = true;
            this.Dgv_Account.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Account.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Dgv_Account.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_Account.RowTemplate.Height = 23;
            this.Dgv_Account.Size = new System.Drawing.Size(786, 360);
            this.Dgv_Account.TabIndex = 2;
            this.Dgv_Account.TitleBack = null;
            this.Dgv_Account.TitleBackColorBegin = System.Drawing.Color.White;
            this.Dgv_Account.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.Dgv_Account.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Account_CellContentClick);
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "账号";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserType
            // 
            this.UserType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserType.DataPropertyName = "UserType";
            this.UserType.HeaderText = "账号类型";
            this.UserType.Name = "UserType";
            this.UserType.ReadOnly = true;
            this.UserType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UserPwd
            // 
            this.UserPwd.DataPropertyName = "UserPwd";
            this.UserPwd.HeaderText = "密码";
            this.UserPwd.Name = "UserPwd";
            this.UserPwd.ReadOnly = true;
            this.UserPwd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UserPwd.Visible = false;
            // 
            // BtnLogin
            // 
            this.BtnLogin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "登录";
            this.BtnLogin.DefaultCellStyle = dataGridViewCellStyle3;
            this.BtnLogin.FillWeight = 30F;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnLogin.HeaderText = "登录";
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.ReadOnly = true;
            this.BtnLogin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BtnRemove
            // 
            this.BtnRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "删除";
            this.BtnRemove.DefaultCellStyle = dataGridViewCellStyle4;
            this.BtnRemove.FillWeight = 30F;
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnRemove.HeaderText = "删除";
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.ReadOnly = true;
            this.BtnRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Btn_AllRemove
            // 
            this.Btn_AllRemove.BackColor = System.Drawing.Color.Transparent;
            this.Btn_AllRemove.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_AllRemove.DownBack = null;
            this.Btn_AllRemove.Location = new System.Drawing.Point(7, 43);
            this.Btn_AllRemove.MouseBack = null;
            this.Btn_AllRemove.Name = "Btn_AllRemove";
            this.Btn_AllRemove.NormlBack = null;
            this.Btn_AllRemove.Size = new System.Drawing.Size(112, 34);
            this.Btn_AllRemove.TabIndex = 3;
            this.Btn_AllRemove.Text = "skinButton1";
            this.Btn_AllRemove.UseVisualStyleBackColor = false;
            this.Btn_AllRemove.Click += new System.EventHandler(this.Btn_AllRemove_Click);
            // 
            // LoginList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_AllRemove);
            this.Controls.Add(this.Dgv_Account);
            this.Controls.Add(this.Btn_AddAccount);
            this.Name = "LoginList";
            this.Text = "LoginList";
            this.Load += new System.EventHandler(this.LoginList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Account)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinButton Btn_AddAccount;
        private CCWin.SkinControl.SkinDataGridView Dgv_Account;
        private CCWin.SkinControl.SkinButton Btn_AllRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPwd;
        private System.Windows.Forms.DataGridViewButtonColumn BtnLogin;
        private System.Windows.Forms.DataGridViewButtonColumn BtnRemove;
    }
}