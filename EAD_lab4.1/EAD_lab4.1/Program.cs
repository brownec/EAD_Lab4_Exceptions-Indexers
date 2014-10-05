// Cliff Browne - X00014810 
// EAD_Lab4.1 Exception Handling
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_lab4._1
{
    /* 1.	Write a Calculator class which contains a static method which divides 2 
    * floating point numbers and returns the answer. 
    * If the second number is 0 throw an ArgumentException since division by 0 is undefined. */

    // --------------------------------------------------
    // --------------------CALCULATOR CLASS--------------
    // --------------------------------------------------
    public class Calculator
    {
        public static double Divide(double lhs, double rhs)
        {
            if (rhs == 0)
            {
                throw new ArgumentException("Error: Attempting to divide by zero");
            }
            else
            {
                return lhs / rhs;
            }
        }
    }
    
    // Use a test class to call the method. 
        
    // --------------------------------------------------
    // --------------------TEST CLASS--------------------
    // --------------------------------------------------
    class Program
    {
        static void Main()
        {
            try
            {
                double num1 = 0;
                double num2 = 0;

                // * Pass in 2 numbers which have been input by the user. 
                bool valid = true;
                do
                {
                    try
                    {
                        /* The test class should validate the inputs by using Double.Parse() to 
                           convert the inputs to floating point numbers catching FormatException 
                           or OverflowExceptions if the inputs are invalid. */

                        // Output to user requesting data
                        Console.Write("Enter the 1st Number: "); 
                        num1 = Double.Parse(Console.ReadLine()); 
                        valid = true;
                    }
                    /* In a call to a method that converts a string to some other data type, the string doesn't 
                     * conform to the required pattern. 
                     * This typically occurs when calling some methods of the Convert class and the Parse and 
                     * ParseExact methods of some types. */
                    catch (FormatException)
                    {
                        valid = false;
                    }
                    /* An arithmetic operation produces a result that is outside the range of the data type 
                       returned by the operation */
                    catch (OverflowException)
                    {
                        valid = false;
                    }
                }
                while (!valid);

                /* If valid then call the static method to divide the numbers and display the result. 
                   Catch any exceptions that may arise. */
                do
                {
                    try
                    {
                        // Request the 2nd number from the user
                        Console.Write("Enter the 2nd Number: "); 
                        /* Double.Parse converts the string the user entered into a double and allows 
                           Console.ReadLine() return the value as a Double */
                        num2 = Double.Parse(Console.ReadLine());
                        valid = true;
                    }
                    catch (Exception)
                    {
                        valid = false;
                    }
                }
                while (!valid);

                Console.WriteLine(Calculator.Divide(num1, num2));
            }
            catch (ArgumentException el)
            {
                Console.WriteLine(el.Message);
            }
        }
    }
}
