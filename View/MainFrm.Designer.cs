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
            this.GropBox = new CCWin.SkinControl.SkinGroupBox();
            this.LblBand = new CCWin.SkinControl.SkinLabel();
            this.GropBox.SuspendLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinGroupBox GropBox;
        private CCWin.SkinControl.SkinLabel LblBand;
    }
}