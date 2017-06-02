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
    public partial class OrderTypeSelector : Form
    {
        public OrderTypeSelector()
        {
            InitializeComponent();
        }

        private void SingleOrderBTN_Click(object sender, EventArgs e)
        {
            SOTicket frm = new SOTicket();
            frm.InsertBTN.Visible = true;

            frm.Show();
            Close();
        }
    }
}
