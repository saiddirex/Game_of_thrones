using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        private String _name;
        private int _numberOfUnities;
        List<Character> _housers;


        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int NumberOfUnities
        {
            get { return _numberOfUnities; }
            set { _numberOfUnities = value; }
        }

        public List<Character> Housers
        {
            get { return _housers; }
            set { _housers = value; }
        }



        public House()
        {
        }

        public House(String Name)
        {
            this.Name = Name;
            NumberOfUnities = GlobalVar.NUMBEROfUNITIES;
            Housers = new List<Character>();
        }

        public House(String Name, int NumberOfUnities)
        {
            this.Name = Name;
            this.NumberOfUnities = NumberOfUnities;
            Housers = new List<Character>();
        }

        public void AddHousers(ref Character character)
        {
            Housers.Add(character);
        }

        override
        public String ToString()
        {
            String s = Name + "\n- Number of unities : " + NumberOfUnities + "\n";

            if (Housers.Count != 0)
            {
                s += "- Housers :\n";
                foreach (Character character in Housers)
                {
                    s += "\t" + character.LastName + " " + character.FirstName + "\n";
                }
            }

            return s;
        }



    }
}
