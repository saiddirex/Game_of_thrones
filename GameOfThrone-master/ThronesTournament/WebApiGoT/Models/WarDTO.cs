using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;

namespace WebApiGoT.Models
{
    public class WarDTO
    {
        public List<FightDTO> Fights;


        public WarDTO(War war) {

            this.Fights = new List<FightDTO>();

            foreach (Fight fight in war.Fights)
            {
                this.Fights.Add(new FightDTO(fight));
            }
        }
    }
}