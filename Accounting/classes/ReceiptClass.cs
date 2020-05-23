using Accounting.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.classes
{
    class ReceiptClass
    {
        DataTable dt = new DataTable();
        List<ReceiptModel> receiptList = new List<ReceiptModel>();
        public async void getAllReceipt(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("التاريخ");
            dt.Columns.Add("الخصم");
            dt.Columns.Add("الضريبة");
            dt.Columns.Add("ملاحظات");
            dt.Columns.Add("رقم الفاتورة");
            dt.Columns.Add("العميل");

            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');

                        receiptList = new List<ReceiptModel>();
                        for (int i = 0; i < tokens.Length; i++)
                        {

                            string[] comma = tokens[i].Split(',');

                            receiptList.Add(new ReceiptModel(comma[0], comma[1], comma[2],
                                comma[3], comma[4], comma[5]));

                        }





                        for (int i = 0; i < receiptList.Count; i++)
                        {
                            dt.Rows.Add(receiptList[i].Date, receiptList[i].Discount, receiptList[i].Tax,
                                receiptList[i].Note, receiptList[i].Id, receiptList[i].Customer);
                        }


                    }
                }
            }
        }
        public DataTable dataTable()
        {
            return dt;
        }
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
