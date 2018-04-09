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
    [RoutePrefix("api/RelationType")]
    public class RelationTypeController : ApiController
    {
        ThronesTournamentManager businessManager = new ThronesTournamentManager();

        [Route("GetRelationTypeById/{id:int}")]
        public RelationTypeDTO GetRelationTypeById(int id)
        {
            RelationTypeDTO relationType = new RelationTypeDTO(businessManager.GetRelationTypeById(id));
            return relationType;
        }
    }
}
