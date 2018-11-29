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

        // Иницилизация приложения и полей во время запуска
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

        // Обработчик нажатия на кнопку старт
        private void start_button_Click(object sender, EventArgs e)
        {
            // Получаем значения из полей ввода и записываем в переменные
            phone = phone_textbox.Text;
            name = name_textbox.Text;

            // Смотрим на наличие введенного имени и телефона в поля
            if ((name_textbox.Text == "") && (phone_textbox.Text == ""))
            {
                name_field_label.Visible = true;
                phone_field_label.Visible = true;
                return;
            }

            // Смотрим на наличие введенного имени в поле
            else if (name_textbox.Text == "")
            {
                name_field_label.Visible = true;

                // Пишем для того чтобы преждевеременно выйти из функции
                return;
            }

            // Смотрим на наличие введенного номера телефона в поле
            else if (phone_textbox.Text == "")
            {
                phone_field_label.Visible = true;

                // Пишем для того чтобы преждевеременно выйти из функции
                return;
            }

            // Если все введено производим запуск вызывая метод смены страницы
            else
            {
                ChangePage(page_number);
            }
        }

        // Убираем сообщение о том что не введено имя когда нажимаем на поле
        private void name_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            name_field_label.Visible = false;
        }

        // Убираем сообщение о том что не введен номер телефона когда нажимаем на поле
        private void phone_textbox_MouseClick(object sender, MouseEventArgs e)
        {
            phone_field_label.Visible = false;
        }

        // Метод смены страницы
        private void ChangePage(int page)
        {
            // Открываем поток для записи в файл
            // Первый аргумент - путь где будет создан/перезаписан файл
            // Второй - возможна ли перезапись файла
            file = new StreamWriter(@"C:\Users\User\Desktop\logs.txt", true);

            // Пишем в файл статус + элемент массива веб-адресов по индексу 
            // Который задается аргументом этого метода
            file.WriteLine("- Загрузка: " + URLs[page]);

            // Блок проверки валидности страницы
            urlCheck = new Uri(URLs[page]);

            // Создаем запрос по URL сайта
            request = (HttpWebRequest)WebRequest.Create(urlCheck);
            request.Timeout = 1000;

            // Отвлавливание исключения 
            try
            {
                // Получаем ответ сайта
                response = (HttpWebResponse)request.GetResponse();
                webBrowser.Navigate(URLs[page]);
            }

            // Вызывается если ответ не был получен
            catch (Exception)
            {
                // Вызываем лог-систему и присваеваем ей код исключения (404 - страница не найдена)
                LogSystem(404);
                count_of_pages--;
                page_number++;
                ChangePage(page_number);
            }       
        }

        // Метод отвечающий за прогрузку веб-страницы до конца
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

        // Метод автозаполнения полей и нажатия на кнопки на сайтах
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

            // Стоп сигнал если количество страниц будет равно нулю
            if (count_of_pages !=0)
               ChangePage(page_number);
        }

        // Метод лог системы
        // В качествер аргумента принимает целочисленное знаничение - код статуса
        private void LogSystem(int status)
        {
            // Выборка по коду статуса и запись в файл информации
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

            // Пишем перенос в файл для раздельного логирования 
            file.WriteLine("\n");

            // Закрываем поток записи в файл для того чтобы изменения были внесенны в файл
            file.Close();
        }

        // Обработка кнопки "отчет"
        private void log_button_Click(object sender, EventArgs e)
        {
            // Открываем текстовый файл в блокноте
            System.Diagnostics.Process.Start(@"C:\Users\User\Desktop\logs.txt");
        }
    }
}
