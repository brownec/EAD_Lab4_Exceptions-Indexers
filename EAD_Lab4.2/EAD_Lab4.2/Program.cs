// Cliff Browne - X00014810
// EAD Lab4.2 - Exception Handling and Indexers
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAD_Lab4._2
{
    /* 2.	Implement a class which represents a set of results for CAs for a 
     * student in a particular module i.e. ModuleCAResults.  */
    public class ModuleCAResults
    {
        /* The class should contain auto-implemented properties for the module name, 
         * and the number of credits it is worth, and the student name.  */
        public String Name // module name
        {
            get;
            set;
        }
        public int Credits // number of credits module is worth
        {
            get;
            set;
        }
        public String StudentName // student name
        {
            get;
            set;
        }

        /* It should contain a collection of results (scores) for CAs in the module in 
           order i.e. CA1 results in the first position in the collection, CA2 in the second etc.  */
        private const int Max = 50;                 // containing a maximum of no more that 50 results
        private double[] results = new double[Max]; // create an ARRAY(collection of results)
        private int nextFreeSlot = 0;               // next free slot to store a result in the array


        // Override ToString to return all module details and CA results.
        public override string ToString()
        {
            String output = "Module: " + Name + " Credits: " + Credits + " Student Name: " + StudentName + " \nResults.";
            for (int i = 0; i < nextFreeSlot; i++)
            {
                output += results[i] + " ";
            }
            return output;
        }

        /* Implement an indexer for the class which allows retrieval of a specific CA result, 
         * and setting or a result i.e. a read/write indexer property. */
        public double this[int CA]
        {
            get
            {
                // CA is at index 0
                int index = CA - 1;
                if ((index >= 0) && (index < nextFreeSlot)) // valid range
                {
                    return results[index]; // return the result
                }
                else
                {
                    // If the CA number is invalid then throw an exception.
                    throw new Exception("Invalid CA Number!");
                }
            }
            set
            {
                // add a result or change an existing result
                int index = CA - 1;
                /* No gaps should be allowed in the result collection e.g. a result for CA3 should not be 
                   entered before results for CA1 and CA2 for instance. */
                if ((index >= 0) && (index <= nextFreeSlot) && (index < (Max)))
                {
                    results[index] = value; // set the result
                    if (index == nextFreeSlot)
                    {
                        nextFreeSlot++; // sets the new result
                    }
                }
                else
                {
                    // If the CA number is invalid then throw an exception.
                    throw new Exception("Invalid CA Number!");
                }
            }
        }
    }

    // TEST CLASS
    // Test in a separate class using a try/catch block
    class Program
    {
        static void Main()
        {
            try
            {
                ModuleCAResults results = new ModuleCAResults()
                {
                    Name = "EAD1", Credits = 10, StudentName = "Cliff Browne"
                };
                results[1] = 20; // new result for CA 1
                results[2] = 40;
                results[3] = 60;
                results[1] = 25; // overwrite the result for CA1
                results[3] = 65; // overwrite the result for CA3
                results[4] = 99;

                Console.WriteLine(results);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

