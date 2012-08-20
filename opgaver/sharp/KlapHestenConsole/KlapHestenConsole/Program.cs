using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlapHestenConsole
{
    class Program
    {
        int horses = 15;
        Boolean play = true;
        
        String[] players = new string[2];
        int currentPlayer = 0;

        public void initializeGame()
        {
            Console.WriteLine("Welcome to sticks game! :)");
            Console.WriteLine("");
            Console.WriteLine("One or Two player? (1 or 2)");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                initializeOnePlayerGame();
            }
            else
            {
                initializeTwoPlayerGame();
            }

            selectStartingPlayer();
            printStatus();
            printPick();
        }

        public void selectStartingPlayer()
        {
            currentPlayer = new Random().Next(0, players.Length - 1);
        }

        public void initializeTwoPlayerGame()
        {
            Console.WriteLine("Enter Player One name:");
            players[0] = Console.ReadLine();

            Console.WriteLine("Enter Player Two name:");
            players[1] = Console.ReadLine();
        }

        public void initializeOnePlayerGame()
        {
            Console.WriteLine("Enter Player One name:");
            players[0] = Console.ReadLine();

            players[1] = "Computer";
        }

        public void printStatus()
        {
            Console.WriteLine("There is " + horses + " horses left.");
        }

        public void printPick()
        {
            Console.WriteLine(getCurrentPlayerName() + ": " + "Pick a number between 1 and " + (horses > 3?"3":"2"));
        }

        public String getCurrentPlayerName()
        {
            return players[currentPlayer];
        }

        public Boolean validate(String arg)
        {
            short converted;

            if (!Int16.TryParse(arg, out converted) || (converted <= 0 || converted > 3) || converted > horses) 
            {
                printPick();
                return false;
            } 
            
            return true;
        }

        public void grabHorse(String horsesToGrab){

           if(validate(horsesToGrab)){
               int i = int.Parse(horsesToGrab);
               Console.WriteLine("");
               horses = (horses - i);
               if (horses > 1)
               {
                   printStatus();
                   printPick();
               }
               else
               {
                   play = false;
               }
           }
        }

        public void switchPlayer()
        {
            currentPlayer++;
            if (currentPlayer > players.Length - 1)
            {
                currentPlayer = 0;
            }
        }

        static void Main(string[] args)
        {
            Program horse = new Program();
            horse.initializeGame();
            while (horse.play)
            {
                String arg = Console.ReadLine();
                horse.grabHorse(arg);
                horse.switchPlayer();

            }

            horse.endGame();
            Console.Read();
        }

        public void endGame()
        {
            switchPlayer();
            Console.WriteLine("There is only one horse left. Sorry " + getCurrentPlayerName()  + " you lost.");
            switchPlayer();
            Console.WriteLine(getCurrentPlayerName() + " won the game.");
        }
    }
}
