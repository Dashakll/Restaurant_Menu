using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class Dessert : Dish
    {
        public bool ContainsSugar { get; private set; }

        public Dessert(string name, decimal price, int weight, bool containsSugar = true,
                      string description = "")
            : base(name, price, weight,"Десерт", description)
        {
            ContainsSugar = containsSugar;
        }
    }
}