using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probability_project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

                int[] data = {
            115,182,191,31,196,1099,5,172,10,179,83,21,20,21,186,177,195,193,
            188,199,62,109,105,183,110
        };

                Array.Sort(data);

                int n = data.Length;

                // Mean
                double mean = data.Average();

                // Median
                double median = (n % 2 == 0) ?
                    (data[n / 2 - 1] + data[n / 2]) / 2.0 :
                    data[n / 2];

                // Mode
                var mode = data.GroupBy(x => x)
                               .OrderByDescending(g => g.Count())
                               .First().Key;

                // Variance
                double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();

                // Standard Deviation
                double stdDev = Math.Sqrt(variance);

                // Range
                int range = data.Max() - data.Min();

                // Percentile function
                double Percentile(double[] arr, double p)
                {
                    int index = (int)Math.Ceiling(p * arr.Length) - 1;
                    return arr[index];
                }

                double[] dataDouble = data.Select(x => (double)x).ToArray();

                double p20 = Percentile(dataDouble, 0.20);
                double p50 = Percentile(dataDouble, 0.50);

                // Quartiles
                double q1 = Percentile(dataDouble, 0.25);
                double q2 = median;
                double q3 = Percentile(dataDouble, 0.75);

                // IQR
                double iqr = q3 - q1;

                // Summation of deviations
                double sumDev = data.Select(x => (x - mean)).Sum();

                // Output
                Console.WriteLine("Mean: " + mean);
                Console.WriteLine("Median: " + median);
                Console.WriteLine("Mode: " + mode);
                Console.WriteLine("Variance: " + variance);
                Console.WriteLine("Standard Deviation: " + stdDev);
                Console.WriteLine("Range: " + range);
                Console.WriteLine("P20: " + p20);
                Console.WriteLine("P50: " + p50);
                Console.WriteLine("Q1: " + q1);
                Console.WriteLine("Q2: " + q2);
                Console.WriteLine("Q3: " + q3);
                Console.WriteLine("IQR: " + iqr);
                Console.WriteLine("Sum of Deviations: " + sumDev);
            }
        }

    }
    

