using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    class ItemModel
    {
        public string itemName;
        public string category;
        public string unit;
        public string priceBuy;
        public string priceSell;
        public ItemModel(string itemName, string category, string unit, string priceBuy, string priceSell)
        {
            this.itemName = itemName;
            this.category = category; 
            this.unit = unit;
            this.priceBuy = priceBuy;
            this.priceSell = priceSell;
        }
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        public string PriceBuy
        {
            get { return priceBuy; }
            set { priceBuy = value; }
        }
        public string PriceSell
        {
            get { return priceSell; }
            set { priceSell = value; }
        }
      
    }
}
