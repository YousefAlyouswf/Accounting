using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    class ReceiptModel
    {
        public string date;
        public string discount;
        public string tax;
        public string note;
        public string id;
        public string customer;

        public ReceiptModel(
            string date,
            string discount,
            string tax,
            string note,
            string id,
            string customer

            )
        {
            this.date = date;
            this.discount = discount;
            this.tax = tax;
            this.note = note;
            this.id = id;
            this.customer = customer;

        }

        public string Date
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
        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }
    }
}
