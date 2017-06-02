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
    public partial class SOTicketForm : Form
    {
        public SOTicketForm()
        {
            InitializeComponent();

        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterTrial1.SLView' table. You can move, or remove it, as needed.
            this.sLViewTableAdapter.Fill(this.masterTrial1.SLView);
            // TODO: This line of code loads data into the 'masterTrial.SLView' table. You can move, or remove it, as needed.
            this.sLViewTableAdapter.Fill(this.masterTrial.SLView);
            // TODO: This line of code loads data into the 'masterTrial.TieView' table. You can move, or remove it, as needed.
            this.tieViewTableAdapter.Fill(this.masterTrial.TieView);
            // TODO: This line of code loads data into the 'masterTrial.ShirtView' table. You can move, or remove it, as needed.
            this.shirtViewTableAdapter.Fill(this.masterTrial.ShirtView);
            // TODO: This line of code loads data into the 'masterTrial.VestView' table. You can move, or remove it, as needed.

            // THIS CREATES a 'newVestView' table from masterStyleList and the GetDataByVestStyle method parses the column
            MasterTrial.MasterStyleListDataTable newVestView;
            newVestView = masterStyleListTableAdapter.GetVestStyle();
            VestStyleCB.DataSource = newVestView;
            VestStyleCB.DisplayMember = "VestStyle";
            //Fills ComboBoxes by Creating newdatatables and getting from table adapters
            MasterTrial.MasterStyleListDataTable newTieStyle;
            newTieStyle = masterStyleListTableAdapter.GetTieStyle();
            TieStyleCB.DataSource = newTieStyle;
            TieStyleCB.DisplayMember = "TieStyle";
            MasterTrial.MasterStyleListDataTable newSLStyle;
            newSLStyle = masterStyleListTableAdapter.GetSLStyle();
            SLCB.DataSource = newSLStyle;
            SLCB.DisplayMember = "SLStyle";
            MasterTrial.MasterStyleListDataTable newPantStyle;
            newPantStyle = masterStyleListTableAdapter.GetPantStyle();
            PantsCB.DataSource = newPantStyle;
            PantsCB.DisplayMember = "PantStyle";
            MasterTrial.MasterStyleListDataTable newShirtStyle;
            newShirtStyle = masterStyleListTableAdapter.GetShirtStyle();
            ShirtCB.DataSource = newShirtStyle;
            ShirtCB.DisplayMember = "ShirtStyle";
            MasterTrial.MasterStyleListDataTable newShoeStyle;
            newShoeStyle = masterStyleListTableAdapter.GetShoeStyle();
            ShoeStyleCB.DataSource = newShoeStyle;
            ShoeStyleCB.DisplayMember = "ShoeStyle";
            MasterTrial.StoresDataTable newStoreList;
            newStoreList = storesTableAdapter.GetData();
            StoreCB.DataSource = newStoreList;
            StoreCB.DisplayMember = "Store";
            MasterTrial.StoresDataTable newPUStoreList;
            newPUStoreList = storesTableAdapter.GetData();
            PUStoreCB.DataSource = newPUStoreList;
            PUStoreCB.DisplayMember = "Store";
            // TODO: This line of code loads data into the 'masterTrial.MasterStyleList' table. You can move, or remove it, as needed.
            this.masterStyleListTableAdapter.Fill(this.masterTrial.MasterStyleList);
            // TODO: This line of code loads data into the 'masterTrial.CoatStyles' table. You can move, or remove it, as needed.
            this.coatStylesTableAdapter.Fill(this.masterTrial.CoatStyles);
            // TODO: This line of code loads data into the 'masterTrial.Stores' table. You can move, or remove it, as needed.
            this.storesTableAdapter.Fill(this.masterTrial.Stores);
            // TODO: This line of code loads data into the 'masterTrial.Order' table. You can move, or remove it, as needed.
            this.orderTableAdapter.Fill(this.masterTrial.Order);
            // TODO: This line of code loads data into the 'masterTrial.Measurements' table. You can move, or remove it, as needed.
            this.measurementsTableAdapter.Fill(this.masterTrial.Measurements);
            // TODO: This line of code loads data into the 'masterTrial.Styles' table. You can move, or remove it, as needed.
            this.stylesTableAdapter1.Fill(this.masterTrial.Styles);
            // TODO: This line of code loads data into the 'masterTrial.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter.Fill(this.masterTrial.Contact);
            // TODO: This line of code loads data into the 'masterTrial.MasterCoatSheet' table. You can move, or remove it, as needed.
            this.masterCoatSheetTableAdapter.Fill(this.masterTrial.MasterCoatSheet);
            // TODO: This line of code loads data into the 'masterTriali1.Order' table. You can move, or remove it, as needed.

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //THIS DIM FOR GLOBAL KEY
                Guid guid = Guid.NewGuid();
                string str = guid.ToString();
                this.orderBindingSource.MoveLast();
                this.Validate();
                //Init int variables for exception handling on measurements
                int chest = 0;
                int overarm = 0;
                int hip = 0;
                int neck = 0;
                int shirtsleeve = 0;
                int waist = 0;
                int adj = 0;
                int outseam = 0;
                int sleeve = 0;
                //if blocks to test measurements for exceptions (not interger)
                if (int.TryParse(ChestCB.Text, out int x))
                {
                    chest = int.Parse(ChestCB.Text);
                }
                if (int.TryParse(OverarmCB.Text, out x))
                {
                    overarm = int.Parse(OverarmCB.Text);
                }
                if (int.TryParse(HipCB.Text, out x))
                {
                    hip = int.Parse(HipCB.Text);
                }
                if (int.TryParse(NeckSizeCB.Text, out x))
                {
                    neck = int.Parse(NeckSizeCB.Text);
                }
                if (int.TryParse(ShirtSleeveCB.Text, out x))
                {
                    shirtsleeve = int.Parse(ShirtSleeveCB.Text);
                }
                if (int.TryParse(PantsWaistCB.Text, out x))
                {
                    waist = int.Parse(PantsWaistCB.Text);
                }
                if (int.TryParse(OutseamCB.Text, out x))
                {
                    outseam = int.Parse(OutseamCB.Text);
                }
                if (int.TryParse(ArmSizeCB.Text, out x))
                {
                    sleeve = int.Parse(ArmSizeCB.Text);
                }
                if (int.TryParse(AdjSizeCB.Text, out x))
                {
                    adj = int.Parse(AdjSizeCB.Text);
                }
                //I suppose this is for Balances mathematics and Exception handling ** THIS NEEDS WORK**
                if (MessageBox.Show("Confirm Payment Amount of $" + BalancePaidTB.Text, "Payment Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int BalPaid = 0;
                    int BalDue = 0;
                    if (int.TryParse(BalancePaidTB.Text, out int y))
                    {
                        BalPaid = int.Parse(BalancePaidTB.Text);
                    }
                    if (int.TryParse(BalanceDueTB.Text, out y))
                    {
                        BalDue = int.Parse(BalanceDueTB.Text);
                    }
                    this.Validate();
                   //Validates and then sends Order Values
                    this.orderTableAdapter.Insert(OrderDateDTP.Value.Date, UseDateDTP.Value.Date, FFDTP.Value.Date, RDateDTP.Value.Date, BalPaid, BalDue, PUStoreCB.Text, PUStoreCB.Text, "0", str);
                    //this.orderBindingSource.MoveLast();
                    //this.contactBindingSource.MoveLast();
                    this.orderBindingSource.EndEdit();
                    this.contactTableAdapter.Update(this.masterTrial.Contact);
                    this.orderTableAdapter.Update(this.masterTrial.Order);
                }
                //this.orderBindingSource.MoveLast();
                this.Validate();
                //This line sends contact info out, **CURRENTLY NEEDS EXCEPTION HANDLING**
                this.contactTableAdapter.Insert(CustFirstTextBox.Text, CustLastTextBox.Text, AddressTextBox.Text,Phone1MTB.Text ,Phone2MTB.Text, EmailTB.Text, str,IDTB.Text);
                //This line sends measurement info ** CURRENTLY NEEDS EXCEPTION HANDLING FOR HEIGHT AND WEIGHT**
                this.measurementsTableAdapter.Insert(chest, overarm, hip, waist, adj, neck, shirtsleeve, sleeve, HeightCB.Text, int.Parse(WeightCB.Text), str);
                //This line sends style info, however, ** HOW ARE VEST AND TIES HANDLING? WHAT IS RETURN? **
                this.stylesTableAdapter1.Insert(CoatCB.Text, PantsCB.Text, SLCB.Text, ShirtCB.Text, VestStyleCB.Text + VestColorCB.Text, TieStyleCB.Text + TieColorCB.Text, str);
                this.contactBindingSource.EndEdit();
                this.measurementsBindingSource.EndEdit();
                this.measurementsTableAdapter.Update(this.masterTrial.Measurements);
                this.contactTableAdapter.Update(this.masterTrial.Contact);
                MessageBox.Show("Update Successful");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Update failed" + ex);
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox7.Items.Add("36");
                comboBox7.Items.Add("37");
                comboBox7.Items.Add("38");
                comboBox7.Items.Add("39");
                comboBox7.Items.Add("40");
                comboBox7.Items.Add("41");
                comboBox7.Items.Add("42");
                comboBox7.Items.Add("43");
                comboBox7.Items.Add("44");
                comboBox7.Items.Add("46");
                comboBox7.Items.Add("48");
                comboBox7.Items.Add("50");
                comboBox7.Items.Add("52");
                comboBox7.Items.Add("54");
                comboBox7.Items.Add("56");
                comboBox7.Items.Add("58");
                comboBox7.Items.Add("60");
                comboBox7.Items.Add("62");
                comboBox7.Items.Add("64");
                comboBox7.Items.Add("66");
                comboBox7.Items.Add("68");
                comboBox7.Items.Add("70");
                comboBox7.Items.Add("72");
                comboBox7.Items.Add("74");
                comboBox7.Items.Add("76");
                comboBox7.Items.Remove("3");
                comboBox7.Items.Remove("6");
                comboBox7.Items.Remove("8");
                comboBox7.Items.Remove("10");
                comboBox7.Items.Remove("12");
                comboBox7.Items.Remove("14");
                comboBox7.Items.Remove("16");
                comboBox7.Items.Remove("18");
            }
            else
            {
                comboBox7.Items.Add("3");
                comboBox7.Items.Add("6");
                comboBox7.Items.Add("8");
                comboBox7.Items.Add("10");
                comboBox7.Items.Add("12");
                comboBox7.Items.Add("14");
                comboBox7.Items.Add("16");
                comboBox7.Items.Add("18");
                comboBox7.Items.Remove("36");
                comboBox7.Items.Remove("37");
                comboBox7.Items.Remove("38");
                comboBox7.Items.Remove("39");
                comboBox7.Items.Remove("40");
                comboBox7.Items.Remove("41");
                comboBox7.Items.Remove("42");
                comboBox7.Items.Remove("43");
                comboBox7.Items.Remove("44");
                comboBox7.Items.Remove("46");
                comboBox7.Items.Remove("48");
                comboBox7.Items.Remove("50");
                comboBox7.Items.Remove("52");
                comboBox7.Items.Remove("54");
                comboBox7.Items.Remove("56");
                comboBox7.Items.Remove("58");
                comboBox7.Items.Remove("60");
                comboBox7.Items.Remove("62");
                comboBox7.Items.Remove("64");
                comboBox7.Items.Remove("66");
                comboBox7.Items.Remove("68");
                comboBox7.Items.Remove("70");
                comboBox7.Items.Remove("72");
                comboBox7.Items.Remove("74");
                comboBox7.Items.Remove("76");
            }

        }
        private void FullPriceTB_TextChanged(object sender, EventArgs e)
        {
            int sweet;
            int discount = 0;
            int fullprice = 0;
            if (int.TryParse(DiscountTB.Text, out int x))
            {
                discount = int.Parse(DiscountTB.Text);
            }
            if (int.TryParse(FullPriceTB.Text, out x))
            {
                fullprice = int.Parse(FullPriceTB.Text);
            }
            sweet = fullprice - discount;
            PriceTB.Text = Convert.ToString(sweet);
                }

        private void DiscountTB_TextChanged(object sender, EventArgs e)
        {
            int subtraction;
            int discount = 0;
            int fullprice = 0;
            if (int.TryParse(DiscountTB.Text, out int x))
            {
                discount = int.Parse(DiscountTB.Text);
            }
            if (int.TryParse(FullPriceTB.Text, out x))
            {
                fullprice = int.Parse(FullPriceTB.Text);
            }
            subtraction = fullprice - discount;
            PriceTB.Text = Convert.ToString(subtraction);
        }

        private void VestStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Init a string to grab the match criteria
            string str;
            str = VestStyleCB.Text;


            // THIS CREATES a 'newVestStyle' table from masterStyleList and the GetDataByStr method parses the column Using a ? param
            MasterTrial.MasterStyleListDataTable newVestStyle;

            newVestStyle = masterStyleListTableAdapter.GetVestColor(str);
            VestColorCB.DataSource = newVestStyle;
            VestColorCB.DisplayMember = "VestColor";
        }

        private void TieStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creates newTieStyle table from masterStyleList and the GetDataByStr method parses the column using ? param
            string str;
            str = TieStyleCB.Text;
            MasterTrial.MasterStyleListDataTable newTieStyle;
            newTieStyle = masterStyleListTableAdapter.GetTieColor(str);
            TieColorCB.DataSource = newTieStyle;
            TieColorCB.DisplayMember = "TieColor";
        }

        private void BalancePaidTB_TextChanged(object sender, EventArgs e)
        {
       
            int orderprice = 0;
            int subtraction;
            int balpaid = 0;
            if (int.TryParse(BalancePaidTB.Text, out int x))
            {
                balpaid = int.Parse(BalancePaidTB.Text);
            }
            if (int.TryParse(PriceTB.Text, out x))
            {
                orderprice = int.Parse(PriceTB.Text);
            }
            subtraction = orderprice - balpaid;
            BalanceDueTB.Text = Convert.ToString(subtraction);

        }
    }
    }
