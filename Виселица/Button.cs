using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Виселица
{
    public class Button
    {
        public int width = 20;
        public int height = 3;
        public string inputname;

        public Button(string name)
        {
            inputname = name;
        }

        public void PrintButton(int cursorLeft, int cursorTop, bool changeColor)
        {
            WorkInConsole consoleWoorker = new WorkInConsole();
            consoleWoorker.ConsolePrintButton(cursorLeft, cursorTop, width, inputname, changeColor);
        }
    }
}
