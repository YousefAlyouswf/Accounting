using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    class InvoiceModel
    {
        public DateTime date;
        public string discount;
        public string tax;
        public string note;
        public string id;
        public string supplier;
   
        public InvoiceModel(
            DateTime date,
            string discount,
            string tax,
            string note,
            string id,
            string supplier
         
            )
        {
            this.date = date;
            this.discount = discount;
            this.tax = tax;
            this.note = note;
            this.id = id;
            this.supplier = supplier;
       
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
    
    }
}
