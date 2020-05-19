using Accounting.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class manager : Form
    {
        bool panelHideOrShow = true;
        public manager()
        {
            InitializeComponent();
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!panelHideOrShow)
            {
                rightPanel.Show();
                panelHideOrShow = !panelHideOrShow;
            }
            else
            {
                rightPanel.Hide();
                panelHideOrShow = !panelHideOrShow;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }




        private void homeButton_Click(object sender, EventArgs e)
        {
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Show();
        }

        private void spareButtonClick(object sender, EventArgs e)
        {
            panelSpare.Show();
            panelEmployee.Hide();
            panelHome.Hide();
        }

        private void employee_Click(object sender, EventArgs e)
        {
            panelSpare.Hide();
            panelEmployee.Show();
            panelHome.Hide();
            getAllEmployee("http://gewscrap.com/allfolder/spare/employee.php");


        }
        async void getAllEmployee(string url)
        {
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {
                        list.Text = "";
                        string theContent = await content.ReadAsStringAsync();
                        string founderMinus1 = theContent.Remove(theContent.Length - 1, 1);
                        string[] tokens = founderMinus1.Split('|');
                        List<employeeModels> employeeList = new List<employeeModels>();

                        for (int i = 0; i < tokens.Length; i++)
                        {



                            string[] comma = tokens[i].Split(',');
                            employeeList.Add(new employeeModels(comma[0], comma[1], comma[2]));

                        }



                        foreach (var emp in employeeList)
                        {

                            list.Text += "الموظف:" + emp.Name + " " + emp.Number + " " + emp.Position;
                            list.Text += "\n";

                        }

                    }
                }
            }
        }
    }
}
