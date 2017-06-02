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
    public partial class SOTicket : Form
    {
        public SOTicket()
        {
            InitializeComponent();

        }
        //************************************** SUB NEEDS BETTER MATH FOR BALANCES
        private void TicketForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterTrial1.SLView' table. You can move, or remove it, as needed.

            // THIS CREATES a 'newVestView' table from masterStyleList and the GetDataByVestStyle method parses the column
            //////////////////MasterTrial.MasterStyleListDataTable newCoatStyle;
            //////////////////newCoatStyle = masterStyleListTableAdapter.GetCoatStyle();
            //////////////////CoatStyleCB.DataSource = newCoatStyle;
            //////////////////CoatStyleCB.DisplayMember = "CoatStyle";
            //////////////////MasterTrial.MasterStyleListDataTable newVestView;
            //////////////////newVestView = masterStyleListTableAdapter.GetVestStyle();
            //////////////////VestStyleCB.DataSource = newVestView;
            //////////////////VestStyleCB.DisplayMember = "VestStyle";
            //////////////////VestStyleCB.Text = "";
            //////////////////VestColorCB.Text = "";
            ////////////////////Fills ComboBoxes by Creating newdatatables and getting from table adapters
            //////////////////MasterTrial.MasterStyleListDataTable newTieStyle;
            //////////////////newTieStyle = masterStyleListTableAdapter.GetTieStyle();
            //////////////////TieStyleCB.DataSource = newTieStyle;
            //////////////////TieStyleCB.DisplayMember = "TieStyle";
            //////////////////TieStyleCB.Text = "";
            //////////////////TieColorCB.Text = "";
            //////////////////MasterTrial.MasterStyleListDataTable newSLStyle;
            //////////////////newSLStyle = masterStyleListTableAdapter.GetSLStyle();
            //////////////////SLStyleCB.DataSource = newSLStyle;
            //////////////////SLStyleCB.DisplayMember = "SLStyle";
            //////////////////MasterTrial.MasterStyleListDataTable newPantStyle;
            //////////////////newPantStyle = masterStyleListTableAdapter.GetPantStyle();
            //////////////////PantStyleCB.DataSource = newPantStyle;
            //////////////////PantStyleCB.DisplayMember = "PantStyle";
            //////////////////MasterTrial.MasterStyleListDataTable newShirtStyle;
            //////////////////newShirtStyle = masterStyleListTableAdapter.GetShirtStyle();
            //////////////////ShirtStyleCB.DataSource = newShirtStyle;
            //////////////////ShirtStyleCB.DisplayMember = "ShirtStyle";
            //////////////////MasterTrial.MasterStyleListDataTable newShoeStyle;
            //////////////////newShoeStyle = masterStyleListTableAdapter.GetShoeStyle();
            //////////////////ShoeStyleCB.DataSource = newShoeStyle;
            //////////////////ShoeStyleCB.DisplayMember = "ShoeStyle";
            //////////////////MasterTrial.StoresDataTable newStoreList;
            //////////////////newStoreList = storesTableAdapter.GetData();
            //////////////////StoreCB.DataSource = newStoreList;
            //////////////////StoreCB.DisplayMember = "Store";
            //////////////////MasterTrial.StoresDataTable newPUStoreList;
            //////////////////newPUStoreList = storesTableAdapter.GetData();
            //////////////////PUStoreCB.DataSource = newPUStoreList;
            //////////////////PUStoreCB.DisplayMember = "Store";


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


                //if blocks to test measurements for exceptions (not interger)
                if (int.TryParse(ChestSizeCB.Text, out int chest))
                {
                }
                if (int.TryParse(OverarmCB.Text, out int overarm))
                {
                }
                if (int.TryParse(HipCB.Text, out int hip))
                {
                }
                if (double.TryParse(NeckSizeCB.Text, out double neck))
                {
                }
                if (int.TryParse(ShirtSleeveCB.Text, out int shirtsleeve))
                {
                }
                if (int.TryParse(PantWaistCB.Text, out int waist))
                {
                }
                if (double.TryParse(OutseamCB.Text, out double outseam))
                {
                    outseam = double.Parse(OutseamCB.Text);
                }
                if (double.TryParse(ArmSizeCB.Text, out double ArmSize))
                {
                }
                if (int.TryParse(AdjSizeCB.Text, out int adj))
                {
                }
                if (int.TryParse(ZipTB.Text, out int zip))
                {
                }
                if (int.TryParse(WeightTB.Text, out int weight))
                {
                }
                if (int.TryParse(NaturalWaistCB.Text, out int naturalwaist))
                {
                }
                if (int.TryParse(CoatSizeCB.Text, out int coatsize))
                {
                }
                if (double.TryParse(ShoeSizeCB.Text, out double shoesize))
                {
                }
                //I suppose this is for Balances mathematics and Exception handling ** THIS NEEDS WORK**
                if (MessageBox.Show("Confirm Payment Amount of $" + BalancePaidTB.Text, "Payment Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    double BalPaid = 0;
                    double BalDue = 0;
                    string coatlength = "";

                    if (double.TryParse(BalancePaidTB.Text, out double y))
                    {
                        BalPaid = double.Parse(BalancePaidTB.Text);
                    }
                    if (double.TryParse(BalanceDueTB.Text, out y))
                    {
                        BalDue = double.Parse(BalanceDueTB.Text);
                    }
                    this.Validate();
                    if (CoatLengthCLB.SelectedItem == null)
                    {

                    }
                    else coatlength = CoatLengthCLB.SelectedItem.ToString();
                    if (PaymentTypeCLB.SelectedItem == null)
                    {
                        MessageBox.Show("Payment Type Not Selected");
                        return;
                    }
                    if (BalancePaidTB.Text == "") { MessageBox.Show("Cannot take a ticket with no payment");return; }
                    if (BalPaid <=0 ) { MessageBox.Show("Balance paid must be Nonnegative above 0"); return; }
                    if (BalDue <= 0) { MessageBox.Show("Balance paid must be Nonnegative above 0 (Check if OrderTotal > Balance Paid)"); return; }

                    //Validates and then sends Order Values
                    //////////////////this.orderTableAdapter.Insert(OrderDateDTP.Value.Date, UseDateDTP.Value.Date, FFDTP.Value.Date, RDateDTP.Value.Date, BalPaid, BalDue, PUStoreCB.Text, PUStoreCB.Text,"", str,TakenByTB.Text, PaymentTypeCLB.SelectedItem.ToString());
                    ////////////////////********************************************is this.bindingsource endedit necessary?
                    //////////////////this.orderBindingSource.EndEdit();
                    //////////////////this.contactTableAdapter.Update(this.masterTrial.Contact);
                    //////////////////this.orderTableAdapter.Update(this.masterTrial.Order);
                    ////////////////////this line sends contact info
                    //////////////////this.contactTableAdapter.Insert(CustFirstTB.Text, CustLastTB.Text, AddressTB.Text, Phone1MTB.Text, Phone2MTB.Text, EmailTB.Text, str, IDTB.Text, "", CityTB.Text, StateTB.Text, zip);
                    ////////////////////This line sends measurement info 
                    //////////////////this.measurementsTableAdapter.Insert(chest, overarm, hip, waist, adj, neck, shirtsleeve, ArmSize, HeightMTB.Text, weight, str, outseam, naturalwaist,coatlength , coatsize, shoesize);
                    ////////////////////This line sends style info
                    //////////////////this.stylesTableAdapter1.Insert(CoatStyleCB.Text, PantStyleCB.Text, SLStyleCB.Text, ShirtStyleCB.Text, VestStyleCB.Text, TieStyleCB.Text, str, VestColorCB.Text, TieColorCB.Text, PocketSquareCB.Text, PocketSquareCB.Text, SpecialInstructionsTB.Text,ShoeStyleCB.Text);
                    //////////////////this.contactBindingSource.EndEdit();
                    //////////////////this.measurementsBindingSource.EndEdit();
                    //////////////////this.measurementsTableAdapter.Update(this.masterTrial.Measurements);
                    //////////////////this.contactTableAdapter.Update(this.masterTrial.Contact);
                    MessageBox.Show("Update Successful");
                }
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
                CoatSizeCB.Items.Add("36");
                CoatSizeCB.Items.Add("37");
                CoatSizeCB.Items.Add("38");
                CoatSizeCB.Items.Add("39");
                CoatSizeCB.Items.Add("40");
                CoatSizeCB.Items.Add("41");
                CoatSizeCB.Items.Add("42");
                CoatSizeCB.Items.Add("43");
                CoatSizeCB.Items.Add("44");
                CoatSizeCB.Items.Add("46");
                CoatSizeCB.Items.Add("48");
                CoatSizeCB.Items.Add("50");
                CoatSizeCB.Items.Add("52");
                CoatSizeCB.Items.Add("54");
                CoatSizeCB.Items.Add("56");
                CoatSizeCB.Items.Add("58");
                CoatSizeCB.Items.Add("60");
                CoatSizeCB.Items.Add("62");
                CoatSizeCB.Items.Add("64");
                CoatSizeCB.Items.Add("66");
                CoatSizeCB.Items.Add("68");
                CoatSizeCB.Items.Add("70");
                CoatSizeCB.Items.Add("72");
                CoatSizeCB.Items.Add("74");
                CoatSizeCB.Items.Add("76");
                CoatSizeCB.Items.Remove("3");
                CoatSizeCB.Items.Remove("6");
                CoatSizeCB.Items.Remove("8");
                CoatSizeCB.Items.Remove("10");
                CoatSizeCB.Items.Remove("12");
                CoatSizeCB.Items.Remove("14");
                CoatSizeCB.Items.Remove("16");
                CoatSizeCB.Items.Remove("18");
            }
            else
            {
                CoatSizeCB.Items.Add("3");
                CoatSizeCB.Items.Add("6");
                CoatSizeCB.Items.Add("8");
                CoatSizeCB.Items.Add("10");
                CoatSizeCB.Items.Add("12");
                CoatSizeCB.Items.Add("14");
                CoatSizeCB.Items.Add("16");
                CoatSizeCB.Items.Add("18");
                CoatSizeCB.Items.Remove("36");
                CoatSizeCB.Items.Remove("37");
                CoatSizeCB.Items.Remove("38");
                CoatSizeCB.Items.Remove("39");
                CoatSizeCB.Items.Remove("40");
                CoatSizeCB.Items.Remove("41");
                CoatSizeCB.Items.Remove("42");
                CoatSizeCB.Items.Remove("43");
                CoatSizeCB.Items.Remove("44");
                CoatSizeCB.Items.Remove("46");
                CoatSizeCB.Items.Remove("48");
                CoatSizeCB.Items.Remove("50");
                CoatSizeCB.Items.Remove("52");
                CoatSizeCB.Items.Remove("54");
                CoatSizeCB.Items.Remove("56");
                CoatSizeCB.Items.Remove("58");
                CoatSizeCB.Items.Remove("60");
                CoatSizeCB.Items.Remove("62");
                CoatSizeCB.Items.Remove("64");
                CoatSizeCB.Items.Remove("66");
                CoatSizeCB.Items.Remove("68");
                CoatSizeCB.Items.Remove("70");
                CoatSizeCB.Items.Remove("72");
                CoatSizeCB.Items.Remove("74");
                CoatSizeCB.Items.Remove("76");
            }

        }
        private void FullPriceTB_TextChanged(object sender, EventArgs e)
        {
            double subtotal;
            double discount = 0;
            double fullprice = 0;
            if (double.TryParse(DiscountTB.Text, out double x))
            {
                discount = double.Parse(DiscountTB.Text);
            }
            if (double.TryParse(FullPriceTB.Text, out x))
            {
                fullprice = double.Parse(FullPriceTB.Text);
            }
            subtotal = fullprice - discount;
            OrderTotalTB.Text = Convert.ToString(subtotal);
                }

        private void DiscountTB_TextChanged(object sender, EventArgs e)
        {
            double subtraction;
            double discount = 0;
            double fullprice = 0;
            if (double.TryParse(DiscountTB.Text, out double x))
            {
                discount = double.Parse(DiscountTB.Text);
            }
            if (double.TryParse(FullPriceTB.Text, out x))
            {
                fullprice = double.Parse(FullPriceTB.Text);
            }
            subtraction = fullprice - discount;
            OrderTotalTB.Text = Convert.ToString(subtraction);
        }

        ////////////////private void VestStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        ////////////////{
        ////////////////    //Init a string to grab the match criteria
        ////////////////    string str;
        ////////////////    str = VestStyleCB.Text;


        ////////////////    // THIS CREATES a 'newVestStyle' table from masterStyleList and the GetDataByStr method parses the column Using a ? param
        ////////////////    MasterTrial.MasterStyleListDataTable newVestStyle;

        ////////////////    newVestStyle = masterStyleListTableAdapter.GetVestColor(str);
        ////////////////    VestColorCB.DataSource = newVestStyle;
        ////////////////    VestColorCB.DisplayMember = "VestColor";
        ////////////////}

        ////////////////private void TieStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        ////////////////{
        ////////////////    //Creates newTieStyle table from masterStyleList and the GetDataByStr method parses the column using ? param
        ////////////////    string str;
        ////////////////    str = TieStyleCB.Text;
        ////////////////    MasterTrial.MasterStyleListDataTable newTieStyle;
        ////////////////    newTieStyle = masterStyleListTableAdapter.GetTieColor(str);
        ////////////////    TieColorCB.DataSource = newTieStyle;
        ////////////////    TieColorCB.DisplayMember = "TieColor";
        ////////////////}

        private void BalancePaidTB_TextChanged(object sender, EventArgs e)
        {
       
            double orderprice = 0;
            double subtraction;
            double balpaid = 0;
            if (double.TryParse(BalancePaidTB.Text, out double x))
            {
                balpaid = double.Parse(BalancePaidTB.Text);
            }
            if (double.TryParse(OrderTotalTB.Text, out x))
            {
                orderprice = double.Parse(OrderTotalTB.Text);
            }
            subtraction = orderprice - balpaid;
            BalanceDueTB.Text = Convert.ToString(subtraction);

        }

        private void UseDateDTP_ValueChanged(object sender, EventArgs e)
        {
            FFDTP.Value = UseDateDTP.Value.AddDays(-2);
            RDateDTP.Value = UseDateDTP.Value.AddDays(+1);
        }

        private void Phone1MTB_Enter(object sender, EventArgs e)
        {
            if (Phone1MTB.Text.Length == 0)
            {
                int Phone = Phone1MTB.Text.Length;
                Phone1MTB.SelectionStart = Phone;
            }
        }

        private void Phone2MTB_Enter(object sender, EventArgs e)
        {
            if (Phone2MTB.Text.Length == 0)
            {
                int Phone = Phone2MTB.Text.Length;
                Phone1MTB.SelectionStart = Phone;
            }
        }

        private void Phone1MTB_Click(object sender, EventArgs e)
        {
            if(Phone1MTB.Text.Length == 0)
            {
                int Phone = Phone1MTB.Text.Length;
                Phone1MTB.SelectionStart = Phone;
            }
            else { Phone1MTB.Focus(); }
        }

        private void Phone2MTB_Click(object sender, EventArgs e)
        {
            if (Phone2MTB.Text.Length == 0)
            {
                int Phone = Phone2MTB.Text.Length;
                Phone2MTB.SelectionStart = Phone;
            }
        }

        private void ChestCB_Leave(object sender, EventArgs e)
        {

            if (int.TryParse(ChestSizeCB.Text,out int x) is true)
            {
            }
            else if (ChestSizeCB.Text == "")
            { }
            else 
            {
                MessageBox.Show("Please Enter a Valid Chest Size (Numbers only)");
                ChestSizeCB.Focus();
            }
        }

        private void HeightMTB_Click(object sender, EventArgs e)
        {
            HeightMTB.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (HeightMTB.Text.Length == 0)
            {
                int start = HeightMTB.Text.Length;
                HeightMTB.SelectionStart = start;
            }
            HeightMTB.TextMaskFormat = MaskFormat.IncludeLiterals;
        }

        private void HeightMTB_Enter(object sender, EventArgs e)
        {
            HeightMTB.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (HeightMTB.Text.Length == 0)
            {
                int start = HeightMTB.Text.Length;
                HeightMTB.SelectionStart = start;
            }
            HeightMTB.TextMaskFormat = MaskFormat.IncludeLiterals;
        }

        private void ZipTB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(ZipTB.Text, out int x) is true)
            {
            }
            else if (ZipTB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Zip Code (Numbers only)");
                ZipTB.Focus();
            }
        }

        private void WeightTB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(WeightTB.Text, out int x) is true)
            {
            }
            else if (WeightTB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Weight (Numbers only)");
                WeightTB.Focus();
            }
        }

        private void CoatSizeCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(CoatSizeCB.Text, out int x) is true)
            {
                CoatLengthCLB.Focus();
            }
            else if (CoatSizeCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Coat Size (Numbers only)");
                CoatSizeCB.Focus();
            }
        }

        private void CoatLengthCLB_Leave(object sender, EventArgs e)
        {
            if (CoatLengthCLB.SelectedItem is null)
            {
                MessageBox.Show("Please Enter a Valid Coat Length (Select One)");
                CoatLengthCLB.Focus();
            }
        }

        private void ArmSizeCB_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(ArmSizeCB.Text, out double x) is true)
            {
            }
            else if (ArmSizeCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input (Numbers only)");
                ArmSizeCB.Focus();
            }
        }

        private void OverarmCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(OverarmCB.Text, out int x) is true)
            {
            }
            else if (OverarmCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                OverarmCB.Focus();
            }
        }

        private void PantsWaistCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(PantWaistCB.Text, out int x) is true)
            {
            }
            else if (PantWaistCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                PantWaistCB.Focus();
            }
        }

        private void NaturalWaistCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(NaturalWaistCB.Text, out int x) is true)
            {
            }
            else if (NaturalWaistCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                NaturalWaistCB.Focus();
            }
        }

        private void AdjSizeCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(AdjSizeCB.Text, out int x) is true)
            {
            }
            else if (AdjSizeCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                AdjSizeCB.Focus();
            }
        }

        private void OutseamCB_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(OutseamCB.Text, out double x) is true)
            {
            }
            else if (OutseamCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                OutseamCB.Focus();
            }
        }

        private void HipCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(HipCB.Text, out int x) is true)
            {
            }
            else if (HipCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                HipCB.Focus();
            }
        }

        private void NeckSizeCB_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(NeckSizeCB.Text, out double x) is true)
            {
            }
            else if (NeckSizeCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input (Numbers only)");
                NeckSizeCB.Focus();
            }
        }

        private void ShirtSleeveCB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(ShirtSleeveCB.Text, out int x) is true)
            {
            }
            else if (ShirtSleeveCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                ShirtSleeveCB.Focus();
            }
        }

        private void ShoeSizeCB_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(ShoeSizeCB.Text, out double x) is true)
            {
            }
            else if (ShoeSizeCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                ShoeSizeCB.Focus();
            }
        }

        private void BalancePaidTB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(BalancePaidTB.Text, out int x) is true)
            {
                PaymentTypeCLB.Focus();
            }
        }

        private void PaymentTypeCLB_Leave(object sender, EventArgs e)
        {
            if (PaymentTypeCLB.SelectedItem is null)
            {
                MessageBox.Show("Please Enter a Select a Valid Payment Type (Select One)");
                PaymentTypeCLB.Focus();
            }
        }

        private void EditContactStyleMeasurementsBTN_Click(object sender, EventArgs e)
        {
            AddressTB.Enabled = true;
            CityTB.Enabled = true;
            StateTB.Enabled = true;
            ZipTB.Enabled = true;
            Phone1MTB.Enabled = true;
            Phone2MTB.Enabled = true;
            EmailTB.Enabled = true;
            IDTB.Enabled = true;
            HeightMTB.Enabled = true;
            WeightTB.Enabled = true;
            CoatStyleCB.Enabled = true;
            CoatSizeCB.Enabled = true;
            CoatLengthCLB.Enabled = true;
            ArmSizeCB.Enabled = true;
            ChestSizeCB.Enabled = true;
            OverarmCB.Enabled = true;
            PantStyleCB.Enabled = true;
            PantWaistCB.Enabled = true;
            NaturalWaistCB.Enabled = true;
            AdjSizeCB.Enabled = true;
            OutseamCB.Enabled = true;
            HipCB.Enabled = true;
            SpecialInstructionsTB.Enabled = true;
            PocketSquareCB.Enabled = true;
            ShirtStyleCB.Enabled = true;
            NeckSizeCB.Enabled = true;
            ShirtSleeveCB.Enabled = true;
            SLStyleCB.Enabled = true;
            VestStyleCB.Enabled = true;
            VestColorCB.Enabled = true;
            TieStyleCB.Enabled = true;
            TieColorCB.Enabled = true;
            ShoeSizeCB.Enabled = true;
            ShoeStyleCB.Enabled = true;
        }

        private void EditStoreBTN_Click(object sender, EventArgs e)
        {
            PUStoreCB.Enabled = true;
        }

        private void EditDatesBTN_Click(object sender, EventArgs e)
        {
            UseDateDTP.Enabled = true;
            FFDTP.Enabled = true;
            RDateDTP.Enabled = true;
        }
    }
}

    
