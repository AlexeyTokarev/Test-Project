using System;

namespace MyTestProject002
{
    /// <summary>
    /// Меню
    /// </summary>
    public class Menu
    {
        private string[] _items;
        public int SelectedItem { get; private set; }
        public ConsoleColor ForegroundColor = ConsoleColor.White;
        public ConsoleColor BackgroundColor = ConsoleColor.Black;
        public ConsoleColor SelectedForegroundColor = ConsoleColor.Black;
        public ConsoleColor SelectedBackgroundColor = ConsoleColor.White;
        public Menu(string[] items)
        {
            _items = items;
            SelectedItem = 0;
            ShowMenu();
        }

        /// <summary>
        /// Нажатие стрелочки вверх
        /// </summary>
        public void SelectUp()
        {
            SelectedItem--;
            if (SelectedItem < 0)
                SelectedItem = _items.Length - 1;
            ShowMenu();
        }

        /// <summary>
        /// Нажатие стрелочки вниз
        /// </summary>
        public void SelectDown()
        {
            SelectedItem++;
            if (SelectedItem >= _items.Length)
                SelectedItem = 0;
            ShowMenu();
        }

        /// <summary>
        /// Скрывает меню
        /// </summary>
        public void HideMenu()
        {
            Console.Clear();
        }

        /// <summary>
        /// Показывает меню
        /// </summary>
        public void ShowMenu()
        {
            Console.Clear();

            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.ForegroundColor;
            Console.WriteLine("Выберите действие:\n");

            for (int i = 0; i < _items.Length; i++)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = this.SelectedBackgroundColor;
                    Console.ForegroundColor = this.SelectedForegroundColor;
                    Console.WriteLine(_items[i]);
                    Console.BackgroundColor = this.BackgroundColor;
                    Console.ForegroundColor = this.ForegroundColor;
                }
                else Console.WriteLine(_items[i]);
            }
        }
    }
}
