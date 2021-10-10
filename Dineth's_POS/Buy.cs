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
using System.Drawing.Printing;

namespace Dineth_s_POS
{
    public partial class Buy : MaterialSkin.Controls.MaterialForm
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        MaterialSkinManager skinManager;
        ConnectionString cs = new ConnectionString();

        public object ToolStripStatusLabel4 { get; private set; }

        public Buy()
        {
            InitializeComponent();
            skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey400, Primary.Green600,
                Primary.Blue500, Accent.LightGreen700,
                TextShade.WHITE
            );

        }
        
      
        private void auto()
        {
            txtInvoiceNo.Text = "IN-" + GetUniqueKey(8);

        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars = "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        
            private void Form1_Load(object sender, EventArgs e)
        {
           
            if (String.IsNullOrEmpty(txtwet.Text))
            {
                txtwet.Text = "0";
            }
        }

       


       
        /*  String.Format("{#,##0.00}", 1243.50); // Outputs “1,243.50″

     String.Format("{0:$#,##0.00;($#,##0.00);Zero}", 1243.50); // Outputs “$1,243.50″ 

     String.Format("{0:$#,##0.00;($#,##0.00);Zero}", -1243.50); // Outputs “($1,243.50)″ 

     String.Format("{0:$#,##0.00;($#,##0.00);Zero}", 0); // Outputs “Zero″ 
         */

        public double subtot()
        {
            int i = 0;
            double j = 0;
            double k = 0;
            i = 0;
            j = 0;
            k = 0;


            try
            {

                j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToDouble(ListView1.Items[i].SubItems[8].Text);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            try {
               if (txtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please Enter Customer Phone No", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }

                if (txtCustomerFName.Text == "" && txtCustomerLName.Text == "")
                {
                    MessageBox.Show("Please Enter Customer Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCustomerFName.Focus();
                    return;
                }
                if (txtAd1.Text == "" && txtAd2.Text == "")
                {
                    MessageBox.Show("Please Enter Customer Address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAd1.Focus();
                    return;
                }

                if (txtProductName.Text == "")
                {
                    MessageBox.Show("Please retrieve product name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProductName.Focus();
                    return;
                }
                int SaleQty = Convert.ToInt32(txtQty.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("no. of sale quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtQty.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
            {

                ListViewItem lst = new ListViewItem();
                lst.SubItems.Add(txtProductID.Text);
                lst.SubItems.Add(txtProductName.Text);
                lst.SubItems.Add(txtPrice.Text);
                lst.SubItems.Add(txtBundle.Text);
                lst.SubItems.Add(txtwet.Text);
                lst.SubItems.Add(txtnetweigth.Text);
                lst.SubItems.Add(txtTarAmt.Text);
                lst.SubItems.Add(txtTotalAmount.Text);
                ListView1.Items.Add(lst);
                txtSubTotal.Text = subtot().ToString("#,##0.00");
                txtProductName.Text = "";
                txtProductID.Text = "";
                txtPrice.Text = "";
                txtBundle.Text = "";
                txtwet.Text = "";
                txtnetweigth.Text = "";
                txtTotalAmount.Text = "";
                txtTarAmt.Text = "";
                txtTotalAmount.Text = "";
                    txtQty.Text = "";
                    return;
            }

            for (int j = 0; j <= ListView1.Items.Count - 1; j++)
            {
                if (ListView1.Items[j].SubItems[1].Text == txtProductID.Text)
                {
                    ListView1.Items[j].SubItems[1].Text = txtProductID.Text;
                    ListView1.Items[j].SubItems[2].Text = txtProductName.Text;
                    ListView1.Items[j].SubItems[3].Text = txtPrice.Text;
                    ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[6].Text) + Convert.ToInt32(txtBundle.Text)).ToString();
                    ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[6].Text) + Convert.ToInt32(txtwet.Text)).ToString();
                    ListView1.Items[j].SubItems[6].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[6].Text) + Convert.ToInt32(txtnetweigth.Text)).ToString();
                    ListView1.Items[j].SubItems[7].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[7].Text) + Convert.ToInt32(txtTarAmt.Text)).ToString();
                    ListView1.Items[j].SubItems[8].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[8].Text) + Convert.ToInt32(txtTotalAmount.Text)).ToString();
                    txtSubTotal.Text = subtot().ToString("#,##0.00");
                   
                        txtProductName.Text = "";
                        txtProductID.Text = "";
                        txtPrice.Text = "";
                        txtBundle.Text = "";
                        txtwet.Text = "";
                        txtnetweigth.Text = "";
                        txtTotalAmount.Text = "";
                        txtTarAmt.Text = "";
                        txtTotalAmount.Text = "";
                        txtQty.Text = "";
                        return;

                }
            }

            ListViewItem lst1 = new ListViewItem();

            lst1.SubItems.Add(txtProductID.Text);
            lst1.SubItems.Add(txtProductName.Text);
            lst1.SubItems.Add(txtPrice.Text);
            lst1.SubItems.Add(txtBundle.Text);
            lst1.SubItems.Add(txtwet.Text);
            lst1.SubItems.Add(txtnetweigth.Text);
            lst1.SubItems.Add(txtTarAmt.Text);
            lst1.SubItems.Add(txtTotalAmount.Text);
            ListView1.Items.Add(lst1);
            txtSubTotal.Text = subtot().ToString("#,##0.00");
                txtProductName.Text = "";
                txtProductID.Text = "";
                txtPrice.Text = "";
                txtBundle.Text = "";
                txtwet.Text = "";
                txtnetweigth.Text = "";
                txtTotalAmount.Text = "";
                txtTarAmt.Text = "";
                txtTotalAmount.Text = "";
                txtQty.Text = "";
                return;

                //auto();
                //con = new SqlConnection(cs.DBcon);
                //con.Open();

                //string cb = "insert Into Invoice(InvoiceNo,InvoiceDate,CustomerContactNo,GrandTotal,PaymentType) VALUES ('" + txtInvoiceNo.Text + "','" + dtpInvoiceDate.Text + "','" + txtPhoneNo.Text + "'," + txtSubTotal.Text + ",'" + cmbPaymentType.Text + "')";
                //cmd = new SqlCommand(cb);
                //cmd.Connection = con;
                //cmd.ExecuteReader();
                //if (con.State == ConnectionState.Open)
                //{
                //    con.Close();
                //}
                //con.Close();


            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

       

        private void txtwet_TextChanged(object sender, EventArgs e)
        {
           

            if (tabControl1.SelectedTab == tabPage3)
            {
                chipscal();
            }
            else {
                wetcal();
            }
        }

        public void wetcal() {
            double qty = 0;
            double wet = 0;
            double totqty = 0;

            double.TryParse(txtQty.Text, out qty);
            double.TryParse(txtwet.Text, out wet);//txtqtyamount

            totqty = qty - wet;
           // txtqtyamount.Text = totqty.ToString();
            try
            {
                if (string.IsNullOrEmpty(txtTarPer.Text))
                {
                    txtTarAmt.Text = "";
                    txtTotalAmount.Text = "";
                    return;
                }
                if (txtTarPer.Text != "")
                {
                    double round = Math.Ceiling((Convert.ToDouble((Convert.ToDouble(totqty) / 100) * Convert.ToDouble(txtTarPer.Text))));

                    txtTarAmt.Text = round.ToString();
                }
                double tarweight = 0;
                double netweight = 0;
                double price = 0;
                double tAmount = 0;
                double.TryParse(txtTarAmt.Text, out tarweight);
                netweight = totqty - tarweight;
                txtnetweigth.Text = netweight.ToString();

                double.TryParse(txtPrice.Text, out price);
                tAmount = price * netweight;
                txtTotalAmount.Text = tAmount.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
      /*  public void Calculate()
        {
            if (txtTarPer.Text != "")
            {
                decimal round = Math.Ceiling((Convert.ToDecimal((Convert.ToDecimal(txtqtyamount.Text) / 100) * Convert.ToDecimal(txtTarPer.Text))));

                txtTarAmt.Text = round.ToString();
            }



            double val1 = 0;
            double val2 = 0;
            double val3 = 0;
            double val4 = 0;
            double val5 = 0;
            double val6 = 0;
            double.TryParse(txtqtyamount.Text, out val1);
            double.TryParse(txtTarAmt.Text, out val2);
            val3 = val1 - val2;
            txtnetweigth.Text = val3.ToString();

            double.TryParse(txtPrice.Text, out val4);
            double.TryParse(txtnetweigth.Text, out val5);
            val6 = val4 * val5;
            txtTotalAmount.Text = val6.ToString("#,##0.00");

        }
        */
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            try
            {
                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    ListView1.FocusedItem.Remove();
                    itmCnt = ListView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                }
                btnRemove.Enabled = false;

                if (ListView1.Items.Count == 0)
                {
                    txtSubTotal.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = true;
        }

        public void pcrear() {

            txtQty.Text = "";
            txtBundle.Text = "";
            txtwet.Text = "0";


        }

        public void clear() {

            ListView1.Items.Clear();
            ListView1.Refresh();
            txtSubTotal.Text = "";
            cmbPay.Text = "";
            txtInvoiceNo.Text = "";
            txtPhoneNo.Text = "";
            txtCustomerFName.Text = "";
            txtCustomerLName.Text = "";
            txtAd1.Text = "";
            txtAd2.Text = "";

        }
        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void customer() {

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select CustomerContactNo from Customer where CustomerContactNo='" + txtPhoneNo.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {


                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();

                string sql = "insert into Customer(CustomerContactNo,CustomerFName,CustomerLName,AddressL1,AddressL2) VALUES (@d1,@d2,@d3,@d4,@d5)";

                cmd = new SqlCommand(sql);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtPhoneNo.Text);
                cmd.Parameters.AddWithValue("@d2", txtCustomerFName.Text);
                cmd.Parameters.AddWithValue("@d3", txtCustomerLName.Text);
                cmd.Parameters.AddWithValue("@d4", txtAd1.Text);
                cmd.Parameters.AddWithValue("@d5", txtAd2.Text);
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            try {
                if (cmbPay.Text == "")
                {
                    MessageBox.Show("Please Select Payment Type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbPay.Focus();
                    return;
                }

               
                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("sorry no product added", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                auto();
                customer();

               
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string cb = "insert Into Invoice(InvoiceNo,InvoiceDate,TotalAmount,PayBy,CheckNo,CustomerContactNo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)";
                    cmd = new SqlCommand(cb);
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("d1", txtInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("d2", dtpInvoiceDate.Text);
                    cmd.Parameters.AddWithValue("d3", txtSubTotal.Text);
                    cmd.Parameters.AddWithValue("d4", cmbPay.Text);
                    cmd.Parameters.AddWithValue("d5", txtCheck.Text);
                    cmd.Parameters.AddWithValue("d6", txtPhoneNo.Text);
                    
                    cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();


                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
            {
                con = new SqlConnection(cs.DBcon);

                string cd = "insert Into BuyProduct(InvoiceNo,PID,ProductName,UnitPrice,Bundle,Wet,Weight,TarAmount,SubTotal) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9)";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("d1", txtInvoiceNo.Text);
                cmd.Parameters.AddWithValue("d2", ListView1.Items[i].SubItems[1].Text);
                cmd.Parameters.AddWithValue("d3", ListView1.Items[i].SubItems[2].Text);
                cmd.Parameters.AddWithValue("d4", ListView1.Items[i].SubItems[3].Text);
                cmd.Parameters.AddWithValue("d5", ListView1.Items[i].SubItems[4].Text);
                cmd.Parameters.AddWithValue("d6", ListView1.Items[i].SubItems[5].Text);
                cmd.Parameters.AddWithValue("d7", ListView1.Items[i].SubItems[6].Text);
                cmd.Parameters.AddWithValue("d8", ListView1.Items[i].SubItems[7].Text);
                cmd.Parameters.AddWithValue("d9", ListView1.Items[i].SubItems[8].Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            for (int i = 0; i <= ListView1.Items.Count - 1; i++)
            {
                        con = new SqlConnection(cs.DBcon);
                        con.Open();
                        string cb1 = "IF EXISTS(select PID from temp_Stock where PID='" + ListView1.Items[i].SubItems[1].Text + "')BEGIN update Temp_Stock set Weight = Weight + " + ListView1.Items[i].SubItems[6].Text + " where PID= '" + ListView1.Items[i].SubItems[1].Text + "' END ELSE BEGIN insert into Temp_Stock(PID,Weight) VALUES ('" + ListView1.Items[i].SubItems[1].Text + "'," + ListView1.Items[i].SubItems[6].Text + ") END";
                        cmd = new SqlCommand(cb1);
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                        con.Close();
                }

                btnpay.Enabled = false;
               // btnsuspend.Enabled = false;
                btnRemove.Enabled = false;
                btnPrint.Enabled = true;
            MessageBox.Show("Successfully Pay", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

       /* public DataSet Invoice_Product()
        {
            ConnectionString cs = new ConnectionString();

            SqlConnection con = null;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            SqlCommand com = new SqlCommand("Sp_InvoiceProduct_Invoiceno", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }*/

       
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                timer1.Enabled = true;
                TestInvoice rpt = new TestInvoice();
                //The report you created.
                cmd = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                var myDS = new POS_DBDataSet();
                //The DataSet you created.
                con = new SqlConnection(cs.DBcon);//BuyProduct.PID=Product.PID and
                cmd.Connection = con;
                //cmd.CommandText = "SELECT distinct * from Invoice,BuyProduct,Customer where Invoice.InvoiceNo=BuyProduct.InvoiceNo and Invoice.CustomerContactNo = Customer.CustomerContactNo and Invoice.InvoiceNo='" + txtInvoiceNo.Text + "' ";
                cmd.CommandText = "Select Invoice.InvoiceNo, Invoice.InvoiceDate,Invoice.PayBy,Invoice.TotalAmount,BuyProduct.PID, BuyProduct.ProductName,BuyProduct.UnitPrice,BuyProduct.Bundle,BuyProduct.Weight,BuyProduct.Wet,BuyProduct.SubTotal,Customer.CustomerContactNo,Customer.CustomerFName from Invoice  inner join buyproduct ON buyproduct.invoiceno = invoice.invoiceno inner join customer on invoice.customercontactno = customer.customercontactno Where Invoice.InvoiceNo='" + txtInvoiceNo.Text + "'";
                cmd.CommandType = CommandType.Text;
                myDA.SelectCommand = cmd;
                //myDA.Fill(myDS, "Product");
                myDA.Fill(myDS, "Invoice");
                myDA.Fill(myDS, "BuyProduct");
                myDA.Fill(myDS, "Customer");
                rpt.SetDataSource(myDS);
               // Invoicecs frm = new Invoicecs();
               //frm.crystalReportViewer1.ReportSource = rpt;
               PrinterSettings getprinterName = new PrinterSettings();
               rpt.PrintOptions.PrinterName = getprinterName.PrinterName;
               rpt.PrintToPrinter(1, true, 1, 1);
                con.Close();
                //frm.Visible = true;
                //frm.crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
            List<InvoiceDetails> _List = new List<InvoiceDetails>();
            DataSet ds = Invoice_Product();
            foreach (DataRow dr in ds.Tables[0].Rows) {
                _List.Add(new InvoiceDetails
                {

                    PID = dr["PID"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    UnitPrice = dr["UnitPrice"].ToString(),
                    Bundle = dr["Bundle"].ToString(),
                    Wet = dr["Wet"].ToString(),
                    Weight = dr["Weight"].ToString(),
                    SubTotal = dr["SubTotal"].ToString(),

                }); 

            }
            Invoicecs frm = new Invoicecs();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
               frm.testInvoice1.SetDataSource(_List);

            }*/


        }

        private void txtPhoneNo_TextChanged(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text != "")
            {
                try
                {
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    String sql = "SELECT * from Customer where CustomerContactNo like '" + txtPhoneNo.Text + "'";
                    //SELECT TOP 1 Product.ProductID,Product.ProductName, Stock.Price, Stock.Quantity FROM Stock, Product  WHERE Stock.ProductID=Product.ProductID AND Product.ProductName = 'apple' AND Stock.Quantity>0
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (rdr.Read() == true)
                    {
                        txtCustomerFName.Text = rdr["CustomerFName"].ToString();
                        txtCustomerLName.Text = rdr["CustomerLName"].ToString();
                        txtAd1.Text = rdr["AddressL1"].ToString();
                        txtAd2.Text = rdr["AddressL2"].ToString();
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                txtCustomerFName.Text = "";
                txtCustomerLName.Text = "";
                txtAd1.Text = "";
                txtAd2.Text = "";

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
          
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton211.ButtonText + "'";
                //SELECT TOP 1 Product.ProductID,Product.ProductName, Stock.Price, Stock.Quantity FROM Stock, Product  WHERE Stock.ProductID=Product.ProductID AND Product.ProductName = 'apple' AND Stock.Quantity>0
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
           
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton28.ButtonText + "'";
                //SELECT TOP 1 Product.ProductID,Product.ProductName, Stock.Price, Stock.Quantity FROM Stock, Product  WHERE Stock.ProductID=Product.ProductID AND Product.ProductName = 'apple' AND Stock.Quantity>0
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton210.ButtonText + "'";
               
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton27 .ButtonText + "'";
               
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton29.ButtonText + "'";
                
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
         
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton26.ButtonText + "'";
               
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            
            txtTarPer.Text = "200";
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton23.ButtonText + "'";
               
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            txtTarPer.Text = "200";
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton22.ButtonText + "'";
               
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            
            txtTarPer.Text = "500";
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton24.ButtonText + "'";
                
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            
            txtTarPer.Text = "200";
            pcrear();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton25.ButtonText + "'";
                
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["PID"].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                txtPType.Visible = false;
                hide();
                txtProductName.Text = "";
                txtPType.Text = "";
                txtPrice.Text = "";
                pcrear();
                label7.Enabled = true;
                txtTarPer.Enabled = true;
                label17.Enabled = true;
                txtTarAmt.Enabled = true;


            }//tabPage4
            else if (tabControl1.SelectedTab == tabPage1)
            {
                txtPType.Visible = true;
                show();
                txtProductName.Text = "";
                txtPType.Text = "";
                txtPrice.Text = "";
                pcrear();
                txtTarAmt.Text = "0";
                txtnetweigth.Text = "0";
                txtTotalAmount.Text = "0.00";
                label7.Enabled = true;
                txtTarPer.Enabled = true;
                label17.Enabled = true;
                txtTarAmt.Enabled = true;

            }
            else if (tabControl1.SelectedTab == tabPage4) {

                
                label11.Enabled = false;
                txtwet.Enabled = false;
                label15.Enabled = false;
                txtTarPer.Text = "200";
                label17.Text = "g";
                txtPType.Visible = false;
            }
            else {
                txtProductName.Text = "";
                txtPType.Text = "";
                txtPrice.Text = "";
                pcrear();
                txtPType.Visible = false;
                txtwet.Enabled = true;
                label15.Enabled = true;
                label7.Enabled = false;
                txtTarPer.Enabled = false;
                label17.Enabled = false;
                txtTarAmt.Enabled = false;

            }
        }

        void hide() {

            label11.Enabled = false;
            txtwet.Enabled = false;
            label15.Enabled= false;
            txtTarPer.Text = "200";
            label17.Text = "g";
        }

        void show()
        {

            label11.Enabled = true;
            txtwet.Enabled = true;
            label15.Enabled = true;
            txtTarPer.Text = "2";
            label17.Text = "%";
        }

        void chipscal() {

            decimal weight = 0;
            decimal wet = 0;
            decimal netweigth = 0;
            double price = 0;
            double total = 0;

            decimal.TryParse(txtQty.Text, out weight);
            decimal.TryParse(txtwet.Text, out wet);
            double.TryParse(txtPrice.Text, out price);

            netweigth = weight - wet;
            txtnetweigth.Text = netweigth.ToString();
            total =   price * Convert.ToDouble(netweigth);
            txtTotalAmount.Text = total.ToString("#,##0.00");
        }

        void othercal() {

            decimal bundle = 0;
            decimal tar = 0;
            decimal weight = 0;
            decimal tottar = 0;
            double price = 0;
            decimal convalue = 0;
            decimal netweigth = 0;
            double total = 0;

            decimal.TryParse(txtBundle.Text, out bundle);
            decimal.TryParse(txtTarPer.Text, out tar);//txtqtyamount
            decimal.TryParse(txtQty.Text, out weight);
            double.TryParse(txtPrice.Text, out price);

            tottar = bundle * tar;
            convalue = tottar / 1000;
            txtTarAmt.Text = convalue.ToString();
            netweigth = weight - convalue;
            txtnetweigth.Text = netweigth.ToString();
            total = price * Convert.ToDouble(netweigth);
            txtTotalAmount.Text = total.ToString("#,##0.00");

        }
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
                if (tabControl1.SelectedTab == tabPage1)
                {
                    if (txtwet.Text != "0")
                    {
                        wetcal();

                    }

                    else
                    {

                    }
                }
                else if (tabControl1.SelectedTab == tabPage2)
                {

                    if (txtBundle.Text != "")
                    {
                        othercal();

                    }

                }
                else if(tabControl1.SelectedTab == tabPage4)
                {
                if (txtBundle.Text != "")
                {

                }


                }
            }
           
        void ScrapRubbercal() {

            decimal price = 0;
            decimal weight = 0;
            double total = 0;

            decimal.TryParse(txtPrice.Text, out price);
            decimal.TryParse(txtQty.Text, out weight);
            //double.TryParse();

        }

        private void txtBundle_TextChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                if (txtBundle.Text != "0" || txtBundle.Text != "" && txtQty.Text!="0" ||txtQty.Text!="" )
                {
                    othercal(); 
                }
                else {
                   txtTarAmt.Text = "0";
                    txtnetweigth.Text = "0";
;                }
                
            }


            }

        private void cmbPay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPay.Text == "Check")
            {
                txtCheck.Visible = true;
                label19.Visible = true;
            }
            else {
                txtCheck.Visible = false;
                label19.Visible = false;
            }
        }

        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton212_Click_1(object sender, EventArgs e)
        {
            pcrear();
            txtwet.Enabled = true;
            label15.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton212.ButtonText + "'";
                //SELECT TOP 1 Product.ProductID,Product.ProductName, Stock.Price, Stock.Quantity FROM Stock, Product  WHERE Stock.ProductID=Product.ProductID AND Product.ProductName = 'apple' AND Stock.Quantity>0
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton219_Click(object sender, EventArgs e)
        {
            pcrear();
            txtwet.Enabled = true;
            label15.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton219.ButtonText + "'";
                //SELECT TOP 1 Product.ProductID,Product.ProductName, Stock.Price, Stock.Quantity FROM Stock, Product  WHERE Stock.ProductID=Product.ProductID AND Product.ProductName = 'apple' AND Stock.Quantity>0
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void bunifuThinButton220_Click(object sender, EventArgs e)
        {
            pcrear();
            txtwet.Enabled = true;
            label15.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton220.ButtonText + "'";
                //SELECT TOP 1 Product.ProductID,Product.ProductName, Stock.Price, Stock.Quantity FROM Stock, Product  WHERE Stock.ProductID=Product.ProductID AND Product.ProductName = 'apple' AND Stock.Quantity>0
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerFName.Focus();

            }
        }

        private void txtCustomerFName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCustomerLName.Focus();

            }
            
        }

        private void txtCustomerLName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAd1.Focus();

            }
        }

        private void txtAd1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAd2.Focus();

            }
        }

        private void txtAd2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQty.Focus();

            }
        }

        private void dtpInvoiceDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhoneNo.Focus();

            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBundle.Focus();

            }
        }

        private void txtBundle_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtwet.Visible == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtwet.Focus();

                }
            }
            

            
        }

        private void bunifuThinButton217_Click(object sender, EventArgs e)
        {
            label7.Enabled = true;
            txtTarPer.Enabled = true;
            label17.Enabled = true;
            txtTarAmt.Enabled = true;
            label10.Enabled = true;
            txtnetweigth.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton217.ButtonText + "'";
               
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bunifuThinButton218_Click(object sender, EventArgs e)
        {
            pcrear();
            label11.Enabled = false;
            txtwet.Enabled = false;
            label15.Enabled = false;
            label7.Enabled = false;
            txtTarPer.Enabled = false;
            label17.Enabled = false;
            txtTarAmt.Enabled = false;
            label10.Enabled = false;
            txtnetweigth.Enabled = false;
            txtPType.Visible = false;

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton218.ButtonText + "'";
               
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton221_Click(object sender, EventArgs e)
        {
            pcrear();
            txtwet.Enabled = true;
            label15.Enabled = true;

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton221.ButtonText + "'";
              
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            pcrear();

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton216.ButtonText + "'";

                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton214_Click(object sender, EventArgs e)
        {
            pcrear();

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton214.ButtonText + "'";

                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton215_Click(object sender, EventArgs e)
        {
            pcrear();

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton215.ButtonText + "'";

                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bunifuThinButton213_Click(object sender, EventArgs e)
        {
            pcrear();

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton213.ButtonText + "'";

                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            pcrear();

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT * from Product where ProductName like '" + bunifuThinButton21.ButtonText + "'";

                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read() == true)
                {
                    txtPrice.Text = String.Format("{0:0.00}", rdr["UnitPrice"]);
                    txtProductName.Text = rdr["ProductName"].ToString();
                    txtProductID.Text = rdr["ProductType"].ToString();

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
    

