using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntitiesLayer;

namespace WebApiGoT.Models
{
    public class RelationTypeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public RelationTypeDTO(RelationType relationType)
        {

            this.id = relationType.IdRelationType;
            this.name = relationType.Name;

        }
    }
}