using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;

namespace WebApiGoT.Models
{
    public class HouseDTO
    {
        public String Name { get; set; }
        public int NumberOfUnities { get; set; }


        public HouseDTO(House house) {

            this.Name = house.Name;
            this.NumberOfUnities = house.NumberOfUnities;
        }
    }
}