using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace phone_killer.core
{
    class WebParser
    {
        // Обьявляем экзмпляры классов для работы с информацей о страницах 
        private static WebBrowser webBrowser = new WebBrowser();
        private Uri urlCheck;
        private HttpWebRequest request;
        private HttpWebResponse response;

        // Объявляем экземпляр класса логирования
        private LogSystem logSystem = new LogSystem();

        // Объявляем лист хранящий URL сайтов
        public List<String> URLs = new List<String>();

        // Объявляем листы для хранения значений полей HTML кода для ввода имени,
        // Номера телефона и кнопки "подтвердить" 
        private List<String> name_field = new List<String>();
        private List<String> phone_field = new List<String>();
        private List<String> button = new List<String>();

        // Получить количество страниц
        public int Pages { get; private set; }

        // Получить или задать номер страницы
        public int PageNumber { get; set; }

        // Иницилизация полей и списков
        public void Init()
        {
            webBrowser.ScriptErrorsSuppressed = true;

            // Добаление сайтов из базы в память программы
            URLs.Add("http://eco-gribs.ru/");
            URLs.Add("http://lexopol-low.dostavka2.me/");
            URLs.Add("http://c.potencialex.ru/149/v1/");
            URLs.Add("http://titan-gel.com");
            URLs.Add("http://imira.a47m.biz/");
            URLs.Add("http://hq.shopent.net/");
            URLs.Add("http://kvlow.meta-complex.com/");

            // Иницилизация списка атрибутов для ввода имени в текстовое поле
            name_field.Add("name");
            name_field.Add("fio");
            name_field.Add("order[fio]");
            name_field.Add("FormLanding[fio]");

            // Иницилизация списка атрибутов для в вода номера телефона в текстовое поле
            phone_field.Add("FormLanding[phone]");
            phone_field.Add("phone");
            phone_field.Add("order[phone]");
            phone_field.Add("FormLanding[phone]");

            // Объявление списка атрибутов для нажатия кнопки
            button.Add("input");
            button.Add("button order-btn ifr_button");

            Pages = URLs.Count;
        }

        public void Start()
        {
            Init();
            logSystem.logField(Pages);
            ChangePage(PageNumber);
        }

        // Метод смены страницы
        private void ChangePage(int page)
        {
            logSystem.log(0, URLs[page]);
            //progress_bar.Value = page + 1;

            // Блок проверки валидности страницы
            urlCheck = new Uri(URLs[page]);

            // Создаем запрос по URL сайта
            request = (HttpWebRequest)WebRequest.Create(urlCheck);
            request.Timeout = 1000;

            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(Completed);
            webBrowser.Navigate(URLs[page]);

            //// Отвлавливание исключения 
            //try
            //{
            //    // Получаем ответ сайта
            //    response = (HttpWebResponse)request.GetResponse();
               
            //}

            //// Вызывается если ответ не был получен
            //catch (Exception)
            //{
            //    // Вызываем лог-систему и присваеваем ей код исключения (404 - страница не найдена)
            //    logSystem.log(404);
            //    Pages--;
            //    PageNumber++;
            //    ChangePage(PageNumber);
            //}
        }

        // Метод отвечающий за прогрузку веб-страницы до конца
        private void Completed(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (Pages > 0)
                {
                    logSystem.log(1);
                    Pages--;
                    PageNumber++;
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
            // Перебор страницы и поиск поля ввода имени 
            // Если найденый атрибут NAME у тега INPUT совпадает с одним из элементом в списке возможных вариантов
            // То заполняем поле в форме нашей переменной 
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String nameElement in name_field)
                    if (htmlElement.GetAttribute("name").Equals(nameElement))
                        htmlElement.InnerText = NumberKiller.app_UI.UserName;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String phoneElement in phone_field)
                    if (htmlElement.GetAttribute("name").Equals(phoneElement))
                        htmlElement.InnerText = NumberKiller.app_UI.Phone;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String buttonElement in button)
                    if (htmlElement.GetAttribute("type").Equals(buttonElement))
                        htmlElement.InvokeMember("c2lick"); // Производим виртуальное нажатие кнопки

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                foreach (String buttonElement in button)
                    if (htmlElement.GetAttribute("type").Equals(buttonElement) || htmlElement.GetAttribute("class").Equals(buttonElement))
                        htmlElement.InvokeMember("cl2ick"); // Производим виртуальное нажатие кнопки

            // Логируем выполнение 
            logSystem.log(-1);

            // Стоп сигнал если количество страниц будет равно нулю
            if (Pages != 0)
                ChangePage(PageNumber);

            // Сброс полоски прогресса и включение кнопки
            else if (Pages == 0)
            {
               // start_button.Enabled = true;
                //progress_bar.Value = 0;
                logSystem.log(3);
            }
        }
    }
}
