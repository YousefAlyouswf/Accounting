using Accounting.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class manager : Form
    {
        bool panelHideOrShow = true;
        EmployeeClass emClass = new EmployeeClass();
        public manager()
        {
            InitializeComponent();
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Show();
            addUserBtn.Hide();
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
            addUserBtn.Hide();
            pageLable.Text = "التقرير";
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Show();
        }

        private void spareButtonClick(object sender, EventArgs e)
        {
            addUserBtn.Hide();
            pageLable.Text = "قطع الغيار";
            panelSpare.Show();
            panelEmployee.Hide();
            panelHome.Hide();
        }

        private void employee_Click(object sender, EventArgs e)
        {
            addUserBtn.Show();
            pageLable.Text = "الموظفين";
            panelSpare.Hide();
            panelEmployee.Show();
            panelHome.Hide();
             emClass.getAllEmployee("http://gewscrap.com/allfolder/spare/employee.php");
            empDataGrid.DataSource = emClass.dataTable();

        }
        private void addUserBtn_Click(object sender, EventArgs e)
        {

            emClass.ShowDialog("رقم الموظف", "أسم الموظف", "كلمة المرور", "الوظيفة", "إظافة موظف جديد", "", "", "", "");
        }

     

        private void showInfo(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = empDataGrid.Rows[e.RowIndex].Index.ToString();
            string cellValue = empDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();

            MessageBox.Show(cellValue.ToString());
        }

    }
}
