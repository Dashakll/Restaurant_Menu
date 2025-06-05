using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantMenu2.Restaurant.Gastronomy
{
    public partial class FormGastronomy1 : Form
    {
        private Form _previousForm;
        public string SelectedFormat { get; set; }
        public FormGastronomy1(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormGastronomy2 formGastronomy2 = new FormGastronomy2();
            formGastronomy2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            this.Hide();
        }

        private void FormGastronomy1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
