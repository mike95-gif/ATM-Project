using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AcademiaBankNet
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mikem\Documents\AcademiaATMDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Compt = Login.NoCompte;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Pin1txt.Text == "" || Pin2txt.Text == "")
            {
                MessageBox.Show("Entrer votre nouveau PIN ");
            }
            else if (Pin2txt.Text != Pin1txt.Text)
            {
                MessageBox.Show("PINS ne se match pas");
            }
            else
            {

                try
                {
                    Con.Open();
                    string query = "update CompteTbl set PIN = " + Pin1txt.Text + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Mise a Jour Avec succes");
                    Con.Close();
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ChangePin_Load(object sender, EventArgs e)
        {

        }
    }
}
