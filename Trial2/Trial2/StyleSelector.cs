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
    public partial class StyleSelector : Form
    {
        public StyleSelector()
        {
            InitializeComponent();
            //Populate ComboBoxes
            ////////////////MasterTrial.MasterStyleListDataTable newCoatStyle;
            ////////////////newCoatStyle = masterStyleListTableAdapter.GetCoatStyle();
            ////////////////CoatStyleCB.DataSource = newCoatStyle;
            ////////////////CoatStyleCB.DisplayMember = "CoatStyle";
            ////////////////MasterTrial.MasterStyleListDataTable newPantStyle;
            ////////////////newPantStyle = masterStyleListTableAdapter.GetPantStyle();
            ////////////////PantStyleCB.DataSource = newPantStyle;
            ////////////////PantStyleCB.DisplayMember = "PantStyle";
            ////////////////MasterTrial.MasterStyleListDataTable newShirtStyle;
            ////////////////newShirtStyle = masterStyleListTableAdapter.GetShirtStyle();
            ////////////////ShirtStyleCB.DataSource = newShirtStyle;
            ////////////////ShirtStyleCB.DisplayMember = "ShirtStyle";
            ////////////////MasterTrial.MasterStyleListDataTable newVestStyle;
            ////////////////newVestStyle = masterStyleListTableAdapter.GetVestStyle();
            ////////////////VestStyleCB.DataSource = newVestStyle;
            ////////////////VestStyleCB.DisplayMember = "VestStyle";
            ////////////////MasterTrial.MasterStyleListDataTable newTieStyle;
            ////////////////newTieStyle = masterStyleListTableAdapter.GetTieStyle();
            ////////////////TieStyleCB.DataSource = newTieStyle;
            ////////////////TieStyleCB.DisplayMember = "TieStyle";
            ////////////////MasterTrial.MasterStyleListDataTable newSLStyle;
            ////////////////newSLStyle = masterStyleListTableAdapter.GetSLStyle();
            ////////////////SLStyleCB.DataSource = newSLStyle;
            ////////////////SLStyleCB.DisplayMember = "SLStyle";
            ////////////////MasterTrial.MasterStyleListDataTable newShoeStyle;
            ////////////////newShoeStyle = masterStyleListTableAdapter.GetShoeStyle();
            ////////////////ShoeStyleCB.DataSource = newShoeStyle;
            ////////////////ShoeStyleCB.DisplayMember = "ShoeStyle";
        }
        //Public Strings to return the selected items to another form
        public string CoatStyle
        {
            get { return CoatStyleCB.Text; }
        }
        public string PantStyle
        {
            get { return PantStyleCB.Text; }
        }
        public string ShirtStyle
        {
            get { return ShirtStyleCB.Text; }
        }
        public string SLStyle
        {
            get { return SLStyleCB.Text; }
        }
        public string VestStyle
        {
            get { return VestStyleCB.Text; }
        }
        public string VestColor
        {
            get { return VestColorCB.Text; }
        }
        public string TieStyle
        {
            get { return TieStyleCB.Text; }
        }
        public string TieColor
        {
            get { return TieColorCB.Text; }
        }
        public string ShoeStyle
        {
            get { return ShoeStyleCB.Text; }
        }
        public string PocketSquareStyle
        {
            get { return PocketSquareStyleCB.Text; }
        }
        public string SpecialInstructions
        {
            get { return SpecialTB.Text; }
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveStylesBTN_Click(object sender, EventArgs e)
        {
        }

        private void StyleSelector_Load(object sender, EventArgs e)
        {


        }

        private void VestStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checks VestStyle and populates VestColor
            string str;
            str = VestStyleCB.Text;
            ////////MasterTrial.MasterStyleListDataTable newVestStyle;
            ////////newVestStyle = masterStyleListTableAdapter.GetVestColor(str);
            ////VestColorCB.DataSource = newVestStyle;
            VestColorCB.DisplayMember = "VestColor";
        }

        private void TieStyleCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Checkes TieStyle and populates TieColor
            string str;
            str = TieStyleCB.Text;
            ////////MasterTrial.MasterStyleListDataTable newTieStyle;
            //////newTieStyle = masterStyleListTableAdapter.GetTieColor(str);
            //////TieColorCB.DataSource = newTieStyle;
            TieColorCB.DisplayMember = "TieColor";
        }
    }
}
