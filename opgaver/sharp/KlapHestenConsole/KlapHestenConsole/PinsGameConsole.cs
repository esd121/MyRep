using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KlapHestenConsole
{
    class PinsGameConsole : PinsGameBase
    {
        public void writeTextLn(String arg)
        {
            Console.WriteLine(arg);
        }

        public void writeText(String arg)
        {
            Console.Write(arg);
        }

        public String readText()
        {
            return Console.ReadLine();
        }

        public void initializeGame()
        {
            writeTextLn("Welcome to sticks game! :)");
            writeTextLn("");
            writeTextLn("One or Two player? (1 or 2)");
            if (int.Parse(readText()) == 1)
            {
                initializeOnePlayerGame();
            }
            else
            {
                initializeTwoPlayerGame();
            }

            selectStartingPlayer();
        }

        public void initializeTwoPlayerGame()
        {
            Console.WriteLine("Enter Player One name:");
            players[0, 0] = Console.ReadLine();
            players[0, 1] = "manual";
            Console.WriteLine("Enter Player Two name:");
            players[1, 0] = Console.ReadLine();
            players[1, 1] = "manual";
        }

        public void initializeOnePlayerGame()
        {
            Console.WriteLine("Enter Player One name:");
            players[0, 0] = Console.ReadLine();
            players[0, 1] = "manual";

            players[1, 0] = "Computer";
            players[1, 1] = "auto";
        }

        public void printStatus()
        {
            Console.WriteLine("There is " + horses + " horses left.");
        }

        public void printPick()
        {
            Console.Write(getCurrentPlayerName() + ": " + "Pick a number between 1 and " + (horses > 3?"3":"2") + ": ");
        }

        override public void playGame()
        {
            initializeGame();
            while (play)
            {
                printStatus();
                printPick();
                String arg = "";
                if (isComputerPlayer())
                {
                    arg = autoPickNumber().ToString();
                    Console.WriteLine(arg);
                }
                else
                {
                    arg = Console.ReadLine();
                }

                if (validate(arg))
                {
                    grabHorse(arg);
                    switchPlayer();

                    if (horses < 2)
                    {
                        play = false;
                    }
                }
                else
                {
                    Console.WriteLine("Argument not valid!");
                }


            }

            endGame();
        }

        override public void endGame()
        {
            switchPlayer();
            Console.WriteLine("Sorry " + getCurrentPlayerName() + " you lost.");
            switchPlayer();
            Console.WriteLine(getCurrentPlayerName() + " won the game.");
        }

        static void Main(string[] args)
        {
            PinsGameConsole horse = new PinsGameConsole();
            horse.playGame();
            Console.Read();
        }

        
    }
}
