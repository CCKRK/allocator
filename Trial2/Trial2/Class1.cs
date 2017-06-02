using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trial2
{
    
    public static class Functions
    //Im going to start adding extension methods here
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
        //this is an extension method to help grab the next weekend from allocationdates
        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }
        public static string LengthSel(MetroFramework.Controls.MetroPanel Panel)
        {
            string value = "";
                MetroFramework.Controls.MetroRadioButton checkedRadioButton;
                checkedRadioButton = Panel.Controls.OfType<MetroFramework.Controls.MetroRadioButton>().FirstOrDefault(n => n.Checked);
            try
            {
                value = checkedRadioButton.Text;
            }  //string value = checkedRadioButton.Text;
            catch (System.Exception ex) { MessageBox.Show("Please Select a Coat Length"); }
            return value;
            

        }

    }
    
    static class DataGridViewExtension
    {
        public static void AddCustomRow(this DataGridView dgv, object[] values, object tag = null)
        {
            int Index = dgv.Rows.Add(values);

            // Add a tag if one has been specified
            if (tag != null)
            {
                DataGridViewRow row = dgv.Rows[Index];
                row.Tag = tag;
            }
        }

        public static void AddCustomRow(this DataGridView dgv, string text, object tag = null)
        {
            AddCustomRow(dgv, new object[] { text }, tag);
        }
    }
}
