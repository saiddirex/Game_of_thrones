using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;


namespace WebApiGoT.Models
{
   
    public class CharacterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public int Pv { get; set; }

        public CharacterDTO(Character character) {

            this.FirstName = character.FirstName;
            this.LastName = character.LastName;
            this.Bravoury = character.Bravoury;
            this.Crazyness = character.Crazyness;
            this.Pv = character.Pv;

        }
    }
}