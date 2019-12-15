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
                if (masterMind.TriesRemaining > 0)
                {
                    if (masterMind.TriesRemaining < masterMind.TriesAllowed - 1 && masterMind.LastAttemptResults() == "++++")
                    {
                        cw("You have Won! MasterMind will now exit.");
                        Console.ReadKey();
                        masterMind.Restart();
                        break;
                    }
                    else if (masterMind.TriesRemaining == masterMind.TriesAllowed && masterMind.GoodEntry)
                    {
                        cw("Welcome to MasterMind. You have " + masterMind.TriesAllowed + " Attempts.");
                    }
                    else
                    {
                        if (masterMind.GoodEntry)
                        {
                            cw("Selection Results: " + masterMind.LastAttemptResults());
                            cw("Attempts Remaining: " + masterMind.TriesRemaining + " of " + masterMind.TriesAllowed);
                        }
                        else
                        {
                            cw("Invalid entry: " + masterMind.BadEntryReason);
                        }

                    }
                    cw("Please enter four digits ranging 1-6");
                    masterMind.SolveAttempt(Console.ReadLine());

                }
                else
                {
                    
                    
                        cw("You have lost! MasterMind will now exit.");
                        Console.ReadKey();
                        masterMind.Restart();
                    
                    
                }
                
                
            }
            
        }
    }
}
