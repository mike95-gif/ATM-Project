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
    public partial class FastCash : Form
    {
        public FastCash()
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

        private void label7_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void FastCash_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        /* int montant1=100,
             montant2=200,
             montant3=300,
             montant4=20,
             montant5=40,
             montant6=80;*/
        private void addTransaction1()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + 100 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction2()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + 200 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction3()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + 300 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction4()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + 20 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction5()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + 40 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void addTransaction6()
        {
            string TrType = "retrait";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','" + TrType + "'," + 80 + ",'" + DateTime.Today.Date.ToString() + "')";
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (bal < 100)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {
               int  newbalance = bal - 100;
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant retirer avec Succes!");
                    Con.Close();
                    addTransaction1();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 20)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {
                int newbalance = bal - 20;
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant retirer avec Succes!");
                    Con.Close();
                    addTransaction4();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 200)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {
                int newbalance = bal - 200;
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant retirer avec Succes!");
                    Con.Close();
                    addTransaction2();  
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bal < 40)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {
                int newbalance = bal - 40;
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant retirer avec Succes!");
                    Con.Close();
                    addTransaction5();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (bal < 300)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {
                int newbalance = bal - 300;
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant retirer avec Succes!");
                    Con.Close();
                    addTransaction3();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (bal < 80)
            {
                MessageBox.Show("Solde Insuffisant");
            }
            else
            {  
                int newbalance = bal - 80;
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant retirer avec Succes!");
                    Con.Close();
                    addTransaction6();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
