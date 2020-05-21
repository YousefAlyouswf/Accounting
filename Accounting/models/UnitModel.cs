using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    class UnitModel
    {
        public string id;
        public string unitName;
        public UnitModel(string id, string unitName)
        {
            this.id = id;
            this.unitName = unitName;
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }
    }
}
