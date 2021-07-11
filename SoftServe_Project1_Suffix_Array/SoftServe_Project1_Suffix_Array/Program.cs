using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftServe_Project1_Suffix_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            SuffixArray arr = new SuffixArray("Lorem Ipsum is simply dummy text of the printing and typesetting industry. ");
            Console.WriteLine(arr.numberOfOccurrences("dummy"));
            arr.printOfOccurrences("dummy");
            arr.printSuffixArray();
        }
    }
}
