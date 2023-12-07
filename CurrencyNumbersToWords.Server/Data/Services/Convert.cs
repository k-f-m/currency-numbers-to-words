namespace CurrencyNumbersToWords.Server.Data.Services
{
    using Microsoft.AspNetCore.Http.HttpResults;
    using System;
    using System.Buffers.Text;
    using System.Collections.Generic;

    /// <summary>
    /// Converts the dollar amount to its equivalent words representation.
    /// </summary>
    /// <returns>The words representation of the dollar amount.</returns>
    class Convert
    {
        internal static string ConvertToWords(int dollars, int cents)
        {
            // Declare a collection of strings to construct the output representation of the input value and initialize it to an empty list.
            List<string> words = [];

            // Define a collection of key-value pairs to help construct the output string.
            Dictionary<int, string> numberWords = new()
            {
                { 0, "zero" },
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" },
                { 20, "twenty" },
                { 30, "thirty" },
                { 40, "forty" },
                { 50, "fifty" },
                { 60, "sixty" },
                { 70, "seventy" },
                { 80, "eighty" },
                { 90, "ninety" }
            };

            // Add the corresponding words to the empty list of words based on the value of dollars.
            if (dollars == 0)
            {
                words.Add(numberWords[0]);
                words.Add("dollars");
            }
            else
            {
                int[] groupsOfThree = new int[5];
                int groupIndex = 0;

                int dollars_ = dollars;
                while (dollars_ > 0)
                {
                    groupsOfThree[groupIndex] = dollars_ % 1000;
                    dollars_ /= 1000;
                    groupIndex++;
                }

                for (int i = groupIndex - 1; i >= 0; i--)
                {
                    int group = groupsOfThree[i];

                    if (group == 0)
                    {
                        continue;
                    }

                    int hundreds = group / 100;
                    int tens = group % 100;

                    string[] powersOfTen =
                    [
                        "hundred",
                        "thousand",
                        "million",
                        "billion",
                        "trillion"
                    ];
                    if (hundreds > 0)
                    {
                        words.Add(numberWords[hundreds]);
                        words.Add(powersOfTen[0]);
                    }

                    if (tens > 0 && tens <= 20)
                    {
                        words.Add(numberWords[tens]);
                    }
                    else if (tens > 20)
                    {
                        int ones = tens % 10;
                        tens -= ones;
                        words.Add(numberWords[tens]);

                        if (ones > 0)
                        {
                            words.Add("-" + numberWords[ones]);
                        }
                    }

                    if (i > 0)
                    {
                        words.Add(powersOfTen[i]);
                    }
                }
                if (dollars == 1)
                {
                    words.Add("dollar");
                }
                else
                {
                    words.Add("dollars");
                }
            }

            // Add the corresponding words to the list of words based on the value of cents.
            if (cents > 0)
            {
                if (dollars >= 0)
                {
                    words.Add("and");
                }

                if (cents == 1)
                {
                    words.Add(numberWords[1]);
                    words.Add("cent");
                }
                else
                {
                    int tens = cents / 10;
                    int ones = cents % 10;

                    if (tens == 1)
                    {
                        words.Add(numberWords[cents]);
                    }
                    else
                    {
                        if (tens > 1)
                        {
                            words.Add(numberWords[tens * 10]);
                        }

                        if (ones > 0)
                        {
                            if (tens > 1)
                            {
                                words.Add('-' + numberWords[ones]);
                            }
                            else
                            {
                                words.Add(numberWords[ones]);
                            }
                        }
                    }
                    words.Add("cents");
                }
            }
            // Create the output string of words using hyphens or spaces.
            string result = "";
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    if (word.Contains('-'))
                    {
                        result += word;
                    }
                    else
                    {
                        result = result + " " + word;
                    }
                }
            }

            Console.WriteLine(result);
            return result;
        }
    }
}
