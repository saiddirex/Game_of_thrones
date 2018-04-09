using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class CharacterType
    {
        private int _idCharacterType;
        private string _name;

        public int IdCharacterType
        {
            get { return _idCharacterType; }
            set { _idCharacterType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public CharacterType() { }

        public CharacterType(CharaterTypeEnum type) {

            _name = type.ToString();
        }
    }
}
