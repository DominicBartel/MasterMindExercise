using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {

            MasterMindGame masterMind = new MasterMindGame(6, 10);
            Action<string> cw = Console.WriteLine;

            while (masterMind.IsRunning)
            {
                Console.Clear();
                if(masterMind.TriesAttempted == masterMind.TriesAllowed)
                {
                    cw("Welcome to MasterMind. You have" + masterMind.TriesAllowed+ "Attempts.");
                }
                else
                {
                    if (masterMind.GoodEntry)
                    {
                        cw("Selection Results: " + masterMind.LastAttemptResults());
                    }
                    else
                    {
                        cw("Invalid entry: " + masterMind.badEntryReason);
                    }
                    
                }

                cw("Please enter four digits ranging 1-6");

                
                masterMind.SolveAttempt(Console.ReadLine());
            }
            
        }
    }
}
