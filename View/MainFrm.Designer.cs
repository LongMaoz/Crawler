namespace WindowsFormsApp1.View
{
    partial class MainFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GropBox = new CCWin.SkinControl.SkinGroupBox();
            this.Panel = new CCWin.SkinControl.SkinPanel();
            this.DgrView = new CCWin.SkinControl.SkinDataGridView();
            this.LblBand = new CCWin.SkinControl.SkinLabel();
            this.TaskCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GropBox.SuspendLayout();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgrView)).BeginInit();
            this.SuspendLayout();
            // 
            // GropBox
            // 
            this.GropBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GropBox.AutoSize = true;
            this.GropBox.BackColor = System.Drawing.Color.Transparent;
            this.GropBox.BorderColor = System.Drawing.Color.Black;
            this.GropBox.Controls.Add(this.Panel);
            this.GropBox.Controls.Add(this.LblBand);
            this.GropBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GropBox.ForeColor = System.Drawing.Color.Crimson;
            this.GropBox.Location = new System.Drawing.Point(7, 35);
            this.GropBox.Name = "GropBox";
            this.GropBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.GropBox.RectBackColor = System.Drawing.Color.White;
            this.GropBox.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.GropBox.Size = new System.Drawing.Size(1055, 541);
            this.GropBox.TabIndex = 0;
            this.GropBox.TabStop = false;
            this.GropBox.Text = "skinGroupBox1";
            this.GropBox.TitleBorderColor = System.Drawing.Color.Black;
            this.GropBox.TitleRectBackColor = System.Drawing.Color.White;
            this.GropBox.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.Transparent;
            this.Panel.Controls.Add(this.DgrView);
            this.Panel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Panel.DownBack = null;
            this.Panel.Location = new System.Drawing.Point(11, 60);
            this.Panel.MouseBack = null;
            this.Panel.Name = "Panel";
            this.Panel.NormlBack = null;
            this.Panel.Size = new System.Drawing.Size(1035, 453);
            this.Panel.TabIndex = 2;
            // 
            // DgrView
            // 
            this.DgrView.AllowUserToAddRows = false;
            this.DgrView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.DgrView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgrView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgrView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgrView.ColumnFont = null;
            this.DgrView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgrView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgrView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgrView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskCompany,
            this.CompanyName,
            this.LoginState,
            this.Count,
            this.Action});
            this.DgrView.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgrView.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgrView.EnableHeadersVisualStyles = false;
            this.DgrView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DgrView.HeadFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DgrView.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgrView.Location = new System.Drawing.Point(0, 0);
            this.DgrView.Name = "DgrView";
            this.DgrView.ReadOnly = true;
            this.DgrView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgrView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgrView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgrView.RowTemplate.Height = 23;
            this.DgrView.Size = new System.Drawing.Size(1035, 453);
            this.DgrView.TabIndex = 1;
            this.DgrView.TitleBack = null;
            this.DgrView.TitleBackColorBegin = System.Drawing.Color.White;
            this.DgrView.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.DgrView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgrView_CellClick);
            // 
            // LblBand
            // 
            this.LblBand.AutoSize = true;
            this.LblBand.BackColor = System.Drawing.Color.Transparent;
            this.LblBand.BorderColor = System.Drawing.Color.White;
            this.LblBand.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblBand.ForeColor = System.Drawing.Color.Black;
            this.LblBand.Location = new System.Drawing.Point(6, 30);
            this.LblBand.Name = "LblBand";
            this.LblBand.Size = new System.Drawing.Size(70, 27);
            this.LblBand.TabIndex = 1;
            this.LblBand.Text = "Demo";
            // 
            // TaskCompany
            // 
            this.TaskCompany.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TaskCompany.DataPropertyName = "TaskCompany";
            this.TaskCompany.HeaderText = "厂商类型";
            this.TaskCompany.Name = "TaskCompany";
            this.TaskCompany.ReadOnly = true;
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "显示名称";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // LoginState
            // 
            this.LoginState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoginState.DataPropertyName = "LoginState";
            this.LoginState.HeaderText = "登录状态";
            this.LoginState.Name = "LoginState";
            this.LoginState.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "今日单量";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "停止获取";
            this.Action.DefaultCellStyle = dataGridViewCellStyle3;
            this.Action.HeaderText = "操作";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Text = "测试";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 583);
            this.Controls.Add(this.GropBox);
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.GropBox.ResumeLayout(false);
            this.GropBox.PerformLayout();
            this.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgrView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox GropBox;
        private CCWin.SkinControl.SkinLabel LblBand;
        private CCWin.SkinControl.SkinPanel Panel;
        private CCWin.SkinControl.SkinDataGridView DgrView;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}