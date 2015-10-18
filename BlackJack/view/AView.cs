using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    abstract class AView
    {
        public Input GetInput()
        {
            int input = Console.In.Read();

            switch (input)
            {
                case 'p':
                    return Input.StartNewGame;
                case 'h':
                    return Input.Hit;
                case 's':
                    return Input.Stand;
                case 'q':
                    return Input.Quit;
                default:
                    return Input.None;
            }
        }
    }
}
