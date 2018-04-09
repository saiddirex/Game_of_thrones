using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLayer;
using WebApiGoT.Models;

namespace WebApiGoT.Controllers
{
    [RoutePrefix("api/CharacterType")]
    public class CharacterTypeController : ApiController
    {
        ThronesTournamentManager businessManager = new ThronesTournamentManager();

        [Route("GetCharacterTypeById/{id:int}")]
        public CharacterTypeDTO GetCharacterTypeById(int id)
        {
            CharacterTypeDTO characterType = new CharacterTypeDTO(businessManager.GetCharacterTypeById(id));
            return characterType;
        }

    }
}
