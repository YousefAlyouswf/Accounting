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
    class InvoiceClass
    {
        DataTable dt = new DataTable();
        List<InvoiceModel> invoiceList = new List<InvoiceModel>();
        public async void getAllInvoice(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("التاريخ");
            dt.Columns.Add("الخصم");
            dt.Columns.Add("الضريبة");
            dt.Columns.Add("ملاحظات");
            dt.Columns.Add("رقم الفاتورة");
            dt.Columns.Add("الموزع");
          
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');

                        invoiceList = new List<InvoiceModel>();
                        for (int i = 0; i < tokens.Length; i++)
                        {

                            string[] comma = tokens[i].Split(',');
                    
                            invoiceList.Add(new InvoiceModel(comma[0], comma[1], comma[2],
                                comma[3], comma[4], comma[5]));

                        }





                        for (int i = 0; i < invoiceList.Count; i++)
                        {
                            dt.Rows.Add(invoiceList[i].Date, invoiceList[i].Discount, invoiceList[i].Tax,
                                invoiceList[i].Note, invoiceList[i].Id, invoiceList[i].Supplier);
                        }


                    }
                }
            }
        }
        public DataTable dataTable()
        {
            return dt;
        }
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
