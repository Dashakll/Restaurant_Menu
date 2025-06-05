using Model.Core.Dishes;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantMenu2.Restaurant.Gastronomy
{
    public partial class SeasonMenuGastronomy : Form
    {
        private readonly BindingSource bindingSource = new BindingSource();
        private readonly Dictionary<string, ListSortDirection> sortDirections = new Dictionary<string, ListSortDirection>();
        private static List<Dish> allDishes = new List<Dish>();

        public SeasonMenuGastronomy()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            ConfigureDataGridView();
            LoadMenuData();
            InitializeFilterControls();
        }

        private void ConfigureDataGridView()
        {
            // Основные настройки таблицы
            dataGridViewSM.AutoGenerateColumns = false;
            dataGridViewSM.DataSource = bindingSource;
            dataGridViewSM.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSM.MultiSelect = false;
            dataGridViewSM.AllowUserToAddRows = false;
            dataGridViewSM.AllowUserToDeleteRows = false;
            dataGridViewSM.ReadOnly = true;
            dataGridViewSM.RowHeadersVisible = false;

            // Стили таблицы
            dataGridViewSM.BackgroundColor = Color.LemonChiffon;
            dataGridViewSM.AlternatingRowsDefaultCellStyle.BackColor = Color.LemonChiffon;
            dataGridViewSM.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dataGridViewSM.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewSM.ColumnHeadersDefaultCellStyle.Font = new Font("Sans Serif", 8, FontStyle.Bold);
            dataGridViewSM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewSM.RowTemplate.Height = 30;

            // Очистка и создание колонок
            dataGridViewSM.Columns.Clear();
            CreateColumns();

            dataGridViewSM.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewSM.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void CreateColumns()
        {
            dataGridViewSM.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "Название блюда",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 168, 141, 51)
                }
            });

            dataGridViewSM.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Price",
                DataPropertyName = "Price",
                HeaderText = "Цена (₽)",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N0",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 168, 141, 51)
                }
            });

            dataGridViewSM.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Weight",
                DataPropertyName = "Weight",
                HeaderText = "Вес (г)",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Format = "N0",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 168, 141, 51)
                }
            });

            dataGridViewSM.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                DataPropertyName = "Description",
                HeaderText = "Описание",
                Width = 250,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    WrapMode = DataGridViewTriState.True,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(255, 168, 141, 51)
                },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void LoadMenuData()
        {
            try
            {
                var establishment = SeasonMenuG.GetGastronomikaEstablishment();
                allDishes = establishment.RegularMenu.Dishes
                    .Concat(establishment.SeasonMenu.Dishes)
                    .ToList();

                bindingSource.DataSource = new BindingList<Dish>(allDishes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки меню: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeFilterControls()
        {
            var filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.LemonChiffon
            };

            var filterLabel = new Label
            {
                Text = "Фильтр по типу блюда:",
                Location = new Point(10, 10),
                AutoSize = true
            };

            var dishTypeComboBox = new ComboBox
            {
                Location = new Point(150, 7),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            UpdateDishTypesComboBox(dishTypeComboBox);

            filterPanel.Controls.Add(filterLabel);
            filterPanel.Controls.Add(dishTypeComboBox);
            this.Controls.Add(filterPanel);
            filterPanel.BringToFront();
        }

        private void UpdateDishTypesComboBox(ComboBox comboBox)
        {
            var dishTypes = allDishes
                .Select(d => d.DishType)
                .Distinct()
                .OrderBy(t => t)
                .ToList();

            dishTypes.Insert(0, "Все типы");
            comboBox.DataSource = dishTypes;
            comboBox.SelectedIndexChanged += (s, e) => ApplyFilters(comboBox.SelectedItem.ToString());
        }

        private void ApplyFilters(string selectedDishType)
        {
            var filtered = selectedDishType == "Все типы"
                ? allDishes
                : allDishes.Where(d => d.DishType == selectedDishType);

            bindingSource.DataSource = new BindingList<Dish>(filtered.ToList());

            if (!string.IsNullOrEmpty(bindingSource.Sort))
                bindingSource.Sort = bindingSource.Sort;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var addForm = new AddDishGastronomySM())
            {
                if (addForm.ShowDialog() == DialogResult.OK && addForm.dish != null)
                {
                    allDishes.Add(addForm.dish);
                    bindingSource.DataSource = new BindingList<Dish>(allDishes);

                    // Сохраняем изменения
                    var establishment = SeasonMenuG.GetGastronomikaEstablishment();
                    establishment.SeasonMenu.Dishes = allDishes;
                    SeasonMenuG.Save(establishment);

                    // Обновляем комбобокс фильтра
                    var comboBox = this.Controls.Find("dishTypeComboBox", true).FirstOrDefault() as ComboBox;
                    if (comboBox != null)
                    {
                        UpdateDishTypesComboBox(comboBox);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewSM.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите блюдо для удаления", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDish = (Dish)dataGridViewSM.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Удалить блюдо '{selectedDish.Name}'?",
                "Подтверждение",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                allDishes.Remove(selectedDish);
                bindingSource.DataSource = new BindingList<Dish>(allDishes);

                // Сохраняем изменения
                var establishment = SeasonMenuG.GetGastronomikaEstablishment();
                establishment.SeasonMenu.Dishes = allDishes;
                SeasonMenuG.Save(establishment);

                // Обновляем комбобокс фильтра
                var comboBox = this.Controls.Find("dishTypeComboBox", true).FirstOrDefault() as ComboBox;
                if (comboBox != null)
                {
                    UpdateDishTypesComboBox(comboBox);
                }
            }
        }

        private void DataGridViewSM_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var column = dataGridViewSM.Columns[e.ColumnIndex];
            var direction = sortDirections.TryGetValue(column.Name, out var dir)
                ? dir == ListSortDirection.Ascending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending
                : ListSortDirection.Ascending;

            sortDirections[column.Name] = direction;
            bindingSource.Sort = $"{column.Name} {direction}";
            UpdateSortGlyphs(column.Name);
        }

        private void UpdateSortGlyphs(string sortedColumnName)
        {
            foreach (DataGridViewColumn col in dataGridViewSM.Columns)
                col.HeaderCell.SortGlyphDirection = SortOrder.None;

            dataGridViewSM.Columns[sortedColumnName].HeaderCell.SortGlyphDirection =
                sortDirections[sortedColumnName] == ListSortDirection.Ascending
                    ? SortOrder.Ascending
                    : SortOrder.Descending;
        }

        private void FormGastronomy2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewSM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SeasonMenuGastronomy_Load(object sender, EventArgs e)
        {

        }
    }
}
