using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
namespace Accounting
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            manager m = new manager();
            this.Hide();
            m.Text = " المدير ";
            m.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {



            getRequest("http://gewscrap.com/allfolder/spare/checkuser.php?userNumber=" + userName.Text + "&password=" + password.Text);




        }

        async void getRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {

                using (HttpResponseMessage httpResponse = await client.GetAsync(url))
                {

                    using (HttpContent content = httpResponse.Content)
                    {
                        string theContent = await content.ReadAsStringAsync();
                        string[] tokens = theContent.Split(',');
                        if (tokens[0] == "مدير")
                        {
                            manager m = new manager();
                            this.Hide();
                            m.Text = " المدير "+tokens[1]  ;
                            m.Show();
                        }
                        else if (tokens[0] == "موظف")
                        {

                            employee em = new employee();

                            this.Hide();
                            em.Text = em.Text = " الموظف "+ tokens[1];
                            em.Show();
                        }
                        else
                        {
                             MessageBox.Show("البيانات غير صحيحة", "خطأ");
                        }
                    }
                }
            }
        }


        private void clearPassword(object sender, EventArgs e)
        {
            if (password.Text == "------")
            {
                password.Text = "";

            }
            if (userName.Text == "")
            {
                userName.Text = "رقم الموظف";
            }

        }

        private void clearNum(object sender, EventArgs e)
        {
            if (userName.Text == "رقم الموظف")
            {
                userName.Text = "";
            }
            if (password.Text == "")
            {
                password.Text = "------";
            }

        }

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minmize(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void userChange(object sender, EventArgs e)
        {

            if (userName.Text != "رقم الموظف")
            {
                userName.ForeColor = Color.Black;
            }
            else
            {
                userName.ForeColor = Color.Silver;
            }
        }

        private void passChange(object sender, EventArgs e)
        {
            if (password.Text != "------")
            {
                password.ForeColor = Color.Black;
            }
            else
            {
                password.ForeColor = Color.Silver;
            }
        }
    }
}