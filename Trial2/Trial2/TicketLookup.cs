using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial2

{
    using System.Data;
    using System.Data.OleDb;
    using System.Data.Odbc;

    public partial class TicketLookup : Form
    {


        public TicketLookup()
        {
            InitializeComponent();
        }

        private void TicketLookup_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterTrial.Contact' table. You can move, or remove it, as needed.
            //this.contactTableAdapter.Fill(this.masterTrial.Contact);

        }

        private void OrderIDCHKB_CheckedChanged(object sender, EventArgs e)
        {
            if (OrderIDCHKB.Checked == true)
            { OrderIDTB.Enabled = true; }
            else { OrderIDTB.Enabled = false; }
        }

        private void PartyIDCHKB_CheckedChanged(object sender, EventArgs e)
        {
            if (PartyIDCHKB.Checked == true)
            { PartyIDTB.Enabled = true; }
            else { PartyIDTB.Enabled = false; }
        }

        private void BrideLastCHKB_CheckedChanged(object sender, EventArgs e)
        {
            if (BrideLastCHKB.Checked == true)
            { BrideLastTB.Enabled = true; }
            else { BrideLastTB.Enabled = false; }
        }

        private void TrialDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {

                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.TrialDGV.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = TrialDGV.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.TicketViewCM.Show(TrialDGV, relativeMousePosition);
                }
            }
        }

        private void BrideLastTB_TextChanged(object sender, EventArgs e)
        {

            //THIS IS A MAJOR BREAKTHROUGH IN QUERYING
            string queryString;
            //queryString = "Select [Order].[ID], [Contact].[CustFirst], [Contact].[CustLast],[Contact].[CustPhone1],[Contact].[CustPhone2],[Contact].[CustEmail],[Order].[UseDate],[Order].[BalPaid],[Order].[BalDue],[Order].[Store],[Order].[PUStore] FROM [Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey]=[Order].[ContactKey] WHERE [CustLast] LIKE '%" + BrideLastTB.Text + "%'";

            //doesnt look quite right
            //queryString = "Select * FROM " +
            //    "(([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
            //    "LEFT OUTER JOIN [Styles] ON [Order].[ContactKey]=[Styles].[ContactKey]) " +
            //    "LEFT OUTER JOIN [Measurements] ON [Styles].[ContactKey] = [Measurements].[ContactKey] " +
            //    "WHERE [CustLast] LIKE '%" + BrideLastTB.Text + "%'";
            queryString = "Select * FROM " +
    "(([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
    "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey]) " +
    "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey] " +
    "WHERE [CustLast] LIKE '%" + BrideLastTB.Text + "%'";

            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
            var conn = new OleDbConnection(connstr);
            conn.Open();
            var cmd = new OleDbCommand(queryString, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            TrialDGV.DataSource = ds.Tables[0];
            conn.Close();
            TrialDGV.Refresh();
        }

        private void TrialDGV_SelectionChanged(object sender, EventArgs e)
        {
            try
            {


                foreach (DataGridViewRow row in TrialDGV.SelectedRows)
                {
                    CustFirstTB.Text = row.Cells[1].Value.ToString();
                    CustLastTB.Text = row.Cells[2].Value.ToString();
                    CustAddressTB.Text = row.Cells[3].Value.ToString();
                    CustPhone1TB.Text = row.Cells[4].Value.ToString();
                    CustPhone2TB.Text = row.Cells[5].Value.ToString();
                    CustEmailTB.Text = row.Cells[6].Value.ToString();
                    CustLicenseTB.Text = row.Cells[8].Value.ToString();
                    CityTB.Text = row.Cells[10].Value.ToString();
                    StateTB.Text = row.Cells[11].Value.ToString();
                    ZipTB.Text = row.Cells[12].Value.ToString();
                    OrderDateDT.Text = row.Cells[14].Value.ToString();

                    UseDateDT.Text = row.Cells[15].Value.ToString();
                    FFDateDT.Text = row.Cells[16].Value.ToString();
                    RDateDT.Text = row.Cells[17].Value.ToString();
                    BalPaidTB.Text = row.Cells[18].Value.ToString();
                    BalDueTB.Text = row.Cells[19].Value.ToString();
                    StoreTB.Text = row.Cells[20].Value.ToString();
                    PUStoreTB.Text = row.Cells[21].Value.ToString();
                    TakenByTB.Text = row.Cells[24].Value.ToString();
                    CoatStyleTB.Text = row.Cells[27].Value.ToString();
                    PantStyleTB.Text = row.Cells[28].Value.ToString();
                    SLStyleTB.Text = row.Cells[29].Value.ToString();
                    ShirtStyleTB.Text = row.Cells[30].Value.ToString();
                    PocketSquareStyleTB.Text = row.Cells[37].Value.ToString();
                    SpecialInstructionsTB.Text = row.Cells[38].Value.ToString();
                    ChestSizeTB.Text = row.Cells[41].Value.ToString();
                    OverarmTB.Text = row.Cells[42].Value.ToString();
                    HeightTB.Text = row.Cells[49].Value.ToString();
                    WeightTB.Text = row.Cells[50].Value.ToString();
                    ArmSizeTB.Text = row.Cells[48].Value.ToString();
                    AdjTB.Text = row.Cells[45].Value.ToString();
                    HipTB.Text = row.Cells[43].Value.ToString();
                    ShirtSizeTB.Text = row.Cells[46].Value.ToString() + " " + row.Cells[47].Value.ToString();
                    
                    VestTieCumTB.Text = row.Cells[31].Value.ToString() + " " + row.Cells[34].Value.ToString() + " " + row.Cells[32].Value.ToString() + " " + row.Cells[35].Value.ToString();
                    WaistSizeTB.Text = row.Cells[44].Value.ToString();
                    OutseamTB.Text = row.Cells[52].Value.ToString();
                    NWaistTB.Text = row.Cells[53].Value.ToString();
                    CoatSizeTB.Text = row.Cells[55].Value.ToString() + ' ' + row.Cells[54].Value.ToString();
                    ShoeStyleTB.Text = row.Cells[56].Value.ToString();
                    GroupNameTB.Text = row.Cells[58].Value.ToString();




                }
            }
            catch (System.Exception ex)
            {
            }
        }


        //************************************************* GOOD CODE HERE *********************************
        private void SearchBTN_Click(object sender, EventArgs e)
        {
            if (AndCHKB.Checked)
            {
                if (SearchTerm1CB.SelectedIndex == 0) 
                {
                    if(Search2CB.SelectedIndex == 0) // Cust First + Cust Last
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Contact].[CustFirst] LIKE '%" + Search1TB.Text + "%' AND [Contact].[CustLast] LIKE '%" + Search2TB.Text + "%'";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                    if (Search2CB.SelectedIndex == 1) // Cust First + PartyName
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Weddings].[GroupName] LIKE '%" + Search2TB.Text + "%' AND [Contact].[CustFirst] LIKE '%" + Search1TB.Text + "%'";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                    if (Search2CB.SelectedIndex == 2) // Cust First + Order Date
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Contact].[CustFirst] LIKE '%" + Search1TB.Text + "%' AND [Order].[OrderDate]= #" + Search2DTP.Value.ToString("yyyy/MM/dd") + "#";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    if (Search2CB.SelectedIndex == 3) // Cust First + Use Date
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Contact].[CustFirst] LIKE '%" + Search1TB.Text + "%' AND ([Weddings].[EventDate]= #" + Search2DTP.Value.ToString("yyyy/MM/dd") + "# OR [Order].UseDate =#" + Search2DTP.Value.ToString("yyyy/MM/dd") + "#)";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                }
                if (SearchTerm1CB.SelectedIndex == 1) 
                {

                    if (Search2CB.SelectedIndex == 0) // Cust Last + PartyName
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Weddings].[GroupName] LIKE '%" + Search2TB.Text + "%' AND [Contact].[CustLast] LIKE '%" + Search1TB.Text + "%'";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {

                        }
                    }
                    if (Search2CB.SelectedIndex == 1) // Cust Last + Order Date
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Contact].[CustLast] LIKE '%" + Search1TB.Text + "%' AND [Order].[OrderDate]= #" + Search2DTP.Value.ToString("yyyy/MM/dd") + "#";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    if (Search2CB.SelectedIndex == 2) // Cust Last + Use Date
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Contact].[CustLast] LIKE '%" + Search1TB.Text + "%' AND ([Weddings].[EventDate]= #" + Search2DTP.Value.ToString("yyyy/MM/dd") + "# OR [Order].UseDate =#" + Search2DTP.Value.ToString("yyyy/MM/dd") + "#)";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                }
                if (SearchTerm1CB.SelectedIndex == 2) 
                {

                    if (Search2CB.SelectedIndex == 0) // Party Name + Order Date
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Weddings].[GroupName] LIKE '%" + Search1TB.Text + "%' AND [Order].[OrderDate]= #" + Search2DTP.Value.ToString("yyyy/MM/dd") + "#";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                    if (Search2CB.SelectedIndex == 1) // Party Name+ Use Date
                    {
                        try
                        {
                            string queryString;
                            queryString = "Select * FROM " +
                            "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                            "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                            "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                            "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                            "WHERE [Weddings].[GroupName] LIKE '%" + Search1TB.Text + "%' AND ([Weddings].[EventDate]= #" + Search2DTP.Value.ToString("yyyy/MM/dd") + "# OR [Order].UseDate =#" + Search2DTP.Value.ToString("yyyy/MM/dd") + "#)";
                            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                            var conn = new OleDbConnection(connstr);
                            conn.Open();
                            var cmd = new OleDbCommand(queryString, conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            TrialDGV.DataSource = ds.Tables[0];
                            conn.Close();
                            TrialDGV.Refresh();
                        }
                        catch (System.Exception ex)
                        {
                        }
                    }
                }
                if (SearchTerm1CB.SelectedIndex == 3)
                {

                    if (Search2CB.SelectedIndex == 0) // Order Date + Use Date
                    {

                    }
                }
                if (SearchTerm1CB.SelectedIndex == 4) //Use Date ONLY
                {
                    try
                    {
                        string queryString;
                        queryString = "Select * FROM " +
                        "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                        "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                        "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                        "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                        "WHERE ([Weddings].[EventDate]= #" + Search1DTP.Value.ToString("yyyy/MM/dd") + "# OR [Order].UseDate =#" + Search1DTP.Value.ToString("yyyy/MM/dd") + "#)";
                        const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                        var conn = new OleDbConnection(connstr);
                        conn.Open();
                        var cmd = new OleDbCommand(queryString, conn);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        TrialDGV.DataSource = ds.Tables[0];
                        conn.Close();
                        TrialDGV.Refresh();
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
            }
            else
            {
                if (SearchTerm1CB.SelectedIndex == 0) //Cust First ONLY
                {
                    try
                    {
                        string queryString;
                        queryString = "Select * FROM " +
                        "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                        "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                        "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                        "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                        "WHERE [Contact].[CustFirst] LIKE '%" + Search1TB.Text + "%'";
                        const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                        var conn = new OleDbConnection(connstr);
                        conn.Open();
                        var cmd = new OleDbCommand(queryString, conn);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        TrialDGV.DataSource = ds.Tables[0];
                        conn.Close();
                        TrialDGV.Refresh();
                    }
                    catch (System.Exception ex) { }
                }
                if (SearchTerm1CB.SelectedIndex == 1) //Cust Last ONLY
                {
                    try
                    {
                        string queryString;
                        queryString = "Select * FROM " +
                        "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                        "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                        "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                        "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                        "WHERE [Contact].[CustLast] LIKE '%" + Search1TB.Text + "%'";
                        const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                        var conn = new OleDbConnection(connstr);
                        conn.Open();
                        var cmd = new OleDbCommand(queryString, conn);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        TrialDGV.DataSource = ds.Tables[0];
                        conn.Close();
                        TrialDGV.Refresh();
                    }
                    catch (System.Exception ex) { }
                }
                if (SearchTerm1CB.SelectedIndex == 2) //PartyName ONLY
                {
                    try
                    {
                        string queryString;
                        queryString = "Select * FROM " +
                        "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                        "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                        "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                        "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                        "WHERE [Weddings].[GroupName] LIKE '%" + Search1TB.Text + "%'";
                        const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                        var conn = new OleDbConnection(connstr);
                        conn.Open();
                        var cmd = new OleDbCommand(queryString, conn);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        TrialDGV.DataSource = ds.Tables[0];
                        conn.Close();
                        TrialDGV.Refresh();
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
                if (SearchTerm1CB.SelectedIndex == 3) // Order Date ONLY
                {
                    try
                    {
                        string queryString;
                        queryString = "Select * FROM " +
                        "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                        "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                        "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                        "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                        "WHERE [Order].[OrderDate]= #" + Search1DTP.Value.ToString("yyyy/MM/dd") + "#";
                        const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                        var conn = new OleDbConnection(connstr);
                        conn.Open();
                        var cmd = new OleDbCommand(queryString, conn);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        TrialDGV.DataSource = ds.Tables[0];
                        conn.Close();
                        TrialDGV.Refresh();
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
                if (SearchTerm1CB.SelectedIndex == 4) // Use Date ONLY
                {
                    try
                    {
                        string queryString;
                        queryString = "Select * FROM " +
                        "((([Contact] LEFT OUTER JOIN [Order] ON [Contact].[ContactKey] = [Order].[ContactKey]) " +
                        "LEFT OUTER JOIN [Styles] ON [Contact].[ContactKey]=[Styles].[ContactKey])" +
                        "LEFT OUTER JOIN [Measurements] ON [Contact].[ContactKey] = [Measurements].[ContactKey]) " +
                        "LEFT OUTER JOIN[Weddings] ON[Contact].[EventKey] =[Weddings].[EventKey] " +
                        "WHERE ([Weddings].[EventDate]= #" + Search1DTP.Value.ToString("yyyy/MM/dd") + "# OR [Order].UseDate =#" + Search1DTP.Value.ToString("yyyy/MM/dd") + "#)";
                        const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
                        var conn = new OleDbConnection(connstr);
                        conn.Open();
                        var cmd = new OleDbCommand(queryString, conn);
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        TrialDGV.DataSource = ds.Tables[0];
                        conn.Close();
                        TrialDGV.Refresh();
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
            }
        }

        private void SearchTerm1CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search2TB.Visible = false;
            Search2DTP.Visible = false;
            if (SearchTerm1CB.SelectedIndex == 0)
            {
                Search2CB.Items.Remove("Customer Last Name");
                Search2CB.Items.Remove("Groom / Party Name");
                Search2CB.Items.Remove("Order Date");
                Search2CB.Items.Remove("Use Date");
                Search2CB.Items.Add("Customer Last Name");
                Search2CB.Items.Add("Groom / Party Name");
                Search2CB.Items.Add("Order Date");
                Search2CB.Items.Add("Use Date");
                AndCHKB.Enabled = true;
                Search1TB.Visible = true;
                Search1DTP.Visible = false;

            }
            if (SearchTerm1CB.SelectedIndex == 1)
            {
                Search2CB.Items.Remove("Customer Last Name");
                Search2CB.Items.Remove("Groom / Party Name");
                Search2CB.Items.Remove("Order Date");
                Search2CB.Items.Remove("Use Date");
                Search2CB.Items.Add("Groom / Party Name");
                Search2CB.Items.Add("Order Date");
                Search2CB.Items.Add("Use Date");
                AndCHKB.Enabled = true;
                Search1TB.Visible = true;
                Search1DTP.Visible = false;
            }
            if (SearchTerm1CB.SelectedIndex == 2)
            {
                Search2CB.Items.Remove("Customer Last Name");
                Search2CB.Items.Remove("Groom / Party Name");
                Search2CB.Items.Remove("Order Date");
                Search2CB.Items.Remove("Use Date");
                Search2CB.Items.Add("Order Date");
                Search2CB.Items.Add("Use Date");
                AndCHKB.Enabled = true;
                Search1TB.Visible = true;
                Search1DTP.Visible = false;
            }
            if (SearchTerm1CB.SelectedIndex == 3)
            {
                Search2CB.Items.Remove("Customer Last Name");
                Search2CB.Items.Remove("Groom / Party Name");
                Search2CB.Items.Remove("Order Date");
                Search2CB.Items.Remove("Use Date");
                Search2CB.Items.Add("Use Date");
                AndCHKB.Enabled = true;
                Search1TB.Visible = false;
                Search1DTP.Visible = true;
            }
            if (SearchTerm1CB.SelectedIndex == 4)
            {
                Search2CB.Items.Remove("Customer Last Name");
                Search2CB.Items.Remove("Groom / Party Name");
                Search2CB.Items.Remove("Order Date");
                Search2CB.Items.Remove("Use Date");
                AndCHKB.Checked = false;
                AndCHKB.Enabled = false;
                Search1TB.Visible = false;
                Search1DTP.Visible = true;
            }
        }

        private void Search2CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Search2CB.SelectedItem.ToString() == "Customer Last Name")
            {
                Search2TB.Visible = true;
                Search2DTP.Visible = false;
            }
            if (Search2CB.SelectedItem.ToString() == "Groom / Party Name")
            {
                Search2TB.Visible = true;
                Search2DTP.Visible = false;
            }
            if (Search2CB.SelectedItem.ToString() == "Order Date")
            {
                Search2TB.Visible = false;
                Search2DTP.Visible = true;
            }
            if (Search2CB.SelectedItem.ToString() == "Use Date")
            {
                Search2TB.Visible = false;
                Search2DTP.Visible = true;
            }

        }

        private void AndCHKB_CheckedChanged(object sender, EventArgs e)
        {
            if (AndCHKB.Checked == true)
            {
                Search2CB.Visible = true;

            }
            else
            {
                Search2CB.Text = "";
                Search2CB.Visible = false;
                Search2TB.Visible = false;
                Search2DTP.Visible = false;
            }
        }

        private void MiscPaySMI_Click(object sender, EventArgs e)
        {

        }

        private void TicketPreviewSMI_Click(object sender, EventArgs e)
        {
            //using (TicketPreviewLocked form4 = new TicketPreviewLocked())
            using (TicketPreviewLocked  form4 = new TicketPreviewLocked())
            {
                foreach (DataGridViewRow row in TrialDGV.SelectedRows)
                {
                    // *************** NEEDS EXCEPTION HANDLING *************
                    form4.CustFirstTB.Text = row.Cells[1].Value.ToString();
                    form4.CustLastTB.Text = row.Cells[2].Value.ToString();
                    form4.AddressTB.Text = row.Cells[3].Value.ToString();
                    form4.EmailTB.Text = row.Cells[6].Value.ToString();
                    form4.IDTB.Text = row.Cells[8].Value.ToString();
                    form4.CityTB.Text = row.Cells[10].Value.ToString();
                    form4.StateTB.Text = row.Cells[11].Value.ToString();
                    form4.ZipTB.Text = row.Cells[12].Value.ToString();
                    form4.OrderDateDTP.Text = row.Cells[14].Value.ToString();
                    form4.UseDateDTP.Text = row.Cells[15].Value.ToString();
                    form4.FFDTP.Text = row.Cells[16].Value.ToString();
                    form4.RDateDTP.Text = row.Cells[17].Value.ToString();
                    form4.BalancePaidTB.Text = row.Cells[18].Value.ToString();
                    form4.BalanceDueTB.Text = row.Cells[19].Value.ToString();
                    form4.StoreCB.Text = row.Cells[20].Value.ToString();
                    form4.PUStoreCB.Text = row.Cells[21].Value.ToString();
                    form4.TakenByTB.Text = row.Cells[24].Value.ToString();

                    form4.CoatStyleCB.Text = row.Cells[27].Value.ToString();

                    form4.PantStyleCB.Text = row.Cells[28].Value.ToString();

                    form4.SLStyleCB.Text = row.Cells[29].Value.ToString();
                    form4.ShirtStyleCB.Text = row.Cells[30].Value.ToString();

                    form4.VestStyleCB.Text = row.Cells[31].Value.ToString();

                    form4.TieStyleCB.Text = row.Cells[32].Value.ToString();
                    form4.VestColorCB.Text = row.Cells[34].Value.ToString();
                    form4.TieColorCB.Text = row.Cells[35].Value.ToString();

                    form4.PocketSquareCB.Text = row.Cells[37].Value.ToString();
                    form4.SpecialInstructionsTB.Text = row.Cells[38].Value.ToString();

                    form4.ShoeStyleCB.Text = row.Cells[40].Value.ToString();
                    form4.ChestSizeCB.Text = row.Cells[41].Value.ToString();

                    form4.OverarmCB.Text = row.Cells[42].Value.ToString();

                    form4.HipCB.Text = row.Cells[43].Value.ToString();

                    form4.PantsWaistCB.Text = row.Cells[44].Value.ToString();
                    form4.AdjSizeCB.Text = row.Cells[45].Value.ToString();

                    form4.NeckSizeCB.Text = row.Cells[46].Value.ToString();

                    form4.ShirtSleeveCB.Text = row.Cells[47].Value.ToString();
                    form4.ArmSizeCB.Text = row.Cells[48].Value.ToString();
                    form4.HeightMTB.Text = row.Cells[49].Value.ToString();
                    form4.WeightTB.Text = row.Cells[50].Value.ToString();
                    form4.OutseamCB.Text = row.Cells[52].Value.ToString();
                    form4.NaturalWaistCB.Text = row.Cells[53].Value.ToString();
                    form4.CoatSizeCB.Text = row.Cells[55].Value.ToString();

                    form4.CoatLengthCLB.SelectedItem = row.Cells[54].Value.ToString();
                    form4.ShoeSizeCB.Text = row.Cells[56].Value.ToString();
                    form4.GroupNameTB.Text = row.Cells[58].Value.ToString();
                        form4.Phone1MTB.Text = row.Cells[4].Value.ToString();
                        form4.Phone2MTB.Text = row.Cells[5].Value.ToString();
                    //form4.MiscPaymentBTN.Visible = true;
                    form4.EditDatesBTN.Visible = true;
                    form4.EditStoreBTN.Visible = true;
                    form4.CustFirstTB.Enabled = false;
                    form4.CustLastTB.Enabled = false;
                    form4.StoreCB.Enabled = false;
                    form4.PUStoreCB.Enabled = false;
                    form4.UseDateDTP.Enabled = false;
                    form4.FFDTP.Enabled = false;
                    form4.RDateDTP.Enabled = false;
                    form4.GroupNameTB.Enabled = false;
                    form4.TakenByTB.Enabled = false;
                    form4.EditMeasurementsStylesBTN.Visible = true;
                    form4.AddressTB.Enabled = false;
                    form4.CityTB.Enabled = false;
                    form4.StateTB.Enabled = false;
                    form4.ZipTB.Enabled = false;
                    form4.Phone1MTB.Enabled = false;
                    form4.Phone2MTB.Enabled = false;
                    form4.EmailTB.Enabled = false;
                    form4.IDTB.Enabled = false;
                    form4.HeightMTB.Enabled = false;
                    form4.WeightTB.Enabled = false;
                    form4.CoatStyleCB.Enabled = false;
                    form4.CoatSizeCB.Enabled = false;
                    form4.CoatLengthCLB.Enabled = false;
                    form4.ArmSizeCB.Enabled = false;
                    form4.ChestSizeCB.Enabled = false;
                    form4.OverarmCB.Enabled = false;
                    form4.PantStyleCB.Enabled = false;
                    form4.PantsWaistCB.Enabled = false;
                    form4.NaturalWaistCB.Enabled = false;
                    form4.AdjSizeCB.Enabled = false;
                    form4.OutseamCB.Enabled = false;
                    form4.HipCB.Enabled = false;
                    form4.SpecialInstructionsTB.Enabled = false;
                    form4.PocketSquareCB.Enabled = false;
                    form4.ShirtStyleCB.Enabled = false;
                    form4.NeckSizeCB.Enabled = false;
                    form4.ShirtSleeveCB.Enabled = false;
                    form4.SLStyleCB.Enabled = false;
                    form4.VestStyleCB.Enabled = false;
                    form4.VestColorCB.Enabled = false;
                    form4.TieStyleCB.Enabled = false;
                    form4.TieColorCB.Enabled = false;
                    form4.ShoeSizeCB.Enabled = false;
                    form4.ShoeStyleCB.Enabled = false;
                    //form4.UpdateBTN.Visible = true;
                    if (row.Cells[13].Value.ToString() == "")
                    {
                        form4.FullPriceTB.Enabled = true;
                        form4.DiscountTB.Enabled = true;
                        form4.OrderTotalTB.Enabled = true;
                        form4.BalanceDueTB.Enabled = true;
                        form4.BalancePaidTB.Enabled = true;
                        form4.MiscPaymentBTN.Visible = false;
                    }

                }



                if (form4.ShowDialog() == DialogResult.OK)
                { }
            }
        }


        //UseDate & GroomLast
        //UseDate & CustLast
        //UseDate & CustFirst
        //OrderDate & GroomLast
        //OrderDate & CustLast
        //OrderDate and CustFirst
        //GroomLast & CustLast
        //GroomLast & CustFirst
    }
}
