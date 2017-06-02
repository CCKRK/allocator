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
    public partial class NewWeddingForm : Form
    {
        public NewWeddingForm()
        {
            InitializeComponent();
        }

        private void NewWeddingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterTrial.Contact' table. You can move, or remove it, as needed.
            this.contactTableAdapter.Fill(this.masterTrial.Contact);
            // TODO: This line of code loads data into the 'masterTrial.Weddings' table. You can move, or remove it, as needed.
            this.weddingsTableAdapter.Fill(this.masterTrial.Weddings);

        }
    }
}
