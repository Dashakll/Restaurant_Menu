using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Est
{
    public class Cafe : Establishment
    {
        // Делегат для получения типа заведения
        public delegate string GetEstablishmentTypeDelegate();

        // Экземпляр делегата 
        public GetEstablishmentTypeDelegate EstablishmentTypeGetter { get; set; }

        public Cafe(string name) : base(name)
        {
            // Инициализация делегата стандартным значением
            EstablishmentTypeGetter = DefaultEstablishmentTypeGetter;
        }

        private string DefaultEstablishmentTypeGetter()
        {
            return "Кафе";
        }

        public override string GetEstablishmentType()
        {
            // Использование делегата вместо прямого возврата значения
            return EstablishmentTypeGetter();
        }
    }
}