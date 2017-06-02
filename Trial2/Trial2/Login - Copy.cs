
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using DevComponents.DotNetBar.Metro.ColorTables;
using MetroFramework.Forms;

namespace Trial2
{
    public partial class Login : MetroForm
    {
       
        public Login()
        {
            
            InitializeComponent();
            //DevComponents.DotNetBar.StyleManager.MetroColorGeneratorParameters = new MetroColorGeneratorParameters(Color.IndianRed, Color.IndianRed);
            //this.BackColor = Color.IndianRed;
            //styleManager1.MetroColorGeneratorParameters = new MetroColorGeneratorParameters(Color.WhiteSmoke, Color.DarkOrange);

        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            string CoatString;
            CoatString = "Select Count(*) FROM [Associates] WHERE [Associates].[username] = @user AND [Associates].[password] = @password";
            const string connstr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:/Users/Cody/Documents/Trials.accdb";
            var conn = new OleDbConnection(connstr);
            conn.Open();
            var cmd = new OleDbCommand(CoatString, conn);
            cmd.Parameters.AddWithValue("@user", UsernameTB.Text);
            cmd.Parameters.AddWithValue("@password", PasswordTB.Text);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable DT = new DataTable();
            
            adapter.Fill(DT);
            adapter.Fill(ds);
            if (DT.Rows[0][0].ToString() == "1")
            {
                //this.Hide();
                SplashScreen ss = new SplashScreen();
                ss.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
                UsernameTB.Text = "";
                PasswordTB.Text = "";
            }
        }
        
        private void Login_Load(object sender, EventArgs e)
        {
          // DevComponents.DotNetBar.StyleManager.MetroColorGeneratorParameters = new MetroColorGeneratorParameters(Color.IndianRed, Color.IndianRed);

            //this.BackColor = Color.IndianRed;
        }
    }
}
