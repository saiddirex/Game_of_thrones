using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Relation
    {
        private Character _character;
        private RelationType _relationType;


        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public RelationType RelationType
        {
            get { return _relationType; }
            set { _relationType = value; }
        }

        public Relation() { }

        public Relation(Character character, RelationType relationType) {

            _character = character;
            _relationType = relationType;
        }

    }
}
