using RestaurantMenu2.Cafe.Brioche;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2.CoffeeShop.Sugar
{
    public partial class FormSugar2 : Form
    {
        public FormSugar2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var formSugar1 = Application.OpenForms.OfType<FormSugar1>().FirstOrDefault();
            if (formSugar1 != null)
            {
                formSugar1.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Просим прощения, данный раздел находится в разработке", ":(",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Просим прощения, данный раздел находится в разработке", ":(",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Просим прощения, данный раздел находится в разработке", ":(",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormSugar2_Load(object sender, EventArgs e)
        {

        }
    }
}
