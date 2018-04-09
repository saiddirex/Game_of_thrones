using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class War : EntityObject
    {
        private string _name;
        private List<Fight> _fights;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Fight> Fights
        {
            get { return _fights; }
            set { _fights = value; }
        }


        public War() { }

    }
}
