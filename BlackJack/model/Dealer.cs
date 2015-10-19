﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinStrategy m_winRule;        

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinRule();
        }

        public bool NewGame(Player a_player)
        {            
            if (m_deck == null || IsGameOver(a_player))
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver(a_player))
            {
                GetAndGiveNewCard(a_player, true);
                return true;
            }
            return false;
        }

        public bool Stand(Player a_player)
        {
            if (m_deck != null)
            {
                ShowHand();                

                while (m_hitRule.DoHit(this))
                {
                    GetAndGiveNewCard(this, true);
                }
                return true;
            }
            return false;
        }

        public void GetAndGiveNewCard(Player a_player, bool show)
        {
            Card c = m_deck.GetCard();
            c.Show(show);
            a_player.DealCard(c);            
        }

        public int GetMaxScore()
        {
            return g_maxScore;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver(Player a_player)
        {
            if (m_deck != null && m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            else if (a_player.CalcScore() > g_maxScore)
            {
                ShowHand();
                return true;
            }
            return false;
        }
    }
}
