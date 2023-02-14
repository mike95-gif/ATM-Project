using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcademiaBankNet
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            this.Hide();
            bal.Show();
        }
        public static String NoCompte;
        private void Home_Load(object sender, EventArgs e)
        {
            NoComptelabel.Text = "Numero de Compte: "  + Login.NoCompte;
            NoCompte = Login.NoCompte;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Depot depot = new Depot();
            depot.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FastCash fast = new FastCash();
            fast.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePin Pin = new ChangePin();
            Pin.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Retrait retrait = new Retrait();
            retrait.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            statement state= new statement();
            state.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
