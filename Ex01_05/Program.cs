﻿using System.Text;
using System;

namespace Ex01_05
{
    class Program
    {
        public static void Main()
        {
            NumberStatistics();
        }

        public static void NumberStatistics()
        {
            int biggerThanFirst, minDigit, countDividedBy3;
            float avarageOfDigits;

            string inputAsString = GetValidInputFromUser("Please enter a number with 6 digits(and press enter):");
            StringBuilder responeToUser = new StringBuilder("", 200);
            biggerThanFirst = BiggerThanFirst(inputAsString);
            minDigit = SmallestDigit(inputAsString);
            countDividedBy3 = CountDigitsDividedBy3(inputAsString);
            avarageOfDigits = AverageOfDigits(inputAsString);
            responeToUser.AppendFormat("{0} digits are bigger than the one's digit\n", biggerThanFirst);
            responeToUser.AppendFormat("{0} is the minimum digit in this number\n", minDigit);
            responeToUser.AppendFormat("{0} digits are divided by 3\n", countDividedBy3);
            responeToUser.AppendFormat("{0:f} is the average of the digits\n", avarageOfDigits);
            Console.WriteLine(responeToUser);
        }

        public static string GetValidInputFromUser(string i_Message)
        {
            bool validInput = true;
            string numberAsString;

            do
            {
                if(!validInput)
                {
                    Console.WriteLine("invalid input, try again");
                }
                Console.WriteLine(i_Message);
                numberAsString = Console.ReadLine();
                if (numberAsString.Length == 6 && int.TryParse(numberAsString,out int number))
                {
                    validInput = true;
                }
                else
                {
                    validInput = false;
                }
            } while (!validInput);

            return numberAsString;
        }

        static public int BiggerThanFirst(string i_NumberAsString)
        {
            int firstDigit = int.Parse(i_NumberAsString[5].ToString());
            int countBiggerThanFirst = 0, otherThanFirst;
            for (int i = 0; i < 5; i++)
            {
                otherThanFirst = int.Parse(i_NumberAsString[i].ToString());
                if(otherThanFirst > firstDigit)
                {
                    countBiggerThanFirst++;
                }
            }

            return countBiggerThanFirst;
        }

        static public int SmallestDigit(string i_NumberAsString)
        {
            int currentDigit, minDigit = int.MaxValue;

            for (int i = 0; i < 6; i++)
            {
                currentDigit = int.Parse(i_NumberAsString[i].ToString());
                minDigit = Math.Min(currentDigit, minDigit);
            }

            return minDigit;
        }

        static public int CountDigitsDividedBy3(string i_NumberAsString)
        {
            int currentDigit, dividedBy3Count = 0;

            for (int i = 0; i < 6; i++)
            {
                currentDigit = int.Parse(i_NumberAsString[i].ToString());
                if (currentDigit % 3 == 0)
                {
                    dividedBy3Count++;
                }
            }

            return dividedBy3Count;
        }

        static public float AverageOfDigits(string i_NumberAsString)
        {
            int currentDigit, sumOfDigits = 0;
            float avarageOfDigits;

            for (int i = 0; i < 6; i++)
            {
                currentDigit = int.Parse(i_NumberAsString[i].ToString());
                sumOfDigits += currentDigit;
            }

            avarageOfDigits = (float)sumOfDigits / 6f;

            return avarageOfDigits;
        }
    }
}
