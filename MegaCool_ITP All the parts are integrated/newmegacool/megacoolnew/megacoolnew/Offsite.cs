using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using megacoolnew.userObjects;
using System.Data.SqlClient;
using System.Data.Sql;

namespace megacoolnew
{
    public partial class Offsite : Form
    {
        public Offsite()
        {
            InitializeComponent();
            PopulateInventoryComboBox();
            PopulateAssEmpCombo();

        }

        public void fillassignedempdatagrid()
        {
            if (JID5Text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID5Text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    newconn.OpenCon();

                    SqlDataAdapter sda1 = new SqlDataAdapter("Select o.JobID, e.Name, o.EmpID, e.Position FROM EmployeeOffsiteJob o, Employee e where o.EmpId = e.EmployeeID and JobID = '" + off.JobID + "'", ConnectionManagerOffsite.conn);

                    DataTable dt = new DataTable();

                    sda1.Fill(dt);

                    ScheduledataGridView.DataSource = dt;

                    AssEmpButt.Enabled = true;
                    AssVehButt.Enabled = true;
                    AssRentButt.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        public void clearitemfields()
        {

            JID4text.Clear();
            IventorycomboBox1.SelectedItem = null;
            Itemtext.Clear();

        }

        public void PopulateAssEmpCombo()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();

            newconn.OpenCon();
            SqlCommand getAvMech = new SqlCommand("SELECT EmpID FROM MechanicAvailability Where Status = 'AV' Order by EmpID ASC", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr = getAvMech.ExecuteReader();

                while (dr.Read())
                {
                    String AssMechCombostring = dr["EmpID"] + " Mechanic";
                    AssEmpCombo.Items.Add(AssMechCombostring);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            newconn.OpenCon();
            SqlCommand getAvDri = new SqlCommand("SELECT DriverNo FROM EmpDriver Where Status = 'Available' Order by DriverNo ASC", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr2 = getAvDri.ExecuteReader();

                while (dr2.Read())
                {
                    String AssDriCombostring = dr2["DriverNo"] + " Driver";
                    AssEmpCombo.Items.Add(AssDriCombostring);
                }

                dr2.Close();
                dr2.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void PopulateUnassEmpCombo(string tempJobId)
        {
            UnassEmpCombo.Items.Clear();
            OffsiteObject off5 = new OffsiteObject();
            off5.JobID = tempJobId;
            Console.WriteLine(tempJobId);
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();

            newconn.OpenCon();
            SqlCommand getUnMech = new SqlCommand("SELECT M.EmpID FROM MechanicAvailability M, EmployeeOffSiteJob E Where M.EmpID = E.EmpID and M.Status = 'NO' and E.JobID='"+ off5.JobID +"' Order by M.EmpID ASC", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr = getUnMech.ExecuteReader();

                while (dr.Read())
                {
                    String UnAssMechCombostring = dr["EmpID"] + " Mechanic";
                    UnassEmpCombo.Items.Add(UnAssMechCombostring);
                }

                dr.Close();
                dr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            newconn.OpenCon();
            SqlCommand getUnDri = new SqlCommand("SELECT D.DriverNO FROM EmpDriver D, EmployeeOffSiteJob E Where D.DriverNO = E.EmpID and D.Status = 'Not Available' and E.JobID='" + off5.JobID + "' Order by D.DriverNo ASC", ConnectionManagerOffsite.conn);
            try
            {
                SqlDataReader dr2 = getUnDri.ExecuteReader();

                while (dr2.Read())
                {
                    String UnAssDriCombostring = dr2["DriverNo"] + " Driver";
                    UnassEmpCombo.Items.Add(UnAssDriCombostring);
                }

                dr2.Close();
                dr2.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void PopulateInventoryComboBox()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();
            SqlCommand getinventory = new SqlCommand("SELECT InventoryID FROM Inventory Order by InventoryID ASC", ConnectionManagerOffsite.conn);

            try
            {
                SqlDataReader dr = getinventory.ExecuteReader();

                while (dr.Read())
                {
                    IventorycomboBox1.Items.Add(dr["InventoryID"]);
                }

                dr.Close();
                dr.Dispose();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void fillwithalljobs()
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();

            SqlDataAdapter sda1 = new SqlDataAdapter("select o.JobID, o.JobType, o.JobStatus, o.StartDate, o.CustomerNIC from OffSiteJob o", ConnectionManagerOffsite.conn);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            OffsitejobsdataGridView.DataSource = dt;
        }

        public void Resetfields()
        {
            JID2text.Clear();
            CIDtext.Items.Clear();
            SIDtext.Clear();
            ODJradio.Checked = false;
            LTPradio.Checked = false;
            JobDescrText.Clear();
            Addbutt.Enabled = true;
            Savebutt.Enabled = false;
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label117_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (JID2text.Text != "")
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                SqlCommand checkJobID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JobID)", ConnectionManagerOffsite.conn);
                checkJobID.Parameters.AddWithValue("@JobID", JID2text.Text);
                SqlDataReader reader = checkJobID.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    Addbutt.Enabled = false;
                    Savebutt.Enabled = true;

                    newconn.OpenCon();

                    SqlCommand checkJobID2 = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JobID)", ConnectionManagerOffsite.conn);
                    checkJobID2.Parameters.AddWithValue("@JobID", JID2text.Text);
                    SqlDataReader readfilltextbox = checkJobID2.ExecuteReader();

                    while (readfilltextbox.Read())
                    {
                        CIDtext.Text = (readfilltextbox["customerNIC"].ToString());
                        SIDtext.Text = (readfilltextbox["SUPERVISOR"].ToString());
                        String Jobtypeforfill = (readfilltextbox["JobType"].ToString());
                        if (Jobtypeforfill == "RJ")
                        {
                            ODJradio.Checked = true;
                            LTPradio.Checked = false;
                        }
                        else
                        {
                            ODJradio.Checked = false;
                            LTPradio.Checked = true;
                        }
                        JobDescrText.Text = (readfilltextbox["JobDescription"].ToString());
                    }
                    readfilltextbox.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Job ID");
                }



            }
            else
            {
                MessageBox.Show("Please fill in the Job ID");
            }


        }

        private void button41_Click(object sender, EventArgs e)
        {
            Resetfields();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            String Jobradio;
            if (ODJradio.Checked)
            {
                Jobradio = "RJ";
            }
            else
            {
                Jobradio = "PJ";
            }

            if (CIDtext.Text == "" || SIDtext.Text == "" || Jobradio == "" || JobDescrText.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds");
            }
            else
            {
                OffsiteObject Off = new OffsiteObject();

                //if (CIDtext.TextLength != 10)
                //    MessageBox.Show("Customer NIC should be 10 characters long");
                //else if (!CIDtext.ToString().EndsWith("v") || CIDtext.ToString().EndsWith("V"))
                //    MessageBox.Show("Customer NIC should end in either 'v' or 'V'");
                //else
                //{
                //    Off.CID = CIDtext.Text;

                //    int i;
                //    if (!int.TryParse(SIDtext.Text, out i))
                //    {
                //        MessageBox.Show("Supervisor ID should only contain numbers");
                //        return;
                //    }
                //    else
                //    {
                //        ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                //        newconn.OpenCon();
                //        SqlCommand checkCID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([CustomerNIC] = @CID)", ConnectionManagerOffsite.conn);
                //        checkCID.Parameters.AddWithValue("@CID", CIDtext.Text);
                //        SqlDataReader reader3 = checkCID.ExecuteReader();
                //        if (reader3.HasRows)
                //        {
                //            reader3.Close();
                //            SqlCommand checkSID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([SUPERVISOR] = @SID)", ConnectionManagerOffsite.conn);
                //            checkSID.Parameters.AddWithValue("@SID", SIDtext.Text);
                //            SqlDataReader reader2 = checkSID.ExecuteReader();
                //            if (reader2.HasRows)
                //            {
                //                reader2.Close();
                //                Off.SID = SIDtext.Text;

                //                if (ODJradio.Checked)
                //                {
                //                    Off.JobType = "RJ";
                //                }
                //                else
                //                {
                //                    Off.JobType = "PJ";
                //                }

                //                Off.JobStatus = "ON";
                //                Off.JobDescription = JobDescrText.Text;

                //                DateTime time = DateTime.Now;
                //                string format = "yyyy-MM-dd HH:MM:ss";
                //                string inserttime = time.ToString(format);
                //                Off.JobStartDate = inserttime;

                //                if (Off.JobType == "RJ")
                //                {
                //                    Off.JobEndDate = inserttime;
                //                }

                //                ConnectionManagerOffsite newconn2 = new ConnectionManagerOffsite();
                //                newconn2.OpenCon();

                //                try
                //                {
                //                    SqlCommand comm = new SqlCommand();
                //                    comm.Connection = ConnectionManagerOffsite.conn;
                //                    comm.CommandText = "INSERT INTO OffSiteJob (JobType, JobStatus, Startdate, Enddate, JobDescription, CustomerNIC, Supervisor) values ('" + Off.JobType + "' , '" + Off.JobStatus + "' , '" + Off.JobStartDate + "' , '" + Off.JobEndDate + "' , '" + Off.JobDescription + "' , '" + Off.CID + "' , '" + Off.SID + "')";
                //                    comm.ExecuteNonQuery();
                //                }
                //                catch (SqlException ex)
                //                {
                //                    Console.WriteLine(ex);
                //                    throw ex;
                //                }

                //                MessageBox.Show("Job added");
                //                fillwithalljobs();
                //                Resetfields();
                //                OPsearchbutt.Enabled = true;
                //                AllJobButt.Enabled = false;

                //            }
                //            else
                //            {
                //                MessageBox.Show("Invalid Supervisor ID");
                //            }

                //        }
                //        else
                //        {
                //            MessageBox.Show("Invalid Customer ID");
                //        }
                //    }

                //}


            }


        }

        private void OPsearchbutt_Click(object sender, EventArgs e)
        {
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();

            SqlDataAdapter sda1 = new SqlDataAdapter("select o.JobID, o.JobType, o.JobStatus, o.StartDate, o.CustomerNIC from OffSiteJob o where o.JobStatus = 'ON' ", ConnectionManagerOffsite.conn);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            OffsitejobsdataGridView.DataSource = dt;

            CID2text.Clear();
            OPsearchbutt.Enabled = false;
            AllJobButt.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fillwithalljobs();
            CID2text.Clear();
            OPsearchbutt.Enabled = true;
            AllJobButt.Enabled = false;
        }

        private void Savebutt_Click(object sender, EventArgs e)
        {
            String Jobradio;
            if (ODJradio.Checked)
            {
                Jobradio = "RJ";
            }
            else
            {
                Jobradio = "PJ";
            }

            if (CIDtext.Text == "" || SIDtext.Text == "" || Jobradio == "" || JobDescrText.Text == "" || JID2text.Text == "")
            {

                MessageBox.Show("Please fill the all required feilds including the Job ID");
            }
            else
            {
                //OffsiteObject Off = new OffsiteObject();

                //if (CIDtext.TextLength != 10)
                //    MessageBox.Show("Customer NIC should be 10 characters long");
                //else if (!CIDtext.ToString().EndsWith("v") || CIDtext.ToString().EndsWith("V"))
                //    MessageBox.Show("Customer NIC should end in either 'v' or 'V'");
                //else
                //{
                //    Off.CID = CIDtext.Text;

                //    int i;
                //    if (!int.TryParse(SIDtext.Text, out i))
                //    {
                //        MessageBox.Show("Supervisor ID should only contain numbers");
                //        return;
                //    }
                //    else
                //    {
                //        ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                //        newconn.OpenCon();
                //        SqlCommand checkCID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([CustomerNIC] = @CID)", ConnectionManagerOffsite.conn);
                //        checkCID.Parameters.AddWithValue("@CID", CIDtext.Text);
                //        SqlDataReader reader3 = checkCID.ExecuteReader();
                //        if (reader3.HasRows)
                //        {
                //            reader3.Close();
                //            SqlCommand checkSID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([SUPERVISOR] = @SID)", ConnectionManagerOffsite.conn);
                //            checkSID.Parameters.AddWithValue("@SID", SIDtext.Text);
                //            SqlDataReader reader2 = checkSID.ExecuteReader();
                //            if (reader2.HasRows)
                //            {
                //                reader2.Close();
                //                Off.SID = SIDtext.Text;

                //                if (ODJradio.Checked)
                //                {
                //                    Off.JobType = "RJ";
                //                }
                //                else
                //                {
                //                    Off.JobType = "PJ";
                //                }

                //                Off.JobStatus = "ON";
                //                Off.JobDescription = JobDescrText.Text;
                //                Off.IID = JID2text.Text;

                //                DateTime time = DateTime.Now;
                //                string format = "yyyy-MM-dd HH:MM:ss";
                //                string inserttime = time.ToString(format);
                //                Off.JobStartDate = inserttime;

                //                if (Off.JobType == "RJ")
                //                {
                //                    Off.JobEndDate = inserttime;
                //                }

                //                ConnectionManagerOffsite newconn2 = new ConnectionManagerOffsite();
                //                newconn2.OpenCon();

                //                try
                //                {
                //                    SqlCommand comm = new SqlCommand();
                //                    comm.Connection = ConnectionManagerOffsite.conn;
                //                    comm.CommandText = "Update OffSiteJob SET JobType='" + Off.JobType + "', JobDescription='" + Off.JobDescription + "', CustomerNIC='" + Off.CID + "', Supervisor='" + Off.SID + "' WHERE JobID = '" + Off.IID + "'";
                //                    comm.ExecuteNonQuery();
                //                    Console.WriteLine("Out 1");
                //                }
                //                catch (SqlException ex)
                //                {
                //                    Console.WriteLine(ex);
                //                    throw ex;
                //                }

                //                MessageBox.Show("Job Updated");
                //                fillwithalljobs();
                //                Resetfields();
                //                OPsearchbutt.Enabled = true;
                //                AllJobButt.Enabled = false;

                //            }
                //            else
                //            {
                //                MessageBox.Show("Invalid Supervisor ID");
                //            }

                //        }
                //        else
                //        {
                //            MessageBox.Show("Invalid Customer ID");
                //        }
                //    }

                //}


            }
        }

        private void Endbutt_Click(object sender, EventArgs e)
        {
            if (JID2text.Text != "")
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                SqlCommand checkJobID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JobID)", ConnectionManagerOffsite.conn);
                checkJobID.Parameters.AddWithValue("@JobID", JID2text.Text);
                SqlDataReader reader = checkJobID.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    OffsiteObject Off = new OffsiteObject();
                    Off.IID = JID2text.Text;

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "Update OffSiteJob SET JobStatus='FN' where JobID = '"+ Off.IID +"'";
                        comm.ExecuteNonQuery();
                        Console.WriteLine("Out 1");
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    Resetfields();
                    fillwithalljobs();

                }
                else
                {
                    MessageBox.Show("Invalid Job ID");
                }



            }
            else
            {
                MessageBox.Show("Please fill in the Job ID");
            }
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OngoingButt2_Click(object sender, EventArgs e)
        {
            JID3text.Clear();
            ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
            newconn.OpenCon();

            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT distinct o.JobID, o.JobType, o.JobStatus, Count(r.JobID) AS 'No. of Items' FROM OffsiteJob o LEFT JOIN Reserves r ON o.JobID = r.JobID GROUP BY o.JobID, o.JobType, o.JobStatus;", ConnectionManagerOffsite.conn);

            DataTable dt = new DataTable();

            sda1.Fill(dt);

            ItemsdataGridView.DataSource = dt;

            OngoingButt2.Enabled = false;
        }

        private void ViewItemsbutt_Click(object sender, EventArgs e)
        {
            if (JID3text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
              ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
              newconn.OpenCon();

              OffsiteObject off = new OffsiteObject();
              off.JobID = JID3text.Text;

              SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
              checkJID.Parameters.AddWithValue("JID", off.JobID);
              SqlDataReader reader3 = checkJID.ExecuteReader();
              if (reader3.HasRows)
              {
                  reader3.Close();

                  newconn.OpenCon();

                  SqlDataAdapter sda1 = new SqlDataAdapter("Select JobID, InventoryID, ItemNo from Reserves where JobID = '"+ off.JobID +"'", ConnectionManagerOffsite.conn);

                  DataTable dt = new DataTable();

                  sda1.Fill(dt);

                  ItemsdataGridView.DataSource = dt;

                  OngoingButt2.Enabled = true;
              }
              else
              {
                  MessageBox.Show("Invalid Job Id");
              }
            }
        }

        private void Jobsearchbutt_Click(object sender, EventArgs e)
        {
                if (CID2text.TextLength != 10)
                    MessageBox.Show("Customer NIC should be 10 characters long");
                else if (!CID2text.ToString().EndsWith("v") || CIDtext.ToString().EndsWith("V"))
                    MessageBox.Show("Customer NIC should end in either 'v' or 'V'");
                else
                {
                    OffsiteObject off = new OffsiteObject();
                    off.CID = CID2text.Text;

                    ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                    newconn.OpenCon();
                    SqlCommand checkCID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([CustomerNIC] = @CID)", ConnectionManagerOffsite.conn);
                    checkCID.Parameters.AddWithValue("@CID", off.CID);
                    SqlDataReader reader3 = checkCID.ExecuteReader();
                    if (reader3.HasRows)
                    {
                        reader3.Close();
                        off.CID = CID2text.Text;
                        Console.WriteLine(off.CID);
                        SqlDataAdapter sda1 = new SqlDataAdapter("select o.JobID, o.JobType, o.JobStatus, o.StartDate, o.CustomerNIC from OffSiteJob o where o.CustomerNIC = '"+ off.CID +"' ", ConnectionManagerOffsite.conn);

                        DataTable dt = new DataTable();

                        sda1.Fill(dt);

                        OffsitejobsdataGridView.DataSource = dt;

                        OPsearchbutt.Enabled = true;
                        AllJobButt.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Customer NIC");
                    }

                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (JID.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off2 = new OffsiteObject();
                off2.JobID = JID4text.Text;
                Console.WriteLine(off2.JobID);
                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("@JID", off2.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    if (IventorycomboBox1.Text == "")
                    {

                        MessageBox.Show("Please choose or fill in an Inventory ID");
                    }
                    else
                    {
                        newconn.OpenCon();

                        off2.IID = IventorycomboBox1.Text;

                        SqlCommand checkIID = new SqlCommand("SELECT * FROM Inventory WHERE ([InventoryID] = @IID)", ConnectionManagerOffsite.conn);
                        checkIID.Parameters.AddWithValue("@IID", off2.IID);
                        SqlDataReader reader4 = checkIID.ExecuteReader();
                        if (reader4.HasRows)
                        {
                            reader4.Close();

                            if (Itemtext.TextLength != 10)
                            {
                                MessageBox.Show("Item Number should be 10 characters");
                            }
                            else
                            {
                                off2.Item = Itemtext.Text;
                                try
                                {
                                    SqlCommand comm = new SqlCommand();
                                    comm.Connection = ConnectionManagerOffsite.conn;
                                    comm.CommandText = "INSERT INTO Reserves (JobID, InventoryID, ItemNo) values ('" + off2.JobID + "' , '" + off2.IID + "' , '" + off2.Item +"')";
                                    comm.ExecuteNonQuery();
                                    Console.WriteLine("Out 1");

                                    newconn.OpenCon();

                                    SqlDataAdapter sda1 = new SqlDataAdapter("Select JobID, InventoryID, ItemNo from Reserves where JobID = '" + off2.JobID + "'", ConnectionManagerOffsite.conn);

                                    DataTable dt = new DataTable();

                                    sda1.Fill(dt);

                                    ItemsdataGridView.DataSource = dt;

                                    OngoingButt2.Enabled = true;

                                    clearitemfields();

                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine(ex);
                                    throw ex;
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Inventory Id");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void IventorycomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (JID.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off2 = new OffsiteObject();
                off2.JobID = JID4text.Text;
                Console.WriteLine(off2.JobID);
                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("@JID", off2.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    if (IventorycomboBox1.Text == "")
                    {

                        MessageBox.Show("Please choose or fill in an Inventory ID");
                    }
                    else
                    {
                        newconn.OpenCon();

                        off2.IID = IventorycomboBox1.Text;

                        SqlCommand checkIID = new SqlCommand("SELECT * FROM Inventory WHERE ([InventoryID] = @IID)", ConnectionManagerOffsite.conn);
                        checkIID.Parameters.AddWithValue("@IID", off2.IID);
                        SqlDataReader reader4 = checkIID.ExecuteReader();
                        if (reader4.HasRows)
                        {
                            reader4.Close();

                            if (Itemtext.TextLength != 10)
                            {
                                MessageBox.Show("Item Number should be 10 characters");
                            }
                            else
                            {
                                newconn.OpenCon();
                                off2.Item = Itemtext.Text;
                                
                                SqlCommand checkItem = new SqlCommand("SELECT * FROM Reserves WHERE ([ItemNo] = @Item)", ConnectionManagerOffsite.conn);
                                checkItem.Parameters.AddWithValue("@Item", off2.Item);
                                SqlDataReader reader5 = checkItem.ExecuteReader();
                                if (reader5.HasRows)
                                {
                                    reader5.Close();

                                    try
                                    {
                                        SqlCommand comm = new SqlCommand();
                                        comm.Connection = ConnectionManagerOffsite.conn;
                                        comm.CommandText = "Delete from Reserves where ItemNo='"+ off2.Item +"'";
                                        comm.ExecuteNonQuery();
                                        Console.WriteLine("Out 1");

                                        newconn.OpenCon();

                                        SqlDataAdapter sda1 = new SqlDataAdapter("Select JobID, InventoryID, ItemNo from Reserves where JobID = '" + off2.JobID + "'", ConnectionManagerOffsite.conn);

                                        DataTable dt = new DataTable();

                                        sda1.Fill(dt);

                                        ItemsdataGridView.DataSource = dt;

                                        OngoingButt2.Enabled = true;

                                        clearitemfields();

                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine(ex);
                                        throw ex;
                                    }

                                }
                                else
                                {

                                 }

                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Inventory Id");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (JID6text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID6text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    if(UnassEmpCombo.Text == "")
                    {
                        MessageBox.Show("No Assigned Employees were selected");
                    }
                    else
                    {
                    String RawUnAssignEmp = UnassEmpCombo.Text;
                    string[] UnAssignEmp = RawUnAssignEmp.Split(' ');
                    off.EmpID = UnAssignEmp[0];
                    off.EmpPos = UnAssignEmp[1];

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "Delete from EmployeeOffSiteJob where EmpId='"+ off.EmpID +"'";
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        if (off.EmpPos == "Mechanic")
                        {
                            comm.CommandText = "Update MechanicAvailability SET Status='AV' where EmpID='" + off.EmpID + "'";
                        }
                        else
                        {
                            comm.CommandText = "Update EmpDriver SET Status='Available' where DriverNo='" + off.EmpID + "'";
                        }

                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }
                    JID5Text.Text = off.JobID;
                    fillassignedempdatagrid();
                    JID6text.Clear();
                    UnassEmpCombo.Items.Clear();
                    AssEmpCombo.Items.Clear();
                    PopulateAssEmpCombo();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            fillassignedempdatagrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearitemfields();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void JID4text_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (JID6text.Text == "")
            {

                MessageBox.Show("Please fill the Job ID");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID6text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();

                    if (AssEmpCombo.Text == "")
                    {
                        MessageBox.Show("No Avalaible Employees selected");
                    }
                    else
                    {
                        
                    String RawAssignEmp = AssEmpCombo.Text;
                    string[] AssignEmp = RawAssignEmp.Split(' ');
                    off.EmpID = AssignEmp[0];
                    off.EmpPos = AssignEmp[1];

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        comm.CommandText = "INSERT INTO EmployeeOffSiteJob (JobID, EmpID) values ('" + off.JobID + "' , '" + off.EmpID + "')";
                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.Connection = ConnectionManagerOffsite.conn;
                        if (off.EmpPos == "Mechanic")
                        {
                            comm.CommandText = "Update MechanicAvailability SET Status='NO' where EmpID='"+ off.EmpID +"'";
                        }
                        else
                        {
                            comm.CommandText = "Update EmpDriver SET Status='Not Available' where DriverNo='" + off.EmpID + "'";
                        }

                        comm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw ex;
                    }
                    JID5Text.Text = off.JobID;
                    fillassignedempdatagrid();
                    JID6text.Clear();
                    AssEmpCombo.Items.Clear();
                    PopulateAssEmpCombo();
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Job Id");
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void JID6text_TextChanged(object sender, EventArgs e)
        {

        }

        private void JID6text_Leave(object sender, EventArgs e)
        {

            if (JID6text.Text == "")
            {
                MessageBox.Show("Please Enter a JobId");
            }
            else
            {
                ConnectionManagerOffsite newconn = new ConnectionManagerOffsite();
                newconn.OpenCon();

                OffsiteObject off = new OffsiteObject();
                off.JobID = JID6text.Text;

                SqlCommand checkJID = new SqlCommand("SELECT * FROM OffSiteJob WHERE ([JobID] = @JID)", ConnectionManagerOffsite.conn);
                checkJID.Parameters.AddWithValue("JID", off.JobID);
                SqlDataReader reader3 = checkJID.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Close();
                    string tempJobId;
                    tempJobId = JID6text.Text;
                    PopulateUnassEmpCombo(tempJobId);
                }
                else
                {
                    MessageBox.Show("Invalid JobID");
                }
            }

        }
    }
}
                    