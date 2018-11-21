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

        //Объявляем листы для хранения значений полей HTML кода для ввода имени,
        //Номера телефона и кнопки "подтвердить" 
        private List<String> URLs = new List<String>();
        private List<String> name_field_ID = new List<String>();
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
                name_textbox.Text = "Напишите имя";
                return;
            }

            else if (phone_textbox.Text == "")
            {
                phone_textbox.Text = "Напишите номер";
                return;
            }

            changePage(page_number);
        }

        private void auto_fill()
        {
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                if (htmlElement.GetAttribute("name").Equals("name"))
                    htmlElement.InnerText = name;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                if (htmlElement.GetAttribute("name").Equals("phone"))
                    htmlElement.InnerText = phone;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                if (htmlElement.GetAttribute("type").Equals("submit"))
                    htmlElement.InvokeMember("click");
        }

 

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                switch (page_number)
                {
                    case 0:
                        webBrowser.Document.GetElementById("lv-formLanding1-phone").InnerText = phone;

                        foreach (HtmlElement he in webBrowser.Document.GetElementsByTagName("button"))
                            if (he.GetAttribute("name").Equals("auth"))
                                he.InvokeMember("click");
                        //page_number++;
                        //changePage(page_number);
                        break;

                    case 1:
                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("name"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = phone;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("submit"))
                                htmlElement.InvokeMember("click");

                        page_number++;
                        changePage(page_number);
                        break;

                    case 2:
                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("name"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = phone;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("submit"))
                                htmlElement.InvokeMember("click");
                        page_number++;
                        changePage(page_number);
                        break;

                    case 3:
                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("fio"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = phone;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("submit"))
                                htmlElement.InvokeMember("click");
                        break;

                    case 4:
                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("name"))
                                htmlElement.InnerText = name;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                            if (htmlElement.GetAttribute("name").Equals("phone"))
                                htmlElement.InnerText = phone;

                        foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                            if (htmlElement.GetAttribute("type").Equals("submit"))
                                htmlElement.InvokeMember("click");
                        break;
                }
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
