using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingAverage
{
    /// <summary>
    /// MovingAverage
    /// This class calculates the moving average from an interface. This is based off the documentation provided by MModal in the documentation folder
    /// There are two parameters to the function that is used to calculate the moving average
    /// The simple moving average and the cumulative moving average are both calculated
    /// Initially all of the averages are calculated as a Cumulative Moving Average (CMA)
    /// Once the first parameter is met, then all of the averages are calculated based off the Simple Moving Average (SMA)
    /// Each average is described at a later point in this file in the relative functions
    /// 
    /// Concerns:
    ///     - Only standard ASCII is recognized as input
    ///     - Length of the bool array input is technically infinite
    ///     - Main rich text box does not limit the length of its text, only applicable in the debug branch
    /// </summary>
    public partial class MovingAverage : Form
    {
        #region MovingAverage Class Variables
        public const string s_MovingAverageVersion = "1.0";     //the version of the application, since this is a simple application the version number will reside only in this file
        #endregion MovingAverage Class Variables

        #region public MovingAverage()
        /// <summary>
        /// public MovingAverage()
        /// Constructor for the form
        /// </summary>
        public MovingAverage()
        {
            InitializeComponent();
            this.Text += " " + s_MovingAverageVersion;        //append the version number to the name of the window
            txt_DblArr.TextChanged += Txt_DblArr_TextChanged;       //assign the text changed event
            txt_WindowSize.TextChanged += Txt_WindowSize_TextChanged;
            //conditionally make some components visible depending on whether the program is debugging or not
#if (DEBUG)
            //then the app is currently in the DEBUG mode 
            rtxt_MovAvg.Visible = true;       //set the window to visible
            txt_WindowSize.Text = "3";      //set the text box text for the window size
            txt_DblArr.Text = "0 1 2 3";        //set the text box for the dbl array
            rtxtWriteLine("Output should be: [0, 0.5, 1, 2]");
#else
            //otherwise the app is current in release mode
            rtxt_MovAvg.Visible = false;        //set the window to invis so the user can't see diag info
            this.Height = this.Height - rtxt_MovAvg.Height;     //adjust the height of this current window to make the window prettier
#endif
        }
        #endregion public MovingAverage()

        #region private double[] ParseInput(string s_ToParse)
        /// <summary>
        /// private double[] ParseInput(string s_ToParse)
        /// This function will take the user input from some text and will parse the input and place its results in a double array which will be returned
        /// Standard deliminators apply, commas, semi colons, spaces, dash, slashes, pretty much anything that isn't a regular character
        /// An error message will be displayed if the input is invalid, if that is the case then null will be returned from the method
        /// </summary>
        /// <param name="s_ToParse">The string that will be parsed</param>
        /// <returns>A double array holding the parsed input, null if there is an error encountered</returns>
        private double[] ParseArrInput(string s_ToParse)
        {
            char[] ca_Delims = { ' ', '-', ':', '/', '*', ';', '\\' };      //bunch of deliminators to remove from the split string
            string[] sa_Split = s_ToParse.Split(ca_Delims);     //split the argument to this method
            double[] da_Ret = new double[sa_Split.Length];      //create the double array return based on the split string
            //loop through each string that was used
            for(int i=0; i < sa_Split.Length; i++)
            {
                double d_Parsed;        //the double that the string represents
                if(!double.TryParse(sa_Split[i], out d_Parsed))
                {
                    //then the parse failed
                    rtxtWriteLine("Error parsing the double: " + sa_Split[i]);      //won't print the error message in the release, that will be handled in the calling code
                    return null;        //return null
                }
                //otherwise the parse succeed, the result is in d_Parsed
                da_Ret[i] = d_Parsed;
            }
            return da_Ret;
        }
        #endregion private double[] ParseInput(string s_ToParse)

        #region private void btn_Calculate_Click(object sender, EventArgs e)
        /// <summary>
        /// private void btn_Calculate_Click(object sender, EventArgs e)
        /// Gets called whenever the user clicks on the 'Calculate' button
        /// First the input is parsed into the respective arrays
        /// If there is an error then the function pre-maturely returns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            int i_WinSz;        //holds the window size to pass to the function
            if (!int.TryParse(txt_WindowSize.Text, out i_WinSz))
            {
                //then the conversion did not succeed, notify the user, will show a message box depending on the mode of debugging
                rtxtWriteLine("Error parsing input for the window size. Please enter a valid number", rtxt_MovAvg, true);
                return;     //return from the function
            }
            double[] da_DblArr = ParseArrInput(txt_DblArr.Text);        //parse the double array into an array
            if (da_DblArr == null)
            {
                //then the conversion to the double array did not succeed, notify the user, will show a message box depending on the mode of debugging
                rtxtWriteLine("Error parsing input for the double array. Please enter a valid array of doubles", rtxt_MovAvg, true);
                return;     //return from the function
            }
            //conditionally display info based on what mode of debugging is occuring
#if (DEBUG)
            //only log the info if we're in debug mode
            rtxtWriteLine("Window size: " + i_WinSz);
            string s_Print = "Double array: ";
            foreach (double d in da_DblArr)
                s_Print += d + " ";
            rtxtWriteLine(s_Print);
#endif
            //now that the information required for the calculation has been obtained, it is safe to start calculating the running averages
        }
        #endregion private void btn_Calculate_Click(object sender, EventArgs e)

        #region private void Txt_DblArr_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// private void Txt_WindowSize_TextChanged(object sender, EventArgs e)
        /// Text changed event for the txt_DblArr text box
        /// Only digits periods and spaces are allowed to go through the text, otherwise the text box will recorrect the text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_DblArr_TextChanged(object sender, EventArgs e)
        {
            string s_CurrentText = txt_DblArr.Text;     //get the current text
            string s_NewText = CleanseDblArrInput(txt_DblArr.Text);      //cleanse the input and set it to the output of the cleanse double array method 
            //if the new changed text is different then the original text...
            if (!s_CurrentText.Equals(s_NewText))
            {
                txt_DblArr.Text = s_NewText;        //set the new text to the cleansed input
                //if the text was adjusted then we must adjust the cursor to the end of the selection
                //determine if the length is too small
                if(txt_DblArr.Text.Length != 0)
                {
                    //then its safe to set the cursor location to the end of the text
                    txt_DblArr.SelectionStart = txt_DblArr.Text.Length - 1;     //set the selection start
                    txt_DblArr.SelectionLength = 0;     //make sure there's nothing selected, only want to set the cursor to the end
                }
            }
        }
        #endregion private void Txt_DblArr_TextChanged(object sender, EventArgs e)

        #region private void Txt_WindowSize_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// private void Txt_WindowSize_TextChanged(object sender, EventArgs e)
        /// Text changed event for the txt_WindowSize text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_WindowSize_TextChanged(object sender, EventArgs e)
        {
            string s_CurrentText = txt_WindowSize.Text;     //get the current text
            string s_NewText = CleanseIntInput(txt_WindowSize.Text);     //cleanse the input and set it to the output of the cleanse int method
            //if the new changed text is different then the original text...
            if(!s_CurrentText.Equals(s_NewText))
            {
                //then the text needs changed
                txt_WindowSize.Text = s_NewText;        //set the new text ot the cleansed input
                //if the text was adjusted then we must adjust the cursor to the end of the selection
                //determine if the length is too small to approriately set the selection cursor
                if(txt_WindowSize.Text.Length != 0)
                {
                    //then its safe to set the cursor location to the end of the text
                    txt_WindowSize.SelectionStart = txt_WindowSize.Text.Length - 1;     //set the selection start
                    txt_WindowSize.SelectionLength = 0;     //make sure there's nothing selected, only want to set the cursor to the end
                }
            }
        }
        #endregion private void Txt_WindowSize_TextChanged(object sender, EventArgs e)

        #region private string CleanseIntInput(string s_Inp)
        /// <summary>
        /// private string CleanseIntInput(string s_Inp)
        /// Cleanses the input for an integer input
        /// Only integers are allowed, everything else will register as an error
        /// If an invalid input is found a wav file plays which is a ding and the user is notified that something has gone wrong
        /// Note that no input will be converted to an int, only character comparisons will be performed
        /// </summary>
        /// <param name="s_Inp">The input that will be cleansed</param>
        /// <returns>The cleansed string</returns>
        private string CleanseIntInput(string s_Inp)
        {
            bool b_PlayedWav = false;       //indicates if we've played the ding dong file
            string s_Ret = "";      //output string, contains the parsed input
            //loop through each character of the s_Inp, needs examined each time unfortunately
            foreach (char c in s_Inp)
            {
                if (c >= '0' && c <= '9')
                {
                    //then this is a valid character, tack it onto the end of the output string
                    s_Ret += c;     //tack the character onto the end
                }
                else
                {
                    //otherwise this is not a valid character, determine if we've played the ding dong file
                    if (!b_PlayedWav)
                    {
                        //then the wav file has not been played, play the wav file so the end user knows what's happened
                        using (SoundPlayer sp_Err = new SoundPlayer("./Windows Ding.wav"))
                        {
                            sp_Err.Play();
                        }
                        b_PlayedWav = true;     //set the flag indicating the user has commited a crime
                    }
                }
            }
            return s_Ret;
        }
        #endregion private string CleanseIntInput(string s_Inp)

        #region private string CleanseDblArrInput(string s_Inp)
        /// <summary>
        /// private string CleanseDblArrInput(string s_Inp)
        /// Cleanses the input of an input requiring a double array
        /// Only periods, doubles, and spaces are allowed in the input
        /// If an invalid input is found a wav file plays which is a ding and the user is notified that something has gone wrong
        /// Note that no double conversion will be done, only character comparisons will be performed
        /// </summary>
        /// <param name="s_Inp"></param>
        /// <returns></returns>
        private string CleanseDblArrInput(string s_Inp)
        {
            bool b_PlayedWav = false;       //indicates if we've played the ding dong file
            string s_Ret = "";      //output string, contains the parsed input
            //loop through each character of the s_Inp, needs examined each time unfortunately
            foreach (char c in s_Inp)
            {
                if (c >= '0' && c <= '9' || 
                    c == ' ' || 
                    c == '.')
                {
                    //then this is a valid character, tack it onto the end of the output string
                    s_Ret += c;     //tack the character onto the end
                }
                else
                {
                    //otherwise this is not a valid character, determine if we've played the ding dong file
                    if (!b_PlayedWav)
                    {
                        //then the wav file has not been played, play the wav file so the end user knows what's happened
                        using (SoundPlayer sp_Err = new SoundPlayer("./Windows Ding.wav"))
                        {
                            sp_Err.Play();
                        }
                        b_PlayedWav = true;     //set the flag indicating the user has commited a crime
                    }
                }
            }
            return s_Ret;
        }
        #endregion private string CleanDblArrInput(string s_Inp)

        #region private void rtxtWriteLine(string s_Print, RichTextBox rtxt)
        /// <summary>
        /// private void rtxtWriteLine(string s_Print, RichTextBox rtxt)
        /// Prints a line of text to a rich text box
        /// Is thread safe
        /// </summary>
        /// <param name="s_Print">The line to print</param>
        /// <param name="rtxt">The rich text box to print to</param>
        /// <param name="b_DispMsgBox">Bool which indicates whether the user should see a message box during the release branch, mainly used for error reporting</param>
        private void rtxtWriteLine(string s_Print, RichTextBox rtxt, bool b_DispMsgBox)
        {
#if (DEBUG)
            //is this on the same thread that the component was created on?
            if(rtxt.InvokeRequired)
            {
                //then the invoke is required
                rtxt.Invoke((MethodInvoker)delegate
                {
                    rtxt.Text += s_Print + Environment.NewLine;     //tack a new line onto the end of the text
                });
            }
            else
            {
                //otherwise invoking is not required
                rtxt.Text += s_Print + Environment.NewLine;     //tack a new line onto the end of the text
            }
#else
            //if the user wants to see the message box
            if(b_DispMsgBox)
                MessageBox.Show(s_Print);
#endif
        }
#endregion private void rtxtWriteLine(string s_Print, RichTextBox rtxt)
        #region private void rtxtWriteLine(string s_Print)
        /// <summary>
        /// private void rtxtWriteLine(string s_Print)
        /// Prints a line of text to the class' rich text box (rtxt_MovAvg)
        /// A message box will not be shown to the user, to do that, call the more in depth rtxtWriteLine method
        /// </summary>
        /// <param name="s_Print">The line of text to print</param>
        private void rtxtWriteLine(string s_Print)
        {
            //call the other rtxtWriteLine with the rtxt_MovAvg as the second param
            rtxtWriteLine(s_Print, rtxt_MovAvg, false);
        }
        #endregion private void rtxtWriteLine(string s_Print)
    }
}
