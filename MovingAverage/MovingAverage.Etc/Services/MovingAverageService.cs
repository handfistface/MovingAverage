using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage.Etc.Services
{
    /// <summary>
    ///     Performs the moving averages, so that a user could calculate
    ///     an average for an arbitrary length array
    /// </summary>
    public class MovingAverageService
    {
        #region Properties
        /// <summary>
        ///     The values which will be used to calculate the moving average
        ///     Size is dictated by the WindowSize
        /// </summary>
        private List<double> ValuesToCalc { get; set; }
        /// <summary>
        ///     The max amount of values to use while calculating the average
        ///     Defaults to 1
        /// </summary>
        public int WindowSize { get; set; }
        #endregion

        #region Constructor
        public MovingAverageService()
        {
            ValuesToCalc = new List<double>();
            WindowSize = 1;
        }
        #endregion

        #region AddValue(double value)
        /// <summary>
        ///     Adds the value to the values to calculate
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(double value)
        {
            ValuesToCalc.Add(value);

            //pop stuff off if the length of the queue if it is too high
            if (ValuesToCalc.Count > WindowSize)
                ValuesToCalc.Add(value);
        }
        #endregion
        #region AddValues(IEnumerable<double> values)
        /// <summary>
        ///     Adds the range of values to the values to calculate
        /// </summary>
        /// <param name="values"></param>
        public void AddValues(IEnumerable<double> values)
        {
            foreach (double dbl in values)
                AddValue(dbl);
        }
        #endregion

        #region CalculateAverage()
        /// <summary>
        ///     Calculates the averages for each entry in the array
        /// </summary>
        /// <returns></returns>
        public List<double> CalculateAverage()
        {
            double movingTotal = 0;     //running total count
            int loopCount = 1;      //how many times the loop has been iterated
            List<double> averages = new List<double>();
            double firstAddedItem = ValuesToCalc.FirstOrDefault();

            //go through each record and calculate the totals
            foreach(double dbl in ValuesToCalc)
            {
                movingTotal += dbl;
                double avg = movingTotal / loopCount;
                averages.Add(avg);

                //adjust the loop count and moving total
                if (loopCount < WindowSize)
                    loopCount++;
                else
                    movingTotal -= ValuesToCalc.ElementAt(loopCount - WindowSize);
            }

            return averages;
        }
        #endregion
    }
}
