using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyTaskClass.Company;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using CCWin;
using CCWin.SkinControl;
using CompanyTaskClass.Model;

namespace WindowsFormsApp1.View
{
    public partial class CompanyListFrm : Skin_Mac, IFrom
    {
        private int LocationX = 20;

        private int LocationY = -10;

        private int BtnWidth = 100;

        private int BtnHeight = 50;

        public CompanyListFrm() => InitializeComponent();

        private class CompanyList
        {
            public int Type { get; set; }
            public string Name { get; set; }

            //分支
            public bool Branch { get; set; }
        }
        public void Initialize()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.BandCompanyList();
        }

        private void CompanyList_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void BandCompanyList()
        {
            var arr = new List<CompanyList>()
            {
                new CompanyList() {Name = "海信", Type = 4, Branch = false},
                new CompanyList() {Name = "奇帅", Type = 18, Branch = false},
                new CompanyList() {Name = "京东", Type = 25, Branch = true},
                new CompanyList() {Name = "国美电器", Type = 35, Branch = false},
                new CompanyList() {Name = "康宝", Type = 45, Branch = false},
                new CompanyList() {Name = "三棱", Type = 40, Branch = false},
                new CompanyList() {Name = "星星", Type = 50, Branch = false},
                new CompanyList() {Name = "国美管家", Type = 56, Branch = false}
            };
            for (int i = 0; i < arr.Count; i++)
            {
                if (i % 5 == 0)
                {
                    LocationX = 20;
                    LocationY += 55;
                }
                var btn = new SkinButton()
                {
                    Width = BtnWidth,
                    Height = BtnHeight,
                    Text = arr[i].Name,
                    Left = LocationX,
                    Top = LocationY
                };
                this.Controls.Add(btn);
                LocationX += BtnWidth + 10;
            }
        }
    }
}
