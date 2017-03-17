using System;

namespace MyTestProject002
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Планировщик";

            DataBaseOperation dbOperation = new DataBaseOperation();
            Menu menu = new Menu(new string[] { "Показать список заданий", "Добавить задание в список",
                "Обновить существующее задание", "Удалить задание из списка", "Удалить весь список", "Выход из программы" });

            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;

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
                            case 0: // Показать список заданий
                                dbOperation.ShowOurTable();                                
                                Console.ReadKey();
                                break;

                            case 1: // Добавить задание в список
                                dbOperation.AddTable();
                                break;

                            case 2: // Обновить существующее задание
                                dbOperation.UpdateTable();
                                break;

                            case 3: // Удалить задание из списка
                                dbOperation.DeleteTaskTable();
                                break;

                            case 4: // Удалить весь список
                                dbOperation.DeleteAllTable();
                                break;

                            case 5: // Выход из программы
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
    }
}

