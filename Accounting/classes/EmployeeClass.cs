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

        public string ShowDialog(string numberText, string nameText,
            string passText, string positionText, string caption, string savenum, string savepass, string savename
            , string savepos)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 450,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabelNumber = new Label() { Left = 50, Top = 20, Text = numberText };
            TextBox textBoxNumber = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Label textLabelPass = new Label() { Left = 50, Top = 100, Text = passText };
            TextBox textBoxPass = new TextBox() { Left = 50, Top = 130, Width = 200 };
            Label textLabelName = new Label() { Left = 50, Top = 180, Text = nameText };
            TextBox textBoxName = new TextBox() { Left = 50, Top = 210, Width = 200 };
            Label textLabelPos = new Label() { Left = 50, Top = 260, Text = positionText };
            TextBox textBoxPos = new TextBox() { Left = 50, Top = 290, Width = 200 };
            Button confirmation = new Button() { Text = "إظافة", Left = 70, Width = 100, Top = 340, DialogResult = DialogResult.OK };

            textBoxNumber.Text = savenum;
            textBoxName.Text = savename;
            textBoxPass.Text = savepass;
            textBoxPos.Text = savepos;


            confirmation.Click += async (sender, e) =>
            {
                string checkError;
                using (HttpClient client = new HttpClient())
                {

                    using (HttpResponseMessage httpResponse = await client.GetAsync("http://gewscrap.com/allfolder/spare/valid.php?userNumber=" +
                textBoxNumber.Text))
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
                    string URL = "http://gewscrap.com/allfolder/spare/addUser.php?userNumber=" +
                      textBoxNumber.Text + "&password=" + textBoxPass.Text + "&position=" + textBoxPos.Text
                       + "&name=" + textBoxName.Text;
                    using (WebClient client = new WebClient())
                    {
                        string src = client.DownloadString(URL);
                        getAllEmployee("http://gewscrap.com/allfolder/spare/employee.php");

                    }
                }
                else
                {
                    MessageBox.Show("رقم الموظف مستخدم");
                    ShowDialog("رقم الموظف", "أسم الموظف", "كلمة المرور", "الوظيفة", "إظافة موظف جديد",
                        textBoxNumber.Text, textBoxPass.Text, textBoxName.Text, textBoxPos.Text);
                }

            };
            prompt.Controls.Add(textLabelNumber);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textBoxNumber);
            prompt.Controls.Add(textLabelPass);
            prompt.Controls.Add(textBoxPass);

            prompt.Controls.Add(textLabelName);

            prompt.Controls.Add(textBoxName);
            prompt.Controls.Add(textLabelPos);
            prompt.Controls.Add(textBoxPos);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textLabelNumber.Text : "";
        }


    }
}
