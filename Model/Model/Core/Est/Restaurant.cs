using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core.Est
{
    public class Restaurant : Establishment
    {
        public Restaurant(string name) : base(name) { }
        public override string GetEstablishmentType()
        {
            return "Ресторан";
        }
    }
}