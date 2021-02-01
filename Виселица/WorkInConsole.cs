using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Виселица
{
    public class WorkInConsole
    {
        public int WriteStartMessage()
        {
            int lifes = 1;
            Console.WriteLine("Здравсвтуй, сейчас я загадаю слово. Выбери сколько жизней у тебя будет");
            bool resultParse = int.TryParse(Console.ReadLine(), out lifes);
            if (!resultParse)
            {
                do
                {
                    Console.WriteLine("Вы ввели что-то не так, попробуйте еще раз");
                    resultParse = int.TryParse(Console.ReadLine(), out lifes);
                }
                while (!resultParse && lifes <= 0);
            }
            return lifes;
        }
        public void DisplayWordwithLifes(int lifes, string encryptedWord, string declination, bool mistake)
        {
            Console.Clear();
            if (mistake)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"осталось {lifes} {declination}") ;
            Console.WriteLine(encryptedWord);
            Console.WriteLine("Введите букву");
            Console.ResetColor();
        }
        public char ReadSymbol()
        {

            string input = Console.ReadLine();
            char[] inputinchar = input.ToLower().ToCharArray();
            return inputinchar[0];
        }
        public void WriteEndMessage(bool win)
        {
            Console.Clear();
            if (win)
            {
                Console.WriteLine("Ты победил, конец игры.");
            }
            else
            {
                Console.WriteLine("Ты проиграл, конец игры.");
            }
            Console.ReadLine();
        }
        public void ConsolePrintButton(int cursorLeft, int cursorTop, int width, string inputname, bool changeColor)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            if (changeColor) Console.BackgroundColor = ConsoleColor.Cyan;
            else Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"┌{new string('─', width - 2)}┐");
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            Console.WriteLine($"│{new string(' ', (18 - inputname.Length) / 2)}" +
                              $"{inputname}{new string(' ', (18 - inputname.Length - (18 - inputname.Length) / 2))}│");
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            Console.WriteLine($"└{new string('─', width - 2)}┘");
        }
        public int SwitchingButton(int buttonNumber, int quantityNumber)
        {
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter) return buttonNumber;
                else if (key.KeyChar == 'w' || key.Key == ConsoleKey.UpArrow)
                {
                    if (buttonNumber == 0) return quantityNumber - 1;
                    else return buttonNumber -= 1;
                }
                else if (key.KeyChar == 's' || key.Key == ConsoleKey.DownArrow)
                {
                    if (buttonNumber == quantityNumber - 1) return 0;
                    else return buttonNumber += 1;
                }
                else continue;
            }
        }
        public void ConsolePrintNameGame(int cursorLeft, int cursorTop)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            Console.WriteLine(@" __   __  _              _   _             ");
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            Console.WriteLine(@" \ \ / / (_)  ___  ___  | | (_)  __   __ _ ");
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            Console.WriteLine(@"  \ V /  | | (_-< / -_) | | | | / _| / _` |");
            Console.SetCursorPosition(cursorLeft, cursorTop++);
            Console.WriteLine(@"   \_/   |_| /__/ \___| |_| |_| \__| \__,_|");
        }
        public void SetDefaultconsole()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }
        public static void ConsolePrintDummy(Button button)
        {
            Console.Clear();
            Console.SetCursorPosition(((120 - button.inputname.Length - 20) / 2), 10);
            Console.WriteLine($"Здесь однажды будет \"{button.inputname}\"");
            Console.SetCursorPosition(((120 - button.inputname.Length - 20) / 2), 11);
            Console.WriteLine("Нажмите любую кнопку, чтобы выйти.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
