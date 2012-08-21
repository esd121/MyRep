using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlapHestenConsole
{
    abstract class PinsGameBase
    {
        protected int horses = 15;
        protected Boolean play = true;

        protected String[,] players = new string[2, 2];
        protected int currentPlayer = 0;
    
        abstract public void playGame();

        abstract public void endGame();

        public Boolean validate(String arg)
        {
            short converted;

            if (!Int16.TryParse(arg, out converted) || (converted <= 0 || converted > 3) || converted > horses)
            {
                return false;
            }

            return true;
        }

        public void selectStartingPlayer()
        {
            currentPlayer = new Random().Next(0, players.GetLength(0) - 1);
        }

        public String getCurrentPlayerName()
        {
            return players[currentPlayer, 0];
        }

        public Boolean isComputerPlayer()
        {
            return players[currentPlayer, 1].Equals("auto");
        }

        public void grabHorse(String horsesToGrab)
        {
            int i = int.Parse(horsesToGrab);
            Console.WriteLine("");
            horses = (horses - i);
        }

        public void switchPlayer()
        {
            currentPlayer++;
            if (currentPlayer > players.GetLength(0) - 1)
            {
                currentPlayer = 0;
            }
        }

        public int autoPickNumber()
        {
            return new Random().Next(1, (horses > 3 ? 3 : horses));
        }
    }
}
