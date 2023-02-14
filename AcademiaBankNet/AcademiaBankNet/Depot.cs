using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaBankNet
{
    public partial class Depot : Form
    {
        public Depot()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mikem\Documents\AcademiaATMDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Compt = Login.NoCompte;
        private void addTransaction()
        {
            string TrType= "Depot";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Compt + "','"+ TrType + "'," + Depottxt.Text + ",'"+DateTime.Today.Date.ToString()+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
               // MessageBox.Show("Compte creer avec succes !!!");
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
            if (Depottxt.Text == "" || Convert.ToInt32(Depottxt.Text)<=0)
            {
                MessageBox.Show("Entrer le MOntant a Deposer");
            }
            else
            {
                
                newbalance = oldbalance + Convert.ToInt32(Depottxt.Text);
                try
                {
                    Con.Open();
                    string query = "update CompteTbl set Balance = " + newbalance + " where NoCompte='" + Compt + "'";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Montant Deposer avec Succes!");
                    Con.Close();
                    addTransaction();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Home home= new Home();
            home.Show();
            this.Hide();
        }
        int oldbalance,newbalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Balance from CompteTbl where NoCompte='" + Compt + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32( dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void Depot_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}
