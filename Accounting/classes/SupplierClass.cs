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
    class SupplierClass
    {
        DataTable dt = new DataTable();
        List<SuppplierModel> supplierList = new List<SuppplierModel>();
        public async void getAllSupplier(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("الشركة");
            dt.Columns.Add("الموزع");
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

                        supplierList = new List<SuppplierModel>();
                        for (int i = 0; i < tokens.Length; i++)
                        {



                            string[] comma = tokens[i].Split(',');
                            supplierList.Add(new SuppplierModel(comma[0], comma[1], comma[3],
                                comma[2], comma[4], comma[5], comma[6], comma[7], comma[8]));

                        }





                        for (int i = 0; i < supplierList.Count; i++)
                        {
                            dt.Rows.Add(supplierList[i].CompanyName, supplierList[i].Person, supplierList[i].Mobile,
                                supplierList[i].Phone, supplierList[i].Fax, supplierList[i].Address,
                                supplierList[i].City, supplierList[i].Email, supplierList[i].Web);
                        }


                    }
                }
            }
        }
        public DataTable dataTable()
        {
            return dt;
        }
        //Add Supplier
        #region
        public async Task addSupplyAsync(
            string companyName,
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
                    "http://gewscrap.com/allfolder/spare/supplier.php?company=" +
                  companyName + "&person=" + person
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
                string URL = "http://gewscrap.com/allfolder/spare/supplier.php?company=" +
                  companyName + "&person=" + person
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
                MessageBox.Show("الموزع موجود");

            }
        }
        #endregion


        //Get All Supplier forInvoice
        #region
        string[] tokens = new string[] { };
        public async Task getSupplierForInvoice()
        {


            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/supplier.php?dropbox=true"))
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
