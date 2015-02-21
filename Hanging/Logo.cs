///		///***********************************************************\\\
///	   //               || || //\\ ||\ || //\\ || ||\ || //\\           \\ 
///	  //                ||=||||==||||\\|||| __ || ||\\|||| __            \\ 
///	 /                  || ||||  |||| \|| \\// || || \|| \\//              \
/// /                 |-----|                                               \
/// \                 |    \0/                                              /
///  \                |    ()                                              / 
///   \\	          |   _/\_                                           //
///	   \\          ___|___                                              //  
///	    \\\***********************************************************///

using System;

namespace Hanging
{
    class Logo : appConst 
    {
        /// <summary>
        /// Print Logo
        /// </summary>
        public static void PrintLogo()
        {
            //headline
            Console.Write(new string(RIFHT_DASH, 3).PadLeft(20));
            Console.Write(new string(ASTERIX, 57));
            Console.WriteLine(new string(LEFT_DASH, 3));

            //HANGING 
            #region first row
            Console.Write(new string(RIFHT_DASH, 2).PadLeft(18));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(16));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIFHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIFHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(RIFHT_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.WriteLine(new string(LEFT_DASH, 2).PadLeft(11));
           
            #endregion
            #region second row
            Console.Write(new string(RIFHT_DASH, 2).PadLeft(17));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(17));
            Console.Write(new string(EQUALLY, 1));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EQUALLY, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(UNDER_SCORE, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(UNDER_SCORE, 2));
            Console.WriteLine(new string(LEFT_DASH, 2).PadLeft(13));

            #endregion
            #region third row
            Console.Write(new string(RIFHT_DASH, 1).PadLeft(15));
            Console.Write(new string(VERTICAL_DASH, 2).PadLeft(19));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 2));
            Console.Write(new string(VERTICAL_DASH, 4));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(RIFHT_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(VERTICAL_DASH, 2));
            Console.Write(new string(EMPTY_SPACE, 1));
            Console.Write(new string(LEFT_DASH, 2));
            Console.Write(new string(RIFHT_DASH, 2));

            Console.WriteLine(new string(LEFT_DASH, 1).PadLeft(14));

            #endregion

            #region The Gibbet
            //the gibbet header /   | ------ |    \
            Console.Write(new string(RIFHT_DASH, 1).PadLeft(14));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(17));
            Console.Write(new string(DASH, 5));
            Console.Write(new string(VERTICAL_DASH, 1));
            Console.WriteLine(new string(LEFT_DASH, 1).PadLeft(47));

            //the gibbet (human arms and head) \   |   \0/   /
            Console.Write(new string(LEFT_DASH, 1).PadLeft(14));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(17));
            Console.Write(new string(EMPTY_SPACE, 4));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(HEAD, 1));
            Console.Write(new string(RIFHT_DASH, 1));
            Console.WriteLine(new string(RIFHT_DASH, 1).PadLeft(46));

            //the gibbet (human body)  \     |    ()     /
            Console.Write(new string(LEFT_DASH, 1).PadLeft(15));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(16));
            Console.Write(new string(EMPTY_SPACE, 4));
            Console.Write(new string(OPEN_BRACKET, 1));
            Console.Write(new string(CLOSE_BRACKET, 1));
            Console.WriteLine(new string(RIFHT_DASH, 1).PadLeft(46));

            //the gibbet (human foots) \\     |  _/\_      //
            Console.Write(new string(LEFT_DASH, 2).PadLeft(17));
            Console.Write(new string(VERTICAL_DASH, 1).PadLeft(14));
            Console.Write(new string(EMPTY_SPACE, 3));
            Console.Write(new string(UNDER_SCORE, 1));
            Console.Write(new string(RIFHT_DASH, 1));
            Console.Write(new string(LEFT_DASH, 1));
            Console.Write(new string(UNDER_SCORE, 1));
            Console.WriteLine(new string(RIFHT_DASH, 2).PadLeft(44));

            //the gibbet bottom \\ _____|_____   //
            Console.Write(new string(LEFT_DASH, 2).PadLeft(18));
            Console.Write(new string(UNDER_SCORE, 3).PadLeft(12));
            Console.Write(new string(VERTICAL_DASH, 1));
            Console.Write(new string(UNDER_SCORE, 3));
            Console.WriteLine(new string(RIFHT_DASH, 2).PadLeft(47));

            #endregion

            //footer
            Console.Write(new string(LEFT_DASH, 3).PadLeft(20));
            Console.Write(new string(ASTERIX, 57));
            Console.WriteLine(new string(RIFHT_DASH, 3));
        }

        /// <summary>
        /// Print greetings and options
        /// </summary>
        public static void Greetings()
        {
            //Greeting
            Console.WriteLine(GREETING.PadLeft(55, EMPTY_SPACE));

            //Options
            Console.WriteLine(CHOOSE_CATEGORY.PadLeft(74, EMPTY_SPACE));
            Console.WriteLine(NUMBER_OF_CATEGORY.PadLeft(76, EMPTY_SPACE));
            Console.WriteLine();
            Console.Write(CATEGORY_REQUEST);
        }
    }
}
