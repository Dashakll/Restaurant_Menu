using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public interface ISeasonMenu
    {
        bool HasSeasonMenu { get; }
        void AddSeasonDish(Dishes.Dish dish);
        void RemoveSeasonDish(Dishes.Dish dish);
        void ClearSeasonMenu();
    }
}