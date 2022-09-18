using System;
using System.IO;

/// <summary>
/// @author: jaracoder
/// @date:   09/04/2017
/// 
/// Problem C. Bathroom Stalls
/// Qualification Round 2017 - Google Code Jam
/// </summary>
/// 
namespace GoogleCodeJam17
{
    public class ProblemC
    {
        const byte NUMBER_GUARDS = 2;

        static char[] bathroom;

        static double toilettes;
        static double persons;
        static int numberTurn;

        static int totalSpacesToLeft;
        static int totalSpacesToRight;

        static string inFile = "C-small-1-attempt1.in";
        static string outFile = "C-small-1-attempt0.out";

        static string[] inputLines = null;
        static string[] outputLines = null;

        static int totalCases;

        static void Main()
        {
            try
            {
                inputLines = GetLinesFromFile();
                totalCases = Int32.Parse(inputLines[0]);
                outputLines = new string[totalCases];

                for (int i = 1; i < inputLines.Length; i++)
                {
                    toilettes = Convert.ToDouble(inputLines[i].Split(' ')[0].Replace(",", "."));
                    persons = Convert.ToDouble(inputLines[i].Split(' ')[1].Replace(",", "."));

                    InitBathroom((int)toilettes + NUMBER_GUARDS);

                    if (toilettes > persons)
                    {
                        do
                        {
                            numberTurn = GetTurnForToilette();
                            bathroom[numberTurn] = '0';

                            persons--;
                        } while (persons > 0);

                        totalSpacesToLeft = GetTotalSpaces(numberTurn - 1, true);
                        totalSpacesToRight = GetTotalSpaces(numberTurn + 1, false);

                        if (totalSpacesToLeft > totalSpacesToRight)
                        {
                            outputLines[i - 1] = "Case #" + i + ": " +
                                totalSpacesToLeft + " " + totalSpacesToRight;
                        }
                        else
                        {
                            outputLines[i - 1] = "Case #" + i + ": " +
                                totalSpacesToRight + " " + totalSpacesToLeft;
                        }
                    }
                    else
                    {
                        outputLines[i - 1] = "Case #" + i + ": 0 0";
                    }
                }

                SaveLinesOnFile(outputLines);
            }
            catch { }
        }


        /// <summary>
        /// Initialize the bathroom array
        /// </summary>
        static void InitBathroom(int size)
        {
            try
            {
                bathroom = new char[size];

                for (int i = 0; i < bathroom.Length; i++)
                {
                    bathroom[i] = '.';
                }

                bathroom[0] = '0';
                bathroom[bathroom.Length - 1] = '0';
            }
            catch
            {
            }
        }


        /// <summary>
        /// Gets the next turn for toilette by following the rules.
        /// </summary>
        static int GetTurnForToilette()
        {
            int total = 0, count = 0;
            int median = 0;

            // check the central position
            if ((bathroom.Length - 2) % 2 == 0)
            {
                median = (bathroom.Length - 2) / 2;
            }
            else
            {
                median = ((bathroom.Length - 2) / 2) + 1;
            }

            if (bathroom[median] == '.')
            {
                return median;
            }


            // Get the next position number
            for (int i = 0; i < bathroom.Length; i++)
            {
                if (bathroom[i] == '.')
                {
                    count++;
                }
                else
                {
                    if (count > total)
                    {
                        total = count;
                        count = 0;

                        if (total % 2 == 0)
                        {
                            median = i - (total / 2);
                        }
                        else
                        {
                            median = i - (total / 2) - 1;
                        }
                    }
                }
            }

            return median;
        }


        /// <summary>
        /// It obtains the number of free spaces to the left and right respectively.
        /// </summary>
        static int GetTotalSpaces(int from, bool leftDirection)
        {
            int total = 0;
            char symbol = ' ';

            try
            {
                if (leftDirection)
                {
                    symbol = bathroom[from];
                    while (symbol == '.')
                    {
                        if (symbol == '.')
                            total++;

                        from--;
                        symbol = bathroom[from];
                    }
                }
                else
                {
                    symbol = bathroom[from];
                    while (symbol == '.')
                    {
                        if (symbol == '.')
                            total++;

                        from++;
                        symbol = bathroom[from];
                    }
                }
            }
            catch
            {
            }

            return total;
        }


        /// <summary>
        /// Gets all lines of a text file.
        /// </summary>
        static string[] GetLinesFromFile()
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(inFile);
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
                File.WriteAllLines(outFile, lines);
            }
            catch { }
        }
    }
}