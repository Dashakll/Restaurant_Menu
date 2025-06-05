using Model.Core;
using Model.Core.Dishes;
using Model.Core.Est;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Model.Repositories
{
    public static class MenuRepository
    {
        private const string DataFilePath = "menu_data.json";

        public static Establishment GetGastronomikaEstablishment()
        {
            // Пытаемся загрузить из файла, если есть
            if (File.Exists(DataFilePath))
            {
                try
                {
                    string json = File.ReadAllText(DataFilePath);
                    return JsonConvert.DeserializeObject<Establishment>(json);
                }
                catch
                {
                    // Если ошибка при загрузке - возвращаем стандартное меню
                    return CreateDefaultEstablishment();
                }
            }

            // Если файла нет - создаем стандартное меню
            return CreateDefaultEstablishment();
        }

        public static void Save(Establishment establishment)
        {
            string json = JsonConvert.SerializeObject(establishment, Formatting.Indented);
            File.WriteAllText(DataFilePath, json);
        }

        private static Establishment CreateDefaultEstablishment()
        {
            var establishment = new Establishment("Гастрономика", "Ресторан современной европейской кухни");

            // Основное меню
            var regularMenu = new ChangeMenu();
            regularMenu.Dishes = new List<Dish>
            {
                // Холодные закуски
                new ColdDish(
                    "Тартар из мраморной говядины",
                    890,
                    250,
                    "Нежная рубленая говядина с трюфельным соусом, каперсами и желтком перепелиного яйца"),

                new Snacks(
                    "Брускетта с утиной грудкой",
                    650,
                    180,
                    "Хрустящий хлеб с нежной утиной грудкой, инжирным джемом и рукколой"),

                // Горячие блюда
                new HotDish(
                    "Утка-конфи с вишнёвым соусом",
                    1500,
                    300,
                    "Утиная ножка, томлёная в собственном жиру"),

                new HotDish(
                    "Ризотто с морепродуктами",
                    1200,
                    250,
                    "Кремовое ризотто с мидиями, креветками и шафраном"),

                // Супы
                new Soup(
                    "Томатный суп с морепродуктами",
                    850,
                    300,
                    "Ароматный томатный бульон с морепродуктами"),

                // Десерты
                new Dessert(
                    "Шоколадный фондан",
                    550,
                    120,
                    true,
                    "Тёплый шоколадный кекс с жидкой сердцевиной")
            };

            
            establishment.SetMenus(regularMenu);
            return establishment;
        }
    }
}