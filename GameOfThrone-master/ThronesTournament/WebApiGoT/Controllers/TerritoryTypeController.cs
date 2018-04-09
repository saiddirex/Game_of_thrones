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
    [RoutePrefix("api/TerritoryType")]
    public class TerritoryTypeController : ApiController
    {
        ThronesTournamentManager businessManager = new ThronesTournamentManager();

        [Route("GetTerritoryTypeById/{id:int}")]
        public TerritoryTypeDTO GetTerritoryTypeById(int id)
        {
            TerritoryTypeDTO territoryType = new TerritoryTypeDTO(businessManager.GetTerritoryTypeById(id));
            return territoryType;
        }
    }
}
