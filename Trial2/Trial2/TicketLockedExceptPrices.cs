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
    public partial class TicketLockedExceptPrices : Form
    {
        public TicketLockedExceptPrices()
        {
            InitializeComponent();
        }
        public int BalanceDue
        { get; set; } = 0;
        public int BalancePaid { get; set; } = 0;
        private void OverarmCB_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        private void FullPriceTB_TextChanged(object sender, EventArgs e)
        {
            int subtotal;
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
            subtotal = fullprice - discount;
            PriceTB.Text = Convert.ToString(subtotal);
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
        private void BalancePaidTB_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(BalancePaidTB.Text, out int x) is true)
            {
                PaymentTypeCLB.Focus();
            }
            else
            {
                MessageBox.Show("Please Enter a Valid Balance Paid (Numbers Only >0)");
                BalancePaidTB.Focus();
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
            if (int.TryParse(PantsWaistCB.Text, out int x) is true)
            {
            }
            else if (PantsWaistCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Input(Numbers only)");
                PantsWaistCB.Focus();
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


    }
}
