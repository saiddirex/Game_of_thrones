using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;

namespace WebApiGoT.Models
{
    public class TerritoryTypeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public TerritoryTypeDTO(TerritoryType territoryType)
        {

            this.id = territoryType.IdTerritoryType;
            this.name = territoryType.Name;

        }
    }
}