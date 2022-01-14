using System;
using System.Threading.Channels;

namespace GameOfLife.Input
{
    public class ConsoleInput : IUserInput
    {
        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}