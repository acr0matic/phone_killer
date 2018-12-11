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
        public int PageNumber { get;  set; }

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
        }

        // Метод запускающий работу класса
        public void Start()
        {
            Pages = URLs.Count - 1;
            PageNumber = 0;
            webBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
            ChangePage(PageNumber);
        }

        // Метод смены страницы
        private void ChangePage(int page)
        {
            if (Pages != 0)
            {
                // Логируем переход по страницам
                logSystem.log(0, URLs[page]);

                // Блок проверки валидности страницы
                urlCheck = new Uri(URLs[page]);
                // Создаем запрос по URL сайта
                request = (HttpWebRequest)WebRequest.Create(urlCheck);
                // Время ожидания запроса, необходимо для точной прогрузки
                request.Timeout = 2000;
                // Отлавливание исключения 
                try
                {
                    // Получаем ответ сайта
                    response = (HttpWebResponse)request.GetResponse();
                    // Создаем событие отвечающее за полную прогрузку страницы, в качестве аргумента - делегат

                    webBrowser.Navigate(URLs[page]);
                }

                // Вызывается если ответ не был получен
                catch (Exception)
                {
                    // Вызываем лог-систему и присваеваем ей код исключения (404 - страница не найдена)
                    logSystem.log(404);
                    ChangePage(PageNumber);
                }
            }
            else
            {
                // Логирование завершения прохода
                logSystem.log(3);
                return;
            }
        }

        // Метод отвечающий за прогрузку веб-страницы до конца
        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Ловим исключение - отстуствие URL 
            try
            {
                logSystem.log(1);
                Auto_fill();
            }
            catch (NullReferenceException)
            {
                // Логируем искючение
                logSystem.log(50);
            }
        }

        // Метод автозаполнения полей и нажатия на кнопки на сайтах
        private void Auto_fill()
        {         
            // Перебор страницы на поиск тэга INPUT                 
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
            {
                // Если найденый атрибут NAME у тега INPUT совпадает с одним из элементом в списке возможных вариантов
                foreach (var nameElement in name_field)
                {
                    if (htmlElement.GetAttribute("name").Equals(nameElement))
                    {
                        // То заполняем поле в форме нашей переменной 
                        htmlElement.InnerText = NumberKiller.app_UI.UserName;
                    }
                }
            }

            // Перебор страницы на поиск тэга INPUT (Поле ввода)
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
            {
                foreach (var phoneElement in phone_field)
                {
                    if (htmlElement.GetAttribute("name").Equals(phoneElement))
                    {
                        htmlElement.InnerText = NumberKiller.app_UI.Phone;
                    }
                }
            }

            // Перебор страницы на поиск тэга INPUT (Кнопка подтверждения)
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
            {
                // Перебор страницы на поиск аттрибута совпадающего с одним из списка доступных аттрибутов
                foreach (var buttonElement in button)
                {
                    if (htmlElement.GetAttribute("type").Equals(buttonElement))
                    {
                        // Производим виртуальное нажатие кнопки
                        htmlElement.InvokeMember("c2lick"); 
                    }
                }
            }

            // Перебор страницы на поиск тэга BUTTON 
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
            {
                // Перебор страницы на поиск аттрибута совпадающего с одним из списка доступных аттрибутов
                foreach (var buttonElement in button)
                {
                    if (htmlElement.GetAttribute("type").Equals(buttonElement) || htmlElement.GetAttribute("class").Equals(buttonElement))
                    {
                        // Производим виртуальное нажатие кнопки
                        htmlElement.InvokeMember("cl2ick"); 
                    }
                }
            }

            // Логируем выполнение 
            logSystem.log(-1);    

            // Декремент и инкрементЁ
            Pages--; PageNumber++;

            // Если количество страниц не равно нулю, продолжать
            ChangePage(PageNumber);
        }
    }
}
