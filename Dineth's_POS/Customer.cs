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
using System.Security.Cryptography;

namespace Dineth_s_POS
{
    public partial class Customer : MaterialSkin.Controls.MaterialForm
    {
        MaterialSkinManager skinManager;
        SqlConnection con = null;
        SqlDataReader rdr = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public Customer()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green900, Primary.Green900, Accent.LightBlue200, TextShade.WHITE);
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(CustomerContactNo),RTRIM(CustomerFName) ,RTRIM(CustomerLName),RTRIM(AddressL1) ,RTRIM(AddressL2) from Customer order by CustomerFName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.RowCount - 1].Tag = rdr;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Customer_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void bunifuCustomDataGrid1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (bunifuCustomDataGrid1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                bunifuCustomDataGrid1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));

        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 )//update
            {
                try
                {

                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    DataGridViewRow dgvrow = bunifuCustomDataGrid1.CurrentRow;
                    string cb = "update Customer set Customer.CustomerFName=@d2,Customer.CustomerLName=@d3,Customer.addressL1=@d4,Customer.addressL2=@d5 FROM Customer where CustomerContactNo=@d1";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@d1", 0);
                    cmd.Parameters.AddWithValue("@d2", 1);
                    cmd.Parameters.AddWithValue("@d3", 2);
                    cmd.Parameters.AddWithValue("@d4", 3);
                    cmd.Parameters.AddWithValue("@d5", 4);
                    cmd.ExecuteReader();
                    MessageBox.Show("Successfully updated", "Customer Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuCustomDataGrid1.Refresh();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (e.ColumnIndex == 6)// delete
            {
                 try
                 {


                     if (MessageBox.Show("Do you really want to delete the record?", "Customer Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                     {
                         try
                         {

                             int RowsAffected = 0;
                             con = new SqlConnection(cs.DBcon);
                             con.Open();
                             string cq = "delete from Customer where CustomerContactNo=@d1";
                              cmd.Parameters.AddWithValue("@d1", 0);
                             cmd = new SqlCommand(cq);
                             cmd.Connection = con;

                             RowsAffected = cmd.ExecuteNonQuery();

                             if (RowsAffected > 0)
                             {
                                 MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bunifuCustomDataGrid1.Refresh();
                            }
                             else
                             {
                                 MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 
                             }
                             con.Close();

                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                     }

                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
            }
        }

        private void txtCustomers_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(CustomerContactNo),RTRIM(CustomerFName) ,RTRIM(CustomerLName),RTRIM(AddressL1) ,RTRIM(AddressL2) from Customer where CustomerFName like '" + txtCustomers.Text + "%' order by CustomerFName", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4]);
                }
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.RowCount - 1].Tag = rdr;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuCustomDataGrid1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.reload.Width;
                var h = Properties.Resources.reload.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.reload.Width;
                var h = Properties.Resources.reload.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.icon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
    }
}
