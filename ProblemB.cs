using System;
using System.IO;

/// <summary>
/// @author: jaracoder
/// @date:   08/04/2017
/// 
/// Tidy Numbers.
/// Problem B - Qualification Round 2017 - Google Code Jam
/// </summary>
/// 
namespace GoogleCodeJam17
{
    public class ProblemB
    {
        static int totalCases;

        static string inputFile = "B-large.in";
        static string[] inputLines = null;

        static string outputFile = "solved.in";
        static string[] outputLines = null;


        static void Main()
        {
            try
            {
                inputLines = GetLinesFromFile();
                totalCases = Int32.Parse(inputLines[0]);
                outputLines = new string[totalCases];

                string number;
                for (int i = 1; i < inputLines.Length; i++)
                {
                    number = inputLines[i];
                    while (!IsTidy(number))
                    {
                        number = (Convert.ToInt64(number) - 1).ToString();
                    }

                    outputLines[i - 1] = "Case #" + i + ": " + number;
                }

                SaveLinesOnFile(outputLines);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Check if it's a tidy number
        /// </summary>
        static bool IsTidy(string number)
        {
            if (number.Length == 1)
                return true;

            for (int i = 0; i < number.Length; i++)
            {
                if (i == number.Length - 1)
                {
                    if (number[i] < number[i - 1])
                    {
                        return false;
                    }
                }
                else
                {
                    if (number[i] > number[i + 1])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Gets all lines of a text file.
        /// </summary>
        static string[] GetLinesFromFile()
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(inputFile);
            }
            catch
            {
                lines = null;
            }

            return lines;
        }


        /// <summary>
        /// Gets all lines of a text file.
        /// </summary>
        static void SaveLinesOnFile(string[] lines)
        {
            try
            {
                File.WriteAllLines(outputFile, lines);
            }
            catch { }
        }
    }
}