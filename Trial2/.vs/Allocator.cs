using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace Trial2
{

    using System.Data;
    using System.Data.OleDb;
    using System.Data.Odbc;

    public partial class AllocationForm : MetroFramework.Forms.MetroForm
    {
        public AllocationForm()
        {
            InitializeComponent();

            string CoatString;
            CoatString = "Select DISTINCT [CoatStyle] FROM [MasterCoatSheet]";
            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
            var conn = new OleDbConnection(connstr);
            conn.Open();
            var Coatcmd = new OleDbCommand(CoatString, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(Coatcmd);
            DataSet Coatds = new DataSet();
            adapter.Fill(Coatds);

            conn.Close();
            CoatStyleCB.DataSource = Coatds.Tables[0];
            CoatStyleCB.DisplayMember = "CoatStyle";
            CoatStyleCB.SelectedItem = null;
            CoatStyleCB.DataSource = Coatds.Tables[0];
            CoatStyleCB.DisplayMember = "CoatStyle";
            CoatStyleCB.SelectedItem = null;
            //metroPanel3.Controls.Add(new MetroFramework.Controls.MetroCheckBox c());



        }

        private void CoatLengthCLB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AttemptBTN_Click(object sender, EventArgs e)
        {
            OrderTypeCB.Enabled = true;
            OrderIDTB.Enabled = true;
            //**Check that all inputs are correct
            if (int.TryParse(CoatSizeCB.Text, out int x) == false) { MessageBox.Show("Error: Please Enter/Select a Size (Numbers Only)"); CoatSizeCB.Focus(); }
            //In this iteration OrderID only accepts numbers.
            else if (int.TryParse(OrderIDTB.Text, out int y) == false) { MessageBox.Show("Error: Please Enter the Ticket Number"); OrderIDTB.Focus(); }
            else if (OrderTypeCB.Text == "") { MessageBox.Show("Error: Please Enter/Select the Order Type"); OrderTypeCB.Focus(); }
            else if (CoatStyleCB.Text == "") { MessageBox.Show("Error: Please Enter/Select a Coat Style"); CoatStyleCB.Focus(); }

            
            else
            {


                //** Ask MasterCoatSheet for CoatIDs
                string queryString;
                queryString = "Select * FROM [MasterCoatSheet]" +
                "WHERE [CoatStyle] = @CoatyStyle AND [Size] = @Size AND [Length] = @Length";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var cmd = new OleDbCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                cmd.Parameters.AddWithValue("@Size", x);
                cmd.Parameters.AddWithValue("@Length", Functions.LengthSel(LengthPanel));
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                //Make datetime variables for between statement
                DateTime dateminus = UseDateDTP.Value.AddDays(-6);
                DateTime dateplus = UseDateDTP.Value.AddDays(+6);
                //For each Unique CoatID from MasterCoatSheet , get the Unique ID, check [AllocationDates] for WHERE CoatID = RowID AND [UseDate] Between DTP +/- a week
                int[] coatid = new int[ds.Tables[0].Rows.Count];
                int[] allocationid = new int[ds.Tables[0].Rows.Count];
                int[] ticketnumber = new int[ds.Tables[0].Rows.Count];
                int[] storeid = new int[ds.Tables[0].Rows.Count];
                bool bumporder = false;
                string allocationnumber = "";
                //THIS LOOP POPULATES A DGV BY FIRST GATHERING UNIQUE COAT IDS FROM THE PREVIOUS QUERY, THEN MAKING A NEW QUERY TO SEE IF
                // UNIQUE COAT IDS ARE USED ON USEDATEDTP VALUE +/- A WEEK, THEN IT FILLS THE DGV WITH ALREADY USED COATS
                for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
                {

                    if (i < ds.Tables[0].Rows.Count)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        string fillstring = "Select CoatID,UseDate,OrderType,OrderID,StoreID,ID FROM [AllocationDates]" +
                        "WHERE [AllocationDates].[CoatID] = @CoatID AND [AllocationDates].[UseDate] BETWEEN #" +
                        dateminus.ToString("yyyy/MM/dd") + "# AND #" + dateplus.ToString("yyyy/MM/dd") + "#";
                        var cmdFill = new OleDbCommand(fillstring, conn);
                        cmdFill.Parameters.AddWithValue("@CoatID", int.Parse(row["ID"].ToString()));
                        OleDbDataAdapter adapterfill = new OleDbDataAdapter(cmdFill);
                        DataSet dsfill = new DataSet();
                        adapterfill.Fill(dsfill);
                        try
                        {
                        }
                        catch (System.Exception ex) { };

                        try
                        {
                            DataRow row2 = dsfill.Tables[0].Rows[0];

                            //pass the date from a string in row object back to datetime then to shortdatestring.....
                            string datepass = row2["UseDate"].ToString();
                            DateTime datepass2 = DateTime.Parse(row2["UseDate"].ToString());

                            //grabs the coatID of the last prom order
                            if (row2["OrderType"].ToString() == "P")
                            {
                                coatid[i] = int.Parse(row2["CoatID"].ToString());
                                allocationid[i] = int.Parse(row2["ID"].ToString());
                                ticketnumber[i] = int.Parse(row2["OrderID"].ToString());
                                storeid[i] = int.Parse(row2["StoreID"].ToString());
                            }
                        }
                        catch (System.Exception ex) { }
                        using (OleDbDataReader trialreader = cmdFill.ExecuteReader())
                        {

                            if (trialreader.HasRows)
                            {
                                if (OrderTypeCB.Text == "W")
                                {
                                }
                            }
                            else
                            {
                                //if (OrderTypeCB.Text == "P")
                                //{
                                string UseDate = UseDateDTP.Value.ToShortDateString();
                                string OrderType = OrderTypeCB.Text;
                                string StoreNumber = StoreNumberCB.Text;
                                int OrderID = int.Parse(OrderIDTB.Text);
                                //MessageBox.Show("Coat Availible! Allocation Number:  " + row["CoatNum"] + "-" + row["Size"] + "-" + row["LengthNum"]);
                                int CoatID = int.Parse(row["ID"].ToString());
                                string insertStringLoop = "INSERT INTO [AllocationDates](CoatID,UseDate,OrderType,StoreID,OrderID)VALUES('" + CoatID + "','" + UseDate +
                                    "','" + OrderType + "','" + StoreNumber + "','" + OrderID + "')";
                                var cmdInsert = new OleDbCommand(insertStringLoop, conn);
                                try { cmdInsert.ExecuteNonQuery(); }
                                catch (System.Exception ex) { MessageBox.Show("Unsuccessful Allocation: " + ex.Message); }
                                break;
                                //}
                            }
                        }

                    }
                    if (i == ds.Tables[0].Rows.Count - 1)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        string fillstring = "Select CoatID,UseDate,OrderType,OrderID,StoreID,ID FROM [AllocationDates]" +
                        "WHERE [AllocationDates].[CoatID] = @CoatID AND [AllocationDates].[UseDate] BETWEEN #" +
                        dateminus.ToString("yyyy/MM/dd") + "# AND #" + dateplus.ToString("yyyy/MM/dd") + "#";
                        var cmdFill = new OleDbCommand(fillstring, conn);
                        cmdFill.Parameters.AddWithValue("@CoatID", int.Parse(row["ID"].ToString()));
                        OleDbDataAdapter adapterfill = new OleDbDataAdapter(cmdFill);
                        DataSet dsfill = new DataSet();
                        adapterfill.Fill(dsfill);
                        using (OleDbDataReader trialreader = cmdFill.ExecuteReader())
                        {

                            if (trialreader.HasRows)
                            {
                                if (OrderTypeCB.Text == "W")
                                {
                                    bumporder = true;
                                    allocationnumber = row["CoatNum"] + "-" + row["Size"] + "-" + row["LengthNum"];
                                }
                            }
                            else
                            {
                                if (OrderTypeCB.Text == "P")
                                {
                                    string UseDate = UseDateDTP.Value.ToShortDateString();
                                    string OrderType = OrderTypeCB.Text;
                                    string StoreNumber = StoreNumberCB.Text;
                                    int OrderID = int.Parse(OrderIDTB.Text);
                                    MessageBox.Show("Coat Availible! Allocation Number : " + row["CoatNum"] + "-" + row["Size"] + "-" + row["LengthNum"] + " ");
                                    int CoatID = int.Parse(row["ID"].ToString());
                                    string insertStringLoop = "INSERT INTO [AllocationDates](CoatID,UseDate,OrderType,StoreID,OrderID)VALUES('" + CoatID + "','" + UseDate +
                                        "','" + OrderType + "','" + StoreNumber + "','" + OrderID + "')";
                                    var cmdInsert = new OleDbCommand(insertStringLoop, conn);
                                    try { cmdInsert.ExecuteNonQuery(); }
                                    catch (System.Exception ex) { MessageBox.Show("Unsuccessful Allocation: " + ex.Message); }
                                    break;
                                }

                            }
                        }
                    }

                }
                int coatidmax = 0;
                int maxcoatindex = 0;
                try
                {
                    coatidmax = coatid.Max();
                    maxcoatindex = coatid.ToList().IndexOf(coatidmax);
                }
                catch (System.Exception ex) { }
                if (bumporder == true)
                {
                    string updateString = "UPDATE [AllocationDates] SET [OrderID] = @OrderID, OrderType = 'W' WHERE [ID] =@ID";
                    var updateCmd = new OleDbCommand(updateString, conn);
                    updateCmd.Parameters.AddWithValue("@OrderID", OrderIDTB.Text);
                    updateCmd.Parameters.AddWithValue("@ID", allocationid[maxcoatindex]);
                    adapter.UpdateCommand = updateCmd;
                    try
                    {
                        adapter.UpdateCommand.ExecuteNonQuery();
                        //MessageBox.Show("Wedding Allocation Success! Allocation Number: " + allocationnumber + 
                          //  " Bumped Prom Order: " + ticketnumber[maxcoatindex] + " Please Reallocate now.");
                    }
                    catch (System.Exception ex) { MessageBox.Show("Unsuccessful Allocation: " + ex.Message); }
                    OrderIDTB.Text = ticketnumber[maxcoatindex].ToString();
                    OrderIDTB.Enabled = false;
                    OrderTypeCB.Text = "P";
                    OrderTypeCB.Enabled = false;
                }
                conn.Close();
                //CheckAvailabilityBTN_Click(sender, e);

            }
        }
        //Saving this for later, may still use in ticket
        //private void CoatLengthCLB_ItemCheck(object sender, ItemCheckEventArgs e)
        //{

        //    if (e.NewValue == CheckState.Checked)
        //    {
        //        CoatLengthCLB.SelectedItem = null;

        //        for (int ix = 0; ix < CoatLengthCLB.Items.Count; ++ix)
        //            if (e.Index != ix) CoatLengthCLB.SetItemChecked(ix, false);
        //    }
        //    else
        //    {
        //        CoatLengthCLB.SelectedItem = null;
        //    }
        //}

        private void CoatStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SizeString;
                SizeString = "Select DISTINCT [Size] FROM [MasterCoatSheet] WHERE [MasterCoatSheet].[CoatStyle] = @CoatStyle";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var Sizecmd = new OleDbCommand(SizeString, conn);
                Sizecmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(Sizecmd);
                DataSet Sizeds = new DataSet();
                adapter2.Fill(Sizeds);
                conn.Close();
                CoatSizeCB.DataSource = Sizeds.Tables[0];
                CoatSizeCB.DisplayMember = "Size";
            }
            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }

        }

        private void CoatStyleCB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SizeString;
                SizeString = "Select DISTINCT [Size] FROM [MasterCoatSheet] WHERE [MasterCoatSheet].[CoatStyle] = @CoatStyle";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var Sizecmd = new OleDbCommand(SizeString, conn);
                Sizecmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(Sizecmd);
                DataSet Sizeds = new DataSet();
                adapter2.Fill(Sizeds);
                conn.Close();
                CoatSizeCB.DataSource = Sizeds.Tables[0];
                CoatSizeCB.DisplayMember = "Size";
            }

            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }

        }
        private void CoatStyleMCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SizeString;
                SizeString = "Select DISTINCT [Size] FROM [MasterCoatSheet] WHERE [MasterCoatSheet].[CoatStyle] = @CoatStyle";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var Sizecmd = new OleDbCommand(SizeString, conn);
                Sizecmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(Sizecmd);
                DataSet Sizeds = new DataSet();
                adapter2.Fill(Sizeds);
                conn.Close();
                CoatSizeCB.DataSource = Sizeds.Tables[0];
                CoatSizeCB.DisplayMember = "Size";
            }

            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }
        }
        private void CheckAvailabilityBTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            
            TrialDGV.Visible = true;
             if (int.TryParse(CoatSizeCB.Text, out int x) == false) { MessageBox.Show("Error: Please Enter/Select a Size (Numbers Only)"); CoatSizeCB.Focus(); }
            //In this iteration OrderID only accepts numbers.
            else if (OrderTypeCB.Text == "") { MessageBox.Show("Error: Please Enter/Select the Order Type"); OrderTypeCB.Focus(); }
            else if (CoatStyleCB.Text == "") { MessageBox.Show("Error: Please Enter/Select a Coat Style"); CoatStyleCB.Focus(); }
            //Need Handler for OK Dialogue here

            else
            {
                //Select All the MasterCoatSheet Variables (of the Same Coat Style, Size and Length) to fill dataset
                string queryString;
                queryString = "Select * FROM [MasterCoatSheet]" +
                "WHERE [CoatStyle] = @CoatyStyle AND [Size] = @Size AND [Length] = @Length";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var cmd = new OleDbCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                cmd.Parameters.AddWithValue("@Size", x);
                cmd.Parameters.AddWithValue("@Length", Functions.LengthSel(LengthPanel));
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                //Make datetime variables for between statement
                DateTime dateminus = UseDateDTP.Value.AddDays(-6);
                DateTime dateplus = UseDateDTP.Value.AddDays(+6);
                TrialDGV.Rows.Clear();
                TrialDGV.Columns.Clear();
                TrialDGV.Columns.Add("CoatID", "Coat ID");
                TrialDGV.Columns.Add("UseDate", "Use Date");
                TrialDGV.Columns.Add("TicketNumber", "Ticket Number");
                TrialDGV.Columns.Add("OrderType", "Order Type");
                TrialDGV.Columns.Add("StoreNumber", "Store Number");
                try
                {
                    TrialDGV.Rows.Add(ds.Tables[0].Rows.Count);
                }
                catch (System.Exception ex) { MessageBox.Show("No Coats of this length yet"); }
                //This int grabs price group from the initial coat choice 
                int pricegroup = 0;
                try
                {
                    pricegroup = int.Parse(ds.Tables[0].Rows[0][6].ToString());
                }
                catch (System.Exception ex) { MessageBox.Show("Looks like something went wrong, check your inputs and try again"); }
                //Start New query here for - Selecting All MasterCoatSheetVariables of Coats with same Price Group, Size +/- 1, and Length +/- 1
                string suggestString;
                suggestString = "Select * FROM [MasterCoatSheet]" +
                "WHERE [PriceGroup] = @PriceGroup AND [Size] = @Size AND [Length] = @Length";
                var suggestCmd = new OleDbCommand(suggestString, conn);
                suggestCmd.Parameters.AddWithValue("@PriceGroup", pricegroup);
                suggestCmd.Parameters.AddWithValue("@Size", x);
                suggestCmd.Parameters.AddWithValue("@Length", Functions.LengthSel(LengthPanel));
                OleDbDataAdapter suggestAdapter = new OleDbDataAdapter(suggestCmd);
                DataSet suggestDs = new DataSet();
                suggestAdapter.Fill(suggestDs);
                DataTable suggestDt = suggestDs.Tables[0];
                DGV2.Rows.Clear();
                DGV2.Columns.Clear();
                DGV2.Columns.Add("CoatStyle", "Coat Style");
                DGV2.Columns.Add("Size", "Size");
                DGV2.Columns.Add("AllocationNum", "Allocation Number");
                DGV2.Columns.Add("UseDate", "Use Date");
                DGV2.Columns.Add("TicketNumber", "Ticket Number");
                DGV2.Columns.Add("OrderType", "Order Type"); 
                DGV2.Columns.Add("StoreNumber", "Store Number");
                try
                {
                    DGV2.Rows.Add(suggestDs.Tables[0].Rows.Count);
                }
                catch (System.Exception ex) { MessageBox.Show("No Coats of this length yet"); }
                // int for counting foreach loop
                int ix = 0;
                //this loops through suggestDs and fills DGV with suggested coats
                foreach (DataRow row in suggestDs.Tables[0].Rows)
                {
                    DGV2[0, ix].Value = row["CoatStyle"];
                    string fillstring = "Select CoatID,UseDate,OrderType,OrderID,StoreID,ID FROM [AllocationDates]" +
                        "WHERE [AllocationDates].[CoatID] = @CoatID AND [AllocationDates].[UseDate] BETWEEN #" +
                        dateminus.ToString("yyyy/MM/dd") + "# AND #" + dateplus.ToString("yyyy/MM/dd") + "#";
                    var cmdFill = new OleDbCommand(fillstring, conn);
                    // ************************ BETTER INT PARSE ON ROW ID (try)
                    cmdFill.Parameters.AddWithValue("@CoatID", int.Parse(row["ID"].ToString()));
                    OleDbDataAdapter rowAdapter = new OleDbDataAdapter(cmdFill);
                    DataSet dsfill = new DataSet();
                    rowAdapter.Fill(dsfill);
                    // this try generates Savvi Style Allocation numbers by concat variables from MasterCoatSheet ( really dsSuggest)
                    try
                    {
                        DGV2[1, ix].Value = row["Size"] +" "+ row["Length"];
                        DGV2[2, ix].Value = row["CoatNum"] + "-" + row["Size"] + "-" + row["LengthNum"];
                    }
                    catch (System.Exception ex) { };
                    try
                    {
                        //Why row 0? - because dsfill is a single row dataset! its JUST allocationdates information for THAT coatID on THAT date.
                        DataRow row2 = dsfill.Tables[0].Rows[0];

                        //pass the date from a string in row object back to datetime then to shortdatestring.....
                        string datepass = row2["UseDate"].ToString();
                        DateTime datepass2 = DateTime.Parse(row2["UseDate"].ToString());


                        DGV2[3, ix].Value = datepass2.ToShortDateString();

                        DGV2[4, ix].Value = row2["OrderID"];

                        DGV2[5, ix].Value = row2["OrderType"];

                        DGV2[6, ix].Value = row2["StoreID"];
                    
                    }
                    catch (System.Exception ex) { }
                    ix++;

                }
 
                //This For Loop generates data from Allocation Dates (Where COATID = Unique Coat IDS from MasterCoatSheet and Usedate is within params)
                for (int i = 0; i <= ds.Tables[0].Rows.Count; i++)
                {

                    if (i < ds.Tables[0].Rows.Count)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        string fillstring = "Select CoatID,UseDate,OrderType,OrderID,StoreID,ID FROM [AllocationDates]" +
                        "WHERE [AllocationDates].[CoatID] = @CoatID AND [AllocationDates].[UseDate] BETWEEN #" +
                        dateminus.ToString("yyyy/MM/dd") + "# AND #" + dateplus.ToString("yyyy/MM/dd") + "#";
                        var cmdFill = new OleDbCommand(fillstring, conn);
                        // ************************ BETTER INT PARSE ON ROW ID
                        cmdFill.Parameters.AddWithValue("@CoatID", int.Parse(row["ID"].ToString()));
                        OleDbDataAdapter adapterfill = new OleDbDataAdapter(cmdFill);
                        DataSet dsfill = new DataSet();
                        adapterfill.Fill(dsfill);
                        try
                        {
                            TrialDGV[0, i].Value = row["CoatNum"] + "-" + row["Size"] + "-" + row["LengthNum"] ;
                            //this array catches coatid
                            //coatid[i] = int.Parse(row["ID"].ToString());
                        }
                        catch (System.Exception ex) { };

                        try
                        {
                            DataRow row2 = dsfill.Tables[0].Rows[0];

                            //pass the date from a string in row object back to datetime then to shortdatestring.....
                            string datepass = row2["UseDate"].ToString();
                            DateTime datepass2 = DateTime.Parse(row2["UseDate"].ToString());

                            TrialDGV[1, i].Value = datepass2.ToShortDateString();

                            TrialDGV[2, i].Value = row2["OrderID"];

                            TrialDGV[3, i].Value = row2["OrderType"];

                            TrialDGV[4, i].Value = row2["StoreID"];

                        }
                        catch (System.Exception ex) { }
                    }
                }
            }
        }

        private void CoatSizeCB_TextChanged(object sender, EventArgs e)
        {
            try
            {
               
                //metroPanel2.Controls.Clear();
                string LengthString;
                string coatstyle = CoatStyleCB.Text;
                LengthString = "Select DISTINCT [Length], [LengthNum] FROM [MasterCoatSheet]" +
                "WHERE [CoatStyle] = @CoatStyle AND [Size] = @Size";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var lengthCmd = new OleDbCommand(LengthString, conn);
                lengthCmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                lengthCmd.Parameters.AddWithValue("@Size", int.Parse(CoatSizeCB.Text));
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(lengthCmd);
                DataSet lengthDs = new DataSet();
                adapter2.Fill(lengthDs);
                conn.Close();
                DataView DV = new DataView();
                DataTable Table = lengthDs.Tables[0];
                lengthDs.Tables[0].DefaultView.Sort = "LengthNum ASC";
                DV = lengthDs.Tables[0].DefaultView;
                foreach (DataRow row in Table.Rows) { Console.WriteLine(row["Length"]); }
                
                foreach (DataRowView dataRow in DV)
                {
                    Console.WriteLine(dataRow["Length"]);
                    foreach (Control C in LengthPanel.Controls)
                    {
                        Console.WriteLine(C);
                        if (dataRow["Length"].ToString() == C.Text)
                        {
                           
                        }
                        else C.Visible = false;
                    }
                }
            }

            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }
        }

        private void CoatSizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string LengthString;
                string coatstyle = CoatStyleCB.Text;
                LengthString = "Select DISTINCT [Length], [LengthNum] FROM [MasterCoatSheet]" +
                "WHERE [CoatStyle] = @CoatStyle AND [Size] = @Size";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var lengthCmd = new OleDbCommand(LengthString, conn);
                lengthCmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                lengthCmd.Parameters.AddWithValue("@Size", int.Parse(CoatSizeCB.Text));
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(lengthCmd);
                DataSet lengthDs = new DataSet();
                adapter2.Fill(lengthDs);
                conn.Close();
                DataView DV = new DataView();
                DataTable Table = lengthDs.Tables[0];
                lengthDs.Tables[0].DefaultView.Sort = "LengthNum ASC";
                DV = lengthDs.Tables[0].DefaultView;
                foreach (DataRow row in Table.Rows) { Console.WriteLine(row["Length"]); }
                foreach (DataRowView dataRow in DV)
                {
                    Console.WriteLine(dataRow["Length"]);
                    foreach (Control C in LengthPanel.Controls)
                    {
                        Console.Write(C.ToString());
                        Console.Write(C.Text);
                        if (dataRow["Length"].ToString() == C.Text)
                        {

                        }
                        else C.Visible = false;
                    }

                }
            }

            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }
        }
        private void UseDateDTP_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void OrderTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void TrialBTN_Click(object sender, EventArgs e)
        {

        }

        private void SuggestionBTN_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            if (int.TryParse(CoatSizeCB.Text, out int x) == false) { MessageBox.Show("Error: Please Enter/Select a Size (Numbers Only)"); CoatSizeCB.Focus(); }
            else if (OrderTypeCB.Text == "") { MessageBox.Show("Error: Please Enter/Select the Order Type"); OrderTypeCB.Focus(); }
            else if (CoatStyleCB.Text == "") { MessageBox.Show("Error: Please Enter/Select a Coat Style"); CoatStyleCB.Focus(); }
            string queryString;
            DateTime dateminus = UseDateDTP.Value.AddDays(-6);
            DateTime dateplus = UseDateDTP.Value.AddDays(+6);

            int.TryParse(CoatSizeCB.Text, out int z);
            try
            {
                string groupString;
                groupString = "Select * FROM [MasterCoatSheet]" +
                "WHERE [CoatStyle] = @CoatyStyle AND [Size] = @Size AND [Length] = @Length";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                //NEED TRY FOR PARSE

                var groupCmd = new OleDbCommand(groupString, conn);
                groupCmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                groupCmd.Parameters.AddWithValue("@Size", z);
                groupCmd.Parameters.AddWithValue("@Length", Functions.LengthSel(LengthPanel));
                OleDbDataAdapter groupadapter = new OleDbDataAdapter(groupCmd);
                DataSet groupds = new DataSet();
                groupadapter.Fill(groupds);
                DataTable groupdt = groupds.Tables[0];
                //Make datetime variables for between statement

                //This int grabs price group and lengthnum from the initial coat choice
                int pricegroup = int.Parse(groupds.Tables[0].Rows[0][6].ToString());
                int lengthnum = int.Parse(groupds.Tables[0].Rows[0][5].ToString());

                queryString = "Select CoatStyle, [MasterCoatSheet].[Size], [MasterCoatSheet].[Length], [MasterCoatSheet].[LengthNum] FROM " +
                    "[MasterCoatSheet]" +
                    "WHERE [MasterCoatSheet].[ID] NOT IN (" +
                        "Select [MasterCoatSheet].[ID] FROM " +
                        "[MasterCoatSheet] LEFT OUTER JOIN [AllocationDates] ON [MasterCoatSheet].[ID] = [AllocationDates].[CoatID]" +
                        "WHERE ([AllocationDates].[UseDate] BETWEEN #" + dateminus.ToString("yyyy/MM/dd") + "# AND #" + dateplus.ToString("yyyy/MM/dd") + "#)" +
                        "AND ([MasterCoatSheet].[PriceGroup] = @PriceGroup))" +
                    "AND ([MasterCoatSheet].[Size] BETWEEN @Size -1 AND @Size +1)" +
                    "AND ([MasterCoatSheet].[LengthNum] BETWEEN @lengthnum -1 AND @lengthnum +1)" +

                
                "GROUP BY CoatStyle,[MasterCoatSheet].[Size], [MasterCoatSheet].[Length], [MasterCoatSheet].[LengthNum]" +
                "ORDER BY CoatStyle, [MasterCoatSheet].[LengthNum] ASC";

                var cmd = new OleDbCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@PriceGroup", pricegroup);
                cmd.Parameters.AddWithValue("@Size", z);
                cmd.Parameters.AddWithValue("@lengthnum", lengthnum);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataView dv = new DataView();
                adapter.Fill(ds);
                DGV3.DataSource = ds.Tables[0];
                conn.Close();
                DGV3.Columns.Remove("LengthNum");
                DGV3.Refresh();
            }
            catch (System.Exception ex) { MessageBox.Show("error: " +ex); }
            DGV3.Refresh();
            }
        
        //private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (this.tabControl1.SelectedTab == this.tabPage2)
        //    {
        //        ViewBoardBTN_Click(sender, e);
        //        this.tabControl1.SelectedTab.Controls.Add(this.DGV3);
        //    }
        //    else
        //    {
        //        this.tabControl1.SelectedTab.Controls.Add(this.DGV2);
        //        CheckAvailabilityBTN_Click(sender, e);
        //    }
        //}

        private void StoreNumberCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                return;
            }
            string t = StoreNumberCB.Text;
            string typedT = t.Substring(0, StoreNumberCB.SelectionStart);
            string newT = typedT + e.KeyChar;

            int i = StoreNumberCB.FindString(newT);
            if (i == -1)
            {
                e.Handled = true;
            }
        }

        private void StoreNumberCB_Leave(object sender, EventArgs e)
        {
            bool inList = false;
            foreach (string s in StoreNumberCB.Items)
            {
                if (s == StoreNumberCB.Text)
                {
                    inList = true;
                    break;
                }
            }
            if (!inList)
            {
                StoreNumberCB.Text = "";
            }
        }

        private void OrderTypeCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (OrderTypeCB.Text.Length > 0)
            {
                OrderTypeCB.Text = "";
            }
            bool wp = false;
            
            string str = e.KeyChar.ToString();
            switch (e.KeyChar.ToString())
            {
                case "w":
                    wp = true;
                    break;
                case "W":
                    wp = true;
                    break;
                case "p":
                    wp = true;
                    break;
                case "P":
                    wp = true;
                    break;
            }
            e.Handled = !(wp || e.KeyChar == (char)Keys.Back);
        }

        private void OrderTypeCB_Leave(object sender, EventArgs e)
        {
   

            OrderTypeCB.Text = OrderTypeCB.Text.ToUpper();
        }

        private void OrderTypeCB_TextChanged(object sender, EventArgs e)
        {
        }
        private void DGV2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {

                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.DGV2.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = DGV2.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.DGV2MenuStrip.Show(DGV2, relativeMousePosition);
                }
            }
        }
        private void DGV3_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {

                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.DGV3.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = DGV3.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.DGV2MenuStrip.Show(DGV3, relativeMousePosition);
                }
            }
        }
        private void AllocateRightClick_Click(object sender, EventArgs e)
        {
            AttemptBTN_Click(sender, e);
        }

        private void DGV2MenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void AllocateRightClick_Click_1(object sender, EventArgs e)
        {
            AttemptBTN_Click(sender, e);
        }

        private void OrderIDTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 32 || e.KeyChar > 126)
            {
                return;
            }
            string t = StoreNumberCB.Text;
            string typedT = t.Substring(0, StoreNumberCB.SelectionStart);
            string newT = typedT + e.KeyChar;

            int i = StoreNumberCB.FindString(newT);
            if (i == -1)
            {
                e.Handled = true;
            }
        }

        private void CoatSizeCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MetroFramework.Controls.MetroComboBox cb = (MetroFramework.Controls.MetroComboBox)sender; HOW TO MAKE THIS WORK
            ComboBox cb = (ComboBox)sender;
            cb.DroppedDown = true;
            string strFindStr = "";
            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }
            int intIdx = -1;
            // Search the string in the ComboBox list.
            intIdx = cb.FindString(strFindStr);
            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void CoatSizeCB_Leave(object sender, EventArgs e)
        {
        }

        private void TrialBTN_Click_1(object sender, EventArgs e)
        {

            DGV4.Rows.Clear();
            DGV4.Refresh();
            if(DGV4.ColumnCount>= 0) { DGV4.Columns.Clear(); }

            try
            {
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                DataSet concat = new DataSet();
                ////first I'll grab all the coats
                string queryString1 = "Select * FROM [MasterCoatSheet] ORDER BY [ID] ASC";
                var cmd1 = new OleDbCommand(queryString1, conn);
                OleDbDataAdapter adapter1 = new OleDbDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1);
                
                // This creates a column in the DGV with all the coats
                DataGridViewColumn coatcol = new DataGridViewTextBoxColumn();
                coatcol.HeaderText = "Coat Style";
                DGV4.Columns.Add(coatcol);

                //I add a col here for the allocation numbers in the old style
                DataGridViewColumn numcol = new DataGridViewTextBoxColumn();
                numcol.HeaderText = "Allocation Number";
                DGV4.Columns.Add(numcol);

                int coatcounter = 0;
                foreach (DataRow coatrow in ds1.Tables[0].Rows)
                {
                    DGV4.Rows.Add();
                    DGV4[0, coatcounter].Value = coatrow["CoatStyle"];
                    DGV4[1, coatcounter].Value = coatrow["CoatNum"] + "-" + coatrow["Size"] + "-" +coatrow["LengthNum"];
                    coatcounter++;
                }


                //then I'll grab the dates to create date column headers where allocations are for this year
                DateTime dateminus = DateTime.Now.AddYears(-1);
                DateTime dateplus = DateTime.Now.AddYears(1);
                string queryString2 = "Select DISTINCT UseDate FROM [AllocationDates]" +
                    "WHERE UseDate BETWEEN #" + dateminus + "# AND #" + dateplus +"#";
                var cmd2 = new OleDbCommand(queryString2, conn);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(cmd2);
                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2);

                //this foreach creates date column headers
                foreach (DataRow row in ds2.Tables[0].Rows)
                {

                    try
                    {
                        DateTime saturday = Trial2.Functions.Next(DateTime.Parse(row["UseDate"].ToString()), DayOfWeek.Saturday);
                        row["UseDate"] = saturday;


                    }
                    catch (System.Exception ex) { }
                    {


                    }
                }
                //this is a cool idea, use a dataview to a table
                DataView view = new DataView(ds2.Tables[0]);
                DataTable distinctValues = view.ToTable(true,"UseDate");
                foreach (DataRow row in distinctValues.Rows)
                {
                    DateTime parse = DateTime.Parse(row["UseDate"].ToString());

                    string colhead = parse.ToShortDateString();
                    DataGridViewColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = colhead;
                    int colIndex = DGV4.Columns.Add(col);
                }

                // then I'll grab all the allocated coats, and link them to their weekend column through Next(), eventually printing their records into the DGV linked through CoatID
                //grab allocated coats
                string queryString3 = "select * from " +
                "[mastercoatsheet] left outer join [allocationdates] on [mastercoatsheet].[id] = [allocationdates].[coatid]" +
                "WHERE [allocationdates].[CoatID] is not null";
                var cmd3 = new OleDbCommand(queryString3, conn);
                OleDbDataAdapter adapter3 = new OleDbDataAdapter(cmd3);
                DataSet ds3 = new DataSet();
                adapter3.Fill(ds3);
                string allocationnumber = "";
                string allocationinput = "";
                int counter = 0;
                //check every coat to see if it is allocated
                foreach (DataRow row2 in ds1.Tables[0].Rows)
                {
                    foreach (DataRow row in ds3.Tables[0].Rows)
                    {
                        allocationnumber = row["CoatNum"] + "-" + row["Size"] + "-" + row["LengthNum"];
                        allocationinput = row["StoreID"] + "-" + row["OrderID"] + " " + row["OrderType"];
                        if (row2["ID"].ToString() == row["CoatID"].ToString())
                        {
                            //Console.WriteLine(row2["ID"]);
                            foreach (DataGridViewColumn column in DGV4.Columns)
                            {
                                try
                                {
                                    //this is very slow and suboptimal
                                    DateTime checkdate = DateTime.Parse(column.HeaderText);
                                    if (Trial2.Functions.Next(DateTime.Parse(row["UseDate"].ToString()), DayOfWeek.Saturday) == checkdate)
                                    {
        
                                        DGV4[column.Index,counter].Value = allocationinput;
                                    }
                                }
                                catch (System.Exception ex) { };
                            }
                        }
                    }
                    counter++;
                }
                conn.Close();
                DGV4.Refresh();
            }
            catch (System.Exception ex) { }
        }

        private void TestValBTN_Click(object sender, EventArgs e)
        {
            
            DateTime date1 = UseDateDTP.Value;
            //try
            //{
            //    for (int i = 0; i <= 100000; i++)
            //    {
            //        Random rnd = new Random();
            //        int rndnumber = rnd.Next(0, 999999999);
            //        int rndsize = rnd.Next(36, 39);
                    CoatStyleCB.Text = "Desire";
            //        CoatSizeCB.Text = rndsize.ToString();
            //        CoatLengthCLB.SetItemChecked(0, true);
            //        StoreNumberCB.Text = "9";
            //        OrderIDTB.Text = rndnumber.ToString();
            //        OrderTypeCB.Text = "W";
            //        UseDateDTP.Value = date1.AddSeconds(rndnumber);
            //        AttemptBTN_Click(sender, e);
            //    }
            //}
            //catch (System.Exception ex) { }
            CoatSizeCB.Text = "37";
            
        }

        private void CoatSizeCB_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void CoatStyleMCB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string SizeString;
                SizeString = "Select DISTINCT [Size] FROM [MasterCoatSheet] WHERE [MasterCoatSheet].[CoatStyle] = @CoatStyle";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var Sizecmd = new OleDbCommand(SizeString, conn);
                Sizecmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(Sizecmd);
                DataSet Sizeds = new DataSet();
                adapter2.Fill(Sizeds);
                conn.Close();
                CoatSizeCB.DataSource = Sizeds.Tables[0];
                CoatSizeCB.DisplayMember = "Size";
            }
            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }
        }

        private void CoatSizeMCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LengthPanel.Controls.Clear();
                string LengthString;
                string coatstyle = CoatStyleCB.Text;
                LengthString = "Select DISTINCT [Length], [LengthNum] FROM [MasterCoatSheet]" +
                "WHERE [CoatStyle] = @CoatStyle AND [Size] = @Size";
                const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                var conn = new OleDbConnection(connstr);
                conn.Open();
                var lengthCmd = new OleDbCommand(LengthString, conn);
                lengthCmd.Parameters.AddWithValue("@CoatStyle", CoatStyleCB.Text);
                lengthCmd.Parameters.AddWithValue("@Size", int.Parse(CoatSizeCB.Text));
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(lengthCmd);
                DataSet lengthDs = new DataSet();
                adapter2.Fill(lengthDs);
                conn.Close();
                DataView DV = new DataView();
                DataTable Table = lengthDs.Tables[0];
                lengthDs.Tables[0].DefaultView.Sort = "LengthNum DESC";
                DV = lengthDs.Tables[0].DefaultView;
                MetroRadioButton btn;
                foreach ( DataRowView row in DV)
                {
                    btn = new MetroRadioButton();
                    btn.Text = row["Length"].ToString();
                    LengthPanel.Controls.Add(btn);
                    btn.Dock = DockStyle.Left;
                    btn.Location = new System.Drawing.Point(0, 0);
                    btn.Name = row["Length"] + "BTN";
                    btn.Size = new System.Drawing.Size(40, 30);
                    btn.UseVisualStyleBackColor = true;
                }
            }

            catch (System.Exception ex) { MessageBox.Show("initialError" + ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(Control C in LengthPanel.Controls)
            {
                if(C is MetroFramework.Controls.MetroRadioButton)
                {
                    Console.WriteLine(C.Text);
                }
            }
        }

        private void Radio3_CheckedChanged(object sender, EventArgs e)
        {
            string length;
            if (((RadioButton)sender).Checked == true)
                length = ((RadioButton)sender).Tag.ToString();
        }
    }
    }
    

    

