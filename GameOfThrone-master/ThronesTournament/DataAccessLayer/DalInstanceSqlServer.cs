using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DalInstanceSqlServer : IDal
    {

        private static string connexionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Said\\Desktop\\GameOfThrone-master\\BD\\db_thrones.mdf;Integrated Security=True;Connect Timeout=30";


        public DalInstanceSqlServer() { }



        public List<House> GetAllHouses()
        {
            List<House> houses = new List<House>();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM House", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        House house = new House();
                        house.idEntityObject = Int32.Parse(sqlDataReader["idHouse"].ToString());
                        house.Name = sqlDataReader["name"].ToString();
                        house.NumberOfUnities = Int32.Parse(sqlDataReader["numberOfUnities"].ToString());

                        houses.Add(house);
                    }
                }

                foreach (House house in houses)
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Character WHERE house_id = " + house.idEntityObject, sqlConnection);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        List<Character> characters = new List<Character>();
                        while (sqlDataReader.Read())
                        {
                            Character character = new Character();
                            character.idEntityObject = Int32.Parse(sqlDataReader["idCharacter"].ToString());
                            character.FirstName = sqlDataReader["firstName"].ToString();
                            character.LastName = sqlDataReader["lastName"].ToString();
                            character.Bravoury = Int32.Parse(sqlDataReader["bravoury"].ToString());
                            character.Crazyness = Int32.Parse(sqlDataReader["crazyness"].ToString());
                            character.Pv = Int32.Parse(sqlDataReader["pv"].ToString());
                            character.Type = GetCharacterTypeById(Int32.Parse(sqlDataReader["characterType_id"].ToString()));
               

                            characters.Add(character);

                        }
                        house.Housers = characters;
                    }

                    foreach(Character character in house.Housers)
                    {
                        sqlCommand = new SqlCommand("SELECT * FROM Relation WHERE idCharacter1 = " + character.idEntityObject, sqlConnection);
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            List<Relation> relations = new List<Relation>();
                            while (sqlDataReader.Read())
                            {
                                Relation relation = new Relation();
       
                                relation.Character = GetCharacterById( Int32.Parse(sqlDataReader["idCharacter2"].ToString()) );
                                relation.RelationType = GetRelationTypeById( Int32.Parse(sqlDataReader["idRelationType"].ToString()) );
                                
                                relations.Add(relation);

                            }
                            character.Relations = relations;
                        }

                    }
                }

                sqlConnection.Close();
            }

                return houses;
        }

        public List<House> GetAllHousesSup200Unit()
        {
            List<House> houses = GetAllHouses();
            foreach (House h in houses)
            {
                if (h.NumberOfUnities < 200) houses.Remove(h);
            }
            return houses;
        }

        public House GetHouseById(int id)
        {
            House house = new House();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM House WHERE IdHouse = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        house.idEntityObject = Int32.Parse(sqlDataReader["IdHouse"].ToString());
                        house.Name = sqlDataReader["name"].ToString();
                        house.NumberOfUnities = Int32.Parse(sqlDataReader["numberOfUnities"].ToString());
                    }
                }

                sqlCommand = new SqlCommand("SELECT * FROM Character WHERE house_id = " + house.idEntityObject, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    List<Character> characters = new List<Character>();
                    while (sqlDataReader.Read())
                    {
                        Character character = new Character();
                        character.idEntityObject = Int32.Parse(sqlDataReader["idCharacter"].ToString());
                        character.FirstName = sqlDataReader["firstName"].ToString();
                        character.LastName = sqlDataReader["lastName"].ToString();
                        character.Bravoury = Int32.Parse(sqlDataReader["bravoury"].ToString());
                        character.Crazyness = Int32.Parse(sqlDataReader["crazyness"].ToString());
                        character.Pv = Int32.Parse(sqlDataReader["pv"].ToString());
                        character.Type = GetCharacterTypeById(Int32.Parse(sqlDataReader["characterType_id"].ToString()));


                        characters.Add(character);

                    }
                    house.Housers = characters;
                }

                foreach (Character character in house.Housers)
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Relation WHERE idCharacter1 = " + character.idEntityObject, sqlConnection);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        List<Relation> relations = new List<Relation>();
                        while (sqlDataReader.Read())
                        {
                            Relation relation = new Relation();

                            relation.Character = GetCharacterById(Int32.Parse(sqlDataReader["idCharacter2"].ToString()));
                            relation.RelationType = GetRelationTypeById(Int32.Parse(sqlDataReader["idRelationType"].ToString()));

                            relations.Add(relation);

                        }
                        character.Relations = relations;
                    }

                }

                sqlConnection.Close();
            }

            return house;
        }

        public void SaveHouse(String name,int numberOfUnities)
        {
            String insertHouseRequest = "INSERT INTO House(name,numberOfUnities) VALUES (@Name,@NumberOfUnities)";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand insertCommand = new SqlCommand(insertHouseRequest, sqlConnection);
                insertCommand.Parameters.AddWithValue("@Name", name);
                insertCommand.Parameters.AddWithValue("@NumberOfUnities", numberOfUnities);
                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void UpdateHouse(int idHouse,String name, int numberOfUnities)
        {
            String updateHouseRequest = "UPDATE House SET name = @Name , numberOfUnities = @NumberOfUnities Where IdHouse = @IdHouse";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                
                SqlCommand updateCommand = new SqlCommand(updateHouseRequest, sqlConnection);
                updateCommand.Parameters.AddWithValue("@idHouse", idHouse);
                updateCommand.Parameters.AddWithValue("@Name", name);
                updateCommand.Parameters.AddWithValue("@NumberOfUnities", numberOfUnities);

                updateCommand.ExecuteNonQuery();
               
                sqlConnection.Close();
            }
        }

        public void DeleteHouse(int idHouse)
        {
            String deleteHouseRequest = "DELETE FROM House WHERE IdHouse = @IdHouse";
            String deleteFightRequest = "DELETE FROM Fight WHERE houseChalleging_id = @IdHouse OR houseChalleged_id = @IdHouse OR winningHouse_id = @IdHouse";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
              
                SqlCommand deleteFightCommand = new SqlCommand(deleteFightRequest, sqlConnection);
                deleteFightCommand.Parameters.AddWithValue("@IdHouse", idHouse);
                deleteFightCommand.ExecuteNonQuery();

                /*foreach (Character character in house.Housers)
                    DeleteCharacter(character);*/

                SqlCommand deleteHouseCommand = new SqlCommand(deleteHouseRequest, sqlConnection);
                deleteHouseCommand.Parameters.AddWithValue("@IdHouse", idHouse);
                deleteHouseCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }



        public List<Character> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Character", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Character character = new Character();
                        character.idEntityObject = Int32.Parse(sqlDataReader["idCharacter"].ToString());
                        character.FirstName = sqlDataReader["firstName"].ToString();
                        character.LastName = sqlDataReader["lastName"].ToString();
                        character.Bravoury = Int32.Parse(sqlDataReader["bravoury"].ToString());
                        character.Crazyness = Int32.Parse(sqlDataReader["crazyness"].ToString());
                        character.Pv = Int32.Parse(sqlDataReader["pv"].ToString());
                        character.Type = GetCharacterTypeById(Int32.Parse(sqlDataReader["characterType_id"].ToString()));

                        characters.Add(character);
                    }
                }

                foreach (Character character in characters)
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Relation WHERE idCharacter1 = " + character.idEntityObject, sqlConnection);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        List<Relation> relations = new List<Relation>();
                        while (sqlDataReader.Read())
                        {
                            Relation relation = new Relation();

                            relation.Character = GetCharacterById(Int32.Parse(sqlDataReader["idCharacter2"].ToString()));
                            relation.RelationType = GetRelationTypeById(Int32.Parse(sqlDataReader["idRelationType"].ToString()));

                            relations.Add(relation);

                        }
                        character.Relations = relations;
                    }
                }

                sqlConnection.Close();
            }

            return characters;
        }

        public Character GetCharacterById(int id)
        {
            Character character = new Character();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Character WHERE IdCharacter = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        character.idEntityObject = Int32.Parse(sqlDataReader["idCharacter"].ToString());
                        character.FirstName = sqlDataReader["firstName"].ToString();
                        character.LastName = sqlDataReader["lastName"].ToString();
                        character.Bravoury = Int32.Parse(sqlDataReader["bravoury"].ToString());
                        character.Crazyness = Int32.Parse(sqlDataReader["crazyness"].ToString());
                        character.Pv = Int32.Parse(sqlDataReader["pv"].ToString());
                        character.Type = GetCharacterTypeById(Int32.Parse(sqlDataReader["characterType_id"].ToString()));

                    }
                }

                sqlCommand = new SqlCommand("SELECT * FROM Relation WHERE idCharacter1 = " + character.idEntityObject, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    List<Relation> relations = new List<Relation>();
                    while (sqlDataReader.Read())
                    {
                        Relation relation = new Relation();

                        relation.Character = GetCharacterById(Int32.Parse(sqlDataReader["idCharacter2"].ToString()));
                        relation.RelationType = GetRelationTypeById(Int32.Parse(sqlDataReader["idRelationType"].ToString()));

                        relations.Add(relation);

                    }
                    character.Relations = relations;
                }

                sqlConnection.Close();
            }

            return character;
        }
        /**/
        public void SaveCharacter(String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id)
        {
            String insertCharacterRequest = "INSERT INTO Character(firstName,lastName,bravoury,crazyness,pv,characterType_id,house_id) VALUES (@FirstName,@LastName,@Bravoury,@Crazyness,@Pv,@CharacterType_id,@House_id)";
            //String insertRelationRequest = "INSERT INTO Relation VALUES (@IdCharacter1,@IdCharacter2,@IdRelationType)";
            // Int32 idCharacter = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                /*
                SqlCommand sqlCommand = new SqlCommand("SELECT IDENT_CURRENT ('Character') AS Current_Identity", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        idCharacter = Int32.Parse(sqlDataReader["Current_Identity"].ToString());
                    }
                }
                */
                
                SqlCommand insertFirstCommand = new SqlCommand(insertCharacterRequest, sqlConnection);
               // insertFirstCommand.Parameters.AddWithValue("@idCharacter", idCharacter);
                insertFirstCommand.Parameters.AddWithValue("@FirstName", firstName);
                insertFirstCommand.Parameters.AddWithValue("@LastName", lastName);
                insertFirstCommand.Parameters.AddWithValue("@Bravoury", bravoury);
                insertFirstCommand.Parameters.AddWithValue("@Crazyness", crazyness);
                insertFirstCommand.Parameters.AddWithValue("@Pv", pv);
                insertFirstCommand.Parameters.AddWithValue("@CharacterType_id", characterType_id);
                insertFirstCommand.Parameters.AddWithValue("@House_id", house_id);
                insertFirstCommand.ExecuteNonQuery();
                
               /* foreach (Relation relation in character.Relations)
                {
                    SqlCommand insertSecondCommand = new SqlCommand(insertRelationRequest, sqlConnection);
                    insertSecondCommand.Parameters.AddWithValue("@IdCharacter1", idCharacter + 1);
                    insertSecondCommand.Parameters.AddWithValue("@IdCharacter2", relation.Character.idEntityObject);
                    insertSecondCommand.Parameters.AddWithValue("@IdRelationType", relation.RelationType.IdRelationType);
                    insertSecondCommand.ExecuteNonQuery();
                }*/

                sqlConnection.Close();
            }
        }

        public void UpdateCharacter(int idCharacter,String firstName, String lastName, int bravoury, int crazyness, int pv, int characterType_id, int house_id)
        {
            String updateCharacterRequest = "UPDATE Character SET firstName = @FirstName, lastName = @LastName, bravoury = @Bravoury, crazyness = @Crazyness, pv = @Pv, characterType_id = @CharacterType_id, house_id=@House_id  Where IdCharacter = @IdCharacter";
           // String updateRelationRequest = "UPDATE Relation SET idCharacter2 = @IdCharacter2, idRelationType = @IdRelationType WHERE idCharacter1 = @IdCharacter";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
              
                SqlCommand updateCharacterCommand = new SqlCommand(updateCharacterRequest, sqlConnection);
                updateCharacterCommand.Parameters.AddWithValue("@IdCharacter", idCharacter);
                updateCharacterCommand.Parameters.AddWithValue("@FirstName", firstName);
                updateCharacterCommand.Parameters.AddWithValue("@LastName", lastName);
                updateCharacterCommand.Parameters.AddWithValue("@Bravoury", bravoury);
                updateCharacterCommand.Parameters.AddWithValue("@Crazyness", crazyness);
                updateCharacterCommand.Parameters.AddWithValue("@Pv", pv);
                updateCharacterCommand.Parameters.AddWithValue("@CharacterType_id", characterType_id);
                updateCharacterCommand.Parameters.AddWithValue("@House_id", house_id);
                updateCharacterCommand.ExecuteNonQuery();

               /* foreach (Relation relation in character.Relations)
                {
                    SqlCommand insertSecondCommand = new SqlCommand(updateRelationRequest, sqlConnection);
                    insertSecondCommand.Parameters.AddWithValue("@IdCharacter2", relation.Character.idEntityObject);
                    insertSecondCommand.Parameters.AddWithValue("@IdRelationType", relation.RelationType.IdRelationType);
                    insertSecondCommand.ExecuteNonQuery();
                }*/
                sqlConnection.Close();
            }
        }

        public void DeleteCharacter(int idCharacter)
        {
            String deleteCharacterRequest = "DELETE FROM Character WHERE IdCharacter = @IdCharacter";
            String deleteRelationRequest = "DELETE FROM Relation WHERE IdCharacter1 = @IdCharacter OR IdCharacter2 = @IdCharacter";
            String deleteTerritoryRequest = "DELETE FROM Territory WHERE owner_id = @IdCharacter";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand deleteTerritoryCommand = new SqlCommand(deleteTerritoryRequest, sqlConnection);
                deleteTerritoryCommand.Parameters.AddWithValue("@IdCharacter", idCharacter);
                deleteTerritoryCommand.ExecuteNonQuery();

                SqlCommand deleteRelationCommand = new SqlCommand(deleteRelationRequest, sqlConnection);
                deleteRelationCommand.Parameters.AddWithValue("@IdCharacter", idCharacter);
                deleteRelationCommand.ExecuteNonQuery();

                SqlCommand deleteCharacterCommand = new SqlCommand(deleteCharacterRequest, sqlConnection);
                deleteCharacterCommand.Parameters.AddWithValue("@IdCharacter", idCharacter);
                deleteCharacterCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }



        public List<Fight> GetAllFights()
        {
            List<Fight> fights = new List<Fight>();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Fight", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Fight fight = new Fight();
                        fight.idEntityObject = Int32.Parse(sqlDataReader["idFight"].ToString());
                        fight.HouseChalleged = GetHouseById(Int32.Parse(sqlDataReader["houseChalleged_id"].ToString()));
                        fight.HouseChalleging = GetHouseById(Int32.Parse(sqlDataReader["houseChalleging_id"].ToString()));
                        fight.WinningHouse = GetHouseById(Int32.Parse(sqlDataReader["winningHouse_id"].ToString()));
                        fight.Territory = GetTerritoryById(Int32.Parse(sqlDataReader["territory_id"].ToString()));
                        fight.War = GetWarById(Int32.Parse(sqlDataReader["war_id"].ToString()));

                        fights.Add(fight);

                    }
                }

                sqlConnection.Close();
            }

            return fights;
        }

        public Fight GetFightById(int id)
        {
            Fight fight = new Fight();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Fight WHERE IdFight = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        fight.idEntityObject = Int32.Parse(sqlDataReader["idFight"].ToString());
                        fight.HouseChalleged = GetHouseById(Int32.Parse(sqlDataReader["houseChalleged_id"].ToString()));
                        fight.HouseChalleging = GetHouseById(Int32.Parse(sqlDataReader["houseChalleging_id"].ToString()));
                        fight.WinningHouse = GetHouseById(Int32.Parse(sqlDataReader["winningHouse_id"].ToString()));
                        fight.Territory = GetTerritoryById(Int32.Parse(sqlDataReader["territory_id"].ToString()));
                        fight.War = GetWarById(Int32.Parse(sqlDataReader["war_id"].ToString()));

                    }
                }
                sqlConnection.Close();
            }

            return fight;
        }

        public void SaveFight(int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id,int war_id)
        {
            String insertFightRequest = "INSERT INTO Fight(houseChalleging_id,houseChalleged_id,winningHouse_id,territory_id,war_id) VALUES (@HouseChalleging_id,@HouseChalleged_id,@WinningHouse_id,@Territory_id,@War_id)";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
               
                SqlCommand insertCommand = new SqlCommand(insertFightRequest, sqlConnection);
                insertCommand.Parameters.AddWithValue("@HouseChalleging_id", houseChalleging_id);
                insertCommand.Parameters.AddWithValue("@HouseChalleged_id", houseChalleged_id);
                insertCommand.Parameters.AddWithValue("@WinningHouse_id", winningHouse_id);
                insertCommand.Parameters.AddWithValue("@Territory_id", territory_id);
                insertCommand.Parameters.AddWithValue("@War_id", war_id);
                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void UpdateFight(int fight_id,int houseChalleging_id, int houseChalleged_id, int winningHouse_id, int territory_id, int war_id)
        {
            String updateFightRequest = "UPDATE Fight SET houseChalleging_id = @HouseChalleging_id ,houseChalleged_id = @HouseChalleged_id ,winningHouse_id = @WinningHouse_id ,territory_id = @Territory_id ,war_id =  @War_id WHERE idFight = @idFight ";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand updateCommand = new SqlCommand(updateFightRequest, sqlConnection);
                updateCommand.Parameters.AddWithValue("@idFight", fight_id);
                updateCommand.Parameters.AddWithValue("@HouseChalleging_id", houseChalleging_id);
                updateCommand.Parameters.AddWithValue("@HouseChalleged_id", houseChalleged_id);
                updateCommand.Parameters.AddWithValue("@WinningHouse_id", winningHouse_id);
                updateCommand.Parameters.AddWithValue("@Territory_id", territory_id);
                updateCommand.Parameters.AddWithValue("@War_id", war_id);
                updateCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void DeleteFight(int fight_id)
        {
            String deleteFightRequest = "DELETE FROM Fight WHERE IdFight = @IdFight";
           
            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand deleteFightCommand = new SqlCommand(deleteFightRequest, sqlConnection);
                deleteFightCommand.Parameters.AddWithValue("@IdFight", fight_id);
                deleteFightCommand.ExecuteNonQuery();
                
                sqlConnection.Close();
            }
        }



        public List<Territory> GetAllTerritories()
        {
            List<Territory> Territories = new List<Territory>();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Territory", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Territory territory = new Territory();

                        territory.idEntityObject = Int32.Parse(sqlDataReader["IdTerritory"].ToString());
                        territory.Owner = GetCharacterById(Int32.Parse(sqlDataReader["owner_id"].ToString()));
                        territory.TerritoryType = GetTerritoryTypeById(Int32.Parse(sqlDataReader["territoryType_id"].ToString()));


                        Territories.Add(territory);
                    }
                }
                sqlConnection.Close();
            }

            return Territories;
        }
        
        public Territory GetTerritoryById(int id)
        {
            Territory territory = new Territory();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Territory WHERE IdTerritory = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        territory.idEntityObject = Int32.Parse(sqlDataReader["IdTerritory"].ToString());
                        territory.Owner = GetCharacterById(Int32.Parse(sqlDataReader["owner_id"].ToString()));
                        territory.TerritoryType = GetTerritoryTypeById(Int32.Parse(sqlDataReader["territoryType_id"].ToString()));

                    }
                }
                sqlConnection.Close();
            }

            return territory;
        }

        public void SaveTerritory(int territoryType_id, int owner_id)
        {
            String insertTerritoryRequest = "INSERT INTO Territory(territoryType_id,owner_id) VALUES (@TerritoryType_id,@Owner_id)";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand insertCommand = new SqlCommand(insertTerritoryRequest, sqlConnection);
                insertCommand.Parameters.AddWithValue("@TerritoryType_id", territoryType_id);
                insertCommand.Parameters.AddWithValue("@Owner_id", owner_id);
                insertCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void UpdateTerritory(int idTerritory,int territoryType_id,int owner_id )
        {
            String updateTerritoryRequest = "UPDATE Territory SET territoryType_id = @TerritoryType_id ,owner_id = @Owner_id WHERE idTerritory = @IdTerritory ";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand updateCommand = new SqlCommand(updateTerritoryRequest, sqlConnection);
                updateCommand.Parameters.AddWithValue("@TerritoryType_id", territoryType_id);
                updateCommand.Parameters.AddWithValue("@Owner_id", owner_id);
                updateCommand.Parameters.AddWithValue("@IdTerritory", idTerritory);
                updateCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }

        public void DeleteTerritory(int idTerritory )
        {
            String deleteTerritoryRequest = "DELETE FROM Territory WHERE IdTerritory = @IdTerritory";

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();

                SqlCommand deleteTerritoryCommand = new SqlCommand(deleteTerritoryRequest, sqlConnection);
                deleteTerritoryCommand.Parameters.AddWithValue("@IdTerritory", idTerritory);
                deleteTerritoryCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }



        public TerritoryType GetTerritoryTypeById(int id)
        {
            TerritoryType territoryType = new TerritoryType();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TerritoryType WHERE IdTerritoryType = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        territoryType.IdTerritoryType = Int32.Parse(sqlDataReader["IdTerritoryType"].ToString());
                        territoryType.Name = sqlDataReader["name"].ToString();
                    }
                }
                sqlConnection.Close();
            }

            return territoryType;
        }

        public CharacterType GetCharacterTypeById(int id)
        {
            CharacterType characterType = new CharacterType();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CharacterType WHERE IdCharacterType = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        characterType.IdCharacterType = Int32.Parse(sqlDataReader["IdCharacterType"].ToString());
                        characterType.Name = sqlDataReader["name"].ToString();
                    }
                }
                sqlConnection.Close();
            }

            return characterType;
        }

        public RelationType GetRelationTypeById(int id)
        {
            RelationType relationType = new RelationType();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM RelationType WHERE IdRelationType = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        relationType.IdRelationType = Int32.Parse(sqlDataReader["IdRelationType"].ToString());
                        relationType.Name = sqlDataReader["name"].ToString();
                    }
                }
                sqlConnection.Close();
            }

            return relationType;
        }




        public List<War> GetAllWars()
        {
            List<War> Wars = new List<War>();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM War", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        War war = new War();
                        war.idEntityObject = Int32.Parse(sqlDataReader["idWar"].ToString());
                        war.Name = sqlDataReader["name"].ToString();


                        Wars.Add(war);
                    }
                }

                foreach (War war in Wars)
                {
                    sqlCommand = new SqlCommand("SELECT * FROM Fight WHERE war_id = " + war.idEntityObject, sqlConnection);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        List<Fight> fights = new List<Fight>();
                        while (sqlDataReader.Read())
                        {
                            Fight fight = new Fight();
                            fight.idEntityObject = Int32.Parse(sqlDataReader["idFight"].ToString());
                            fight.HouseChalleged = GetHouseById(Int32.Parse(sqlDataReader["houseChalleged_id"].ToString()));
                            fight.HouseChalleging = GetHouseById(Int32.Parse(sqlDataReader["houseChalleging_id"].ToString()));
                            fight.WinningHouse = GetHouseById(Int32.Parse(sqlDataReader["winningHouse_id"].ToString()));
                            fight.Territory = GetTerritoryById(Int32.Parse(sqlDataReader["territory_id"].ToString()));
                            fight.War = war;



                            fights.Add(fight);

                        }
                        war.Fights = fights;
                    }
                }

                sqlConnection.Close();
            }

            return Wars;
        }

        public War GetWarById(int id)
        {
            War war = new War();

            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM War WHERE idWar = " + id, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        war.idEntityObject = Int32.Parse(sqlDataReader["idWar"].ToString());
                        war.Name = sqlDataReader["name"].ToString();

                    }
                }

                sqlCommand = new SqlCommand("SELECT * FROM Fight WHERE war_id = " + war.idEntityObject, sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    List<Fight> fights = new List<Fight>();
                    while (sqlDataReader.Read())
                    {
                        Fight fight = new Fight();
                        fight.idEntityObject = Int32.Parse(sqlDataReader["idFight"].ToString());
                        fight.HouseChalleged = GetHouseById(Int32.Parse(sqlDataReader["houseChalleged_id"].ToString()));
                        fight.HouseChalleging = GetHouseById(Int32.Parse(sqlDataReader["houseChalleging_id"].ToString()));
                        fight.WinningHouse = GetHouseById(Int32.Parse(sqlDataReader["winningHouse_id"].ToString()));
                        fight.Territory = GetTerritoryById(Int32.Parse(sqlDataReader["territory_id"].ToString()));
                        fight.War = war;

                        fights.Add(fight);

                    }
                    war.Fights = fights;
                }

                sqlConnection.Close();
            }

            return war;
        }

        public int GetLastId(String table)
        {
            int index = -1;
            using (SqlConnection sqlConnection = new SqlConnection(connexionString))
            {
                sqlConnection.Open();
               
                SqlCommand sqlCommand = new SqlCommand("SELECT IDENT_CURRENT ('" + table + "') AS Current_Identity", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        index = Int32.Parse(sqlDataReader["Current_Identity"].ToString());
                    }
                }
                sqlConnection.Close();
            }
            return index;
        }
    }
}
