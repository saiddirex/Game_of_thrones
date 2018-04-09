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
    [RoutePrefix("api/Fight")]
    public class FightController : ApiController
    {
        ThronesTournamentManager businessManager = new ThronesTournamentManager();

        [Route("GetAllFights")]
        public List<FightDTO> GetAllFights()
        {
            List<FightDTO> listFight = new List<FightDTO>();

            foreach (var fight in businessManager.ListFights())
            {
                listFight.Add(new FightDTO(fight));
            }

            return listFight;
        }

        [Route("GetFightById/{id:int}")]
        public FightDTO GetFightById(int id)
        {
            FightDTO fight = new FightDTO(businessManager.GetFightById(id));
            return fight;
        }

        [Route("SaveFight/{houseChalleging_id}/{houseChalleged_id}/{winningHouse_id}/{territory_id}/{war_id}")]
        [HttpPost]
        public void SaveFight(int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id, int war_id)
        {
            businessManager.AddFight(houseChalleging_id, houseChalleged_id, winningHouse_id,  territory_id,  war_id);

        }

        [Route("UpdateFight/{fight_id}/{houseChalleging_id}/{houseChalleged_id}/{winningHouse_id}/{territory_id}/{war_id}")]
        [HttpPut]
        public void UpdateFight(int fight_id, int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id, int war_id)
        {
            businessManager.UpdateFight(fight_id, houseChalleging_id, houseChalleged_id,  winningHouse_id,  territory_id,  war_id);

        }

        [Route("DeleteFight/{fight_id}")]
        [HttpDelete]
        public void DeleteFight(int fight_id)
        {
            businessManager.DeleteFight(fight_id);

        }
    }
}
