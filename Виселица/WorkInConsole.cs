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
                while (!resultParse);
            }
            return lifes;
        }
        public void DisplayWordwithLifes(int lifes, string encryptedWord, string declination)
        {
            Console.Clear();
            Console.WriteLine($"осталось {lifes} {declination}") ;
            Console.WriteLine(encryptedWord);
        }
        public char ReadSymbol()
        {
            Console.WriteLine("Введите букву");
            string input = Console.ReadLine();
            char[] inputinchar = input.ToLower().ToCharArray();
            return inputinchar[0];
        }
        public void WriteEndMessage()
        {
            Console.Clear();
            Console.WriteLine("Конец игры друг");
            Console.ReadLine();
        }

    }
}
