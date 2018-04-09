using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    
    public class Territory : EntityObject
    {

        private TerritoryType _territoryType;
        private Character _owner;


        public Character Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public TerritoryType TerritoryType
        {
            get { return _territoryType; }
            set { _territoryType = value; }
        }


        public Territory()
        {
            TerritoryType = new TerritoryType(TerritoryTypeEnum.DESERT);
            Owner = null;
        }

        public Territory(TerritoryType TerritoryType)
        {
            this.TerritoryType = TerritoryType;
            Owner = null;
        }

        public Territory(TerritoryType TerritoryType, Character Owner)
        {
            this.TerritoryType = TerritoryType;
            this.Owner = Owner;
        }
    }
}
