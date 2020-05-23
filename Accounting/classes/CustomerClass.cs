using Accounting.models;
using System;
using System.Collections.Generic;
using System.Data;
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
        DataTable dt = new DataTable();
        List<CostomerModel> customerList = new List<CostomerModel>();
        public async void getAllCusomer(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("أسم العميل");
            dt.Columns.Add("الجوال");
            dt.Columns.Add("الهاتف");
            dt.Columns.Add("فاكس");
            dt.Columns.Add("العنوان");
            dt.Columns.Add("المدينة");
            dt.Columns.Add("الإيميل");
            dt.Columns.Add("ويب");
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');

                        customerList = new List<CostomerModel>();
                        for (int i = 0; i < tokens.Length; i++)
                        {



                            string[] comma = tokens[i].Split(',');
                            customerList.Add(new CostomerModel(comma[0], comma[2], comma[1],
                                comma[3], comma[4], comma[5], comma[6], comma[7]));

                        }





                        for (int i = 0; i < customerList.Count; i++)
                        {
                            dt.Rows.Add(customerList[i].Person, customerList[i].Mobile,
                                customerList[i].Phone, customerList[i].Fax, customerList[i].Address,
                                customerList[i].City, customerList[i].Email, customerList[i].Web);
                        }


                    }
                }
            }
        }
        public DataTable dataTable()
        {
            return dt;
        }
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
        //Get All Supplier forInvoice
        #region
        string[] tokens = new string[] { };
       async public Task getCustomerForReceipt()
        {


            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/customer.php?dropbox=true"))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        tokens = founderMinus1.Split('|');
                    }
                }
            }


        }
        public string[] WildcardFiles()
        {



            return tokens;
        }
        #endregion
    }
}
