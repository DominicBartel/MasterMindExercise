using System;

namespace MasterMind
{
    internal class MasterMindGame
    {
        internal int DigitRange { get; private set; }
        internal int TriesAllowed { get; private set; }
        internal bool IsRunning { get; private set; }

        internal string CorrectNumbers { get; private set; }

        internal string[] AllAttempts { get; private set; }

        public int TriesAttempted { get; private set; }
        public bool GoodEntry { get; internal set; }

        public MasterMindGame(int digitRange, int triesAllowed)
        {
            this.DigitRange = digitRange;
            this.TriesAllowed = triesAllowed;
            this.TriesAttempted = triesAllowed;
            this.IsRunning = true;
            this.AllAttempts = new string[this.TriesAllowed];
            this.GoodEntry = true;
            SetCorrectNumbers();
        }

        private void SetCorrectNumbers()
        {
            Random getNumber = new Random();
            this.CorrectNumbers = getNumber.Next(0, 999999).ToString("D6");

        }

        internal void SolveAttempt(string fourDigits)
        {
            if (GoodAttempt())
            {
                this.AllAttempts[this.TriesAttempted - 1] = fourDigits;
                this.TriesAttempted--;
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
            string currentAttempt = AllAttempts[TriesAttempted];

            if (this.GoodEntry)
            {
                for (int i = 0; i < currentAttempt.Length; i++)
                {
                    if (currentAttempt[i] == CorrectNumbers[i])
                    {
                        correctLocationPresent++;
                    }
                    else
                    {
                        string removedNumberAttempt = currentAttempt.Replace(currentAttempt[i], '\0');
                        string currentCheckedNumber = CorrectNumbers[i].ToString();
                        if (removedNumberAttempt.Contains(currentCheckedNumber))
                        {
                            incorrectLocationPresent++;
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

        private bool GoodAttempt()
        {
            bool attempt = true;
            try
            {

            }
            catch
            {

            }
            return attempt;
        }
    }
}