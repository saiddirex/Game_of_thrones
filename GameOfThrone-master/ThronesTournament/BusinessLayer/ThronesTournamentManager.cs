using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntitiesLayer;

namespace BusinessLayer
{
    public class ThronesTournamentManager
    {
        private IDal dal;

        public ThronesTournamentManager()
        {
            dal = DalManager.Instance.Dal;
        }

        public List<House> ListHouses()
        {
            List<House> res = new List<House>();
            dal.GetAllHouses().ForEach(h => res.Add(h) );

            return res;
        }

        public List<String> ListHousesSup200Unit()
        {
            List<House> houses = dal.GetAllHouses();
            List<String> res = new List<String>();

            foreach (House h in houses)
            {
                if (h.NumberOfUnities > 200) res.Add(h.ToString());
            }

            return res;

        }

        public void AddHouse(String name, int numberOfUnities)
        {
            dal.SaveHouse(name, numberOfUnities);
        }

        public void DeleteHouse(int idHouse)
        {
            dal.DeleteHouse(idHouse);
        }

        public void UpdateHouse(int idHouse, String name, int numberOfUnities)
        {
            dal.UpdateHouse(idHouse,  name, numberOfUnities);
        }




        public List<Character> ListCharacters()
        {
            List<Character> res = new List<Character>();
            dal.GetAllCharacters().ForEach(c => res.Add(c));

            return res;
        }

        public Character GetCharacterById(int id)
        {
            Character res = dal.GetCharacterById(id);
            return res;

        }

        public void AddCharacter( String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id)
        {
            dal.SaveCharacter(firstName,lastName,bravoury, crazyness,  pv, characterType_id, house_id);
        }

        public void DeleteCharacter(int idCharacter)
        {
            dal.DeleteCharacter(idCharacter);
        }

        public void UpdateCharacter(int idCharacter, String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id)
        {
            dal.UpdateCharacter( idCharacter, firstName, lastName, bravoury, crazyness, pv,  characterType_id,house_id);
        }



        public List<Fight> ListFights()
        {
            List<Fight> res = new List<Fight>();
            dal.GetAllFights().ForEach(h => res.Add(h));

            return res;
        }

        public Fight GetFightById(int id)
        {
            Fight res = dal.GetFightById(id);
            return res;

        }

        public void AddFight(int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id, int war_id)
        {
            dal.SaveFight( houseChalleging_id,  houseChalleged_id,  winningHouse_id,  territory_id,  war_id);
        }

        public void DeleteFight(int fight_id)
        {
            dal.DeleteFight(fight_id);
        }

        public void UpdateFight(int fight_id,int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id, int war_id)
        {
            dal.UpdateFight(fight_id, houseChalleging_id, houseChalleged_id, winningHouse_id, territory_id, war_id);
        }





        public List<Territory> ListTerritories()
        {
            List<Territory> res = new List<Territory>();
            dal.GetAllTerritories().ForEach(t => res.Add(t));

            return res;
        }

        public Territory GetTerritoryById(int id)
        {
            Territory res = dal.GetTerritoryById(id);
            return res;

        }

        public void AddTerritory(int territoryType_id, int owner_id)
        {
            dal.SaveTerritory(territoryType_id,  owner_id);
        }

        public void UpdateTerritory(int idTerritory, int territoryType_id, int owner_id)
        {
            dal.UpdateTerritory( idTerritory,  territoryType_id,  owner_id);
        }

        public void DeleteTerritory(int idTerritory)
        {
            dal.DeleteTerritory(idTerritory);
        }




        public TerritoryType GetTerritoryTypeById(int id)
        {
            TerritoryType res = dal.GetTerritoryTypeById(id);
            return res;

        }

        public CharacterType GetCharacterTypeById(int id)
        {
            CharacterType res = dal.GetCharacterTypeById(id);
            return res;
        }

        public RelationType GetRelationTypeById(int id)
        {
            RelationType res = dal.GetRelationTypeById(id);
            return res;
        }





        public List<War> ListWars()
        {
            List<War> res = new List<War>();
            dal.GetAllWars().ForEach(h => res.Add(h));

            return res;
        }

        public War GetWarById(int id)
        {
            War res = dal.GetWarById(id);
            return res;
        }


    }
}
