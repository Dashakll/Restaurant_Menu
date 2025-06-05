using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using Model.Data;
using Model.Core.Est;

namespace Model.Data
{
    public class DishXmlSerializer : Serializer
    {
        public DishXmlSerializer()
        {
        }

        public override List<string> DeserealizerDishes(string file)
        {
            List<string> lines = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNode root = doc.SelectSingleNode("Dish");
            if (root == null)
                return lines;

            string GetNodeText(string nodeName)
            {
                var node = root.SelectSingleNode(nodeName);
                return node?.InnerText ?? "";
            }

            lines.Add(GetNodeText("Тип_заведения"));
            lines.Add(GetNodeText("Название_ресторана"));
            lines.Add(GetNodeText("Название_блюда"));
            lines.Add(GetNodeText("Цена_блюда"));
            lines.Add(GetNodeText("Описание_блюда"));
            lines.Add(GetNodeText("Вес_блюда"));
            lines.Add(GetNodeText("Тип_блюда"));

            return lines;
        }

        public override void SerializerDishes<T>(T dish, Establishment rest)
        {
            if (dish == null) return;

            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "Dish");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName = $"{dish.Name}_{DateTime.Now:yyyyMMddHHmmss}.xml";
            string fullPath = Path.Combine(folderPath, fileName);

            using (XmlWriter writer = XmlWriter.Create(fullPath, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Dish");

                writer.WriteElementString("Тип_заведения", rest.Name);
                writer.WriteElementString("Название_ресторана", rest.EstablishmentType);
                writer.WriteElementString("Название_блюда", dish.Name);
                writer.WriteElementString("Цена_блюда", dish.Price.ToString());
                writer.WriteElementString("Описание_блюда", dish.Description);
                writer.WriteElementString("Вес_блюда", dish.Weight.ToString());
                writer.WriteElementString("Тип_блюда", dish.DishType);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}