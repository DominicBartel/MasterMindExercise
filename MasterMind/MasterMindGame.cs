using System;

namespace MasterMind
{
    internal class MasterMindGame
    {
        internal string badEntryReason;
        internal int DigitRange { get; private set; }
        internal int TriesAllowed { get; private set; }
        internal bool IsRunning { get; private set; }
        internal string CorrectNumbers { get; private set; }
        internal string[] AllAttempts { get; private set; }
        public int TriesRemaining { get; private set; }
        public bool GoodEntry { get; internal set; }

        public MasterMindGame(int digitRange, int triesAllowed)
        {
            this.DigitRange = digitRange;
            this.TriesAllowed = triesAllowed;
            this.TriesRemaining = triesAllowed;
            this.IsRunning = true;
            this.AllAttempts = new string[this.TriesAllowed];
            this.GoodEntry = true;
            SetCorrectNumbers();
        }

        private void SetCorrectNumbers()
        {
            Random getNumber = new Random();
            string firstNumber = getNumber.Next(1, 6).ToString();
            string secondNumber = getNumber.Next(1, 6).ToString();
            string thirdNumber = getNumber.Next(1, 6).ToString();
            string fourthNumber = getNumber.Next(1, 6).ToString();
            this.CorrectNumbers = firstNumber + secondNumber + thirdNumber + fourthNumber;

        }

        internal void SolveAttempt(string fourDigits)
        {
            if (GoodAttempt(fourDigits))
            {
                this.AllAttempts[this.TriesRemaining - 1] = fourDigits;
                this.TriesRemaining--;
                this.GoodEntry = true;
            }
            else
            {
                this.GoodEntry = false;
            }
            
            
        }

        internal string LastAttemptResults()
        {
            string lastAttempt = "";
            int correctLocationPresent = 0;
            int incorrectLocationPresent = 0;
            string currentAttempt = AllAttempts[TriesRemaining];
            bool[] checkedNumbers = { false, false, false, false };

            if (this.GoodEntry)
            {
                for (int i = 0; i < currentAttempt.Length; i++)
                {
                    if (currentAttempt[i] == CorrectNumbers[i] && !checkedNumbers[i])
                    {
                        correctLocationPresent++;
                        checkedNumbers[i] = true;
                    }
                    else
                    {
                        string currentCheckedNumber = CorrectNumbers[i].ToString();
                        
                        
                        if (this.CorrectNumbers.Contains(currentCheckedNumber))
                        {
                            for(int h = 0; h < currentAttempt.Length; h++)
                            {
                                if(h != i && currentAttempt[i] == this.CorrectNumbers[h] && !checkedNumbers[h])
                                {
                                    if (currentAttempt[h] == CorrectNumbers[h])
                                    {
                                        correctLocationPresent++;
                                        checkedNumbers[h] = true;
                                    }
                                    else
                                    {
                                        incorrectLocationPresent++;
                                        checkedNumbers[h] = true;
                                        h = currentAttempt.Length;
                                    }
                                    
                                }
                                
                            }
                            
                        }
                    }
                }

                for (int i = 0; i < correctLocationPresent; i++)
                {
                    lastAttempt += "+";
                }

                for (int i = 0; i < incorrectLocationPresent; i++)
                {
                    lastAttempt += "-";
                }
            }
            
            return lastAttempt;

        }

        private bool GoodAttempt(string fourDigits)
        {
            bool attempt = true;
            try
            {
                if (fourDigits.Length != 4)
                {
                    attempt = false;
                    badEntryReason = "Did not enter four digits";
                }
            }
            catch
            { 
                attempt = false;
            }
            return attempt;
        }
    }
}