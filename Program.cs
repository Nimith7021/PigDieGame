using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalScore = 0;
            int turnScore = 0;
            int noOfTurns = 1;
            int roll = 0;
            Console.WriteLine("Welcome to the game of pig");

            while (totalScore < 20)
            {
                Console.WriteLine($"Turn {noOfTurns} \n");
                bool isTurnChange = true;
                PigDieGameOperation(ref isTurnChange,ref roll,ref noOfTurns,ref turnScore,ref totalScore);
                
            }
            Console.WriteLine($"You win! You finished the game in {noOfTurns-1} turns");
            Console.WriteLine("Game Over !");
        }

        static void RollIsOne(ref int noOfTurns , ref int turnScore ,ref bool isTurnChange,ref int roll )
        {
            noOfTurns++;
            turnScore = 0;
            Console.WriteLine("Turn Over. No Score \n");
            isTurnChange = false;
            roll = 0;
        } 

        static void PrintTurnScoreAndTotalScore(int turnScore , int totalScore)
        {
            Console.WriteLine($"Turn Score = {turnScore}");
            Console.WriteLine($"Total Score = {totalScore}");
            Console.WriteLine($"If you hold you will have " +
                $"{turnScore + totalScore} points \n");
        }

        static void HoldChoice(ref int noOfTurns, ref int turnScore, ref bool isTurnChange,
            ref int roll, int totalScore)
        {
            noOfTurns++;
            Console.WriteLine($"Turn Score = {turnScore}");
            Console.WriteLine($"Total Score = {totalScore}");
            isTurnChange = false;
            turnScore = 0;
            Console.WriteLine("\n");
        }

        static void PigDieGameOperation(ref bool isTurnChange,ref int roll,ref int noOfTurns,
            ref int turnScore,ref int totalScore)
        {
            Random rnd = new Random();

            while (isTurnChange)
            {
                Console.WriteLine("Enter 'r' to roll again,'h' to hold");
                char ch = Convert.ToChar(Console.ReadLine());
                RollAndHoldOperation(ch, rnd, roll, ref noOfTurns,
            ref turnScore, ref isTurnChange, ref totalScore);



            }
        }

        static void RollAndHoldOperation(char ch , Random rnd ,int roll,ref int noOfTurns,
            ref int turnScore, ref bool isTurnChange,ref int totalScore)
        {
            if (ch == 'r')
            {
                roll = rnd.Next(1, 7);
                Console.WriteLine($"You rolled {roll}");
                if (roll == 1)
                {
                    RollIsOne(ref noOfTurns, ref turnScore, ref isTurnChange, ref roll);
                }
                else
                {
                    turnScore += roll;
                    PrintTurnScoreAndTotalScore(turnScore, totalScore);
                }
            }

            if (ch == 'h')
            {
                totalScore += turnScore;
                HoldChoice(ref noOfTurns, ref turnScore, ref isTurnChange, ref roll, totalScore);
            }
        }
    }
}
