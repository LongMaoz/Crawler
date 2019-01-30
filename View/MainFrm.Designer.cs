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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.GropBox = new CCWin.SkinControl.SkinGroupBox();
            this.LblPullTime = new CCWin.SkinControl.SkinLabel();
            this.LblTime = new CCWin.SkinControl.SkinLabel();
            this.Btn_AddCompany = new CCWin.SkinControl.SkinButton();
            this.Panel = new CCWin.SkinControl.SkinPanel();
            this.DgrView = new CCWin.SkinControl.SkinDataGridView();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CompanyTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoginState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
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
            this.GropBox.Controls.Add(this.LblPullTime);
            this.GropBox.Controls.Add(this.LblTime);
            this.GropBox.Controls.Add(this.Btn_AddCompany);
            this.GropBox.Controls.Add(this.Panel);
            this.GropBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.GropBox.ForeColor = System.Drawing.Color.Crimson;
            this.GropBox.Location = new System.Drawing.Point(7, 35);
            this.GropBox.Name = "GropBox";
            this.GropBox.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.GropBox.RectBackColor = System.Drawing.Color.White;
            this.GropBox.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.GropBox.Size = new System.Drawing.Size(1055, 539);
            this.GropBox.TabIndex = 0;
            this.GropBox.TabStop = false;
            this.GropBox.Text = "skinGroupBox1";
            this.GropBox.TitleBorderColor = System.Drawing.Color.Black;
            this.GropBox.TitleRectBackColor = System.Drawing.Color.White;
            this.GropBox.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // LblPullTime
            // 
            this.LblPullTime.AutoSize = true;
            this.LblPullTime.BackColor = System.Drawing.Color.Transparent;
            this.LblPullTime.BorderColor = System.Drawing.Color.White;
            this.LblPullTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPullTime.Location = new System.Drawing.Point(123, 34);
            this.LblPullTime.Name = "LblPullTime";
            this.LblPullTime.Size = new System.Drawing.Size(39, 20);
            this.LblPullTime.TabIndex = 7;
            this.LblPullTime.Text = "暂无";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.BackColor = System.Drawing.Color.Transparent;
            this.LblTime.BorderColor = System.Drawing.Color.White;
            this.LblTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTime.Location = new System.Drawing.Point(16, 34);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(114, 20);
            this.LblTime.TabIndex = 6;
            this.LblTime.Text = "最后更新时间：";
            // 
            // Btn_AddCompany
            // 
            this.Btn_AddCompany.BackColor = System.Drawing.Color.Transparent;
            this.Btn_AddCompany.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.Btn_AddCompany.DownBack = null;
            this.Btn_AddCompany.ForeColor = System.Drawing.Color.Black;
            this.Btn_AddCompany.Location = new System.Drawing.Point(908, 22);
            this.Btn_AddCompany.MouseBack = null;
            this.Btn_AddCompany.Name = "Btn_AddCompany";
            this.Btn_AddCompany.NormlBack = null;
            this.Btn_AddCompany.Size = new System.Drawing.Size(138, 32);
            this.Btn_AddCompany.TabIndex = 4;
            this.Btn_AddCompany.Text = "skinButton1";
            this.Btn_AddCompany.UseVisualStyleBackColor = false;
            this.Btn_AddCompany.Click += new System.EventHandler(this.Btn_AddCompany_Click);
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgrView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgrView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgrView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Remove,
            this.CompanyTypeName,
            this.CompanyName,
            this.Count,
            this.LoginState});
            this.DgrView.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgrView.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgrView.EnableHeadersVisualStyles = false;
            this.DgrView.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DgrView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.DgrView.HeadFont = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DgrView.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgrView.Location = new System.Drawing.Point(0, 0);
            this.DgrView.Name = "DgrView";
            this.DgrView.ReadOnly = true;
            this.DgrView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgrView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgrView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DgrView.RowTemplate.Height = 23;
            this.DgrView.Size = new System.Drawing.Size(1035, 453);
            this.DgrView.TabIndex = 1;
            this.DgrView.TitleBack = null;
            this.DgrView.TitleBackColorBegin = System.Drawing.Color.White;
            this.DgrView.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.DgrView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgrView_CellClick);
            this.DgrView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgrView_CellFormatting);
            // 
            // Action
            // 
            this.Action.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "登录";
            this.Action.DefaultCellStyle = dataGridViewCellStyle3;
            this.Action.FillWeight = 40F;
            this.Action.HeaderText = "操作";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Text = "登录";
            // 
            // Remove
            // 
            this.Remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.NullValue = "删除";
            this.Remove.DefaultCellStyle = dataGridViewCellStyle4;
            this.Remove.FillWeight = 40F;
            this.Remove.HeaderText = "删除";
            this.Remove.Name = "Remove";
            this.Remove.ReadOnly = true;
            this.Remove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CompanyTypeName
            // 
            this.CompanyTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyTypeName.DataPropertyName = "CompanyTypeName";
            this.CompanyTypeName.HeaderText = "厂商类型";
            this.CompanyTypeName.Name = "CompanyTypeName";
            this.CompanyTypeName.ReadOnly = true;
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "显示名称";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Count
            // 
            this.Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "本次单量";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LoginState
            // 
            this.LoginState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoginState.DataPropertyName = "LoginState";
            dataGridViewCellStyle5.Format = "未登录";
            dataGridViewCellStyle5.NullValue = "false";
            this.LoginState.DefaultCellStyle = dataGridViewCellStyle5;
            this.LoginState.HeaderText = "登录状态";
            this.LoginState.Name = "LoginState";
            this.LoginState.ReadOnly = true;
            this.LoginState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 581);
            this.Controls.Add(this.GropBox);
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.SizeChanged += new System.EventHandler(this.MainFrm_SizeChanged);
            this.GropBox.ResumeLayout(false);
            this.GropBox.PerformLayout();
            this.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgrView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox GropBox;
        private CCWin.SkinControl.SkinPanel Panel;
        private CCWin.SkinControl.SkinDataGridView DgrView;
        private CCWin.SkinControl.SkinButton Btn_AddCompany;
        private System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinLabel LblPullTime;
        private CCWin.SkinControl.SkinLabel LblTime;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginState;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}