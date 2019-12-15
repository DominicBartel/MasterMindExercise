using System;
using System.Text.RegularExpressions;

namespace MasterMind
{
    public class MasterMindGame
    {
        public string BadEntryReason;
        public int DigitRange { get; private set; }
        public int TriesAllowed { get; private set; }
        public bool IsRunning { get; private set; }
        public string CorrectNumbers { get; private set; }
        public string[] AllAttempts { get; private set; }
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
            string firstNumber = getNumber.Next(1, this.DigitRange).ToString();
            string secondNumber = getNumber.Next(1, this.DigitRange).ToString();
            string thirdNumber = getNumber.Next(1, this.DigitRange).ToString();
            string fourthNumber = getNumber.Next(1, this.DigitRange).ToString();
            this.CorrectNumbers = firstNumber + secondNumber + thirdNumber + fourthNumber;

        }

        public void SolveAttempt(string fourDigits)
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
        public void SetCorrectNumbers(string numbersToSet)
        {
            this.CorrectNumbers = numbersToSet;
        }

        internal void Restart()
        {
            this.IsRunning = false;
        }

        

        public string LastAttemptResults()
        {
            
            string lastAttempt = "";
            int correctLocationPresent = 0;
            int incorrectLocationPresent = 0;
            bool[] checkedNumbers = { false, false, false, false };

            try
            {
                string currentAttempt = AllAttempts[TriesRemaining];

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
                                for (int h = 0; h < currentAttempt.Length; h++)
                                {
                                    if (h != i && currentAttempt[i] == this.CorrectNumbers[h] && !checkedNumbers[h])
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
            }
            catch (Exception e)
            {
                Console.WriteLine("error:" + e);
            }
            

            
            
            return lastAttempt;

        }

        public bool GoodAttempt(string fourDigits)
        {
            bool attempt = true;
            try
            {
                if (fourDigits.Length != 4)
                {
                    attempt = false;
                    BadEntryReason = "Did not enter four digits";
                }
                if (NotNumbers(fourDigits))
                {
                    attempt = false;
                    BadEntryReason = "Incorrect input, please enter numbers 1-6";
                }

            }
            catch (Exception e)
            { 
                attempt = false;
                Console.WriteLine("error:" + e);
            }
            return attempt;
        }

        private bool NotNumbers(string fourDigits)
        {
            bool isNumbers = false;
            foreach(char c in fourDigits)
            {
                if (c < '1' || c > this.DigitRange.ToString()[0])
                {
                    isNumbers = true;
                }
            }
            return isNumbers;
        }
    }
}