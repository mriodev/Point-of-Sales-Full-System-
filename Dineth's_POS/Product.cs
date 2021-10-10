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
    public partial class Product : MaterialSkin.Controls.MaterialForm
    {
        SqlDataReader rdr = null;
        SqlConnection con = null;
        SqlCommand cmd = null;
        ConnectionString cs = new ConnectionString();
        public Product()
        {
            InitializeComponent();
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(PID),RTRIM(ProductName),RTRIM(ProductType),RTRIM(UnitPrice) from Product order by Productname", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void bunifuCustomDataGrid1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.reload.Width;
                var h = Properties.Resources.reload.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 4)
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

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)//update
            {
                try
                {

                     con = new SqlConnection(cs.DBcon);
                     con.Open();
                     DataGridViewRow dgvrow = bunifuCustomDataGrid1.CurrentRow;
                     string cb = "update Product set Product.ProductName=@d2,Product.ProductType=@d3,Product.UnitPrice=@d4 FROM Product where PID=@d1";
                     cmd = new SqlCommand(cb);
                     cmd.Connection = con;
                     cmd.Parameters.AddWithValue("@d1", 0.ToString());
                     cmd.Parameters.AddWithValue("@d2", 1);
                     cmd.Parameters.AddWithValue("@d3", 2);
                     cmd.Parameters.AddWithValue("@d4", 3);
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
            if (e.ColumnIndex == 5)// delete
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
                            string cq = "delete from Product where PID=@d1";
                            cmd = new SqlCommand(cq);
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@d1", 0);
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

        private void txtProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(PID),RTRIM(ProductName),RTRIM(ProductType),RTRIM(UnitPrice) from Product where ProductName like '" + txtProduct.Text + "%' order by Productname", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

