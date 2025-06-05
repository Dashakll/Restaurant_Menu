using Model.Core.Dishes;
using Model.Core.Est;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Model.Data
{
    public class JSONSerializer : Serializer
    {
        public string FileName {  get; private set; }
        public override void SerializerDishes<T>(T dish, Establishment rest)
        {
            if (dish == null) return;

            // Указываем путь к рабочему столу
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Dish");

            // Создаем папку если не существует
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Уникальное имя файла
            FileName = $"{dish.Name}_{DateTime.Now:yyyyMMddHHmmss}";

            var result = new
            {
                Тип_заведения = rest.Name,
                Название_ресторана = rest.EstablishmentType,
                Название_блюда = dish.Name,
                Цена_блюда = dish.Price,
                Описание_блюда = dish.Description,
                Вес_блюда = dish.Weight,
                Тип_блюда = dish.DishType
            };

            string json = JsonConvert.SerializeObject(result, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented);
            string fullPath = Path.Combine(folderPath, FileName + ".json");

            File.WriteAllText(fullPath, json);
        }
        public override List<string> DeserealizerDishes(string file)
        {
            List<string> lines = new List<string>();
            string json = File.ReadAllText(file);
            var obj = JObject.Parse(json);

            string type = (string)obj["Тип_заведения"];
            string nanerest = (string)obj["Название_ресторана"];
            string dishname = (string)obj["Название_блюда"] ?? "";
            string price = (string)obj["Цена_блюда"];
            string description = (string)obj["Описание_блюда"];
            string weight = (string)obj["Вес_блюда"];
            string dishType = (string)obj["Тип_блюда"];

            lines.Add(dishname);
            lines.Add(price);
            lines.Add(description);
            lines.Add(weight);
            lines.Add(dishType);


            return lines;
        }
    }
}