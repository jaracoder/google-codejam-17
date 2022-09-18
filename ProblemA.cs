using System;
using System.IO;

/// <summary>
/// @author: jaracoder
/// @date:   08/04/2017
/// 
/// Oversized Pancake Flipper.
/// Problem A - Qualification Round 2017 - Google Code Jam
/// </summary>
/// 
namespace GoogleCodeJam17
{
    public class ProblemA
    {
        static int totalCases;

        static string inputFile = "test.txt";
        static string[] inputLines = null;

        static string outputFile = "solvedA.in";
        static string[] outputLines = null;

        static int TotalVueltas = 0;
        static int PosicionInicial = 1;

        static void Main()
        {
            try
            {
                inputLines = GetLinesFromFile();
                totalCases = Int32.Parse(inputLines[0]);
                outputLines = new string[totalCases];

                string pancakes;
                int flipperSize;
                for (int i = 1; i < inputLines.Length; i++)
                {
                    pancakes = inputLines[i].Split(' ')[0];
                    flipperSize = Convert.ToInt32(inputLines[i].Split(' ')[1]);

                    string number = GetNumber(pancakes, flipperSize);

                    outputLines[i - 1] = "Case #" + i + ": " + number;
                }

                SaveLinesOnFile(outputLines);
            }
            catch
            {

            }
        }


        // Pega la vuelta a un número determinado de galletas,
        // dependiendo del tamaño de la espátula.
        // Continua desde la posición anterior. 
        // Contempla todas las posibilidades recorriendo de derecha a izquierda indistintamente.
        static string GetNumber(string pancakes, int flipperSize)
        {
            if (pancakes.Contains("-"))
            {
                int total;

                // Recorre la fila desde la posición inicial hacia la derecha
                string volteo = "";
                for (int i = 0; i < pancakes.Length; i++)
                {
                    volteo += pancakes[i];

                    if (volteo.Length.Equals(flipperSize))
                    {
                        if (volteo.Contains("-"))
                        {
                            TotalVueltas++;
                            pancakes = pancakes.Substring(i - flipperSize);
                        }

                        volteo = "";
                    }
                }
            }

            // Comprueba si todas se encuentran en su cara feliz
            // Retorna el número total acumulado de vueltas realizadas.
            if (!pancakes.Contains("-"))
            {
                return TotalVueltas.ToString();
            }

            return "IMPOSSIBLE";
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