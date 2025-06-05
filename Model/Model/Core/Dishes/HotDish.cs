using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Dishes
{
    public class HotDish : Dish
    {

        public HotDish(string name, decimal price, int weight, string description = "") : base(name, price, weight,"Горячие блюда", description) { }
    }
}