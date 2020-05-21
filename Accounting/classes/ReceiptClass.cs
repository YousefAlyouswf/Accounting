using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.classes
{
    class ReceiptClass
    {
        public void addReceiptAsync(
         DateTime date,
         string discount,
         string tax,
         string note,
         string id,
         string customer
         )
        {

            string URL = "http://gewscrap.com/allfolder/spare/receipt.php?date=" +
              date + "&discount=" + discount
              + "&tax=" + tax + "&note=" + note
              + "&id=" + id + "&customer=" + customer
              ;
            using (WebClient client = new WebClient())
            {

                client.DownloadString(URL);

            }

        }
    }
}
