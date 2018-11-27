using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberKiller
{
    public partial class app_UI : Form
    {
        private String phone;
        private String name;

        private int page_number = 0;
        private int count_of_pages = 0;

        //Объявляем листы для хранения значений полей HTML кода для ввода имени,
        //Номера телефона и кнопки "подтвердить" 
        private List<String> URLs = new List<String>();
        private List<String> name_field = new List<String>();
        private List<String> phone_field = new List<String>();
        private List<String> button_ID = new List<String>();

        public app_UI()
        {
            InitializeComponent();

            //Добаление сайтов из базы в память программы
            URLs.Add("http://eco-gribs.ru/");
            URLs.Add("http://lexopol-low.dostavka2.me/");
            URLs.Add("http://flk.officialhealth.ru/");
            URLs.Add("http://c.potencialex.ru/149/v1/");
            URLs.Add("http://titan-gel.com");
            URLs.Add("http://c.reduslim.ru/149/v1");
            URLs.Add("http://f4.orlium.ru");

            count_of_pages = 1;

            //Иницилизация списка атрибутов для ввода имени в текстовое поле
            name_field.Add("name");
            name_field.Add("fio");
            name_field.Add("order[fio]");

            //Иницилизация списка атрибутов для ввода номера телефона в текстовое поле
            name_field.Add("FormLanding[phone]");
            name_field.Add("phone");
        }

        private void changePage(int page)
        {
            webBrowser.Navigate(URLs[page]);
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            phone = phone_textbox.Text;
            name = name_textbox.Text;
         
            if (name_textbox.Text == "") {
                info_label.ForeColor = Color.Red;
                info_label.Text = "Вы не указали имя";
                return;
            }

            else if (phone_textbox.Text == "") {
                info_label.ForeColor = Color.Red;
                info_label.Text = "Вы не указали номер телефона";
                return;
            }

            changePage(page_number);
        }

        private void auto_fill()
        {
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String nameElement in name_field)
                    if (htmlElement.GetAttribute("name").Equals(nameElement))
                        htmlElement.InnerText = name;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String phoneElement in phone_field)
                    if (htmlElement.GetAttribute("name").Equals(phoneElement))
                        htmlElement.InnerText = phone;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                if (htmlElement.GetAttribute("type").Equals("subm1it"))
                    htmlElement.InvokeMember("click");

            if (count_of_pages !=0)
               changePage(page_number++);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (count_of_pages >= 0) {
                    count_of_pages--;
                    auto_fill();
                }
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
