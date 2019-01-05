using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class WebFrm : Skin_Mac, IFrom
    {
        public WebFrm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        private void WebFrm_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("http://www.baidu.com");
        }
    }
}
