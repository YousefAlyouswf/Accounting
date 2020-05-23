using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.classes
{
    class AddWindow
    {


        async public Task<string> ShowDialog(
             string urladd,
             string[] sendValue,
             string[] labelName,
             int heigh = 300,
             int width = 400,
             string caption = "",
             int labelAndTextbox = 1,
             bool unique = false,
             string errorMessage = "خطأ في الادخال",
             bool dateTime = false,
             bool dropBox = false,
             bool dropBox2 = false,
             string classNameForCombp = "supplier"
             )
        {
            List<Label> labels = new List<Label>();
            List<TextBox> textBoxs = new List<TextBox>();
            DateTimePicker datePicker = new DateTimePicker();
            ComboBox combo = new ComboBox();
            ComboBox combo2 = new ComboBox();
            SupplierClass supplier = new SupplierClass();
            CustomerClass customer = new CustomerClass();
            Category category = new Category();
            Unit unit = new Unit();
            Form prompt = new Form()
            {
                Width = width,
                Height = heigh,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };


            bool dateAdded = false;
            bool dateSend = false;
            bool comboAdded = false;
            bool comboSend = false;
            bool comboAdded2 = false;
            bool comboSend2 = false;
            int labelTop = 20;
            int textboxTop = 50;
            for (int i = 0; i < labelAndTextbox; i++)
            {


                if (dateTime)
                {
                    labels.Add(new Label() { Left = 50, Top = labelTop, Text = labelName[i] });
                    datePicker = new DateTimePicker() { Left = 50, Top = textboxTop, Width = 200 };
                    dateTime = false;
                    dateAdded = true;
                    dateSend = true;
                }
                else if (dropBox)
                {
                    labels.Add(new Label() { Left = 50, Top = labelTop, Text = labelName[i] });
                    combo = new ComboBox() { Left = 50, Top = textboxTop, Width = 200 };
                    dropBox = false;
                    comboAdded = true;
                    comboSend = true;
                }else if (dropBox2)
                {
                    labels.Add(new Label() { Left = 50, Top = labelTop, Text = labelName[i] });
                    combo2 = new ComboBox() { Left = 50, Top = textboxTop, Width = 200 };
                    dropBox2 = false;
                    comboAdded2 = true;
                    comboSend2 = true;
                }
                else
                {
                    labels.Add(new Label() { Left = 50, Top = labelTop, Text = labelName[i] });
                    textBoxs.Add(new TextBox() { Left = 50, Top = textboxTop, Width = 200 });

                }
                labelTop += 80;
                textboxTop += 80;

            }

            if (comboSend)
            {
                if (classNameForCombp == "supplier")
                {
                    await supplier.getSupplierForInvoice();
                    string[] listCategory = supplier.WildcardFiles();

                    for (int i = 0; i < listCategory.Length; i++)
                    {
                        combo.Items.Add(listCategory[i]);
                    }
                    combo.Text = "أختر الموزع";
                }
                else if(classNameForCombp == "customer")
                {
                    await customer.getCustomerForReceipt();
                    string[] listCategory = customer.WildcardFiles();

                    for (int i = 0; i < listCategory.Length; i++)
                    {
                        combo.Items.Add(listCategory[i]);
                    }
                    combo.Text = "أختر العميل";
                }
                else
                {
                    await category.getCategoryForItem();
                    string[] listCategory = category.WildcardFiles();

                    for (int i = 0; i < listCategory.Length; i++)
                    {
                        combo.Items.Add(listCategory[i]);
                    }
                    combo.Text = "أختر القسم";
                }
                 if(comboSend2)
                {
                    await unit.getUnitForItem();
                    string[] listCategory = unit.WildcardFiles();

                    for (int i = 0; i < listCategory.Length; i++)
                    {
                        combo2.Items.Add(listCategory[i]);
                    }
                    combo2.Text = "أختر الوحدة";
                }


            }

            Button confirmation = new Button() { Text = "إظافة", Left = 70, Width = 100, Top = textboxTop, DialogResult = DialogResult.OK };




            confirmation.Click += async (sender, e) =>
            {
                string maketheAddUrl = "";
                int n = 0;
                if (dateSend)
                {
                    maketheAddUrl += sendValue[n] + "=" + datePicker.Value.Date + "&";
                    n++;

                }
                if (comboSend)
                {

                    maketheAddUrl += sendValue[n] + "=" + combo.SelectedItem + "&";
                    n++;

                }
                if (comboSend2)
                {

                    maketheAddUrl += sendValue[n] + "=" + combo2.SelectedItem + "&";
                    n++;

                }
                if (n == 0)
                {
                    for (int i = n; i < sendValue.Length; i++)
                    {

                        maketheAddUrl += sendValue[i] + "=" + textBoxs[i].Text + "&";

                    }
                }
                else
                {
                    for (int i = n; i < sendValue.Length; i++)
                    {

                        maketheAddUrl += sendValue[i] + "=" + textBoxs[i - n].Text + "&";

                    }
                }



                maketheAddUrl = urladd + "?" + maketheAddUrl;
                string checkError = "";
                if (unique)
                {
                    using (HttpClient client = new HttpClient())
                    {

                        using (HttpResponseMessage httpResponse =
                        await client.GetAsync(urladd + "?valid=" + textBoxs[0].Text))
                        {

                            using (HttpContent content = httpResponse.Content)
                            {

                                string theContent = await content.ReadAsStringAsync();
                                checkError = theContent;
                            }
                        }
                    }
                }


                if (checkError == "")
                {
                    string URL = maketheAddUrl;
                    using (WebClient client = new WebClient())
                    {
                        string src = client.DownloadString(URL);
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);

                }

            };
            for (int i = 0; i < textBoxs.Count; i++)
            {
                prompt.Controls.Add(textBoxs[i]);
            }
            for (int i = 0; i < labels.Count; i++)
            {
                prompt.Controls.Add(labels[i]);
            }
            if (dateAdded)
            {
                prompt.Controls.Add(datePicker);

            }
            if (comboAdded)
            {
                prompt.Controls.Add(combo);

            }
            if (comboAdded2)
            {
                prompt.Controls.Add(combo2);

            }


            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBoxs[0].Text : "";
        }
    }
}
