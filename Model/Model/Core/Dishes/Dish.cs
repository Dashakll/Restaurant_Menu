using System;
using System.Text;
using System.Xml.Serialization;

namespace Model.Core.Dishes
{
    [Serializable]
    public class Dish
    {
        [XmlIgnore]
        public string Name { get; private set; }

        [XmlElement("Name")]
        public string XmlName
        {
            get => Name;
            set => Name = value;
        }
        [XmlIgnore]
        public decimal Price { get; private set; }

        [XmlElement("Price")]
        public decimal XmlPrice
        {
            get => Price;
            set => Price = value;
        }
        [XmlIgnore]
        public string Description { get; private set; }

        [XmlElement("Description")]
        public string XmlDescription
        {
            get => Description;
            set => Description = value;
        }
        [XmlIgnore]
        public int Weight { get; private set; }

        [XmlElement("Weight")]
        public int XmlWeight
        {
            get => Weight;
            set => Weight = value;
        }
        [XmlIgnore]
        public string DishType { get; private set; }

        [XmlElement("DishType")]
        public string XmlDishType
        {
            get => DishType;
            set => DishType = value;
        }
        [XmlIgnore]
        public bool IsSeasonal { get; private set; }

        [XmlElement("IsSeasonal")]
        public bool XmlIsSeasonal
        {
            get => IsSeasonal;
            set => IsSeasonal = value;
        }
        public void NewName(string name)
        {
            Name = name;
        }
        
        public void NewPrice(decimal price)
        {
            Price = price;
        }
        public void NewDescription(string description)
        {
            Description = description ;
        }
        public void NewWeight(int weight)
        {
            Weight = weight;
        }
        public void NewDishType(string dishtype)
        {
            DishType = dishtype;
        }
        public void NewIsSeasonal(bool isseasonal)
        {
            IsSeasonal = isseasonal;
        }
        public Dish() { }

        public Dish(string name, decimal price, int weight, string dishType, string description = "")
        {
            Name = name;
            Price = price;
            Weight = weight;
            DishType = dishType;
            Description = description;
        }
    }
}