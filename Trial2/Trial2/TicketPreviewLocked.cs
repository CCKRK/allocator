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
    public partial class TicketPreviewLocked : Form
    {
        public TicketPreviewLocked()
        {
            InitializeComponent();
        }

        private void EditStoreBTN_Click(object sender, EventArgs e)
        {
            PUStoreCB.Enabled = true;
        }

        private void EditMeasurementsStylesBTN_Click(object sender, EventArgs e)
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
            PantsWaistCB.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (StyleSelector form4 = new StyleSelector())
            {
                
            }
        }
    }
}
