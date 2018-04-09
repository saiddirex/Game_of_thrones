using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class TerritoryType
    {
        private int _idTerritoryType;
        private string _name;

        public int IdTerritoryType
        {
            get { return _idTerritoryType; }
            set { _idTerritoryType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public TerritoryType() { }

        public TerritoryType(TerritoryTypeEnum type)
        {

            _name = type.ToString();
        }
    }
}
