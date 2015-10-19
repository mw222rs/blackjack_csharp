using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.controller
{
    class PlayGame : model.IBlackJackObserver
    {
        private view.IView m_view;
        private model.Game m_game;

        public void NewHandDealt()
        {
            m_view.Wait();    
            ShowHands();
        }

        public PlayGame(view.IView a_view, model.Game a_game)
        {
            m_view = a_view;
            m_game = a_game;
        }

        public bool Play()
        {
            m_game.AddSubscriber(this);

            ShowHands();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            view.Input input = m_view.GetInput();

            switch (input)
            {
                case view.Input.StartNewGame:
                    m_game.NewGame();
                    break;
                case view.Input.Stand:
                    m_game.Stand();
                    break;
                case view.Input.Hit:
                    m_game.Hit();
                    break;
                case view.Input.Quit:
                    return false;
                case view.Input.None:
                    break;
                default:
                    break;
            }
            return true;            
        }

        private void ShowHands()
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }
    }
}
