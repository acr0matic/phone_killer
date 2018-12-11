using System;
using System.IO;

namespace phone_killer.core
{
    class LogSystem
    {
        private StreamWriter file;
        private string webPage;
        private string userName;
        private string userPhone;

        // Иницилизация 
        public void init()
        {
            userName = NumberKiller.app_UI.UserName;
            userPhone = NumberKiller.app_UI.Phone;
        }

        // В качестве единственного аргумента принимает целочисленное знаничение - код статуса
        public void log(int status)
        {
            writeInFile(status);       
        }

        // Перегрузка метода, второй аргумент принимает строку - адрес сайта
        public void log(int status, string page)
        {
            webPage = page;
            writeInFile(status);
        }

        public void logField(object obj)
        {
            // Второй - возможна ли перезапись файла
            file = new StreamWriter("", true);

            // Пишет перед каждой строчкой текущую дату и время
            file.Write(DateTime.Now.ToString("dd.MM.yyyy | HH:mm:ss "));

            file.Write(obj);

            // Переносим строку
            file.Write("\n");

            // Закрываем поток записи в файл для того чтобы изменения были внесенны в файл
            file.Close();
        }

        private void writeInFile(int status)
        {

            // Открываем поток для записи в файл
            // Первый аргумент - путь где будет создан/перезаписан файл
            // Второй - возможна ли перезапись файла
            file = new StreamWriter("logs.txt", true);

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
                    file.Write("- Загрузка: " + webPage);
                    break;
                case 1:
                    file.Write("- Успешно загружено");
                    break;
                case 2:
                    file.Write("- Атака на номер: " + userPhone + ", Имя: " + userName);
                    break;
                case 3:
                    file.Write("- Проход завершен успешно.");
                    break;
                case 50:
                    file.Write("- URL не был передан в DocumentCompleted");
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
