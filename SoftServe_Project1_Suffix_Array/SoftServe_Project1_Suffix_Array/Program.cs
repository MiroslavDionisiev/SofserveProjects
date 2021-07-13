using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftServe_Project1_Suffix_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            SuffixArray arr = new SuffixArray("hh");
            Console.WriteLine(arr.numberOfOccurrences("h"));
            arr.printOfOccurrences("ee");
            arr.printOfOccurrences("h");

            arr.Text = "tree";
            Console.WriteLine(arr.numberOfOccurrences("ee"));
            arr.printOfOccurrences("ee");
            
            arr.Text = "ab bf";
            Console.WriteLine(arr.numberOfOccurrences("b b"));
            arr.printOfOccurrences("b b");
        }
    }
}
