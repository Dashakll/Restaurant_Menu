using Model.Core.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Est
{
    public partial class Establishment
    {
        public IEnumerable<Dish> Select(Type dishType)
        {
            return RegularMenu.Dishes.Where(d => d.GetType() == dishType);
        }
    }
}