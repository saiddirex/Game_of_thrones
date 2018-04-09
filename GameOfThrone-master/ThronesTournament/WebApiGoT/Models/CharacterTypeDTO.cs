using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;

namespace WebApiGoT.Models
{
    public class CharacterTypeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public CharacterTypeDTO(CharacterType characterType)
        {

            this.id = characterType.IdCharacterType;
            this.name = characterType.Name;
           

        }

    }
}