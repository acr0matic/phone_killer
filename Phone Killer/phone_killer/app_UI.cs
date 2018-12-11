using System;
using System.Windows.Forms;
using phone_killer.core;
using System.IO;

namespace NumberKiller
{

    public partial class app_UI : Form
    {
        // Объявление констант формы за любой ее участок
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // Объявляем методы с внешней реализацией
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // Объявляем экземпляр класса логирования
        private LogSystem logSystem = new LogSystem();

        // Объявляем экземпляр класса веб-парсера
        private WebParser webParser = new WebParser();

        // Переменные для хранения значений из полей ввода 
        public static String Phone { get; set; }
        public static String UserName { get; set; }
    
        // Иницилизация приложения и полей во время запуска
        public app_UI()
        {
            InitializeComponent();
            webParser.Init();
            if (!System.IO.File.Exists("logs.txt"))
            {
                System.IO.File.Create("logs.txt");
            }
        }

        // Обработчик нажатия на кнопку старт
        private void start_button_Click(object sender, EventArgs e)
        {
            // Сброс номера страницы
            webParser.PageNumber = 0;

            // Получаем значения из полей ввода и записываем в переменные          
            UserName = name_textbox.Text;
            Phone = phone_textbox.Text;          

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
                // Иницилизируем лог систему, логируем информацию о жертве
                // И включаем кнопку "ОТЧЕТ"
                logSystem.init();
                logSystem.log(2);
                start_button.Enabled = false;

                // Запускаем парсер
                webParser.Start();

                start_button.Enabled = true;
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
        // Не ловим исключение потому, что мы его заранее предотвратили, отключив кнопку, если файла нет
        private void log_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("logs.txt");
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
    }
}
