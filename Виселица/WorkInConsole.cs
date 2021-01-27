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
            Console.WriteLine("Здравсвтуй, сейчас я загадаю слово, выбери сколько жизней у тебя будет");
            int lifes = int.Parse(Console.ReadLine());
            return lifes;
        }
        public void DisplayWordwithLifes(int lifes, string encryptedWord)
        {
            Console.Clear();
            Console.WriteLine($"осталось {lifes} жизней") ;
            Console.WriteLine(encryptedWord);
        }
        public char ReadSymbol()
        {
            Console.WriteLine("Введите букву");
            string input = Console.ReadLine();
            char[] inputinchar = input.ToLower().ToCharArray();
            return inputinchar[0];
        }
        public void End()
        {
            Console.Clear();
            Console.WriteLine("Конец игры друг");
            Console.ReadLine();
        }

    }
}
