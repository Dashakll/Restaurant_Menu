using Model.Core;
using Model.Core.Dishes;
using Model.Core.Est;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Model.Repositories
{
    public static class SeasonMenuB
    {
        private const string DataFilePath = "menu_data_brioche.json"; // Уникальное имя файла для этого кафе

        public static Establishment GetBriocheEstablishment()
        {
            if (File.Exists(DataFilePath))
            {
                try
                {
                    string json = File.ReadAllText(DataFilePath);
                    return JsonConvert.DeserializeObject<Establishment>(json);
                }
                catch
                {
                    return CreateDefaultBriocheEstablishment();
                }
            }
            return CreateDefaultBriocheEstablishment();
        }

        public static void Save(Establishment establishment)
        {
            string json = JsonConvert.SerializeObject(establishment, Formatting.Indented);
            File.WriteAllText(DataFilePath, json);
        }

        private static Establishment CreateDefaultBriocheEstablishment()
        {
            var establishment = new Establishment("Бриошь", "Французская пекарня и уютное кафе");

          
            var regularMenu = new ChangeMenu();
            regularMenu.Dishes = new List<Dish>
            {
                new Bakery(
                    "Тыквенный кекс",
                    300,
                    120,
                    "Ароматный кекс с тыквой, корицей и грецкими орехами",
                    true),

                new Drink(
                    "Горячий шоколад с маршмэллоу",
                    400,
                    300,
                    false,
                    "Густой горячий шоколад с ванилью и зефирками")
            };

            establishment.SetMenus(regularMenu);
            return establishment;
        }
    }
}