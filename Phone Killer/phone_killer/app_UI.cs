using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace NumberKiller
{
    public partial class app_UI : Form
    {
        // Объявляем запись в файл и задаем путь по умлочанию для файла
        private StreamWriter file;

        // Обьявляем экзмпляры классов для работы с информацей о страницах 
        private Uri urlCheck;
        private HttpWebRequest request;
        private HttpWebResponse response;

        // Переменные для хранения значений из полей ввода 
        private String phone;
        private String name;

        // Поля - счетчики
        private int page_number = 0;
        private int count_of_pages = 0;

        // Объявляем листы для хранения значений полей HTML кода для ввода имени,
        // Номера телефона и кнопки "подтвердить" 
        private List<String> URLs = new List<String>();
        private List<String> name_field = new List<String>();
        private List<String> phone_field = new List<String>();
        private List<String> button = new List<String>();

        public app_UI()
        {
            InitializeComponent();

            // Добаление сайтов из базы в память программы
            URLs.Add("http://eco-gribs.ru/");
            URLs.Add("http://lexopol-low.dostavka2.me/");
            URLs.Add("http://flk.officialhealth.ru/");
            URLs.Add("http://c.pote1ncialex.ru/149/v1/");
            URLs.Add("http://1titan-gel.com");
            URLs.Add("http://c.reduslim.ru/149/v1");
            URLs.Add("http://f4.orlium.ru");

            // Иницилизация количества сайтов
            count_of_pages = URLs.Count;

            // Иницилизация списка атрибутов для ввода имени в текстовое поле
            name_field.Add("name");
            name_field.Add("fio");
            name_field.Add("order[fio]");

            // Иницилизация списка атрибутов для ввода номера телефона в текстовое поле
            name_field.Add("FormLanding[phone]");
            name_field.Add("phone");
            name_field.Add("order[phone]");

            // Объявление списка атрибутов для нажатия кнопки
            button.Add("input");
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            // Получаем значения из полей ввода и записываем в переменные
            phone = phone_textbox.Text;
            name = name_textbox.Text;
         
            // Смотрим на наличие введенного имени в поле
            if (name_textbox.Text == "") {
                info_label.ForeColor = Color.Red;
                info_label.Text = "Вы не указали имя";
                return;
            }

            // Смотрим на наличие введенного номера телефона в поле
            else if (phone_textbox.Text == "") {
                info_label.ForeColor = Color.Red;
                info_label.Text = "Вы не указали номер телефона";

                // Пишем для того чтобы преждевеременно выйти из функции
                return;
            }

            // Производим старт вызывая метод смены страницы
            ChangePage(page_number);
        }

        private void ChangePage(int page)
        {
            // Открываем поток для записи в файл
            // Первый аргумент - путь где будет создан/перезаписан файл
            // Второй - возможна ли перезапись файла
            file = new StreamWriter(@"C:\Users\User\Desktop\logs.txt", true);

            // Пишем в файл статус + элемент массива веб-адресов по индексу 
            // Который задается аргументом этого метода
            file.WriteLine("- Загрузка: " + URLs[page]);

            // Блок проверки страницы на ошибки
            urlCheck = new Uri(URLs[page]);
            request = (HttpWebRequest)WebRequest.Create(urlCheck);
            request.Timeout = 1000;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                webBrowser.Navigate(URLs[page]);
            }
            catch (Exception)
            {
                LogSystem(404);
                count_of_pages--;
                page_number++;
                ChangePage(page_number);
            }       
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (count_of_pages >= 0)
                {
                    LogSystem(1);
                    count_of_pages--;
                    page_number++;              
                    Auto_fill();
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        private void Auto_fill()
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
                foreach (String buttonElement in button)
                    if (htmlElement.GetAttribute("type").Equals("subm1it"))
                        htmlElement.InvokeMember("click");

            if (count_of_pages !=0)
               ChangePage(page_number);
        }

        private void LogSystem(int status)
        {
            switch (status)
            {
                case 1:
                    file.WriteLine("- Успешно загружено");
                    break;
                case 200:
                    file.WriteLine("- Поле для ввода имени найдено и заполнено");
                    break;
                case 205:
                    file.WriteLine("- Поле для ввода телефона найдено и заполнено");
                    break;
                case 404:
                    file.WriteLine("- Страница не найдена (404)");
                    break;
            }
            file.WriteLine("\n");
            file.Close();
        }        
    }
}
