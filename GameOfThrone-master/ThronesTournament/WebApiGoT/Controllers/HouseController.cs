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
    [RoutePrefix("api/House")]
    public class HouseController : ApiController
    {
        ThronesTournamentManager businessManager = new ThronesTournamentManager();

        [Route("GetAllHouses")]
        public List<HouseDTO> GetAllHouses()
        {
            List<HouseDTO> listHouse = new List<HouseDTO>();

            foreach (var house in businessManager.ListHouses())
            {
                listHouse.Add(new HouseDTO(house));
            }

            return listHouse;
        }

        [Route("GetHousesSup200Unit")]
        public List<String> GetHouseSup200Unit()
        {
            List<String> listHouse;
            listHouse = businessManager.ListHousesSup200Unit();
            return listHouse;
        }

        [Route("SaveHouse/{name}/{numberOfUnities}")]
        [HttpPost]
        public void SaveHouse(String name, int numberOfUnities)
        {
            businessManager.AddHouse(name,numberOfUnities);

        }

        [Route("UpdateHouse/{idHouse}/{name}/{numberOfUnities}")]
        [HttpPut]
        public void UpdateHouse(int idHouse, String name, int numberOfUnities)
        {
            businessManager.UpdateHouse(idHouse,name, numberOfUnities);

        }

        [Route("DeleteHouse/{idHouse}")]
        [HttpDelete]
        public void DeleteHouse(int idHouse)
        {
            businessManager.DeleteHouse(idHouse);

        }
    }
}
