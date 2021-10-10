using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MaterialSkin;

namespace Dineth_s_POS
{
    public partial class RecoveryPassword : MaterialSkin.Controls.MaterialForm
    {
        MaterialSkinManager skinManager;
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public RecoveryPassword()
        {
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.LightBlue200, TextShade.WHITE);
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
