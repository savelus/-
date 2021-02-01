using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Виселица
{
    class StartMenu
    {
        public void CreateWindow()
        {
            Button[] buttonsMenu = new Button[] {new Button("Новая игра"), new Button("Рейтинг"), new Button ("Добавить слова"),
                                             new Button("Выйти из игры") };
            Console.SetWindowSize(120, 30);
            var consoleWorker = new WorkInConsole();
            int buttonNumber = 0;
            consoleWorker.SetDefaultconsole();
            while (true)
            {
                consoleWorker.ConsolePrintNameGame(38, 2); //Название игры
                PrintButtons(buttonsMenu, buttonNumber); // отрисовка кнопок
                int buttonNumberTemp = consoleWorker.SwitchingButton(buttonNumber, buttonsMenu.Length); //выбор кнопки
                if (buttonNumber != buttonNumberTemp) buttonNumber = buttonNumberTemp;
                else
                {
                    ChoiseButton(buttonNumber, buttonsMenu);
                }
            }
        }

        public void ChoiseButton(int buttonNumber, Button[] buttons)
        {
            switch (buttonNumber)
            {
                case 0:
                    NewGame.StartGame(buttons[0]);
                    break;
                case 1:
                    Rating.StartRating(buttons[1]);
                    break;
                case 2:
                    Words.StartWords(buttons[2]);
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void PrintButtons(Button[] buttons, int buttonNumber)
        {
            int cursorLeft = 50;
            int cursorTop = 10;

            for (int i = 0; i < buttons.Length; i++)
            {
                bool changeColor = false;
                if (i == buttonNumber) changeColor = true;
                buttons[i].PrintButton(cursorLeft, cursorTop, changeColor);
                cursorTop += 3;
            }
        }
    }
}
