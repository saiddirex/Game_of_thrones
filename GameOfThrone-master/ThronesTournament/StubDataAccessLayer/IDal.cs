using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace StubDataAccessLayer
{
    public interface IDal
    {
        List<House> GetAllHouses();

        List<House> GetAllHousesSup200Unit();

        List<Territory> GetAllTerritory();

        List<Character> GetAllCharacter();

    }
}
