using Model.Core.Dishes;
using Model.Core.Est;
using System.Collections.Generic;

namespace Model.Data
{
    public static class DataInitializer
    {
        public static List<Establishment> GetEstablishments()
        {
            var establishments = new List<Establishment>();

            // Ресторан "Гастрономика"
            var gastro = new Restaurant("Гастрономика");
            establishments.Add(gastro);

            return establishments;
        }
    }
}