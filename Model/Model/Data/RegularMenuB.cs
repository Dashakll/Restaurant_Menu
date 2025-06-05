using Model.Core;
using Model.Core.Dishes;
using Model.Core.Est;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Model.Repositories
{
    public static class ReguralMenuB
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

            // Основное меню
            var regularMenu = new ChangeMenu();
            regularMenu.Dishes = new List<Dish>
            {
                // Выпечка
                new Bakery(
                    "Круассан классический",
                    250,
                    80,
                    "Слоёный круассан с хрустящей корочкой и нежной текстурой"),

                new Bakery(
                    "Бриошь с яблоком",
                    280,
                    100,
                    "Пышная булочка с карамелизированными яблоками и корицей"),

                // Завтраки
                new Breakfast(
                    "Гренки с ягодами",
                    450,
                    200,
                    "Хрустящие гренки с ягодным топпингом и кленовым сиропом"),

                new Breakfast(
                    "Омлет с трюфельным маслом",
                    550,
                    180,
                    "Воздушный омлет с трюфельным маслом и зеленью"),

                // Десерты
                new Dessert(
                    "Эклер ванильный",
                    350,
                    120,
                    true,
                    "Заварной эклер с ванильным кремом и глазурью"),
                new Drink(
                    "Café au lait",
                    450,
                    200,
                    false,
                    "Французская версия кофе с подогретым молоком")
            };

           

            establishment.SetMenus(regularMenu);
            return establishment;
        }
    }
    // Класс для выпечки
    public class Bakery : Dish
    {
        public Bakery(string name, decimal price, int weight, string description, bool containsSugar = false)
            : base(name, price, weight, "Выпечка", description)
        {
            ContainsSugar = containsSugar;
        }

        public bool ContainsSugar { get; set; }
    }

    // Класс для завтраков
    public class Breakfast : Dish
    {
        public Breakfast(string name, decimal price, int weight, string description)
            : base(name, price, weight, "Завтраки", description)
        {
        }
    }
}