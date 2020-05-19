using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    public class employeeModels
    {
       public string name;
        public string number;
        public string position;
        public employeeModels(string name, string number, string position)
        {
            this.name = name;
            this.number = number;
            this.position = position;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
