using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearManagementProject
{
    class Unit
    {
        #region Constructors
        public Unit(String _Classname, String _Image, String _Name, UnitType _Type, int _Price, int _BuildTime, int _Upgradelevel, FactoryType _Factory, String _Script, Side _Side)
        {
            Classname = _Classname;
            Image = _Image;
            Name = _Name;
            Type = _Type;
            Price = _Price;
            BuildTime = _BuildTime;
            UpgradeLevel = _Upgradelevel;
            Factory = _Factory;
            Script = _Script;
            Side = _Side;
        }
        #endregion
        #region Variables
        public String Classname { get; private set; }
        public String Image { get; private set; }
        public String Name { get; private set; }
        public UnitType Type { get; private set; }
        public int Price { get; private set; }
        public int BuildTime { get; private set; }
        public int UpgradeLevel { get; private set; }
        public FactoryType Factory { get; private set; }
        public String Script { get; private set; }
        public Side Side { get; set; }
        #endregion
    }
}