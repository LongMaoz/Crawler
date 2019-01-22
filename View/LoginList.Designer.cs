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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Btn_AddAccount = new CCWin.SkinControl.SkinButton();
            this.Dgv_Account = new CCWin.SkinControl.SkinDataGridView();
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
            this.Dgv_Account.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Account.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_Account.EnableHeadersVisualStyles = false;
            this.Dgv_Account.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Dgv_Account.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv_Account.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.Dgv_Account.Location = new System.Drawing.Point(7, 83);
            this.Dgv_Account.Name = "Dgv_Account";
            this.Dgv_Account.ReadOnly = true;
            this.Dgv_Account.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Account.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.Dgv_Account.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv_Account.RowTemplate.Height = 23;
            this.Dgv_Account.Size = new System.Drawing.Size(786, 360);
            this.Dgv_Account.TabIndex = 2;
            this.Dgv_Account.TitleBack = null;
            this.Dgv_Account.TitleBackColorBegin = System.Drawing.Color.White;
            this.Dgv_Account.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // LoginList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}