using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage.Etc.Services
{
    /// <summary>
    ///     Prints items to the terminal in use
    /// </summary>
    public class PrintService
    {
        #region PrintDoubles(IEnumerable<double> dbls)
        /// <summary>
        ///     Prints a collection of doubles to the terminal in the format:
        ///     "[ 1.0, 2.0, 3.0 ]"
        /// </summary>
        /// <param name="dbls"></param>
        public void PrintDoubles(IEnumerable<double> dbls)
        {
            Console.Write("[ ");
            for(int i = 0; i < dbls.Count(); i++)
            {
                double dbl = dbls.ElementAt(i);
                Console.Write(dbl.ToString("0.###"));

                //conditionally write the comma
                if (i < dbls.Count() - 1)
                    Console.Write(", ");
            }
            Console.Write(" ]");
        }
        #endregion
    }
}
