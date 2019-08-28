using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheAlphabetProblem;
using CombinationLockProblem;

namespace DailyProgrammerChallenges
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("tryk et tal for den ønskede metode");
                Console.WriteLine("1: the alphabet problem");
                Console.WriteLine("2: combination lock");
                string SelectionKey = Console.ReadLine();
                switch (SelectionKey)
                {
                    case "1":
                        Alphabetencryption();
                        break;
                    case "2":
                        CombinationLock();
                        break;
                    default:
                        break;
                }
            }

        }

        static void Alphabetencryption()
        {
            Console.WriteLine("skriv din krypteringsnøgle");
            string key = Console.ReadLine();
            Console.WriteLine("skriv din sætning");
            String text = Console.ReadLine();
            Console.WriteLine("kryptering af text: " + AlphabetProblem.AlphabetProblemScramble(key, text));
            Console.WriteLine("dekryptering af text: " + AlphabetProblem.AlphabetProblemUnScramble(key, text));
        }


        static void CombinationLock()
        {

            int Wheelsize = 1;
            List<int> Sequence = new List<int>();

            bool Success = false;
            while (Success == false)
            {
                Console.WriteLine("skriv antal tal på din kodelås:");
                Success = Int32.TryParse(Console.ReadLine(), out Wheelsize);

            }
            while (Success)
            {
                
                Console.WriteLine("skriv et tal mellem 0 og " + (Wheelsize - 1).ToString() + " eller tryk enter for at starte");
                Success = Int32.TryParse(Console.ReadLine(), out int value);
                if (value < Wheelsize)
                {
                    Sequence.Add(value);
                }
                else
                {
                    Console.WriteLine(value.ToString() + " er ikke gyldig, prøv igen.");
                }


            }

            CombinationLock cl = new CombinationLock(Wheelsize, Sequence.ToArray() );

            cl.TurnSequence();
            Console.WriteLine("det tog " + cl.Clicks.ToString() + " antal klik at låse op");

        }
    }
}
