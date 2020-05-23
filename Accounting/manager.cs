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
        AddWindow addWindow = new AddWindow();
        ItemClass item = new ItemClass();
       
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
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addInvoiceBtn.Hide();
            reloadInvoiceBtn.Hide();
            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();


            #endregion

            // تواريخ الشراء والبيع فورمات
            #region
            //dateTimeInvoice.Format = DateTimePickerFormat.Custom;
            //dateTimeInvoice.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;


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

            pageLable.Text = "التقرير";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            panelReceipt.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addInvoiceBtn.Hide();
            reloadInvoiceBtn.Hide();
            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
            addCustomerBtn.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            reloadCustomerBtn.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();

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
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addInvoiceBtn.Hide();
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            reloadInvoiceBtn.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();

            addUserBtn.Show();
            pageLable.Text = "الموظفين";

            //اظهار واخفاء الصفحات
            panelEmployee.Show();

            emClass.getAllEmployee("http://gewscrap.com/allfolder/spare/employee.php");
            empDataGrid.DataSource = emClass.dataTable();
        }
        // اظافة موظف جديد
        async private void addUserBtn_Click(object sender, EventArgs e)
        {

            //  emClass.ShowDialog("رقم الموظف", "أسم الموظف", "كلمة المرور", "الوظيفة", "إظافة موظف جديد", "", "", "", "");



            string[] labelName = { "رقم الموظف", "أسم الموظف", "كلمة المرور", "الوظيفة" };
            string[] sendValue = { "userNumber", "name", "password", "position" };
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/addUser.php",
                 sendValue,
                 labelName,
                 heigh: 450,
                 width: 300,
                 caption: "إظافة موظف جديد",
                 labelAndTextbox: 4,
                 unique: true,
                 errorMessage: "رقم الموظف موجود مسبقا"
                 );
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
        async private void buttonCategory_Click(object sender, EventArgs e)
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
            catgoryReload_btn.Show();
            addInvoiceBtn.Hide();
            addCustomerBtn.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            reloadCustomerBtn.Hide();
            reloadInvoiceBtn.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();

            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();


            addCategoryBtn.Show();

            await category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            categoryGridView.DataSource = category.dataTable();
        }
        //اظافة قسم جديد

        async private void catgoryReload_btn_Click(object sender, EventArgs e)
        {
            await category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            categoryGridView.DataSource = category.dataTable();
        }
        async private void addCategoryBtn_Click(object sender, EventArgs e)
        {


            string[] labelName = { "أسم القسم" };
            string[] sendValue = { "category" };
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/addCatgory.php",
                 sendValue,
                 labelName,
                 heigh: 400,
                 width: 300,
                 caption: "إظافة قسم جديد",
                 labelAndTextbox: 1,
                 unique: true,
                 errorMessage: "القسم موجود"
                 );
            await category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            categoryGridView.DataSource = category.dataTable();
        }
        // اظهار جميع الاقسام

        //---------------------------------- صفحة الوحدات 

        //اظهار جميع الوحدات
        async private void buttonUnit_Click(object sender, EventArgs e)
        {
            await unit.getAllUnit("http://gewscrap.com/allfolder/spare/unit.php?auth=true");
            dataGridView1Unit.DataSource = unit.dataTable();
            pageLable.Text = "الوحدات";
            panelEmployee.Hide();
            addUserBtn.Hide();
            panelItem.Hide();
            panelInvoice.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();
            panelReceipt.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            panelSupplier.Hide();
            panelCustomer.Hide();

            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
            panelUnit.Show();
            panel_catagory.Hide();
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            unitReload_btn.Show();
            addUnitBtn.Show();
            addInvoiceBtn.Hide();
            reloadInvoiceBtn.Hide();

        }
        //اظافة وحده جديده

        async private void addUnitBtn_Click(object sender, EventArgs e)
        {
            //unit.ShowDialog("أسم الوحدة", "إظافة وحدة جديدة", "");

            string[] labelName = { "أسم الوحدة" };
            string[] sendValue = { "unit" };
            await addWindow.ShowDialog(
                  "http://gewscrap.com/allfolder/spare/unit.php",
                  sendValue,
                  labelName,
                  heigh: 400,
                  width: 300,
                  caption: "إظافة وحدة جديدة",
                  labelAndTextbox: 1,
                  unique: true,
                  errorMessage: "الوحدة موجودة"
                  );
            await unit.getAllUnit("http://gewscrap.com/allfolder/spare/unit.php?auth=true");
            dataGridView1Unit.DataSource = unit.dataTable();
        }

        async private void unitReload_btn_Click(object sender, EventArgs e)
        {
            await unit.getAllUnit("http://gewscrap.com/allfolder/spare/unit.php?auth=true");
            dataGridView1Unit.DataSource = unit.dataTable();
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
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            panelSupplier.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            panelCustomer.Hide();
            panelUnit.Hide();
            panel_catagory.Hide();
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addInvoiceBtn.Hide();
            reloadInvoiceBtn.Hide();

            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
           
            addUserBtn.Hide(); 
            reloadItemBtn.Show();
            addItemBtn.Show();
           
            pageLable.Text = "البضاعة";
            panelEmployee.Hide();
            item.getAllItem("http://gewscrap.com/allfolder/spare/newitem.php?auth=1");
            gunaDataGridViewItem.DataSource = item.dataTable();

        }
        async private void addItemBtn_Click(object sender, EventArgs e)
        {
            string[] labelName = { "القسم", "الوحدة", "أسم البضاعة", "سعر الشراء", "سعر البيع" };
            string[] sendValue = { "category", "unit", "itemName", "price_buy", "price_sell"};
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/newItem.php",
                 sendValue,
                 labelName,
                 heigh: 600,
                 width: 300,
                 caption: "إظافة بضاعة جديدة",
                 labelAndTextbox: 5,
                dropBox2: true,
                 dropBox: true,
                 classNameForCombp: "customer1"
                 );
        }
        //اظافة بضاعه جديده
      
      
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
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            panelUnit.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();
            panel_catagory.Hide();
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addInvoiceBtn.Hide();
            reloadInvoiceBtn.Hide();
            reloadSupplierBtn.Show();
            addSupplierBtn.Show();
            supplier.getAllSupplier("http://gewscrap.com/allfolder/spare/supplier.php?auth=1");
            gunaDataGridViewSupplier.DataSource = supplier.dataTable();

        }
        async private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            string[] labelName = { "الشركة", "أسم الموزع", "الجوال", "الهاتف", "الفاكس", "العنوان", "المدينة", "البريد الإكتروني", "موقع الإكتروني" };
            string[] sendValue = { "company", "person", "mobile", "phone", "fax", "address", "city", "email", "web" };
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/supplier.php",
                 sendValue,
                 labelName,
                 heigh: 950,
                 width: 300,
                 caption: "إظافة موزع جديد",
                 labelAndTextbox: 9,
                 unique: true,
                 errorMessage: "الموزع موجود"
                 );
            //await category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            //categoryGridView.DataSource = category.dataTable();
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
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            panel_catagory.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addInvoiceBtn.Hide();
            reloadInvoiceBtn.Hide();
            reloadCustomerBtn.Show();
            addCustomerBtn.Show();

            customer.getAllCusomer("http://gewscrap.com/allfolder/spare/customer.php?auth=1");
            gunaDataGridViewCustomer.DataSource = customer.dataTable();

        }
        async private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            string[] labelName = { "أسم العميل", "الجوال", "الهاتف", "الفاكس", "العنوان", "المدينة", "البريد الإكتروني", "موقع الإكتروني" };
            string[] sendValue = { "person", "mobile", "phone", "fax", "address", "city", "email", "web" };
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/customer.php",
                 sendValue,
                 labelName,
                 heigh: 850,
                 width: 300,
                 caption: "إظافة عميل جديد",
                 labelAndTextbox: 8,
                 unique: true,
                 errorMessage: "العميل موجود"
                 );
            //await category.getAllCategroies("http://gewscrap.com/allfolder/spare/addCatgory.php?auth=true");
            //categoryGridView.DataSource = category.dataTable();
        }

        #endregion
        //---------------------------------- صفحة فاتورة شراء والبيع
        #region
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
            addItemBtn.Hide();
            reloadItemBtn.Hide();
            addCategoryBtn.Hide();
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            catgoryReload_btn.Hide();
            reloadInvoiceBtn.Show();
            addInvoiceBtn.Show();
            addUnitBtn.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            unitReload_btn.Hide();

            addReceiptBtn.Hide();
            reloadReceiptBtn.Hide();
            invoice.getAllInvoice("http://gewscrap.com/allfolder/spare/invoice.php?auth=1");
            gunaDataGridView1Invoice.DataSource = invoice.dataTable();
        }
        async private void addInvoiceBtn_Click(object sender, EventArgs e)
        {



            string[] labelName = { "التاريخ", "الموزع", "الخصم", "الضريبه", "ملاحظات", "رقم الفاتورة" };
            string[] sendValue = { "date", "supplier", "discount", "tax", "note", "id" };
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/invoice.php",
                 sendValue,
                 labelName,
                 heigh: 600,
                 width: 300,
                 caption: "إصدار فاتورة شراء",
                 labelAndTextbox: 6,
                 dateTime: true,
                 dropBox: true
                 );
        }

        async private void addReceiptBtn_Click(object sender, EventArgs e)
        {
            string[] labelName = { "التاريخ", "العميل", "الخصم", "الضريبه", "ملاحظات", "رقم الفاتورة" };
            string[] sendValue = { "date", "customer", "discount", "tax", "note", "id" };
            await addWindow.ShowDialog(
                 "http://gewscrap.com/allfolder/spare/receipt.php",
                 sendValue,
                 labelName,
                 heigh: 600,
                 width: 300,
                 caption: "إصدار فاتورة بيع",
                 labelAndTextbox: 6,
                 dateTime: true,
                 dropBox: true,
                 classNameForCombp: "customer"
                 );
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
            addCustomerBtn.Hide();
            reloadCustomerBtn.Hide();
            addCategoryBtn.Hide();
            catgoryReload_btn.Hide();
            addInvoiceBtn.Hide();
            addItemBtn.Hide();
            reloadItemBtn.Hide();
            reloadInvoiceBtn.Hide();
            addUnitBtn.Hide();
            unitReload_btn.Hide();
            addSupplierBtn.Hide();
            reloadSupplierBtn.Hide();
            reloadReceiptBtn.Show();
            addReceiptBtn.Show();
            receipt.getAllReceipt("http://gewscrap.com/allfolder/spare/receipt.php?auth=1");
            gunaDataGridViewReceipt.DataSource = receipt.dataTable();

        }




















        #endregion


    }

}
