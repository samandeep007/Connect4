using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    internal class StartMenu
    {
        public static void StartScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;




            Console.WriteLine("  ██████  ██████  ███    ██ ███    ██ ███████  ██████ ████████     ██   ██ ");
            Console.WriteLine(" ██      ██    ██ ████   ██ ████   ██ ██      ██         ██        ██   ██ ");
            Console.WriteLine(" ██      ██    ██ ██ ██  ██ ██ ██  ██ █████   ██         ██        ███████ ");
            Console.WriteLine(" ██      ██    ██ ██  ██ ██ ██  ██ ██ ██      ██         ██             ██ ");
            Console.WriteLine("  ██████  ██████  ██   ████ ██   ████ ███████  ██████    ██             ██ ");
            Console.ResetColor();
        }

        public static int GetGameMode()
        {
            Console.WriteLine("\nSelect an option:");
            string[] options = { "Human vs Human", "Human vs AI", "Exit" };
            return ShowMenu(options);
        }

        public static int GetDifficultyLevel()
        {
            Console.WriteLine("\nSelect AI difficulty level:");
            string[] options = { "Easy", "Medium", "Hard" };
            return ShowMenu(options);
        }

        public static int ShowMenu(string[] options)
        {
            int selectedIndex = 0;

            ConsoleKey key;
            do
            {
                Console.Clear();
                StartScreen();
                Console.WriteLine("\nUse arrow keys to navigate and Enter to select:");

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"> {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {options[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % options.Length;
                }

            } while (key != ConsoleKey.Enter);

            return selectedIndex + 1;
        }
    }
}
