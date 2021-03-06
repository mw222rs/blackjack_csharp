﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {        

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
        }
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
        public void DisplayCard(model.Card a_card)
        {            
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {            
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(string a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            Console.WriteLine("Score: {0}", a_score);
            Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                Console.WriteLine("Dealer Won!");
            }
            else
            {
                Console.WriteLine("You Won!");
            }
            
        }

        public void Wait()
        {            
            System.Threading.Thread.Sleep(500);
        }
    }
}
