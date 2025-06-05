using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class Snacks : Dish
    {
        public Snacks(string name, decimal price, int weight, string description = "") : base(name, price, weight,"Закуски", description) { }
    }
}