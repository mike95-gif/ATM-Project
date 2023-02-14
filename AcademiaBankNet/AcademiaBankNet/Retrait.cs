using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaBankNet
{
    public partial class Retrait : Form
    {
        public Retrait()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mikem\Documents\AcademiaATMDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Compt = Login.NoCompte;
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from CompteTbl where NoCompte='" + Compt + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelabel.Text = " Solde Actuel CAD " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void addTransaction()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + retraittxt.Text + ",'" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int newbalance;
        private void button1_Click(object sender, EventArgs e)
        {
            if(retraittxt.Text == "")
            {
                MessageBox.Show("Information Manquante");
            }else if (Convert.ToInt32(retraittxt.Text) <= 0)
            {
                MessageBox.Show("Entrer un Montant");
            }else if(Convert.ToInt32(retraittxt.Text) > bal)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(retraittxt.Text);
                    try
                    {
                        Con.Open();
                        string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Montant retirer avec Succes!");
                        Con.Close();
                        addTransaction();
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Retrait_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this .Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
