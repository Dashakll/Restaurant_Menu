using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class ColdDish : Dish
    {

        public ColdDish(string name, decimal price, int weight, string description = "") : base(name, price, weight, "Холодные блюда",description) { }
    }
}