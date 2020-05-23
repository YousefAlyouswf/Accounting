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
    public class EmployeeClass
    {
        DataTable dt = new DataTable();
        List<employeeModels> employeeList = new List<employeeModels>();
        public async void getAllEmployee(string url)
        { 
            dt = new DataTable();
                        dt.Columns.Add("رقم الموظف");
                        dt.Columns.Add("الأسم");
                        dt.Columns.Add("الوظيفة");
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {

                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');

                        employeeList = new List<employeeModels>();
                        for (int i = 0; i < tokens.Length; i++)
                        {



                            string[] comma = tokens[i].Split(',');
                            employeeList.Add(new employeeModels(comma[1], comma[0], comma[2]));

                        }


                      


                        for (int i = 0; i < employeeList.Count; i++)
                        {
                            dt.Rows.Add(employeeList[i].Name, employeeList[i].Number, employeeList[i].Position);
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
