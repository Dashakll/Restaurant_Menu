using Model.Core.Dishes;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Data;
using System.Windows.Forms;
using Model.Core.Est;
using SystemXmlSerializer = System.Xml.Serialization.XmlSerializer;
using MyXmlSerializer = Model.Data.DishXmlSerializer;

namespace RestaurantMenu2.Cafe.Brioche
{
    public partial class AddDishBrioche : Form
    {
        public Dish dish { get; private set; }

        public AddDishBrioche()
        {
            InitializeComponent();
            Text = "Добавить блюдо";
            numericUpDown2.Minimum = 1; // Минимальное значение 1
            numericUpDown2.Maximum = decimal.MaxValue; // Максимальное - максимально возможное
            numericUpDown2.Value = 100; // Значение по умолчанию

            // Настройка numericUpDown для цены (numericUpDown1)
            numericUpDown1.Minimum = 1; 
            numericUpDown1.Maximum = decimal.MaxValue;
            numericUpDown1.DecimalPlaces = 2; 
            numericUpDown1.Value = 100;
        }

        private void AddDishBrioche_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Цена должна быть больше 0", "Некорректные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown1.Value = 1;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value <= 0)
            {
                MessageBox.Show("Вес должен быть больше 0", "Некорректные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown2.Value = 1; // Возвращаем минимальное допустимое значение
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Введите название блюда", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericUpDown1.Value <= 0 || numericUpDown2.Value <= 0)
            {
                MessageBox.Show("Цена и вес должны быть больше 0", "Некорректные данные",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dish == null) // Если создаем новое блюдо
            {
                dish = new Dish(
                    textBox1.Text,
                    numericUpDown1.Value,
                    (int)numericUpDown2.Value,
                    comboBox1.Text,
                    textBox2.Text);
            }
            else // Если редактируем существующее
            {
                dish.NewName(textBox1.Text);
                dish.NewPrice(numericUpDown1.Value);
                dish.NewWeight((int)numericUpDown2.Value);
                dish.NewDishType(comboBox1.Text);
                dish.NewDescription(textBox2.Text);
            }

            var n = new Establishment("Гастрономика", "Ресторан");

            if (Form1.SelectedItem == "Json")
            {
                new JSONSerializer().SerializerDishes(dish, n);
            }
            if (Form1.SelectedItem == "Xml")
            {
                new DishXmlSerializer().SerializerDishes(dish, n);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void numericUpDown2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Запрещаем ввод минуса
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                MessageBox.Show("Вес не может быть отрицательным", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
