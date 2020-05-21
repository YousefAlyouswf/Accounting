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
    class Unit
    {
        public async Task addUnitAsync(string textBoxCategory)
        {
            string checkError;
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/unit.php?unit=" +
                  textBoxCategory))
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
                string URL = "http://gewscrap.com/allfolder/spare/unit.php?unit=" +
                  textBoxCategory;
                using (WebClient client = new WebClient())
                {

                    client.DownloadString(URL);

                }
            }
            else
            {
                MessageBox.Show("الوحدة موجودة");

            }
        }
        DataTable dt = new DataTable();
        List<UnitModel> categoryList = new List<UnitModel>();
        public async void getAllUnit(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("أسم الوحدة");
            dt.Columns.Add("رقم الوحدة");

            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        if (theContent != "")
                        {
                            string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                            string[] tokens = founderMinus1.Split('|');

                            categoryList = new List<UnitModel>();
                            for (int i = 0; i < tokens.Length; i++)
                            {

                                string[] comma = tokens[i].Split(',');
                                categoryList.Add(new UnitModel(comma[1], comma[0]));

                            }





                            for (int i = 0; i < categoryList.Count; i++)
                            {
                                dt.Rows.Add(categoryList[i].Id, categoryList[i].UnitName);
                            }
                        }



                    }
                }
            }
        }
        public DataTable dataTable()
        {
            return dt;
        }
        string[] tokens = new string[] { };
        public async void getUnitForItem()
        {


            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/unit.php?dropbox=true"))
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
    }
}
