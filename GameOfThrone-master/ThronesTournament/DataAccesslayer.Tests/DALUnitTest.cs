using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;
using EntitiesLayer;
using System.Collections.Generic;

namespace DataAccesslayer.Tests
{
    [TestClass]
    public class DALUnitTest
    {
        private IDal dal;

        public DALUnitTest()
        {
            dal = DalManager.Instance.Dal;
        }


        [TestMethod]
        public void TestGetAllHouses()
        {
            List<House> houses = dal.GetAllHouses();
            Assert.IsNotNull(houses, "Impossible de récupérer les données");
        }

        
        [TestMethod]
        public void TestGetAllCharacters()
        {
            List<Character> Characters = dal.GetAllCharacters();
            Assert.IsNotNull(Characters, "Impossible de récupérer les données");
        }
        
        [TestMethod]
        public void TestGetAllFights()
        {
            List<Fight> fights = dal.GetAllFights();
            Assert.IsNotNull(fights, "Impossible de récupérer les données");
        }
        
        [TestMethod]
        public void TestGetAllTerritories()
        {
            List<Territory> territories = dal.GetAllTerritories();
            Assert.IsNotNull(territories, "Impossible de récupérer les données");
        }

        [TestMethod]
        public void TestGetAllWars()
        {
            List<War> wars = dal.GetAllWars();
            Assert.IsNotNull(wars, "Impossible de récupérer les données");
        }

        [TestMethod]
        public void TestGetHouseById()
        {
            int lastID = dal.GetLastId("House");
            House house = dal.GetHouseById(lastID);
            Assert.IsNotNull(house, "GetHouseById return null");
        }

        [TestMethod]
        public void TestGetCharacterById()
        {
            int lastID = dal.GetLastId("Character");
            Character character = dal.GetCharacterById(lastID);
            Assert.IsNotNull(character, "GetCharacterById return null");
        }

        [TestMethod]
        public void TestGetFightById()
        {
            int lastID = dal.GetLastId("Fight");
            Fight fight = dal.GetFightById(lastID);
            Assert.IsNotNull(fight, "GetFightById return null");
        }

        [TestMethod]
        public void TestGetTerritoryById()
        {
            int lastID = dal.GetLastId("Territory");
            Territory territory = dal.GetTerritoryById(lastID);
            Assert.IsNotNull(territory, "GetTerritoryById return null");
        }

        [TestMethod]
        public void TestGetWarById()
        {
            int lastID = dal.GetLastId("War");
            War war = dal.GetWarById(lastID);
            Assert.IsNotNull(war, "GetWarById return null");
        }

        [TestMethod]
        public void TestGetTerritoryTypeById()
        {
            int lastID = dal.GetLastId("TerritoryType");
            TerritoryType territoryType = dal.GetTerritoryTypeById(lastID);
            Assert.IsNotNull(territoryType, "GetTerritoryTypeById return null");
        }

        [TestMethod]
        public void TestGetCharacterTypeById()
        {
            int lastID = dal.GetLastId("CharacterType");
            CharacterType characterType = dal.GetCharacterTypeById(lastID);
            Assert.IsNotNull(characterType, "GetCharacterTypeById return null");
        }

        [TestMethod]
        public void TestGetRelationTypeById()
        {
            int lastID = dal.GetLastId("RelationType");
            RelationType relationType = dal.GetRelationTypeById(lastID);
            Assert.IsNotNull(relationType, "GetRelationTypeById return null");
        }
        
        [TestMethod]
        public void TestSaveHouse()
        {
        
            House house = new House();
            house.Name = "Test";
            house.NumberOfUnities = 0;
            house.Housers = new List<Character>();
            house.Housers.Add(new Character());

            dal.SaveHouse(house);
   
            int index = dal.GetLastId("House");
            House houseAdded = dal.GetHouseById(index);

            Assert.AreEqual(house.NumberOfUnities, houseAdded.NumberOfUnities, "Différent Number Of Unities");
            Assert.AreEqual(house.Name, houseAdded.Name, "Différents Nom");
            //Assert.AreEqual(house.Housers.Count, houseAdded.Housers.Count, "Nombre de housers différent");
        }

        [TestMethod]
        public void TestSaveCharacter()
        {

            int index = dal.GetLastId("House");
            House house = dal.GetHouseById(index);

            index = dal.GetLastId("CharacterType");
            CharacterType charactertype = dal.GetCharacterTypeById(index);

            index = dal.GetLastId("RelationType");
            RelationType relationType = dal.GetRelationTypeById(index);

            index = dal.GetLastId("Character");
            Character characterRel = dal.GetCharacterById(index);

            Character character = new Character("test","test", charactertype,house);
            character.AddRelation(characterRel,relationType);
            
            dal.SaveCharacter(character);

            index = dal.GetLastId("Character");
            Character lastCharacter = dal.GetCharacterById(index);


            Assert.AreEqual(character.FirstName,lastCharacter.FirstName, "Différent Nom");
            Assert.AreEqual(character.Type.IdCharacterType,lastCharacter.Type.IdCharacterType, "Différents type de character");
            Assert.AreEqual(character.Relations.Count,lastCharacter.Relations.Count, "Nombre de relation différent");
        }
        
        [TestMethod]
        public void TestDeleteHouse()
        {
            int index = dal.GetLastId("House");
            House house = dal.GetHouseById(index);

            dal.DeleteHouse(house);

            House currentHouse = dal.GetHouseById(index);
            
            Assert.IsNull(currentHouse.Name, "House n'a pas ete supprime ");
            Assert.AreEqual(currentHouse.idEntityObject, 0, "House n'a pas ete supprime ");
        }
        
    }
}
