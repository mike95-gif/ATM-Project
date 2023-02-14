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
    public partial class Compte : Form
    {
        public Compte()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mikem\Documents\AcademiaATMDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
           int bal = 0;
            if (NoComptetxt.Text == "" || Nomtxt.Text == "" || Prenomtxt.Text == "" || Adressetxt.Text == "" || Pintxt.Text=="" || Professiontxt.Text =="'" )
            {
                MessageBox.Show("Remplir Champ Obligatoire");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CompteTbl values('" + NoComptetxt.Text + "','" + Nomtxt.Text + "','" + Prenomtxt.Text + "','" + datedeNaissancetxt.Value.Date + "','" + Mobiletxt.Text + "','" + Adressetxt.Text + "','" + Educationtxt.SelectedItem.ToString() + "','" + Professiontxt.Text + "','" + Pintxt.Text + "',"+bal+")";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Compte creer avec succes !!!");
                    Con.Close();    
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
