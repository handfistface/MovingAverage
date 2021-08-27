using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingAverage.Etc.Services
{
    /// <summary>
    ///     Performs input functionality in the terminal
    /// </summary>
    public class InputService
    {
        //public methods
        #region GetDouble()
        /// <summary>
        ///     Gets a double from the console
        ///     Will terminate upon entering a space or new line
        /// </summary>
        /// <returns></returns>
        public double GetDouble()
        {
            //get a double
            string allowedKeys = "1234567890.";
            string strDbl = GetString(allowedKeys);

            //convert the input over to a double
            double dbl;
            if (!double.TryParse(strDbl, out dbl))
            {
                //then parsing failed, reattempt the double
                Console.WriteLine("");
                Console.Write("Your double is not in the correct format. Please try again... ");
                dbl = GetDouble();
            }
            return dbl;
        }
        #endregion
        #region GetDoubleArray(int arraySize)
        /// <summary>
        ///     Gets a collection of doubles from the console
        /// </summary>
        /// <param name="arraySize">The amount of doubles to get from the console</param>
        /// <returns></returns>
        public double[] GetDoubleArray(int arraySize)
        {
            List<double> dbls = new List<double>();

            for(int i=0; i < arraySize; i++)
            {
                double input = GetDouble();
                dbls.Add(input);
                Console.Write(" ");
            }

            return dbls.ToArray();
        }
        #endregion
        #region GetInteger()
        /// <summary>
        ///     Gets an integer from the console
        ///     Will terminate upon entering a space or new line
        /// </summary>
        /// <returns></returns>
        public int GetInteger()
        {
            string allowedKeys = "1234567890";
            string strInt = GetString(allowedKeys);

            //convert the input over to an integer
            int castedInt;
            if (!int.TryParse(strInt, out castedInt))
            {
                //then parsing failed, reattempt the integer
                Console.WriteLine("");
                Console.Write("Your integer is not in the correct format. Please try again... ");
                castedInt = GetInteger();
            }
            return castedInt;
        }
        #endregion

        //private methods
        #region GetString(string allowedKeys)
        /// <summary>
        ///     Gets a string with the allowed keys
        ///     Will terminate upon entering a space or newline
        /// </summary>
        /// <param name="allowedKeys"></param>
        /// <returns></returns>
        private string GetString(string allowedKeys)
        {
            string bufferedInput = "";      //holds the string we're trying to get
            string strKey = "";     //used to hold the last key entered in the console

            do
            {
                //read in a character
                ConsoleKeyInfo consoleKey = Console.ReadKey(true);
                strKey = consoleKey.KeyChar.ToString();

                //then we can append the input string
                if (string.IsNullOrWhiteSpace(strKey))
                    //skip input if we're at the termination keys
                    Console.Write("");
                else if (allowedKeys.Contains(strKey))
                {
                    //then there is not a period and we're not entering a period
                    //safe to add to the end of the string
                    bufferedInput += strKey;
                    Console.Write(strKey);
                }
            }
            while (!string.IsNullOrWhiteSpace(strKey));

            return bufferedInput;
        }
        #endregion
    }
}
