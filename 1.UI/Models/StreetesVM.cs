using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1.UI.Models
{
    public class StreetesVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }

        public StreetesVM(int id, string name, int cityId)
        {
            ID = id;
            Name = name;
            CityID = cityId;
        }
    }
}