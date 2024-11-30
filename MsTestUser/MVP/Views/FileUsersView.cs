using System;
using System.Collections.Generic;
using System.IO;
using Users;

namespace MsTestUser.MVP.Views
{
    public class FileUsersView : IUsersView
    {
        private string filePath_;

        public void DisplayUsers(List<User> users)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            filePath_ = Path.Combine(desktopPath, "UsersList.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath_))
                {
                    writer.WriteLine("Список пользователей:");
                    writer.WriteLine("ID\tLogin\tPassword\tName\tSurname");
                    writer.WriteLine(new string('-', 50));

                    foreach (var user in users)
                    {
                        writer.WriteLine($"{user.id}\t{user.Login}\t{user.Password}\t{user.Name}\t{user.Surname}");
                    }
                }

                Console.WriteLine($"Файл успешно сохранён на рабочем столе: {filePath_}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }

        public string GetFile()
        {
            return filePath_;
        }
    }
}
