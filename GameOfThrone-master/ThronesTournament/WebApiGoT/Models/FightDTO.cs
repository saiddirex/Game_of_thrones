using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;

namespace WebApiGoT.Models
{
    public class FightDTO
    {

        public string HouseChalleging { get; set; }
        public string HouseChalleged { get; set; }
        public string WinningHouse { get; set; }
        public string Territory { get; set; }

        public FightDTO(Fight fight) {

            this.HouseChalleging = fight.HouseChalleging.Name;
            this.HouseChalleged = fight.HouseChalleged.Name;
            this.WinningHouse = fight.WinningHouse.Name;
            this.Territory = fight.Territory.TerritoryType.Name;

        }
    }
}