using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public interface IDal
    {
        List<House> GetAllHouses();
        List<House> GetAllHousesSup200Unit();
        House GetHouseById(int id);
        void SaveHouse(String name, int numberOfUnities);
        void UpdateHouse(int idHouse, String name, int numberOfUnitie);
        void DeleteHouse(int idHouse);
       

        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        void SaveCharacter( String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id);
        void UpdateCharacter(int idCharacter, String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id);
        void DeleteCharacter(int idCharacter);


        List<Fight> GetAllFights();
        Fight GetFightById(int id);
        void SaveFight(int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id,int war_id);
        void UpdateFight(int fight_id, int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id, int war_id);
        void DeleteFight(int fight_id);


        List<Territory> GetAllTerritories();
        Territory GetTerritoryById(int id);
        void SaveTerritory(int territoryType_id, int owner_id);
        void UpdateTerritory(int idTerritory, int territoryType_id, int owner_id);
        void DeleteTerritory(int idTerritory);


        TerritoryType GetTerritoryTypeById(int id);
        CharacterType GetCharacterTypeById(int id);
        RelationType GetRelationTypeById(int id);


        List<War> GetAllWars();
        War GetWarById(int id);

        int GetLastId(String table);

    }
}
