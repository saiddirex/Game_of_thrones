using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using EntitiesLayer;
using WebApiGoT.Models;

namespace WebApiGoT.Controllers
{
    [RoutePrefix("api/Character")]
    public class CharacterController : ApiController
    {
        ThronesTournamentManager businessManager = new ThronesTournamentManager();
        

        [Route("GetAllCharacters")]
        public List<CharacterDTO> GetAllCharacters()
        {
            List<CharacterDTO> listCharacter = new List<CharacterDTO>();

            foreach(var character in businessManager.ListCharacters())
            {
                listCharacter.Add(new CharacterDTO(character));
            }

            return listCharacter;
        }

        [Route("GetCharacterById/{id:int}")]
        public CharacterDTO GetCharacterById(int id)
        {
            CharacterDTO character = new CharacterDTO(businessManager.GetCharacterById(id));
            return character;
        }

        [Route("SaveCharacter/{firstName}/{lastName}/{bravoury}/{crazyness}/{pv}/{characterType_id}/{house_id}")]
        [HttpPost]
        public void SaveCharacter(String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id)
        {
            businessManager.AddCharacter( firstName, lastName, bravoury, crazyness,  pv, characterType_id, house_id);

        }

        [Route("UpdateCharacter/{idCharacter}/{firstName}/{lastName}/{bravoury}/{crazyness}/{pv}/{characterType_id}/{house_id}")]
        [HttpPut]
        public void UpdateCharacter(int idCharacter, String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id)
        {
            businessManager.UpdateCharacter(idCharacter, firstName, lastName, bravoury,  crazyness,  pv, characterType_id, house_id);

        }

        [Route("DeleteCharacter/{idCharacter}")]
        [HttpDelete]
        public void DeleteCharacter(int idCharacter)
        {
            businessManager.DeleteCharacter(idCharacter);
        }


    }
}
