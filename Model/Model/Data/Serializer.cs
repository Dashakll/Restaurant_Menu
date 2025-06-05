using Model.Core.Dishes;
using Model.Core.Est;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data
{
    public abstract class Serializer
    {
        public abstract void SerializerDishes<T>(T dish, Establishment rest) where T : Dish;
        public abstract List<string> DeserealizerDishes(string file);
    }
}