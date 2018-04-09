using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class RelationType
    {
        private int _idRelationType;
        private string _name;

        public int IdRelationType
        {
            get { return _idRelationType; }
            set { _idRelationType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public RelationType() { }
    }
}
