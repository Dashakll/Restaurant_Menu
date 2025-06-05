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
    public partial class FormSugar1 : Form
    {
        private Form _previousForm;
        public FormSugar1(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSugar2 formSugar2 = new FormSugar2();
            formSugar2.Show();
            this.Hide();
        }

        private void FormSugar1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }
    }
}
