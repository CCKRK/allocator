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
    public partial class WeddingRegistry : Form
    {
        public WeddingRegistry()
        {
            InitializeComponent();
            //ADD THREE ROWS TO DGV FOR 3 GUYS NEEDED
            DataGridViewRow row = (DataGridViewRow)PartyInfoDGV.Rows[0].Clone();
            row.Cells[1].Value = "G";

            PartyInfoDGV.Rows.Add(row);
            DataGridViewRow row2 = (DataGridViewRow)PartyInfoDGV.Rows[0].Clone();
            row2.Cells[1].Value = "GM";
            PartyInfoDGV.Rows.Add(row2);
            PartyInfoDGV[1, 2].Value = "GM";
        }
        // NEED EXCEPTION HANDLING FOR EVERYTHING

        public int GroomCoatSize
        {
            get;
            set;
        } = 0;
        public string CoatLength
        {
            get;
            set;
        } = string.Empty;
        public string SpecialInstructions
        {
            get;
            set;
        } = string.Empty;
        public int CoatLengthSelected
        {
            get;
            set;
        } = 0;
        public double ArmSize
        {
            get;
            set;
        } = 0;

        public int ChestSize
        {
            get;
            set;
        } = 0;

        public int OverarmSize
        {
            get;
            set;
        } = 0;

        public int PantWaistSize
        {
            get;
            set;
        } = 0;

        public int NaturalWaistSize
        {
            get;
            set;
        } = 0;

        public int AdjSize
        {
            get;
            set;
        } = 0;

        public double OutseamSize
        {
            get;
            set;
        } = 0;

        public int HipSize
        {
            get;
            set;
        } = 0;

        public double NeckSize
        {
            get;
            set;
        } = 0;

        public int ShirtSleeveSize
        {
            get;
            set;
        } = 0;

        public double ShoeSize
        {
            get;
            set;
        } = 0;

        public string HeightSize
        {
            get;
            set;
        } = string.Empty;

        public int WeightSize
        {
            get;
            set;
        } = 0;
        public string GroomCoatStyle
        {
            get;
            set;
        } = string.Empty;
        public string GPantStyle
        {
            get;
            set;
        } = string.Empty;
        public string GShirtStyle
        {
            get;
            set;
        } = string.Empty;
        public string GSLStyle
        {
            get;
            set;
        } = string.Empty;
        public string GVestStyle
        {
            get;
            set;
        } = string.Empty;
        public string GVestColor
        {
            get;
            set;
        } = string.Empty;
        public string GTieStyle
        {
            get;
            set;
        } = string.Empty;
        public string GTieColor
        {
            get;
            set;
        } = string.Empty;
        public string GShoeStyle
        {
            get;
            set;
        } = string.Empty;
        public string GSpecialInstructions
        {
            get;
            set;
        } = string.Empty;

        //Init public variables for GM/u/F/RB/O styles... this is bad code.

        public string GMCoatStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMPantStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMShirtStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMSLStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMVestStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMVestColor
        {
            get;
            set;
        } = string.Empty;
        public string GMTieStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMTieColor
        {
            get;
            set;
        } = string.Empty;
        public string GMShoeStyle
        {
            get;
            set;
        } = string.Empty;
        public string GMSpecialInstructions
        {
            get;
            set;
        } = string.Empty;
        public string UCoatStyle
        {
            get;
            set;
        } = string.Empty;
        public string UPantStyle
        {
            get;
            set;
        } = string.Empty;
        public string UShirtStyle
        {
            get;
            set;
        } = string.Empty;
        public string USLStyle
        {
            get;
            set;
        } = string.Empty;
        public string UVestStyle
        {
            get;
            set;
        } = string.Empty;
        public string UVestColor
        {
            get;
            set;
        } = string.Empty;
        public string UTieStyle
        {
            get;
            set;
        } = string.Empty;
        public string UTieColor
        {
            get;
            set;
        } = string.Empty;
        public string UShoeStyle
        {
            get;
            set;
        } = string.Empty;
        public string USpecialInstructions
        {
            get;
            set;
        } = string.Empty;
        public string FCoatStyle
        {
            get;
            set;
        } = string.Empty;
        public string FPantStyle
        {
            get;
            set;
        } = string.Empty;
        public string FShirtStyle
        {
            get;
            set;
        } = string.Empty;
        public string FSLStyle
        {
            get;
            set;
        } = string.Empty;
        public string FVestStyle
        {
            get;
            set;
        } = string.Empty;
        public string FVestColor
        {
            get;
            set;
        } = string.Empty;
        public string FTieStyle
        {
            get;
            set;
        } = string.Empty;
        public string FTieColor
        {
            get;
            set;
        } = string.Empty;
        public string FShoeStyle
        {
            get;
            set;
        } = string.Empty;
        public string FSpecialInstructions
        {
            get;
            set;
        } = string.Empty;
        public string RBCoatStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBPantStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBShirtStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBSLStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBVestStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBVestColor
        {
            get;
            set;
        } = string.Empty;
        public string RBTieStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBTieColor
        {
            get;
            set;
        } = string.Empty;
        public string RBShoeStyle
        {
            get;
            set;
        } = string.Empty;
        public string RBSpecialInstructions
        {
            get;
            set;
        } = string.Empty;
        public string OCoatStyle
        {
            get;
            set;
        } = string.Empty;
        public string OPantStyle
        {
            get;
            set;
        } = string.Empty;
        public string OShirtStyle
        {
            get;
            set;
        } = string.Empty;
        public string OSLStyle
        {
            get;
            set;
        } = string.Empty;
        public string OVestStyle
        {
            get;
            set;
        } = string.Empty;
        public string OVestColor
        {
            get;
            set;
        } = string.Empty;
        public string OTieStyle
        {
            get;
            set;
        } = string.Empty;
        public string OTieColor
        {
            get;
            set;
        } = string.Empty;
        public string OShoeStyle
        {
            get;
            set;
        } = string.Empty;
        public string OSpecialInstructions
        {
            get;
            set;
        } = string.Empty;


        private void WeddingRegistry_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterTrial.Measurements' table. You can move, or remove it, as needed.

            Guid guid = Guid.NewGuid();
            string str = guid.ToString();
            EventKeyTB.Text = str;
            // TODO: This line of code loads data into the 'masterTrial.PantView' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'masterTrial.Weddings' table. You can move, or remove it, as needed.
            PricingDGV.Rows.Add();
            PricingDGV.Rows.AddCopies(0, 3);
            PricingDGV[0, 0].Value = "A";
            //PricingDGV.Rows.Add();

            PricingDGV[0, 1].Value = "B";
            //PricingDGV.Rows.Add();
            PricingDGV[0, 2].Value = "C";
           // PricingDGV.Rows.Add();
            PricingDGV[0, 3].Value = "D";
           // PricingDGV.Rows.Add();
        }
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            //Unique Identifier in public class
            Guid guid = Guid.NewGuid();
            string contactkey = guid.ToString();
            string firstname;
            string lastname;
            string CoatStyle;
            string PantStyle;
            string SLStyle;
            string ShirtStyle;
            string VestStyle;
            string VestColor;
            string TieStyle;
            string TieColor;
            string PocketSquare;
            string ShoeStyle;


            using (TicketLockedExceptPrices form4 = new TicketLockedExceptPrices())
            {
                // *************** NEEDS EXCEPTION HANDLING *************
                form4.CustFirstTextBox.Text = GroomFirstTB.Text;
                form4.CustLastTextBox.Text = GroomLastTB.Text;
                form4.AddressTextBox.Text = GroomAddressTB.Text;
                form4.CityTB.Text = GroomCityTB.Text;
                form4.StateTB.Text = GroomStateTB.Text;
                form4.ZipTB.Text = GroomZipTB.Text;
                form4.Phone1MTB.Text = GroomPhone1TB.Text;
                form4.Phone2MTB.Text = GroomPhone2TB.Text;
                form4.StoreCB.Text = StoreCB.Text;
                form4.PUStoreCB.Text = StoreCB.Text;
                form4.UseDateDTP.Text = EventDateDTP.Text;
                form4.RDateDTP.Text = RDateDTB.Text;
                form4.FFDTP.Text = FFDTP.Text;
                form4.TakenByTB.Text = RegByTB.Text;
                form4.GroupNameTB.Text = GroomLastTB.Text;
                //****************************************************************
                form4.CoatCB.Text = GroomCoatStyle;
                form4.PantsCB.Text = GPantStyle;
                form4.SLCB.Text = GSLStyle;
                form4.ShirtCB.Text = GShirtStyle;
                form4.VestColorCB.Text = GVestColor;
                form4.VestStyleCB.Text = GVestStyle;
                form4.TieStyleCB.Text = GTieStyle;
                form4.TieColorCB.Text = GTieColor;
                form4.SpecialInstructionsTB.Text = GSpecialInstructions;
                form4.ShoeStyleCB.Text = GShoeStyle;
                form4.CoatSizeCB.Text = GroomCoatSize.ToString();
                form4.PantsWaistCB.Text = PantWaistSize.ToString();
                form4.ArmSizeCB.Text = ArmSize.ToString();
                form4.ChestCB.Text = ChestSize.ToString();
                form4.OverarmCB.Text = OverarmSize.ToString();
                form4.NaturalWaistCB.Text = NaturalWaistSize.ToString();
                form4.AdjSizeCB.Text = AdjSize.ToString();
                form4.OutseamCB.Text = OutseamSize.ToString();
                form4.HipCB.Text = HipSize.ToString();
                form4.NeckSizeCB.Text = NeckSize.ToString();
                form4.ShirtSleeveCB.Text = ShirtSleeveSize.ToString();
                form4.ShoeSizeCB.Text = ShoeSize.ToString();
                form4.HeightMTB.Text = HeightSize.ToString();
                form4.WeightTB.Text = WeightSize.ToString();
                form4.SpecialInstructionsTB.Text = SpecialInstructions;
                form4.CoatLengthCLB.SelectedIndex = CoatLengthSelected;
                form4.IDTB.Text = GroomLicenseTB.Text;
                if (form4.ShowDialog() == DialogResult.OK)
                {
                    int balancedue = 0;
                    int balancepaid = 0;
                    if (int.TryParse(form4.BalanceDueTB.Text,out int x))
                    {
                        balancedue = int.Parse(form4.BalanceDueTB.Text);
                    }
                    if (int.TryParse(form4.BalancePaidTB.Text, out x)) 
                    {
                        balancepaid = int.Parse(form4.BalanceDueTB.Text);
                    }
                
                    string paymenttype = form4.PaymentTypeCLB.SelectedItem.ToString();
                    //if (PartyInfoDGV[5, 0].Value is null)
                    //{
                    //    GroomCoatStyle = "";
                    //}
                    //else
                    //{
                    //    GroomCoatStyle = PartyInfoDGV[5, 0].Value.ToString();
                    //}
                    if (int.TryParse(GroomZipTB.Text, out int GroomZip))
                    {
                    }
                    if (int.TryParse(GroomPhone1TB.Text, out int GroomPhone1)) { }
                    if (int.TryParse(GroomPhone2TB.Text, out int GroomPhone2)) { }
                    //////////this.contactTableAdapter.Insert(PartyInfoDGV[3, 0].Value.ToString(), PartyInfoDGV[4, 0].Value.ToString(), GroomAddressTB.Text, GroomPhone1TB.Text,GroomPhone2TB.Text, GroomEmailTB.Text, contactkey,GroomLicenseTB.Text, EventKeyTB.Text, GroomCityTB.Text, GroomStateTB.Text, GroomZip);
                    //////////this.stylesTableAdapter.Insert(GroomCoatStyle, GPantStyle, GSLStyle, GShirtStyle, GVestStyle, GTieStyle, contactkey, GVestColor, GTieColor, "needpocketsquare", "needpocketsquare", GSpecialInstructions,GShoeStyle);
                    //////////this.measurementsTableAdapter.Insert(ChestSize, OverarmSize, HipSize, PantWaistSize, AdjSize, NeckSize, ShirtSleeveSize, ArmSize, HeightSize, WeightSize, contactkey, OutseamSize, NaturalWaistSize, CoatLength, GroomCoatSize, ShoeSize);

                    for (int i = 1; i < this.PartyInfoDGV.NewRowIndex; i++)
                    {
                        Guid loopguid = Guid.NewGuid();
                        string contactloop = loopguid.ToString();
                        // I assume these ifs are for unnamed groomsmen to pass their info to contact list

                        if (PartyInfoDGV[3, i].Value == null)
                        {

                            firstname = "";
                        }
                        else
                        {
                            firstname = PartyInfoDGV[3, i].Value.ToString();
                        }
                        if (PartyInfoDGV[4, i].Value == null)
                        {
                            lastname = "";
                        }
                        else
                        {
                            lastname = PartyInfoDGV[4, i].Value.ToString();
                        }
                        if (PartyInfoDGV[5, i].Value is null)
                        {
                            CoatStyle = "";
                        }
                        else
                        {
                            CoatStyle = PartyInfoDGV[5, i].Value.ToString();
                        }
                        if (PartyInfoDGV[6, i].Value is null)
                        {
                            PantStyle = "";
                        }
                        else
                        {
                            PantStyle = PartyInfoDGV[6, i].Value.ToString();
                        }
                        if (PartyInfoDGV[7, i].Value is null)
                        {
                            ShirtStyle = "";
                        }
                        else
                        {
                            ShirtStyle = PartyInfoDGV[7, i].Value.ToString();
                        }
                        if (PartyInfoDGV[8, i].Value is null)
                        {
                            SLStyle = "";
                        }
                        else
                        {
                            SLStyle = PartyInfoDGV[8, i].Value.ToString();
                        }
                        if (PartyInfoDGV[9, i].Value is null)
                        {
                            VestStyle = "";
                        }
                        else
                        {
                            VestStyle = PartyInfoDGV[9, i].Value.ToString();
                        }
                        if (PartyInfoDGV[11, i].Value is null)
                        {
                            TieStyle = "";
                        }
                        else
                        {
                            TieStyle = PartyInfoDGV[11, i].Value.ToString();
                        }
                        if (PartyInfoDGV[10, i].Value is null)
                        {
                            VestColor = "";
                        }
                        else
                        {
                            VestColor = PartyInfoDGV[10, i].Value.ToString();
                        }
                        if (PartyInfoDGV[12, i].Value is null)
                        {
                            TieColor = "";
                        }
                        else
                        {
                            TieColor = PartyInfoDGV[14, i].Value.ToString();
                        }
                        if (PartyInfoDGV[14, i].Value is null)
                        {
                            SpecialInstructions = "";
                        }
                        else
                        {
                            SpecialInstructions= PartyInfoDGV[14, i].Value.ToString();
                        }
                        if (PartyInfoDGV[13, i].Value is null)
                        {
                            ShoeStyle = "";
                        }
                        else
                        {
                            ShoeStyle = PartyInfoDGV[13, i].Value.ToString();
                        }
                        ////this.contactTableAdapter.Insert(firstname, lastname, "", "", "", "", contactloop, "", EventKeyTB.Text, "", "", 0);
                        ////needs handler for null styles
                        // this line has errors for SpecialInstructions, need better Pocketsquare, NeedShoestyle
                        ////this.stylesTableAdapter.Insert(CoatStyle, PantStyle, SLStyle, ShirtStyle, VestStyle, TieStyle, contactloop, VestColor, TieColor, "needpocketsquare", "needpocketsquare",SpecialInstructions,ShoeStyle);
                    }
                    ////this.weddingsTableAdapter.Insert(GroomLastTB.Text, EventDateDTP.Value.Date, EventKeyTB.Text);
                    ////this.orderTableAdapter.Insert(OrderDateDTP.Value.Date, EventDateDTP.Value.Date, FFDTP.Value.Date, RDateDTB.Value.Date, balancepaid, balancedue, StoreCB.Text, StoreCB.Text, EventKeyTB.Text, contactkey, RegByTB.Text, paymenttype);
                    MessageBox.Show("Update Successful");
                    Close();

                }
            }

        }

        private void PartyInfoDGV_RowsAdded(object sender, System.Windows.Forms.DataGridViewRowsAddedEventArgs e)
        {
            PartyNumberTB.Text = this.PartyInfoDGV.NewRowIndex.ToString();
            //Automatically populate as a GM
            if (e.RowIndex >= 2)
            {
                PartyInfoDGV[1, e.RowIndex - 1].Value = "GM";
            }
            if (e.RowIndex is 1)
            {

            }

            if (e.RowIndex is 2)
            {
            }



        }
        //Autopopulate GroomsName
        private void GroomFirstTB_TextChanged(object sender, EventArgs e)
        {
            PartyInfoDGV[3, 0].Value = GroomFirstTB.Text;
        }

        private void GroomLastTB_TextChanged(object sender, EventArgs e)
        {
            PartyInfoDGV[4, 0].Value = GroomLastTB.Text;
        }

        private void PartyInfoDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex is 1 & e.RowIndex >= 2)
            { //foreach (DataGridViewRow row in PartyInfoDGV.Rows)
              //{
                if (PartyInfoDGV[1, e.RowIndex].Value is "GM")
                {
                    PartyInfoDGV[5, e.RowIndex].Value = GMCoatStyle;
                    PartyInfoDGV[6, e.RowIndex].Value = GMPantStyle;
                    PartyInfoDGV[7, e.RowIndex].Value = GMShirtStyle;
                    PartyInfoDGV[8, e.RowIndex].Value = GMSLStyle;
                    PartyInfoDGV[9, e.RowIndex].Value = GMVestStyle;
                    PartyInfoDGV[10, e.RowIndex].Value = GMVestColor;
                    PartyInfoDGV[11, e.RowIndex].Value = GMTieStyle;
                    PartyInfoDGV[12, e.RowIndex].Value = GMTieColor;
                    PartyInfoDGV[13, e.RowIndex].Value = GMShoeStyle;
                    PartyInfoDGV[14, e.RowIndex].Value = GMSpecialInstructions;

                }
                if (PartyInfoDGV[1, e.RowIndex].Value is "U")
                {
                    PartyInfoDGV[5, e.RowIndex].Value = UCoatStyle;
                    PartyInfoDGV[6, e.RowIndex].Value = UPantStyle;
                    PartyInfoDGV[7, e.RowIndex].Value = UShirtStyle;
                    PartyInfoDGV[8, e.RowIndex].Value = USLStyle;
                    PartyInfoDGV[9, e.RowIndex].Value = UVestStyle;
                    PartyInfoDGV[10, e.RowIndex].Value = UVestColor;
                    PartyInfoDGV[11, e.RowIndex].Value = UTieStyle;
                    PartyInfoDGV[12, e.RowIndex].Value = UTieColor;
                    PartyInfoDGV[13, e.RowIndex].Value = UShoeStyle;
                    PartyInfoDGV[14, e.RowIndex].Value = USpecialInstructions;
                }
                if (PartyInfoDGV[1, e.RowIndex].Value is "F")
                {
                    PartyInfoDGV[5, e.RowIndex].Value = FCoatStyle;
                    PartyInfoDGV[6, e.RowIndex].Value = FPantStyle;
                    PartyInfoDGV[7, e.RowIndex].Value = FShirtStyle;
                    PartyInfoDGV[8, e.RowIndex].Value = FSLStyle;
                    PartyInfoDGV[9, e.RowIndex].Value = FVestStyle;
                    PartyInfoDGV[10, e.RowIndex].Value = FVestColor;
                    PartyInfoDGV[11, e.RowIndex].Value = FTieStyle;
                    PartyInfoDGV[12, e.RowIndex].Value = FTieColor;
                    PartyInfoDGV[13, e.RowIndex].Value = FShoeStyle;
                    PartyInfoDGV[14, e.RowIndex].Value = FSpecialInstructions;
                }
                if (PartyInfoDGV[1, e.RowIndex].Value is "RB")
                {
                    PartyInfoDGV[5, e.RowIndex].Value = RBCoatStyle;
                    PartyInfoDGV[6, e.RowIndex].Value = RBPantStyle;
                    PartyInfoDGV[7, e.RowIndex].Value = RBShirtStyle;
                    PartyInfoDGV[8, e.RowIndex].Value = RBSLStyle;
                    PartyInfoDGV[9, e.RowIndex].Value = RBVestStyle;
                    PartyInfoDGV[10, e.RowIndex].Value = RBVestColor;
                    PartyInfoDGV[11, e.RowIndex].Value = RBTieStyle;
                    PartyInfoDGV[12, e.RowIndex].Value = RBTieColor;
                    PartyInfoDGV[13, e.RowIndex].Value = RBShoeStyle;
                    PartyInfoDGV[14, e.RowIndex].Value = RBSpecialInstructions;
                }
                if (PartyInfoDGV[1, e.RowIndex].Value is "O")
                {
                    PartyInfoDGV[5, e.RowIndex].Value = OCoatStyle;
                    PartyInfoDGV[6, e.RowIndex].Value = OPantStyle;
                    PartyInfoDGV[7, e.RowIndex].Value = OShirtStyle;
                    PartyInfoDGV[8, e.RowIndex].Value = OSLStyle;
                    PartyInfoDGV[9, e.RowIndex].Value = OVestStyle;
                    PartyInfoDGV[10, e.RowIndex].Value = OVestColor;
                    PartyInfoDGV[11, e.RowIndex].Value = OTieStyle;
                    PartyInfoDGV[12, e.RowIndex].Value = OTieColor;
                    PartyInfoDGV[13, e.RowIndex].Value = OShoeStyle;
                    PartyInfoDGV[14, e.RowIndex].Value = OSpecialInstructions;
                }
                //}
            }
        }
        //GroomStyle Button
        private void GroomStylesBTN_Click(object sender, EventArgs e)
        {
            using (StyleSelector form2 = new StyleSelector())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    PartyInfoDGV[5, 0].Value = form2.CoatStyle;
                    PartyInfoDGV[6, 0].Value = form2.PantStyle;
                    PartyInfoDGV[7, 0].Value = form2.ShirtStyle;
                    PartyInfoDGV[8, 0].Value = form2.SLStyle;
                    PartyInfoDGV[9, 0].Value = form2.VestStyle;
                    PartyInfoDGV[10, 0].Value = form2.VestColor;
                    PartyInfoDGV[11, 0].Value = form2.TieStyle;
                    PartyInfoDGV[12, 0].Value = form2.TieColor;
                    PartyInfoDGV[13, 0].Value = form2.ShoeStyle;
                    PartyInfoDGV[14, 0].Value = form2.SpecialInstructions;
                }
                GroomCoatStyle = form2.CoatStyle;
                GPantStyle = form2.PantStyle;
                GShirtStyle = form2.ShirtStyle;
                GSLStyle = form2.SLStyle;
                GVestStyle = form2.VestStyle;
                GVestColor = form2.VestColor;
                GTieStyle = form2.TieStyle;
                GTieColor = form2.TieColor;
                GShoeStyle = form2.ShoeStyle;
                GSpecialInstructions = form2.SpecialInstructions;
            }

        }
        //GM Style BTN
        private void GroomsMenStylesBTN_Click(object sender, EventArgs e)
        {
            using (StyleSelector form2 = new StyleSelector())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in PartyInfoDGV.Rows)
                    {
                        if (row.Cells[1].Value is "GM")
                        {
                            row.Cells["CoatStyleColumn"].Value = form2.CoatStyle;
                            row.Cells["PantStyleColumn"].Value = form2.PantStyle;
                            row.Cells["ShirtStyleColumn"].Value = form2.ShirtStyle;
                            row.Cells["SLStyleColumn"].Value = form2.SLStyle;
                            row.Cells["VestStyleColumn"].Value = form2.VestStyle;
                            row.Cells["VestColorColumn"].Value = form2.VestColor;
                            row.Cells["TieStyleColumn"].Value = form2.TieStyle;
                            row.Cells["TieColorColumn"].Value = form2.TieColor;
                            row.Cells["ShoeStyleColumn"].Value = form2.ShoeStyle;
                            row.Cells["SpecialInstructionsColumn"].Value = form2.SpecialInstructions;
                        }
                    }
                    //terrible code
                    GMCoatStyle = form2.CoatStyle;
                    GMPantStyle = form2.PantStyle;
                    GMShirtStyle = form2.ShirtStyle;
                    GMSLStyle = form2.SLStyle;
                    GMVestStyle = form2.VestStyle;
                    GMVestColor = form2.VestColor;
                    GMTieStyle = form2.TieStyle;
                    GMTieColor = form2.TieColor;
                    GMShoeStyle = form2.ShoeStyle;
                    GMSpecialInstructions = form2.SpecialInstructions;
                }
            }
        }

        private void UsherStylesBTN_Click(object sender, EventArgs e)
        {
            using (StyleSelector form2 = new StyleSelector())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in PartyInfoDGV.Rows)
                    {
                        if (row.Cells[1].Value is "U")
                        {
                            row.Cells["CoatStyleColumn"].Value = form2.CoatStyle;
                            row.Cells["PantStyleColumn"].Value = form2.PantStyle;
                            row.Cells["ShirtStyleColumn"].Value = form2.ShirtStyle;
                            row.Cells["SLStyleColumn"].Value = form2.SLStyle;
                            row.Cells["VestStyleColumn"].Value = form2.VestStyle;
                            row.Cells["VestColorColumn"].Value = form2.VestColor;
                            row.Cells["TieStyleColumn"].Value = form2.TieStyle;
                            row.Cells["TieColorColumn"].Value = form2.TieColor;
                            row.Cells["ShoeStyleColumn"].Value = form2.ShoeStyle;
                            row.Cells["SpecialInstructionsColumn"].Value = form2.SpecialInstructions;
                        }
                    }
                    //terrible code
                    UCoatStyle = form2.CoatStyle;
                    UPantStyle = form2.PantStyle;
                    UShirtStyle = form2.ShirtStyle;
                    USLStyle = form2.SLStyle;
                    UVestStyle = form2.VestStyle;
                    UVestColor = form2.VestColor;
                    UTieStyle = form2.TieStyle;
                    UTieColor = form2.TieColor;
                    UShoeStyle = form2.ShoeStyle;
                    USpecialInstructions = form2.SpecialInstructions;
                }
            }
        }

        private void FatherStylesBTN_Click(object sender, EventArgs e)
        {
            using (StyleSelector form2 = new StyleSelector())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in PartyInfoDGV.Rows)
                    {
                        if (row.Cells[1].Value is "F")
                        {
                            row.Cells["CoatStyleColumn"].Value = form2.CoatStyle;
                            row.Cells["PantStyleColumn"].Value = form2.PantStyle;
                            row.Cells["ShirtStyleColumn"].Value = form2.ShirtStyle;
                            row.Cells["SLStyleColumn"].Value = form2.SLStyle;
                            row.Cells["VestStyleColumn"].Value = form2.VestStyle;
                            row.Cells["VestColorColumn"].Value = form2.VestColor;
                            row.Cells["TieStyleColumn"].Value = form2.TieStyle;
                            row.Cells["TieColorColumn"].Value = form2.TieColor;
                            row.Cells["ShoeStyleColumn"].Value = form2.ShoeStyle;
                            row.Cells["SpecialInstructionsColumn"].Value = form2.SpecialInstructions;
                        }
                    }
                    //terrible code
                    FCoatStyle = form2.CoatStyle;
                    FPantStyle = form2.PantStyle;
                    FShirtStyle = form2.ShirtStyle;
                    FSLStyle = form2.SLStyle;
                    FVestStyle = form2.VestStyle;
                    FVestColor = form2.VestColor;
                    FTieStyle = form2.TieStyle;
                    FTieColor = form2.TieColor;
                    FShoeStyle = form2.ShoeStyle;
                    FSpecialInstructions = form2.SpecialInstructions;
                }
            }
        }

        private void RingbearerStylesBTN_Click(object sender, EventArgs e)
        {
            using (StyleSelector form2 = new StyleSelector())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in PartyInfoDGV.Rows)
                    {
                        if (row.Cells[1].Value is "RB")
                        {
                            row.Cells["CoatStyleColumn"].Value = form2.CoatStyle;
                            row.Cells["PantStyleColumn"].Value = form2.PantStyle;
                            row.Cells["ShirtStyleColumn"].Value = form2.ShirtStyle;
                            row.Cells["SLStyleColumn"].Value = form2.SLStyle;
                            row.Cells["VestStyleColumn"].Value = form2.VestStyle;
                            row.Cells["VestColorColumn"].Value = form2.VestColor;
                            row.Cells["TieStyleColumn"].Value = form2.TieStyle;
                            row.Cells["TieColorColumn"].Value = form2.TieColor;
                            row.Cells["ShoeStyleColumn"].Value = form2.ShoeStyle;
                            row.Cells["SpecialInstructionsColumn"].Value = form2.SpecialInstructions;
                        }
                    }
                    //terrible code
                    RBCoatStyle = form2.CoatStyle;
                    RBPantStyle = form2.PantStyle;
                    RBShirtStyle = form2.ShirtStyle;
                    RBSLStyle = form2.SLStyle;
                    RBVestStyle = form2.VestStyle;
                    RBVestColor = form2.VestColor;
                    RBTieStyle = form2.TieStyle;
                    RBTieColor = form2.TieColor;
                    RBShoeStyle = form2.ShoeStyle;
                    RBSpecialInstructions = form2.SpecialInstructions;
                }
            }
        }

        private void OtherStylesBTN_Click(object sender, EventArgs e)
        {
            using (StyleSelector form2 = new StyleSelector())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in PartyInfoDGV.Rows)
                    {
                        if (row.Cells[1].Value is "O")
                        {
                            row.Cells["CoatStyleColumn"].Value = form2.CoatStyle;
                            row.Cells["PantStyleColumn"].Value = form2.PantStyle;
                            row.Cells["ShirtStyleColumn"].Value = form2.ShirtStyle;
                            row.Cells["SLStyleColumn"].Value = form2.SLStyle;
                            row.Cells["VestStyleColumn"].Value = form2.VestStyle;
                            row.Cells["VestColorColumn"].Value = form2.VestColor;
                            row.Cells["TieStyleColumn"].Value = form2.TieStyle;
                            row.Cells["TieColorColumn"].Value = form2.TieColor;
                            row.Cells["ShoeStyleColumn"].Value = form2.ShoeStyle;
                            row.Cells["SpecialInstructionsColumn"].Value = form2.SpecialInstructions;
                        }
                    }
                    //terrible code
                    OCoatStyle = form2.CoatStyle;
                    OPantStyle = form2.PantStyle;
                    OShirtStyle = form2.ShirtStyle;
                    OSLStyle = form2.SLStyle;
                    OVestStyle = form2.VestStyle;
                    OVestColor = form2.VestColor;
                    OTieStyle = form2.TieStyle;
                    OTieColor = form2.TieColor;
                    OShoeStyle = form2.ShoeStyle;
                    OSpecialInstructions = form2.SpecialInstructions;
                }
            }
        }

        private void EventDateDTP_ValueChanged(object sender, EventArgs e)
        {
            FFDTP.Value = EventDateDTP.Value.AddDays(-2);
            RDateDTB.Value = EventDateDTP.Value.AddDays(+1);
        }

        private void GroomMeasurementsBTN_Click(object sender, EventArgs e)
        {
            using (GroomMeasurementTaker form3 = new GroomMeasurementTaker())
            {
                form3.CustFirstTextBox.Text = GroomFirstTB.Text;
                form3.CustLastTextBox.Text = GroomLastTB.Text;
                form3.AddressTextBox.Text = GroomAddressTB.Text;
                form3.CityTB.Text = GroomCityTB.Text;
                form3.StateTB.Text = GroomStateTB.Text;
                form3.ZipTB.Text = GroomZipTB.Text;
                if (PartyInfoDGV[5, 0].Value is null)
                {
                    GroomCoatStyle = "";
                }
                else
                {
                    GroomCoatStyle = PartyInfoDGV[5, 0].Value.ToString();
                }
                form3.CoatCB.Text = GroomCoatStyle;
                if (PartyInfoDGV[6, 0].Value is null)
                {
                    GPantStyle = "";
                }
                else
                {
                    GPantStyle = PartyInfoDGV[6, 0].Value.ToString();
                }
                if (PartyInfoDGV[7, 0].Value is null)
                {
                    GShirtStyle = "";
                }
                else
                {
                    GShirtStyle = PartyInfoDGV[7, 0].Value.ToString();
                }
                if (PartyInfoDGV[8, 0].Value is null)
                {
                    GSLStyle = "";
                }
                else
                {
                    GSLStyle = PartyInfoDGV[8, 0].Value.ToString();
                }
                if (PartyInfoDGV[9, 0].Value is null)
                {
                    GVestStyle = "";
                }
                else
                {
                    GVestStyle = PartyInfoDGV[9, 0].Value.ToString();
                }
                if (PartyInfoDGV[10, 0].Value is null)
                {
                    GVestColor = "";
                }
                else
                {
                    GVestColor = PartyInfoDGV[10, 0].Value.ToString();
                }
                if (PartyInfoDGV[11, 0].Value is null)
                {
                    GTieStyle = "";
                }
                else
                {
                    GTieStyle = PartyInfoDGV[11, 0].Value.ToString();
                }
                if (PartyInfoDGV[12, 0].Value is null)
                {
                    GTieColor = "";
                }
                else
                {
                    GTieColor = PartyInfoDGV[12, 0].Value.ToString();
                }
                if (PartyInfoDGV[13, 0].Value is null)
                {
                    GShoeStyle = "";
                }
                else
                {
                    GShoeStyle = PartyInfoDGV[13, 0].Value.ToString();
                }
                if (PartyInfoDGV[14, 0].Value is null)
                {
                    GSpecialInstructions = "";
                }
                else
                {
                    GSpecialInstructions = PartyInfoDGV[14, 0].Value.ToString();
                }
                form3.CoatCB.Text = GroomCoatStyle;
                form3.PantsCB.Text = GPantStyle;
                form3.SLCB.Text = GSLStyle;
                form3.ShirtCB.Text = GShirtStyle;
                form3.VestColorCB.Text = GVestColor;
                form3.VestStyleCB.Text = GVestStyle;
                form3.TieStyleCB.Text = GTieStyle;
                form3.TieColorCB.Text = GTieColor;
                form3.SpecialInstructionsTB.Text = GSpecialInstructions;
                form3.ShoeStyleCB.Text = GShoeStyle;
                //PartyInfoDGV[12, 0].Value = form2.TieColor;
                //PartyInfoDGV[13, 0].Value = form2.ShoeStyle;
                //PartyInfoDGV[14, 0].Value = form2.SpecialInstructions;

                if (form3.ShowDialog() == DialogResult.OK)
                {
                    GroomCoatSize = form3.CoatSize;
                    PantWaistSize = form3.PantWaistSize;
                    ArmSize = form3.ArmSize;
                    ChestSize = form3.ChestSize;
                    OverarmSize = form3.OverarmSize;
                    NaturalWaistSize = form3.NaturalWaist;
                    AdjSize = form3.AdjSize;
                    OutseamSize = form3.OutseamSize;
                    HipSize = form3.HipSize;
                    NeckSize = form3.NeckSize;
                    ShirtSleeveSize = form3.ShirtSleeveSize;
                    ShoeSize = form3.ShoeSize;
                    HeightSize = form3.HeightSize;
                    WeightSize = form3.WeightSize;
                    SpecialInstructions = form3.SpecialInstructions;
                    CoatLengthSelected = form3.CoatLengthSelected;
                    CoatLength = form3.CoatLength;
                    



                }

            }
        }

        private void PreviewBTN_Click(object sender, EventArgs e)
        {
            //using (TicketPreviewLocked form4 = new TicketPreviewLocked())
            //{
            //    // *************** NEEDS EXCEPTION HANDLING *************
            //    form4.CustFirstTextBox.Text = GroomFirstTB.Text;
            //    form4.CustLastTextBox.Text = GroomLastTB.Text;
            //    form4.AddressTextBox.Text = GroomAddressTB.Text;
            //    form4.CityTB.Text = GroomCityTB.Text;
            //    form4.StateTB.Text = GroomStateTB.Text;
            //    form4.ZipTB.Text = GroomZipTB.Text;
            //    form4.Phone1MTB.Text = GroomPhone1TB.Text;
            //    form4.Phone2MTB.Text = GroomPhone2TB.Text;
            //    form4.StoreCB.Text = StoreCB.Text;
            //    form4.PUStoreCB.Text = StoreCB.Text;
            //    form4.UseDateDTP.Text = EventDateDTP.Text;
            //    form4.RDateDTP.Text = RDateDTB.Text;
            //    form4.FFDTP.Text = FFDTP.Text;
            //    form4.TakenByTB.Text = RegByTB.Text;
            //    form4.GroupNameTB.Text = GroomLastTB.Text;
            ////****************************************************************
            //    form4.CoatCB.Text = GroomCoatStyle;
            //    form4.PantsCB.Text = GPantStyle;
            //    form4.SLCB.Text = GSLStyle;
            //    form4.ShirtCB.Text = GShirtStyle;
            //    form4.VestColorCB.Text = GVestColor;
            //    form4.VestStyleCB.Text = GVestStyle;
            //    form4.TieStyleCB.Text = GTieStyle;
            //    form4.TieColorCB.Text = GTieColor;
            //    form4.SpecialInstructionsTB.Text = GSpecialInstructions;
            //    form4.ShoeStyleCB.Text = GShoeStyle;
            //    form4.CoatSizeCB.Text = GroomCoatSize.ToString();
            //    form4.PantsWaistCB.Text = PantWaistSize.ToString();
            //    form4.ArmSizeCB.Text = ArmSize.ToString();
            //    form4.ChestCB.Text = ChestSize.ToString();
            //    form4.OverarmCB.Text = OverarmSize.ToString();
            //    form4.NaturalWaistCB.Text = NaturalWaistSize.ToString();
            //    form4.AdjSizeCB.Text = AdjSize.ToString();
            //    form4.OutseamCB.Text = OutseamSize.ToString();
            //    form4.HipCB.Text = HipSize.ToString();
            //    form4.NeckSizeCB.Text = NeckSize.ToString();
            //    form4.ShirtSleeveCB.Text = ShirtSleeveSize.ToString();
            //    form4.ShoeSizeCB.Text = ShoeSize.ToString();
            //    form4.HeightMTB.Text = HeightSize.ToString();
            //    form4.WeightTB.Text = WeightSize.ToString();
            //    form4.SpecialInstructionsTB.Text = SpecialInstructions;
            //    form4.CoatLengthCLB.SelectedIndex = CoatLengthSelected;
            //    form4.IDTB.Text = GroomLicenseTB.Text;
                
            //    if (form4.ShowDialog() == DialogResult.OK)
            //    {
            //        //string contactkey = "asdasdadsadds";
            //        //string queryString;
            //        //queryString = "INSERT INTO [Measurements] (Chest,Overarm,Hip,Waist,Adjust,Neck,ShirtSleeve,ArmSize,Height,Weight," +
            //        //    "Contactkey,Outseam,NaturalWaist,CoatLength,CoatSize,ShoeSize) values ('" +
            //        //    ChestSize + "','" + OverarmSize + "','" + HipSize + "','"+ PantWaistSize + "','" + AdjSize + "','" +
            //        //    double.Parse(NeckSize) + "','" + ShirtSleeveSize + "','" + double.Parse(ArmSize) + "','" + WeightSize  + "','" + WeightSize + "','"
            //        //    + contactkey + "','" + double.Parse(OutseamSize) + "','" + NaturalWaistSize + "','" + "R" + "','" + GroomCoatSize + "','" + double.Parse(ShoeSize) +"')";

            //        //const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
            //        //var conn = new OleDbConnection(connstr);
            //        //conn.Open();
            //        //var cmd = new OleDbCommand(queryString, conn);
            //        //cmd.ExecuteNonQuery();
            //        //conn.Close();


            //        //OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //        //DataSet ds = new DataSet();
            //        //adapter.Fill(ds);
            //        //conn.Close();
                    
                   
            //    }

            }

        private void PricingDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex  > 1)

                {
                    try
                    {//int exceptions for pricing
                        double regprice = double.Parse(PricingDGV[1, e.RowIndex].Value.ToString());
                        double discount = double.Parse(PricingDGV[2, e.RowIndex].Value.ToString());
                        double pocketsquare = 0;
                        double deductions = 0;
                        double upgrades = 0;
                        if (PricingDGV[4, e.RowIndex].Value is null) { }


                        else pocketsquare = double.Parse(PricingDGV[4, e.RowIndex].Value.ToString());
                        if (PricingDGV[5, e.RowIndex].Value is null) { }


                        else upgrades = double.Parse(PricingDGV[5, e.RowIndex].Value.ToString());
                        if (PricingDGV[6, e.RowIndex].Value is null) { }


                        else deductions = double.Parse(PricingDGV[6, e.RowIndex].Value.ToString());

                        PricingDGV[3, e.RowIndex].Value = regprice - discount;
                        PricingDGV[7, e.RowIndex].Value = regprice - discount + upgrades + pocketsquare - deductions;
                        PricingDGV[8, e.RowIndex].Value = regprice - discount + upgrades + pocketsquare - deductions + 30;
                    }
                    catch ( System.Exception ex)
                    {
                        MessageBox.Show("Error - Invalid Value Detected in Pricing List (Numbers only)");
                    }

                }
            }
        }
    }
    }

