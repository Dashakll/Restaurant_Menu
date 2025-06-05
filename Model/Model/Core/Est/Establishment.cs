using Model.Core.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Core.Est
{
    public partial class Establishment : ISeasonMenu
    {
        public string Name { get; private set; }
        public string EstablishmentType { get; protected set; }

        private IMenu _regularMenu;
        private IMenu _seasonMenu;

        public IMenu RegularMenu
        {
            get => _regularMenu;
            private set => _regularMenu = value; // Добавляем private set
        }

        public IMenu SeasonMenu
        {
            get => _seasonMenu;
            private set => _seasonMenu = value; // Добавляем private set
        }

        public bool HasSeasonMenu => SeasonMenu != null && SeasonMenu.Dishes.Any();

        public Establishment(string name)
        {
            Name = name;
            RegularMenu = new ChangeMenu();
            SeasonMenu = new ChangeMenu();
        }

        public Establishment(string name, string establishmentType) : this(name)
        {
            EstablishmentType = establishmentType;
        }

        public virtual string GetEstablishmentType() => EstablishmentType;

        public delegate void UpdateMenu(object sender, EventArgs e);
        public event UpdateMenu MenuIsUpdated;

        protected virtual void OnMenuUpdated()
        {
            MenuIsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void AddSeasonDish(Dish dish)
        {
            SeasonMenu.AddDish(dish);
            OnMenuUpdated();
        }
        public void SetMenus(IMenu regularMenu)
        {
            this._regularMenu = regularMenu;
        }
        public void RemoveSeasonDish(Dish dish)
        {
            SeasonMenu.RemoveDish(dish);
            OnMenuUpdated();
        }

        public void ClearSeasonMenu()
        {
            SeasonMenu.ClearMenu();
            OnMenuUpdated();
        }
    }
}