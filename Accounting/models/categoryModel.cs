using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    class categoryModel
    {
        public string id;
        public string categoryName;
        public categoryModel(string id, string categoryName)
        {
            this.id = id;
            this.categoryName = categoryName;
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }
       
    }
}
