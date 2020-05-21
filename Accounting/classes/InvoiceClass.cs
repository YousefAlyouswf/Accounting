using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.classes
{
    class InvoiceClass
    {
        public void addInvoiceAsync(
           DateTime date,
           string discount,
           string tax,
           string note,
           string id,
           string supplier
           )
        {

            string URL = "http://gewscrap.com/allfolder/spare/invoice.php?date=" +
              date + "&discount=" + discount
              + "&tax=" + tax + "&note=" + note
              + "&id=" + id + "&supplier=" + supplier
              ;
            using (WebClient client = new WebClient())
            {

                client.DownloadString(URL);

            }

        }
    }
}
