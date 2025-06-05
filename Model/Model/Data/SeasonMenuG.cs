using Model.Core;
using Model.Core.Dishes;
using Model.Core.Est;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Model.Repositories
{
    public static class SeasonMenuG
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

            

            // Сезонное меню
            var regularMenu = new ChangeMenu();
            regularMenu.Dishes = new List<Dish>
            {
                new ColdDish(
                    "Капрезе с бураттой",
                    750,
                    220,
                    "Свежие розовые томаты с нежной бураттой, базиликом и оливковым маслом"),

                new HotDish(
                    "Сибас на гриле с цукини",
                    1600,
                    300,
                    "Свежий сибас с лимонным соусом"),

                new Dessert(
                    "Клубничный парфе",
                    650,
                    150,
                    true,
                    "Слоёный десерт из свежей клубники, ванильного крема и воздушного бисквита"),

                new Drink(
                    "Мохито с маракуйей",
                    450,
                    300,
                    true,
                    "Освежающий коктейль с белым ромом, лаймом, мятой и мякотью маракуйи")
            };

            //establishment.SetMenus(regularMenu, seasonMenu);
            establishment.SetMenus(regularMenu);
            return establishment;
        }
    }
}