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

namespace Accounting
{
    class Category
    {
        public async Task addCategoryAsync(string textBoxCategory)
        {
            string checkError;
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/addCatgory.php?category=" +
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
                string URL = "http://gewscrap.com/allfolder/spare/addCatgory.php?category=" +
                  textBoxCategory;
                using (WebClient client = new WebClient())
                {

                    client.DownloadString(URL);

                }
            }
            else
            {
                MessageBox.Show("القسم موجود");

            }
        }
        DataTable dt = new DataTable();
        List<categoryModel> categoryList = new List<categoryModel>();
        public async void getAllCategroies(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("أسم القسم");
            dt.Columns.Add("رقم القسم");

            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');

                        categoryList = new List<categoryModel>();
                        for (int i = 0; i < tokens.Length; i++)
                        {

                            string[] comma = tokens[i].Split(',');
                            categoryList.Add(new categoryModel(comma[1], comma[0]));

                        }





                        for (int i = 0; i < categoryList.Count; i++)
                        {
                            dt.Rows.Add(categoryList[i].Id, categoryList[i].CategoryName);
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
        public async void getCategoryForItem()
        {
            

            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/addCatgory.php?dropbox=true"))
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
