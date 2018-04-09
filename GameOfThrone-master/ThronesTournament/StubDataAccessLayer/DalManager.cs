using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public class DalManager : IDal
    {

        public DalManager()
        { }

        public List<House> GetAllHouses()
        {
            List<House> houses = new List<House>();
            houses.Add(new House("Stark"));
            houses.Add(new House("Lannister"));
            houses.Add(new House("Baratheon"));
            houses.Add(new House("Tyrell"));
            houses.Add(new House("Martell"));
            houses.Add(new House("Tully"));
            houses.Add(new House("Arryn"));
            houses.Add(new House("Greyjoy"));
            houses.Add(new House("Bolton"));
            houses.Add(new House("Clegane"));
            houses.Add(new House("Targaryen"));

            return houses;
        }

        public List<House> GetAllHousesSup200Unit()
        {
            List<House> houses = GetAllHouses();
            foreach(House h in houses)
            {
                if (h.NumberOfUnities < 200) houses.Remove(h);
            }
            return houses;
        }

        public List<Territory> GetAllTerritory()
        {
            List<Territory> territories = new List<Territory>();
            territories.Add(new Territory());

            return territories;
        }

        public List<Character> GetAllCharacter()
        {
            List<Character> characters = new List<Character>();
            characters.Add(new Character());

            return characters;
        }

    }
}
