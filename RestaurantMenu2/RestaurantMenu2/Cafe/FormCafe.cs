using RestaurantMenu2.Cafe.Brioche;
using System;
using System.Windows.Forms;

namespace RestaurantMenu2
{
    public partial class FormCafe : Form
    {
        public FormCafe()
        {
            InitializeComponent();
        }

        private void FormCafe_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            FormBrioche1 formBrioche1 = new FormBrioche1(this);
            formBrioche1.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
