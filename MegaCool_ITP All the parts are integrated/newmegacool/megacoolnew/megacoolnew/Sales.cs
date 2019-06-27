using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using megacoolnew;
using megacoolnew.userObjects;

namespace megacoolnew
{
    public partial class Sales : Form
    {
        string qLoad = "select * from ServiceInvoice";
        int invoiceID;
        //string cardType;
        CustomerObject co = new CustomerObject();

        public Sales()
        {
            InitializeComponent();
            lblPurDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            groupBox1.Enabled = false;
         //   lblSerDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");

        }
        MegaCoolMethods mcm = new MegaCoolMethods();
        
        SqlConnection con = ConnectionManager.GetConnection();

        SalesObject so = new SalesObject();
        

        //Filling Product Type Combo box
        public void FillComboType()
        {
            
            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {

                string q = "select distinct ProductType from dbo.Inventory";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cmbPurType.DataSource = dt;
                cmbPurType.DisplayMember = "ProductType";
                cmbPurType.Text = "";


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();

        }
        

        //Filling Make Combo box
        public void FillComboMake()
        {

            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }
            try
            {

                SqlCommand cmd1 = con.CreateCommand();

                cmd1.Connection = con;
                cmd1.CommandType = CommandType.Text;

                cmd1.CommandText = "select distinct Make from dbo.Inventory where ProductType='" + cmbPurType.Text + "'";

                SqlDataReader dr = cmd1.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cmbPurMake.DataSource = dt;
                cmbPurMake.DisplayMember = "Make";
                cmbPurMake.Text = "";

                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();


        }

       //---Fill Combo jobID---
       public void fillComboJobID()
        {
            SqlConnection con = ConnectionManager.GetConnection();

            if (con.State.ToString() == "Closed")
            {
                con.Open();
            }

            try
            {

                string q = "select distinct JobID from dbo.Repair_Inventory";

                SqlCommand cmd = new SqlCommand(q, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                cmbSerJobID.DataSource = dt;
                cmbSerJobID.DisplayMember = "JobID";
                cmbSerJobID.Text = "";


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            con.Close();





        }





        private void button5_Click(object sender, EventArgs e)
        {
            //EmployeeObject em = new EmployeeObject();
        }

        private void btnDemo_Click_1(object sender, EventArgs e)
        {
            //cmbPurType.Text = "AC Filter";
           // cmbPurMake.Text = "Filter free";
           // cmbPurModel.Text = "F5664";
            txtPurSKey.Text = "569325";
            txtPurTot.Text = "5627";
            txtPurDis.Text = "627";
            txtPurGrand.Text = "5000";
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
   //         txtbLocation2.Text = "Malabe";
    //        cmbPaymntType.Text = "Card";
        }
         

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            //---reset upper part---
            lblPurDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            txtPurNIC.Text = "";
            cmbPurPayType.SelectedIndex = -1;
            lblPurName.Text = "";

            //---reset combo boxes---
            cmbPurType.SelectedIndex = -1;
            cmbPurMake.SelectedIndex = -1;
            cmbPurModel.SelectedIndex = -1;

            //---reset lower part---
            txtPurSKey.Text = "";
            txtPurTot.Text = "";
            txtPurDis.Text = "";
            txtPurGrand.Text = "";

            //---resetting button settings---
            btnPurAdd.Enabled = false;
            btnPurCreate.Enabled = true;
            txtPurNIC.Enabled = true;
            cmbPurPayType.Enabled = true;
            btnPurSub.Enabled = true;
            btn2Demo.Enabled = true;
            btnPurDelete.Enabled = true;
            btn9Demo.Enabled = true;
            btn10Clear.Enabled = true; 

          //  dataGridView4.DataSource = null;

        }
        



        //add to invoice btn
        private void button6_Click(object sender, EventArgs e)
        {
            //if (txtINVser.Text == "")
            //{
            //    MessageBox.Show("Please Insert the Serial Key");

            //}
            //else
            //{
            //    string pt = cmbPurModel.CurrentRow.Cells[1].Value.ToString();
            //    string mk = cmbPurModel.CurrentRow.Cells[2].Value.ToString();
            //    string inID = cmbPurModel.CurrentRow.Cells[0].Value.ToString();
                
            //    string q="insert into Inventory_Invoice values('"+inID+"', '"++"')";

            //}


            //cmbPurModel.DataSource = mcm.loadGridView(q);

        }

        //sales_invoice_search_btn
        private void button1_Click_2(object sender, EventArgs e) 
        {
            String q = "select InventoryID, ProductType, Make, Model, SellingPrice from Inventory Where Make = '" + cmbPurMake.Text + "' and ProductType = '" + cmbPurType.Text + "'";
            cmbPurModel.DataSource = mcm.loadGridView(q);
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            
            if(txtPurSKey.Text == ""  || txtPurNIC.Text == "" || lblPurName.Text == "" || cmbPurPayType.Text=="")
            {   
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                string pt = cmbPurType.Text;
                string mk = cmbPurMake.Text;
                string md = cmbPurModel.Text;
                string Skey = txtPurSKey.Text;

                string inID;
                string q1 = "select InventoryID from Inventory where Make='"+mk+"' and Model='"+md+"'";
                string FindInvoiceQ = "SELECT TOP 1 InvoiceID FROM Invoice ORDER BY InvoiceID DESC";
                SqlCommand cmd1 = new SqlCommand(q1,con);
                SqlCommand cmdFindInvoice = new SqlCommand(FindInvoiceQ, con);
                so.InvoiceNo = invoiceID;
                
                con.Open();

                try
                {
                    SqlDataReader dr = cmd1.ExecuteReader(); 
                    dr.Read(); 
                    inID = dr.GetString(0);
                    so.InventoryID = inID;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                string q2 = "insert into PurchaseItems (InvoiceID, InventoryID, SerialKey) values('"+invoiceID+"', '" + inID + "', '" + Skey + "')";
                 
                string q3 = "SELECT DISTINCT Inv.make, Inv.model, PIn.serialkey, Inv.sellingprice , PIn.idx " +
                            "FROM PurchaseItems PIn, Inventory Inv, Invoice Invc "+
                            "WHERE Pin.InvoiceID = '"+invoiceID+"' AND PIn.InventoryID = Inv.InventoryID "+
                            "order by PIn.idx";
                
                dataGridView4.DataSource = mcm.loadGridView(q3);
                SqlCommand cmd2 = new SqlCommand(q2,con);

                con.Open();
                try
                {
                    cmd2.ExecuteNonQuery();
                }
                //catch { }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting data\n");
                    throw ex;
                }
                con.Close();

                dataGridView4.DataSource = mcm.loadGridView(q3);
                
                //---get the total to the text box---

                double sum = mcm.getPurchaseTotal(dataGridView4);
                so.Discount =  mcm.calcDiscount(so.CardType, sum);
                double netTot = sum - so.Discount;
                so.PurchaseGrand = netTot;
                txtPurTot.Text = sum.ToString();
                txtPurDis.Text = so.Discount.ToString();
                txtPurGrand.Text = netTot.ToString();
                
            }
        }
        
        private void cmbPurMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            String q = "select Model from Inventory Where Make = '" + cmbPurMake.Text + "' and ProductType = '" + cmbPurType.Text + "'";
            cmbPurModel.DataSource = mcm.loadGridView(q);
            cmbPurModel.DisplayMember = "Model";
        }

  
        private void cmbPurType_Enter(object sender, EventArgs e)
        {
            FillComboType();
            cmbPurModel.Text= "";
            txtPurSKey.Text = "";

        }

        private void cmbPurType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillComboMake();
            cmbPurModel.Text = "";
            cmbPurMake.SelectedIndex = -1;
        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            //SalesObject so = new SalesObject();
            groupBox1.Enabled = true;
            so.NIC = txtPurNIC.Text;
            string cusName = lblPurName.Text;
            string type = cmbPurPayType.Text;
            string Skey = txtPurSKey.Text;
            DateTime date = DateTime.Now;
            if (so.NIC == "" || cusName == "" || type == "")
            {
                MessageBox.Show("Please Enter all the details");
            }
            else
            { 
                string q = "INSERT INTO Invoice (NIC, Date) VALUES ('"+so.NIC+"', '"+date+"')";
                SqlCommand cmd = new SqlCommand(q, con);
                
                string cardType = mcm.getCardType(so);
                //label6.Text = cardType;
                string q2 = "select * from CustomerLoyalatyCard where NIC='" + so.NIC + "'";
                SqlCommand cmd2 = new SqlCommand(q2, con);

                con.Open();
                try
                {
                    SqlDataReader rd = cmd2.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        so.CardType = rd[3].ToString();

                    }
                }
                catch (Exception ex) { throw ex; }
                con.Close();


                con.Open();
                try
                {
                    cmd.ExecuteNonQuery(); 
                    btnPurAdd.Enabled = true;
                    btnPurCreate.Enabled = false;
                    txtPurNIC.Enabled = false;
                    cmbPurPayType.Enabled = false;
                    btn9Demo.Enabled = false;
                    btn10Clear.Enabled = false;


                    MessageBox.Show("Invoice created Successfully ");
                    groupBox1.Enabled = true;
                    cmbPurType.Enabled = true;
                    cmbPurMake.Enabled = true;
                    cmbPurModel.Enabled = true;
                    txtPurSKey.Enabled = true;

                }
                catch (Exception ex)
                {

                    MessageBox.Show("not success");
                    throw ex;
                }

                

                string invIDquery = "select top 1 InvoiceID from Invoice order by InvoiceID desc";
                SqlCommand cmd1 = new SqlCommand(invIDquery, con);

                SqlDataReader reader;
                try
                {
                    reader = cmd1.ExecuteReader();
                    reader.Read();
                    invoiceID = reader.GetInt32(0);
                }
                catch (Exception ex)
                {

                    throw ex;
                }


                con.Close();
            }

        }
        

        private void txtPurNIC_Leave(object sender, EventArgs e)
        {
            
            string NIC = txtPurNIC.Text;
            if (NIC != "")
            {

                string q = "select * from Customer where NIC='"+NIC+"'";
                string cusName;
                SqlCommand cmd = new SqlCommand(q,con);
                
                con.Open();
                try
                {
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        co.CustomrName = rd[1].ToString();
                        lblPurName.Text = co.CustomrName;
                    }
                    else{
                        MessageBox.Show("Invalid NIC");
                        txtPurNIC.Text = "";
                    }
                    rd.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
                string q1 = "select * from CustomerLoyalatyCard where NIC='"+NIC+"' ";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                
                try
                {
                    SqlDataReader rd = cmd1.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        co.CardPoints= Convert.ToInt16(rd[2]);
                        //lblPurPoints.Text = co.CardPoints.ToString();
                    }
                    
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                con.Close();
                
                try
                {

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }

        }

        private void btn9Demo_Click(object sender, EventArgs e)
        {
            lblPurDate.Text = DateTime.Now.ToString();
            txtPurNIC.Text = "950220155v";
            lblPurName.Text = "uda";
            cmbPurPayType.Text = "Card";
        }

        private void btn10Clear_Click(object sender, EventArgs e)
        {
            txtPurNIC.Text = "";
            lblPurName.Text = "";
            cmbPurPayType.SelectedIndex = -1;
        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            //string jobID = cmbSerJobID.Text;
            //DateTime date = DateTime.Now;
            //so.NIC = mcm.getNIC(so, jobID);

            //lblSerDate.Text = so.NIC;
            //string mobile = txtSerMobile.Text;
            //double grandTotal = Convert.ToDouble(lblSerGrand.Text);

            //string q = "INSERT INTO ServiceInvoice VALUES('" + jobID + "','" + so.NIC + "','" + so.CustomerName + "','" + date + "','" + mobile + "','" + grandTotal + "' )";
            //SqlCommand cmd = new SqlCommand(q, con);
            //con.Open();
            //try
            //{
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //con.Close();


            //mcm.AddPoints(co, so);

        }
        //string cardType;
        private void btnDelete_Click(object sender, EventArgs e)
        { 
            string idx = dataGridView4.CurrentRow.Cells[4].Value.ToString();

            //string cardType;

            if (mcm.deletePurchaseItem(idx))
            {
                string q3 = "SELECT DISTINCT Inv.make, Inv.model, PIn.serialkey, Inv.sellingprice , PIn.idx " +
                               "FROM PurchaseItems PIn, Inventory Inv, Invoice Invc " +
                               "WHERE Pin.InvoiceID = '" + invoiceID + "' AND PIn.InventoryID = Inv.InventoryID " +
                               "order by PIn.idx";
                dataGridView4.DataSource = mcm.loadGridView(q3);
              
                double sum = mcm.getPurchaseTotal(dataGridView4);
                double discount = mcm.calcDiscount(so.CardType, sum);
                double netTot = sum - discount;

                txtPurTot.Text = sum.ToString();
                txtPurDis.Text = discount.ToString();
                txtPurGrand.Text = netTot.ToString();
            }
            

        }

        
        

        private void cmbSerJobID_Enter(object sender, EventArgs e)
        {
            fillComboJobID();
        }

        

        private void cmbSerJobID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobID = cmbSerJobID.Text;
            so.JobID = jobID;
            so.NIC= mcm.getNIC(so, jobID);
            if (jobID != "")
            {
                string q = "select C.* from Repair_Job R, Customer C where R.CustomerNIC=C.NIC and R.JobID='" + jobID + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                string cardType = mcm.getCardType(so);
                //lblTest.Text = cardType;
                con.Open();
                try
                {
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        string cusName = rd[1].ToString();
                        string email = rd[2].ToString();
                        txtSerCusName.Text = cusName;
                        txtSerEmail.Text = email;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                string q1 = "SELECT i.ProductType, i.Make, i.Model, r.ItemNo, r.SellingPrice " +
                            "FROM Inventory i ,Repair_Inventory r " +
                            "WHERE i.InventoryID=r.InventoryID AND r.JobID='" + jobID + "'";

                SqlCommand cmd1 = new SqlCommand(q1, con);
                con.Open();
                try
                {
                    SqlDataReader rd1 = cmd1.ExecuteReader();
                    if (rd1.HasRows)
                    {
                        dataGridView1.DataSource = mcm.loadGridView(q1);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                con.Close();

                string q2 = "select * from CustomerLoyalatyCard where NIC='"+so.NIC+"'";
                SqlCommand cmd2 = new SqlCommand(q2, con);
                
                
                con.Open();
                try
                {
                    SqlDataReader rd = cmd2.ExecuteReader();
                    if (rd.HasRows)
                    {
                        rd.Read();
                        so.CardType = rd[3].ToString();
                        co.CardPoints = Convert.ToInt16( rd[2]);
                    }
                }
                catch (Exception ex) { throw ex; }
                

                double serviceTotal = mcm.getServiceTotal(dataGridView1);
                double serviceDiscount = mcm.calcDiscount(so.CardType, serviceTotal);
                double grandTotal = serviceTotal - serviceDiscount;

                lblSerDis.Text = serviceDiscount.ToString();
                lblGTotalD.Text = serviceTotal.ToString();
                lblSerGrand.Text = grandTotal.ToString();
                //lbltes

                //lblTest2.Text = so.CardType;
                con.Close();

            }
        }
        
        private void btnPurSub_Click(object sender, EventArgs e)
        {
            mcm.AddPoints(co,so);
            
            if (co.CardPoints >0)
            {
                DialogResult dr;
                dr = MessageBox.Show("           " + co.CustomrName + " have " + co.CardPoints + " points \n" +
                    "                   want to spend?", "Confirm", MessageBoxButtons.YesNo);
                double amountToPay;
                if (dr.ToString() == "Yes")
                {
                    amountToPay = so.PurchaseGrand - co.CardPoints;
                    //txtPurGrand.Text = amountToPay.ToString();
                    MessageBox.Show("amount to pay " + amountToPay);

                    mcm.DeductPoints(co, so);

                }
                
            }

            string q = "update Invoice set Amount='"+ so.PurchaseGrand +"' where NIC= '"+so.NIC+"' and InvoiceID='"+ so.InvoiceNo + "' ";
            SqlCommand cmd = new SqlCommand(q,con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully Submitted");
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            con.Close();

            cmbPurType.Enabled = false;
            cmbPurMake.Enabled = false;
            cmbPurModel.Enabled = false;
            txtPurSKey.Enabled = false;


            btnPurSub.Enabled = false;
            btnPurAdd.Enabled = false;
            btnPurDelete.Enabled = false;
            btn2Demo.Enabled = false;


        }
        

        private void cmbSumType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSumType.SelectedIndex == 0)
            {
                //label6.Text = ":D :P hari";
                string q = "select * from Invoice"; 
                dataGridView2.DataSource = mcm.loadGridView(q);
                
            }
            else if (cmbSumType.SelectedIndex == 1)
            {
                string q = "select * from ServiceInvoice";
                dataGridView2.DataSource = mcm.loadGridView(q);
            }
        }
    }
}
