using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    public class CityesVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CityesVM(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}