using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Core.Dishes;

namespace Model.Core
{
    public partial class ChangeMenu : IMenu
    {
        public event Action RefreshRequested;

        public virtual string MenuType() => "Постоянное меню";
        public List<Dish> Dishes { get;  set; } = new List<Dish>();

        public void AddDish(Dish dish)
        {
            if (dish != null && !Dishes.Contains(dish)) Dishes.Add(dish);

        }
        public void AddDish(List<Dish> dishes) { }
        public void ClearMenu()
        {
            Dishes.Clear();
        }

        public void RemoveDish(Dish dish)
        {
            if (dish != null && Dishes.Contains(dish)) Dishes.Remove(dish);
        }

        public void RenderMenu()
        {
            throw new NotImplementedException();
        }
    }
}