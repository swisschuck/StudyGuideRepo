using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace StudyGuide.Classes.Examples.InterviewQuestions
{
    public class InterviewQuestionsMenu
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public InterviewQuestionsMenu()
        {

        }

        #endregion constructors


        #region public methods

        public void RunInterviewQuestionsMenu()
        {
            Console.Clear();
            printInterviewQuestionsMenu();

            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        RunPalindromeStringExample();
                        break;

                    case "2":
                        RunPalindromeIntExample();
                        break;

                    case "3":
                        RunRecursionExample();
                        break;

                    case "4":
                        RunTimerExample();
                        break;
                }
                Console.WriteLine(string.Empty);
                printInterviewQuestionsMenu();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        #endregion public methods


        #region private methods

        private void printInterviewQuestionsMenu()
        {
            Console.WriteLine("Interview Questions Menu:");
            Console.WriteLine("----------------------");
            Console.WriteLine("1) Write a method that will determine if a string value is a palindrome");
            Console.WriteLine("2) Write a method that will determine if a int value is a palindrome");
            Console.WriteLine("3) Demonstrate a recursive method");
            Console.WriteLine("4) Demonstrate a Timer");
            Console.WriteLine("0) Back Home");
        }


        private void RunPalindromeStringExample()
        {
            Console.WriteLine("Please enter a string value to check:");

            string valueToCheck = Console.ReadLine();
            int valueToCheckLength = valueToCheck.Length;
            char[] valueAsCharArray = valueToCheck.ToLower().ToArray();
            bool isPalindrome = true;

            for (int index = 0; index < valueToCheckLength; index++)
            {
                if (valueAsCharArray[index] != valueAsCharArray[valueToCheckLength - 1])
                {
                    // if the first and last letter in the string are not the same, dont go any further
                    Console.WriteLine($"{valueToCheck} is NOT a Palindrome");
                    isPalindrome = false;
                    break;
                }
                else
                {
                    // shorten the length by 1 and keep going
                    valueToCheckLength--;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine($"{valueToCheck} IS a Palindrome");
            }
        }

        private void RunPalindromeIntExample()
        {
            Console.WriteLine("Please enter an int value to check:");

            string valueToCheck = Console.ReadLine();
            int parsedValue;

            if (!int.TryParse(valueToCheck, out parsedValue))
            {
                Console.WriteLine("Sorry but that is not a valid number value, please try again:");
                return;
            }

            int valueToCheckLength = valueToCheck.Length;
            char[] valueAsStringArray = valueToCheck.ToArray();
            bool isPalindrome = true;

            for (int index = 0; index < valueToCheckLength; index++)
            {
                if (valueAsStringArray[index] != valueAsStringArray[valueToCheckLength - 1])
                {
                    // if the first and last number are not the same, dont go any further
                    Console.WriteLine($"{valueToCheck} is NOT a Palindrome");
                    isPalindrome = false;
                    break;
                }
                else
                {
                    // shorten the length by 1 and keep going
                    valueToCheckLength--;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine($"{valueToCheck} IS a Palindrome");
            }
        }

        private void RunRecursionExample()
        {
            Console.WriteLine("Please enter bob or something else");
            string valueEntered = Console.ReadLine();

            while(!doSomethingOverAndOver(valueEntered))
            {
                Console.WriteLine("Please enter bob or something else");
                valueEntered = Console.ReadLine();
                doSomethingOverAndOver(valueEntered);
            }
        }

        private void RunTimerExample()
        {
            Timer timer = new Timer();
            timer.Interval = 10000;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Raised: {0}", e.SignalTime);
        }


        #endregion private methods


        #region private helper methods

        private bool doSomethingOverAndOver(string valueToCheck)
        {
            return valueToCheck.ToLower() == "bob";
        }


        #endregion private helper methods
    }
}
