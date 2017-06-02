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
    public partial class GroomMeasurementTaker : Form
    {
        public GroomMeasurementTaker()
        {
            InitializeComponent();
        }
        public int CoatSize
        {
            get { return int.Parse(CoatSizeCB.Text); }
        }
        public double ArmSize
        {
            get { return double.Parse(ArmSizeCB.Text); }
        }
        public int ChestSize
        {
            get { return int.Parse(ChestCB.Text); }
        }
        public int OverarmSize
        {
            get { return int.Parse(OverarmCB.Text); }
        }
        public int PantWaistSize
        {
            get { return int.Parse(PantsWaistCB.Text); }
        }
        public int AdjSize
        {
            get { return int.Parse(AdjSizeCB.Text); }
        }
        public int NaturalWaist
        {
            get { return int.Parse(NaturalWaistCB.Text); }
        }
        public double OutseamSize
        {
            get { return double.Parse(OutseamCB.Text); }
        }
        public int HipSize
        {
            get { return int.Parse(HipCB.Text); }
        }
        public double NeckSize
        {
            get { return double.Parse(NeckSizeCB.Text); }
        }
        public int ShirtSleeveSize
        {
            get { return int.Parse(ShirtSleeveCB.Text); }
        }
        public double ShoeSize
        {
            get { return double.Parse(ShoeSizeCB.Text); }
        }
        public string HeightSize
        {
            get { return HeightMTB.Text; }
        }
        public int WeightSize
        {
            get { return int.Parse(WeightTB.Text); }
        }
        public string SpecialInstructions
        {
            get { return SpecialInstructionsTB.Text; }
        }
        public int CoatLengthSelected
        {
            get { return CoatLengthCLB.SelectedIndex ; }
        }
        public string CoatLength
        {
            get { return CoatLengthCLB.SelectedItem.ToString(); }
        }


        private void MeasurementTaker_Load(object sender, EventArgs e)
        {

        }

        private void HeightMTB_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

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
        private void ChestCB_Leave(object sender, EventArgs e)
        {

            if (int.TryParse(ChestCB.Text, out int x) is true)
            {
            }
            else if (ChestCB.Text == "")
            { }
            else
            {
                MessageBox.Show("Please Enter a Valid Chest Size (Numbers only)");
                ChestCB.Focus();
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
    }
    }
    

