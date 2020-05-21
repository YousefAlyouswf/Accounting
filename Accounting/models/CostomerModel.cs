using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.models
{
    class CostomerModel
    {
        public string person;
        public string phone;
        public string mobile;
        public string fax;
        public string address;
        public string city;
        public string email;
        public string web;
        public CostomerModel(
            string person,
            string phone,
            string mobile,
            string fax,
            string address,
            string city,
            string email,
            string web
            )
        {
            this.person = person;
            this.phone = phone;
            this.mobile = mobile;
            this.fax = fax;
            this.address = address;
            this.city = city;
            this.email = email;
            this.web = web;
        }
      
        public string Person
        {
            get { return person; }
            set { person = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Web
        {
            get { return web; }
            set { web = value; }
        }
    }
}
