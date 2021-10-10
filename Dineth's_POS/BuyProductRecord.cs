using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using System.Data.SqlClient;

namespace Dineth_s_POS
{
    public partial class BuyProductRecord : MaterialSkin.Controls.MaterialForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        MaterialSkinManager skinManager;
        ConnectionString cs = new ConnectionString();
        public BuyProductRecord()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();//Select Customer.CustomerFName, Invoice.InvoiceNo, Invoice.InvoiceDate, BuyProduct.ProductName, BuyProduct.Bundle,BuyProduct.Weight, BuyProduct.SubTotal from Invoice Inner join Customer On Invoice.CustomerContactNo = Customer.CustomerContactNo Inner join BuyProduct ON BuyProduct.InvoiceNo = Invoice.InvoiceNo
                String sql = "SELECT RTRIM(Customer.CustomerContactNo), RTRIM(Customer.CustomerFName),RTRIM(Invoice.InvoiceNo),RTRIM(Invoice.InvoiceDate),RTRIM(BuyProduct.ProductName),RTRIM(BuyProduct.Bundle),RTRIM(BuyProduct.Weight),RTRIM(BuyProduct.SubTotal) from Invoice Inner join Customer On Invoice.CustomerContactNo = Customer.CustomerContactNo Inner join BuyProduct ON BuyProduct.InvoiceNo = Invoice.InvoiceNo order by ProductName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuyProductRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();//Select Customer.CustomerFName, Invoice.InvoiceNo, Invoice.InvoiceDate, BuyProduct.ProductName, BuyProduct.Bundle,BuyProduct.Weight, BuyProduct.SubTotal from Invoice Inner join Customer On Invoice.CustomerContactNo = Customer.CustomerContactNo Inner join BuyProduct ON BuyProduct.InvoiceNo = Invoice.InvoiceNo
                String sql = "SELECT RTRIM(Customer.CustomerContactNo), RTRIM(Customer.CustomerFName),RTRIM(Invoice.InvoiceNo),RTRIM(Invoice.InvoiceDate),RTRIM(BuyProduct.ProductName),RTRIM(BuyProduct.Bundle),RTRIM(BuyProduct.Weight),RTRIM(BuyProduct.SubTotal) from Invoice Inner join Customer On Invoice.CustomerContactNo = Customer.CustomerContactNo Inner join BuyProduct ON BuyProduct.InvoiceNo = Invoice.InvoiceNo where Customer.CustomerContactNo like '" + txtContactNo.Text + "%'   order by ProductName";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();//Select Customer.CustomerFName, Invoice.InvoiceNo, Invoice.InvoiceDate, BuyProduct.ProductName, BuyProduct.Bundle,BuyProduct.Weight, BuyProduct.SubTotal from Invoice Inner join Customer On Invoice.CustomerContactNo = Customer.CustomerContactNo Inner join BuyProduct ON BuyProduct.InvoiceNo = Invoice.InvoiceNo
                String sql = "SELECT RTRIM(Customer.CustomerContactNo), RTRIM(Customer.CustomerFName),RTRIM(Invoice.InvoiceNo),RTRIM(Invoice.InvoiceDate),RTRIM(BuyProduct.ProductName),RTRIM(BuyProduct.Bundle),RTRIM(BuyProduct.Weight),RTRIM(BuyProduct.SubTotal) from Invoice Inner join Customer On Invoice.CustomerContactNo = Customer.CustomerContactNo Inner join BuyProduct ON BuyProduct.InvoiceNo = Invoice.InvoiceNo where Invoice.InvoiceDate between @d1 and @d2 order by ProductName";
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "StockDate").Value = dtpStockDateFrom.Value.Date;
                cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "StockDate").Value = dtpStockDateTo.Value.Date;
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                bunifuCustomDataGrid1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    bunifuCustomDataGrid1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7]);
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

