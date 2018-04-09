using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EntitiesLayer
{

    public class Character : EntityObject
    {
        private string _firstName;
        private string _lastName;
        private int _bravoury;
        private int _crazyness;
        private int _pv;
        private CharacterType _type;
        private List<Relation> _relations;
        private House _house;


        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public int Bravoury
        {
            get { return _bravoury; }
            set { _bravoury = value; }
        }

        public int Crazyness
        {
            get { return _crazyness; }
            set { _crazyness = value; }
        }

        public int Pv
        {
            get { return _pv; }
            set { _pv = value; }
        }

        public CharacterType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public List<Relation> Relations
        {
            get { return _relations; }
            set { _relations = value; }
        }

        public House House
        {
            get { return _house; }
            set { _house = value; }
        }


        public Character()
        {
            FirstName = "Guest";
            LastName = "Guest";
            Type = new CharacterType(CharaterTypeEnum.WARRIOR);
            Bravoury = 0;
            Crazyness = 0;
            Pv = GlobalVar.PV;
            House = new House();
            Relations = new List<Relation>();
          
        }

        public Character(String FirstName, String LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            Type = new CharacterType(CharaterTypeEnum.WARRIOR);
            Bravoury = 0;
            Crazyness = 0;
            Pv = GlobalVar.PV;
            House = new House();
            Relations = new List<Relation>();
        }

        public Character(String FirstName, String LastName, CharacterType characterType , House house)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            Type = characterType;
            Bravoury = 0;
            Crazyness = 0;
            Pv = GlobalVar.PV;
            House = house;
            Relations = new List<Relation>();
        }

        public Character(String FirstName, String LastName, CharaterTypeEnum CharaterType)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            new CharacterType(CharaterType);
            this.Bravoury = 0;
            this.Crazyness = 0;
            this.Pv = GlobalVar.PV;
            House = new House();
            Relations = new List<Relation>();
        }


        public Character(String FirstName, String LastName, CharaterTypeEnum CharaterType, int Bravoury, int Crazyness)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Type = new CharacterType(CharaterType);
            this.Bravoury = Bravoury;
            this.Crazyness = Crazyness;
            this.Pv = GlobalVar.PV;
            House = new House();
            Relations = new List<Relation>();
        }


        public void AddRelation(Character Character, RelationType Relation)
        {
            Relations.Add(new Relation(Character, Relation));
        }

        override
        public String ToString()
        {
            String s = FirstName + " " + LastName + "\n- Bravoury : " + Bravoury + "\n- Crazyness : " + Crazyness + "\n- Pv : " + Pv + "\n";
            if (Relations.Count != 0)
            {
                s += "- Relationships :\n";
                foreach (Relation relation in Relations)
                {
                    s += String.Format("\t{2} with {0} {1}\n", relation.Character.FirstName, relation.Character.LastName, relation.RelationType.Name);
                }
            }
            

            return s;

        }

    }
}
