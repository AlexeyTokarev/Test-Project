using System;

namespace MyTestProject002
{
    /// <summary>
    /// Операции над Базой данных
    /// </summary>
    public class DataBaseOperation : DataBaseDeclaring
    {
        DataBaseDeclaring dbDeclaring = new DataBaseDeclaring();
        
        /// <summary>
        /// Показывает список заданий 
        /// </summary>
        public void ShowOurTable()   
        {
            string sql = "SELECT [intId] as [№], [mvcTask] as [Задание], [tTime] as [Время], [intResult] as [Результат]  FROM [Table];";
            dbDeclaring.DeclareDataBase(sql);
        }

        /// <summary>
        /// Добавление данных в базу
        /// </summary>
        public void AddTable()       
        {
            Console.CursorVisible = true;
            Console.Write("Введите задание: ");
            string stringTask = Console.ReadLine();
            if (stringTask == "") { Console.CursorVisible = false; return; }

            Console.Write("Введите время исполнения (в формате ЧЧ:ММ:СС): ");
            string stringTime = Console.ReadLine();
            if (stringTime == "") { Console.Clear(); AddTable(); }

            Console.CursorVisible = false;
            string sql = "INSERT INTO [Table] ([mvcTask], [tTime], [intResult]) VALUES (N'" + stringTask + "', '" + stringTime + "', 0);";

            try { dbDeclaring.DeclareDataBase(sql); }
            catch
            {
                Console.Clear();
                Console.WriteLine("Введите корректное время!\n");
                AddTable();
            }
        }

        /// <summary>
        /// Обновление данных в базе
        /// </summary>
        public void UpdateTable() 
        {
            string updateId;
            string updateTask;
            string updateTime;
            string updateResult;
            string sql;

            Console.Clear();
            Menu menu = new Menu(new string[] { "Редактировать задание", "Редактировать время", "Редактировать результат выполнения", "Отменить редактирование" });
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;

            // Делаем меню для редактирования
            bool flag = true;
            do
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        menu.SelectDown();
                        break;

                    case ConsoleKey.UpArrow:
                        menu.SelectUp();
                        break;

                    case ConsoleKey.Enter:
                        menu.HideMenu();
                        switch (menu.SelectedItem)
                        {
                            case 0: // Редактировать задание
                                Console.Clear();
                                ShowOurTable();
                                Console.CursorVisible = true;

                                Console.Write("\n\nВведите номер задания, которое хотите редактировать: ");
                                updateId = Console.ReadLine();
                                if (updateId == "") { Console.CursorVisible = false; return; }

                                Console.Write("\nВведите новое задание: ");
                                updateTask = Console.ReadLine();
                                if (updateTask == "") { Console.CursorVisible = false; return; }

                                sql = "UPDATE [Table] SET  [mvcTask] = N'" + updateTask + "' WHERE [intId] = " + updateId + ";";
                                try
                                {
                                    Console.CursorVisible = false;
                                    dbDeclaring.DeclareDataBase(sql);
                                }
                                catch
                                {
                                    Console.Clear();
                                    ShowOurTable();
                                    Console.WriteLine("\n\nВведите корректные параметры!");
                                }
                                break;

                            case 1: // Редактировать время
                                Console.Clear();
                                ShowOurTable();
                                Console.CursorVisible = true;

                                Console.Write("\n\nВведите номер задания, которое хотите редактировать: ");
                                updateId = Console.ReadLine();
                                if (updateId == "") { Console.CursorVisible = false; return; }

                                Console.Write("\nВведите новое время исполнения (в формате ЧЧ:ММ:СС): ");
                                updateTime = Console.ReadLine();
                                if (updateTime == "") { Console.CursorVisible = false; return; }

                                sql = "UPDATE [Table] SET  [tTime] = '" + updateTime + "' WHERE [intId] = " + updateId + ";";
                                try
                                {
                                    Console.CursorVisible = false;
                                    dbDeclaring.DeclareDataBase(sql);
                                }
                                catch
                                {
                                    Console.Clear();
                                    ShowOurTable();
                                    Console.WriteLine("\n\nВведите корректные параметры!");
                                    Console.ReadKey();
                                    UpdateTable();
                                }
                                break;

                            case 2: // Редактировать результат выполнения
                                Console.Clear();
                                ShowOurTable();
                                Console.CursorVisible = true;

                                Console.Write("\n\nВведите номер задания, которое хотите редактировать: ");
                                updateId = Console.ReadLine();
                                if (updateId == "") { Console.CursorVisible = false; return; }

                                Console.Write("\nВведите новый результат (0 или 1): ");
                                updateResult = Console.ReadLine();
                                if (updateResult == "") { Console.CursorVisible = false; return; }
                                if ((updateResult != "0") && (updateResult != "1"))
                                {
                                    Console.Clear();
                                    ShowOurTable();
                                    Console.WriteLine("\n\nВведите корректные параметры!");
                                    Console.ReadKey();
                                    UpdateTable();
                                }

                                sql = "UPDATE [Table] SET  [intResult] = '" + updateResult + "' WHERE [intId] = " + updateId + ";";
                                try
                                {
                                    Console.CursorVisible = false;
                                    dbDeclaring.DeclareDataBase(sql);
                                }
                                catch
                                {
                                    Console.Clear();
                                    ShowOurTable();
                                    Console.WriteLine("\n\nВведите корректные параметры!");
                                }
                                break;

                            case 3: // Отменить редактирование
                                menu.HideMenu();
                                flag = false;
                                break;

                            default: continue;
                        }

                        menu.ShowMenu();
                        break;

                    default: break;
                }
            } while (flag);
        }

        /// <summary>
        /// Удалить определенное задание
        /// </summary>
        public void DeleteTaskTable() 
        {
            Console.Clear();
            ShowOurTable();
            Console.CursorVisible = true;

            Console.Write("\n\nВведите номер задания, которое хотите удалить: ");
            string deleteId = Console.ReadLine();
            if (deleteId == "") { Console.CursorVisible = false; return; }

            string sql = "DELETE FROM [Table] WHERE intId = " + deleteId + ";";
            Console.CursorVisible = false;

            try { dbDeclaring.DeclareDataBase(sql); }
            catch
            {
                Console.WriteLine("Введите корректный номер задания!\n");
                DeleteTaskTable();
            }
        }

        /// <summary>
        /// Удалить всю таблицу
        /// </summary>
        public void DeleteAllTable() 
        {
            Console.CursorVisible = true;

            Console.Write("Вы уверены в том, что хотите удалить таблицу? (Y/N): ");
            string are_you_sure = Console.ReadLine();
            
            // Согласие на удаление
            if ((are_you_sure == "Y") || (are_you_sure == "y") || (are_you_sure == "Н") || (are_you_sure == "н")) 
            {
                Console.CursorVisible = false;
                string sql = "DELETE FROM [Table] WHERE intId > 0;";
                dbDeclaring.DeclareDataBase(sql);
            }
            
            // Несогласие на удаление
            else if ((are_you_sure == "N") || (are_you_sure == "n") || (are_you_sure == "Т") || (are_you_sure == "т")) 
            {
                Console.CursorVisible = false;
                return;
            }
            
            // Некорректный ответ на вопрос об удалении
            else 
            {
                Console.CursorVisible = false;
                Console.Clear();
                DeleteAllTable();
            }
        }        
    }
}
