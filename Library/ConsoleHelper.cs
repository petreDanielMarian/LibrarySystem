using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    /// <summary>
    /// https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter
    /// </summary>
    public class ConsoleHelper
    {
        /// <summary>
        /// Displays the list you gave him as a list with one element under another.
        /// Can go through items with the arrow keys
        /// </summary>
        /// <param name="menuOptionsDescriptions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T MultipleChoicePrompter<T>(IList<T> menuOptionsDescriptions)
        {
            const int startX = 1;
            const int startY = 2;
            const int optionsPerLine = 1;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < menuOptionsDescriptions.Count; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine), startY + i / optionsPerLine);

                    if(i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"- {menuOptionsDescriptions.ElementAt(i)}");

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                    {
                        if (currentSelection >= optionsPerLine)
                            currentSelection -= optionsPerLine;
                        break;
                    }
                    case ConsoleKey.DownArrow:
                    {
                        if (currentSelection + optionsPerLine < menuOptionsDescriptions.Count)
                            currentSelection += optionsPerLine;
                        break;
                    }
                    case ConsoleKey.Escape:
                    {
                        break;
                    }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return menuOptionsDescriptions.ElementAt(currentSelection);
        }
    }
}