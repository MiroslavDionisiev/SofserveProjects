using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftServe_Project1_Suffix_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            SuffixArray arr = new SuffixArray("tree");
            Console.WriteLine(arr.numberOfOccurrences("tree"));
            arr.printOfOccurrences("h");
            arr.printSuffixArray();
        }
    }
}
