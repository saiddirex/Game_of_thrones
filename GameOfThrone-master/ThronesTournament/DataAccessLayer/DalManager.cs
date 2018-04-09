using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class DalManager
    {
        private static DalManager _instance;
        private static readonly object padlock = new object();

        private IDal _dal;

        public IDal Dal
        {
            get { return _dal; }
            set { _dal = value; }
        }


        public static DalManager Instance
        {
            get
            {

                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DalManager();
                        }
                    }
                }
                return _instance;
            }

        }

        private DalManager() {

            _dal = new DalInstanceSqlServer();
        }

        
    }
}
