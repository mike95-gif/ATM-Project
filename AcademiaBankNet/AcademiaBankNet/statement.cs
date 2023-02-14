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
    public partial class statement : Form
    {
        public statement()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mikem\Documents\AcademiaATMDB.mdf;Integrated Security=True;Connect Timeout=30");
        string Compt = Login.NoCompte;
        private void Remplissage()
        {
            Con.Open();
            string query = "Select * from TransactionTbl where NoCompte='" + Compt + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StatementDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void statement_Load(object sender, EventArgs e)
        {
            Remplissage();
        }

        private void StatementDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Home home= new Home();
            home.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
