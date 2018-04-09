using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
     
        private House _houseChalleging;
        private House _houseChalleged;
        private House _winningHouse;
        private Territory _territory;
        private War _war;


        public House HouseChalleging
        {
            get { return _houseChalleging; }
            set { _houseChalleging = value; }
        }

        public House HouseChalleged
        {
            get { return _houseChalleged; }
            set { _houseChalleged = value; }
        }

        public House WinningHouse
        {
            get { return _winningHouse; }
            set { _winningHouse = value; }
        }

        public Territory Territory
        {
            get { return _territory; }
            set { _territory = value; }
        }

        public War War
        {
            get { return _war; }
            set { _war = value; }
        }


        public Fight() { }

        public Fight(House houseChalleging, House houseChalleged, Territory territory)
        {
            this.HouseChalleging = houseChalleging;
            this.HouseChalleged = houseChalleged;
            this.Territory = territory;
            this.WinningHouse = this.HouseChalleging;
        }

        public void Winner()
        {
            Console.WriteLine("The winner is : \n" + WinningHouse);
        }
    }
}
