using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace ThronesTournamentConsole
{
     class Program
    {
         static void Main(string[] args)
         {/*
            Character c = new Character();
            Character c1 = new Character("fff","yyh");
            Character c2 = new Character("fff", "yyh", CharaterTypeEnum.LEADER, 0,0);

            c.AddRelatives(c2, RelationshipEnum.FRIENDSHIP);
            c.AddRelatives(c1, RelationshipEnum.HATRED);
            c1.AddRelatives(c2, RelationshipEnum.RIVALRY);
            c2.AddRelatives(c, RelationshipEnum.FRIENDSHIP);

            Console.WriteLine(c);
            Console.WriteLine(c1);
            Console.WriteLine(c2);

            House house = new House("H1");
            house.AddHousers(ref c);
            house.AddHousers(ref c1);

            House house2 = new House("H2");
            house2.AddHousers(ref c2);

            Console.WriteLine(house);
            Console.WriteLine(house2);

            Territory territory = new Territory(TerritoryType.MOUNTAIN, c);
        
            Fight fight = new Fight(house,house2,territory);
            fight.Winner();*/

            Console.ReadLine();
         }
    }
}
