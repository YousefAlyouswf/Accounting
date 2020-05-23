using Accounting.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.classes
{
    class ItemClass
    {
        DataTable dt = new DataTable();
        List<ItemModel> ItemList = new List<ItemModel>();
        public async void getAllItem(string url)
        {
            dt = new DataTable();
            dt.Columns.Add("المنتج");
            dt.Columns.Add("القسم");
            dt.Columns.Add("الوحدة");
            dt.Columns.Add("سعر الشراء");
            dt.Columns.Add("سعر البيع");

            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');

                        ItemList = new List<ItemModel>();
                        for (int i = 0; i < tokens.Length; i++)
                        {

                            string[] comma = tokens[i].Split(',');

                            ItemList.Add(new ItemModel(comma[0], comma[1], comma[2],
                                comma[3], comma[4]));

                        }





                        for (int i = 0; i < ItemList.Count; i++)
                        {
                            dt.Rows.Add(ItemList[i].ItemName, ItemList[i].Category, ItemList[i].Unit,
                                ItemList[i].PriceBuy, ItemList[i].PriceSell);
                        }


                    }
                }
            }
        }
        public DataTable dataTable()
        {
            return dt;
        }
    }
}
