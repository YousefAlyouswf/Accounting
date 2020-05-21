using Accounting.classes;
using Accounting.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        Category category = new Category();
        Unit unit = new Unit();
        SupplierClass supplier = new SupplierClass();
        string itemCatgory;
        string itemUnit;
        public manager()
        {
            InitializeComponent();
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Show();
            addUserBtn.Hide();
            panelBill.Hide();



            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }
        //أساسيات صفحة المدير
        #region
        // عرض أو اخفاء القائمة الجانبية لصفحة
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
        // زر الخروج من البرنامج
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }
        #endregion
        //اظهار صفحة التقارير
        private void homeButton_Click(object sender, EventArgs e)
        {
            addUserBtn.Hide();
            pageLable.Text = "التقرير";
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Show();
            panelBill.Hide();

        }
       
        //اظهار صفحة فاتورة البيع
        private void billBtn_Click(object sender, EventArgs e)
        {
            addUserBtn.Hide();
            pageLable.Text = "الفاتورة";
            panelSpare.Hide();
            panelEmployee.Hide();
            panelHome.Hide();
            panelBill.Show();

        }
        //---------------------------------- صفحة الموظفين
        #region
        //اظهار صفحة الموظفين
        private void employee_Click(object sender, EventArgs e)
        {
            addUserBtn.Show();
            pageLable.Text = "الموظفين";
            panelSpare.Hide();
            panelEmployee.Show();
            panelBill.Hide();
            panelHome.Hide();
            emClass.getAllEmployee("http://gewscrap.com/allfolder/spare/employee.php");
            empDataGrid.DataSource = emClass.dataTable();

        }
        // اظافة موظف جديد
        private void addUserBtn_Click(object sender, EventArgs e)
        {

            emClass.ShowDialog("رقم الموظف", "أسم الموظف", "كلمة المرور", "الوظيفة", "إظافة موظف جديد", "", "", "", "");
        }
        //عرض معلومات الموظفين بالضغط على سطر الموظف مرتين
        private void showInfo(object sender, DataGridViewCellEventArgs e)
        {
            var dataIndexNo = empDataGrid.Rows[e.RowIndex].Index.ToString();
            string cellValue = empDataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();

            MessageBox.Show(cellValue.ToString());
        }

        #endregion
        //---------------------------------- صفحة أقسام وحدات البضاعه
        #region
        //اظافة قسم جديد
        async private void addCatgreoryBtn_Click(object sender, EventArgs e)
        {
            await category.addCategoryAsync(textBoxCategory.Text);

        }
        // اظهار جميع الاقسام
        private void category_btn_Click(object sender, EventArgs e)
        {
            category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            categoryGridView.DataSource = category.dataTable();
        }
        //---------------------------------- صفحة الوحدات 
      
        //اظهار جميع الوحدات
        private void buttonUnit_Click(object sender, EventArgs e)
        {
            unit.getAllUnit("http://gewscrap.com/allfolder/spare/unit.php?auth=true");
            dataGridView1Unit.DataSource = unit.dataTable();
        }
        //اظافة وحده جديده
        async private void buttonAddUnit_Click_1(object sender, EventArgs e)
        {
            await unit.addUnitAsync(textBoxUnit.Text);
        }

        #endregion
        //---------------------------------- صفحة البضاعه بداية
        #region
        //اظهار صفحة البضاعه
        private void itemButtonClick(object sender, EventArgs e)
        {
            comboBoxItemcategory.Items.Clear();
            comboBoxItemUnit.Items.Clear();
            addUserBtn.Hide();
            pageLable.Text = "البضاعة";
            panelSpare.Show();
            panelEmployee.Hide();
            panelHome.Hide();
            panelBill.Hide();
            category.getCategoryForItem();
            string[] listCategory = category.WildcardFiles();

            for (int i = 0; i < listCategory.Length; i++)
            {
                comboBoxItemcategory.Items.Add(listCategory[i]);
            }

            unit.getUnitForItem();
            string[] listUnit = unit.WildcardFiles();

            for (int i = 0; i < listUnit.Length; i++)
            {
                comboBoxItemUnit.Items.Add(listUnit[i]);
            }
        }
        //اظافة بضاعه جديده
        private void buttonNewItem_Click(object sender, EventArgs e)
        {
            

            string URL = "http://gewscrap.com/allfolder/spare/newItem.php?itemName=" +
                  textBoxItemName.Text + "&category=" + itemCatgory + "&unit=" + itemUnit
                  + "&price_buy=" + textBoxItemBuyPrice.Text + "&price_sell=" + textBoxItemPriceSell.Text;
            using (WebClient client = new WebClient())
            {

                client.DownloadString(URL);

            }

        }

        private void comboBoxItemcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemCatgory = comboBoxItemcategory.Text;
        }

        private void comboBoxItemUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemUnit = comboBoxItemUnit.Text;

        }
        private void productBuy_Keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void productSell_keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
  (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        #endregion

        //---------------------------------- صفحة الموزعين بداية
       async private void buttonAddSuplier_Click(object sender, EventArgs e)
        {
          await  supplier.addSupplyAsync(textBoxSuplier_Company.Text, textBoxSuplier_person.Text, textBoxSuplier_phone.Text,
                textBoxSuplier_mobile.Text, textBoxSuplier_Fax.Text, textBoxSuplier_Address.Text, textBoxSuplier_City.Text,
                textBoxSuplier_Email.Text, textBoxSuplier_Web.Text);
        }
    }

}
