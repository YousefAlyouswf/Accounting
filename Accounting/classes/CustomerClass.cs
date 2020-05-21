using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.classes
{
    class CustomerClass
    {
        public async Task addCustomerAsync(
          string person,
          string phone,
          string mobile,
          string fax,
          string address,
          string city,
          string email,
          string web)
        {
            string checkError;
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(
                    "http://gewscrap.com/allfolder/spare/customer.php?person=" + person
                  + "&phone=" + phone + "&mobile=" + mobile
                  + "&fax=" + fax + "&address=" + address
                  + "&city=" + city + "&email=" + email
                  + "&web=" + web))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        checkError = theContent;
                    }
                }
            }

            if (checkError == "")
            {
                string URL = "http://gewscrap.com/allfolder/spare/customer.php?person=" + person
                  + "&phone=" + phone + "&mobile=" + mobile
                  + "&fax=" + fax + "&address=" + address
                  + "&city=" + city + "&email=" + email
                  + "&web=" + web;
                using (WebClient client = new WebClient())
                {

                    client.DownloadString(URL);

                }
            }
            else
            {
                MessageBox.Show("العميل موجود");

            }
        }
    }
}
