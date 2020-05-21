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
        // Golbal Variable
        #region
        bool panelHideOrShow = true;
        EmployeeClass emClass = new EmployeeClass();
        Category category = new Category();
        Unit unit = new Unit();
        SupplierClass supplier = new SupplierClass();
        CustomerClass customer = new CustomerClass();
        InvoiceClass invoice = new InvoiceClass();
        ReceiptClass receipt = new ReceiptClass();
        string itemCatgory;
        string itemUnit;
        #endregion
        public manager()
        {
            // اظهار واخفاء الصفحات في البدايه
            #region
            InitializeComponent();
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();
            #endregion

            // تواريخ الشراء والبيع فورمات
            #region
            dateTimeInvoice.Format = DateTimePickerFormat.Custom;
            dateTimeInvoice.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;

            dateTimeReceipt.Format = DateTimePickerFormat.Custom;
            dateTimeReceipt.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
            #endregion
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
            panelEmployee.Hide();

        }


        //---------------------------------- صفحة الموظفين
        #region
        //اظهار صفحة الموظفين
        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            pageLable.Text = "الموظفين";
            panelEmployee.Show();
            addUserBtn.Show();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();

            addUserBtn.Show();
            pageLable.Text = "الموظفين";

            //اظهار واخفاء الصفحات
            panelEmployee.Show();

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
        //---------------------------------- صفحة أقسام وحدات 
        #region
        //اظهار صفحة الاقسام
        private void buttonCategory_Click(object sender, EventArgs e)
        {
            pageLable.Text = "أقسام البضاعه";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Show();

            category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            categoryGridView.DataSource = category.dataTable();
        }
        //اظافة قسم جديد
        async private void addCatgreoryBtn_Click(object sender, EventArgs e)
        {
            await category.addCategoryAsync(textBoxCategory.Text);

        }
        // اظهار جميع الاقسام

        //---------------------------------- صفحة الوحدات 

        //اظهار جميع الوحدات
        private void buttonUnit_Click(object sender, EventArgs e)
        {
            unit.getAllUnit("http://gewscrap.com/allfolder/spare/unit.php?auth=true");
            dataGridView1Unit.DataSource = unit.dataTable();
            pageLable.Text = "الوحدات";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Show();
            panel_catagory.Hide();
        }
        //اظافة وحده جديده
        async private void buttonAddUnit_Click_1(object sender, EventArgs e)
        {
            await unit.addUnitAsync(textBoxUnit.Text);
        }

        #endregion
        //---------------------------------- صفحة البضاعه 
        #region
        //اظهار صفحة البضاعه
        private void buttonItem_Click(object sender, EventArgs e)
        {
            pageLable.Text = "بضاعه";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Show();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();

            comboBoxItemcategory.Items.Clear();
            comboBoxItemUnit.Items.Clear();
            addUserBtn.Hide();
            pageLable.Text = "البضاعة";
            panelEmployee.Hide();
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
        //---------------------------------- صفحة الموزعين , العملاء 
        #region
        //اظهار صفحة الموزعين
        private void buttonSupplier_Click(object sender, EventArgs e)
        {
            pageLable.Text = "الموزعين";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Show();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();
        }
        async private void buttonAddSuplier_Click(object sender, EventArgs e)
        {
            await supplier.addSupplyAsync(textBoxSuplier_Company.Text, textBoxSuplier_person.Text, textBoxSuplier_phone.Text,
                  textBoxSuplier_mobile.Text, textBoxSuplier_Fax.Text, textBoxSuplier_Address.Text, textBoxSuplier_City.Text,
                  textBoxSuplier_Email.Text, textBoxSuplier_Web.Text);
        }
        //اظهار صفحة العملاء
        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            pageLable.Text = "العملاء";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Show();
            panelUnit.Hide();
            panel_catagory.Hide();
        }
        async private void buttonAddCustomer_Click(object sender, EventArgs e)
        {
            await customer.addCustomerAsync(
                textBoxCustomerName.Text, textBoxCustomerPhone.Text,
                  textBoxCustomerMobile.Text, textBoxCustomerFax.Text, textBoxCustomerAddress.Text, textBoxCustomerCity.Text,
                  textBoxCustomerEmail.Text, textBoxCustomerWeb.Text
                );
        }

        #endregion
        //---------------------------------- صفحة فاتورة شراء والبيع
        #region
        string suplierFromInvoice;
        string customerFromReceipt;
        //اظهار صفحة فاتورة شراء
        private void buttonInvoice_Click(object sender, EventArgs e)
        {
            pageLable.Text = "فاتورة شراء";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Show();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();
        }
        private void buttonIvoiceRefresh_Click(object sender, EventArgs e)
        {
            comboBoxInvoiceSupllier.Items.Clear();
            supplier.getSupplierForInvoice();
            string[] listCategory = supplier.WildcardFiles();

            for (int i = 0; i < listCategory.Length; i++)
            {
                comboBoxInvoiceSupllier.Items.Add(listCategory[i]);
            }
        }

        private void comboBoxInvoiceSupllier_SelectedIndexChanged(object sender, EventArgs e)
        {
            suplierFromInvoice = comboBoxInvoiceSupllier.Text;
        }

        private void buttonAddInvoice_Click(object sender, EventArgs e)
        {
            invoice.addInvoiceAsync(dateTimeInvoice.Value.Date, textBoxinvoiceDiscount.Text, textBoxinvoiceTax.Text,
                textBoxinvoiceNote.Text,textBoxinvoiceID.Text ,suplierFromInvoice);
        }
        //اظهار فاتوره بيع
        private void buttonReceipt_Click(object sender, EventArgs e)
        {
            pageLable.Text = "فاتورة بيع";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Show();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();
        }
        private void buttonCustomerRefresh_Click(object sender, EventArgs e)
        {
            comboBoxReceipt.Items.Clear();
            customer.getCustomerForReceipt();
            string[] listCategory = customer.WildcardFiles();

            for (int i = 0; i < listCategory.Length; i++)
            {
                comboBoxReceipt.Items.Add(listCategory[i]);
            }
        }

        private void buttonAddReceipt_Click(object sender, EventArgs e)
        {
            receipt.addReceiptAsync(dateTimeReceipt.Value.Date, textBoxReceiptDiscount.Text, textBoxReceiptTax.Text,
                            textBoxReceiptNote.Text, textBoxReceiptID.Text, customerFromReceipt);
        }

        private void comboBoxReceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerFromReceipt = comboBoxReceipt.Text;
        }

        #endregion

       

       

       

        

      

     
    }

}
