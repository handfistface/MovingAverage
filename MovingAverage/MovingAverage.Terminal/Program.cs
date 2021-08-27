using MovingAverage.Etc.Services;
using System;
using System.Collections.Generic;

namespace MovingAverage.Terminal
{
    class Program
    {
        /// <summary>
        ///     Ask for how large the WindowSize should be for the moving average
        ///     Ask for how many doubles the array should contain
        ///     Ask for all of the doubles
        ///     Calculate the moving average
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            InputService inputServ = new InputService();
            PrintService printServ = new PrintService();

            int windowSize = 0;
            do
            {
                Console.Write("Please enter the WindowSize to calculate the moving average: ");
                windowSize = inputServ.GetInteger();
                Console.WriteLine("");
            } while (windowSize <= 0);

            int arraySize = 0;
            do
            {
                Console.Write("Please enter the size of the array: ");
                arraySize = inputServ.GetInteger();
                Console.WriteLine("");
            } while (arraySize <= 0);

            Console.Write("Please enter the array of doubles (separated by space/enter): ");
            double[] dbls = inputServ.GetDoubleArray(arraySize);
            Console.WriteLine("");

            //calculate the moving average
            MovingAverageService movingAverageServ = new MovingAverageService();
            movingAverageServ.WindowSize = windowSize;
            movingAverageServ.AddValues(dbls);
            List<double> movingAve = movingAverageServ.CalculateAverage();

            //print out the results for the user
            Console.Write("You entered: ");
            printServ.PrintDoubles(dbls);
            Console.WriteLine("");
            Console.Write("The moving average is: ");
            printServ.PrintDoubles(movingAve);
            Console.WriteLine("");
        }
    }
}
