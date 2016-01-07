using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearManagementProject
{
    class Gear
    {
        #region Constructors
        public Gear(String _Classname, int _UpgradeLevel, int _Price, Side _Side)
        {
            Classname = _Classname;
            UpgradeLevel = _UpgradeLevel;
            Price = _Price;
            Side = _Side;
        }
        #endregion
        #region Variables
        public String Classname { get;set; }
        public int UpgradeLevel{ get;set; }
        public int Price { get;set; }
        public Side Side { get; set; }
        #endregion
    }
}
