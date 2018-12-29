namespace WindowsFormsApp1.View
{
    partial class Code
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
            this.LblCode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.skinTextBox1 = new CCWin.SkinControl.SkinTextBox();
            this.BtnOk = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // LblCode
            // 
            this.LblCode.AutoSize = true;
            this.LblCode.Location = new System.Drawing.Point(71, 139);
            this.LblCode.Name = "LblCode";
            this.LblCode.Size = new System.Drawing.Size(63, 15);
            this.LblCode.TabIndex = 0;
            this.LblCode.Text = "label1:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(74, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 53);
            this.panel1.TabIndex = 1;
            // 
            // skinTextBox1
            // 
            this.skinTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinTextBox1.DownBack = null;
            this.skinTextBox1.Icon = null;
            this.skinTextBox1.IconIsButton = false;
            this.skinTextBox1.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.IsPasswordChat = '\0';
            this.skinTextBox1.IsSystemPasswordChar = false;
            this.skinTextBox1.Lines = new string[] {
        "skinTextBox1"};
            this.skinTextBox1.Location = new System.Drawing.Point(137, 126);
            this.skinTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTextBox1.MaxLength = 32767;
            this.skinTextBox1.MinimumSize = new System.Drawing.Size(28, 28);
            this.skinTextBox1.MouseBack = null;
            this.skinTextBox1.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.skinTextBox1.Multiline = false;
            this.skinTextBox1.Name = "skinTextBox1";
            this.skinTextBox1.NormlBack = null;
            this.skinTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.skinTextBox1.ReadOnly = false;
            this.skinTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.skinTextBox1.Size = new System.Drawing.Size(185, 28);
            // 
            // 
            // 
            this.skinTextBox1.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skinTextBox1.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTextBox1.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.skinTextBox1.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.skinTextBox1.SkinTxt.Name = "BaseText";
            this.skinTextBox1.SkinTxt.Size = new System.Drawing.Size(175, 22);
            this.skinTextBox1.SkinTxt.TabIndex = 0;
            this.skinTextBox1.SkinTxt.Text = "skinTextBox1";
            this.skinTextBox1.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.SkinTxt.WaterText = "";
            this.skinTextBox1.TabIndex = 2;
            this.skinTextBox1.Text = "skinTextBox1";
            this.skinTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.skinTextBox1.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.skinTextBox1.WaterText = "";
            this.skinTextBox1.WordWrap = true;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.Transparent;
            this.BtnOk.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BtnOk.DownBack = null;
            this.BtnOk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnOk.Location = new System.Drawing.Point(325, 126);
            this.BtnOk.MouseBack = null;
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.NormlBack = null;
            this.BtnOk.Size = new System.Drawing.Size(80, 28);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "skinButton1";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // Code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 192);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.skinTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Code";
            this.Text = "Code";
            this.Load += new System.EventHandler(this.Code_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblCode;
        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinTextBox skinTextBox1;
        private CCWin.SkinControl.SkinButton BtnOk;
    }
}