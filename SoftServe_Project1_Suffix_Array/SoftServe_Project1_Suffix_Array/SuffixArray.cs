using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftServe_Project1_Suffix_Array
{
    public class SuffixArray
    {
        private const int ALPHABET = 256;
        private string text;
        private List<int> suffixArray;
        private List<int> classes;

        public SuffixArray(string text)
        {
            this.text = text;
            this.createSuffixArray();
        }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                this.createSuffixArray();
            }
        }

        private void createSuffixArray()
        {
            this.text += "$";

            this.suffixArray = Enumerable.Repeat(0, this.text.Length).ToList();
            this.classes = Enumerable.Repeat(0, this.text.Length).ToList();

            int indexofSpecialSymbol = 0;
            this.createArray(ref indexofSpecialSymbol);
            // removing the index of the additionally added buffer
            this.suffixArray.RemoveAt(indexofSpecialSymbol);

            // removing the additionally added buffer to the text
            this.text = this.text.Remove(this.text.Length - 1);
        }

        ///<summary> sort the substring until lexicographic order </summary>  
        private void createArray(ref int indexofSpecialSymbol)
        {
            List<int> count = new List<int>(Math.Max(ALPHABET, this.text.Length));
            count = Enumerable.Repeat(0, count.Capacity).ToList();
            int classesCurrent = suffixHelper(ref count);
            // permutations by the second element
            List<int> permutations = Enumerable.Repeat(0, this.text.Length).ToList();
            // new classes after the iteration
            List<int> newClasses = Enumerable.Repeat(0, this.text.Length).ToList();

            for (int h = 0; (1 << h) < this.text.Length; h++)
            {
                // sorting by the last element of the suffix by subtracting 2^h
                for (int i = 0; i < this.text.Length; i++)
                {
                    permutations[i] = this.suffixArray[i] - (1 << h);
                    if (permutations[i] < 0)
                    {
                        permutations[i] += this.text.Length;
                    }
                }

                // sorting by the first element
                count = Enumerable.Repeat(0, classesCurrent).ToList();
                for (int i = 0; i < this.text.Length; i++)
                {
                    count[this.classes[permutations[i]]]++;
                }
                for (int i = 1; i < classesCurrent; i++)
                {
                    count[i] += count[i - 1];
                }
                for (int i = this.text.Length - 1; i >= 0; i--)
                {
                    if (permutations[i] == this.text.Length - 1)
                    {
                        indexofSpecialSymbol = count[this.classes[permutations[i]]] - 1;
                    }
                    this.suffixArray[--count[this.classes[permutations[i]]]] = permutations[i];
                }

                // computing the new classes after sorting 
                newClasses[this.suffixArray[0]] = 0;
                classesCurrent = 1;
                for (int i = 1; i < this.text.Length; i++)
                {
                    Tuple<int, int> cur = new Tuple<int, int>(this.classes[this.suffixArray[i]], this.classes[(this.suffixArray[i] + (1 << h)) % this.text.Length]);
                    Tuple<int, int> prev = new Tuple<int, int>(this.classes[this.suffixArray[i - 1]], this.classes[(this.suffixArray[i - 1] + (1 << h)) % this.text.Length]);
                    if (cur.Item1 != prev.Item1 || cur.Item2 != prev.Item2)
                    {
                        classesCurrent++;
                    }
                    newClasses[this.suffixArray[i]] = classesCurrent - 1;
                }
                swapLists(ref newClasses);
            }
        }

        ///<summary> for each character we count how many times it appears in the string, and then use this information to create the suffixArray. 
        /// After that we go through the suffixArary and construct classes by comparing adjacent characters and return the number of classes. </summary>  
        private int suffixHelper(ref List<int> count)
        {
            for (int i = 0; i < this.text.Length; i++)
            {
                count[this.text[i]]++;
            }
            for (int i = 1; i < ALPHABET; i++)
            {
                count[i] += count[i - 1];
            }
            for (int i = 0; i < this.text.Length; i++)
            {
                this.suffixArray[--count[this.text[i]]] = i;
            }

            int classesCurrent = 1;
            this.classes[this.suffixArray[0]] = 0;
            for (int i = 1; i < this.text.Length; i++)
            {
                // if the characters on the consecutive suffixArray indexes are different increase the class
                if (this.text[this.suffixArray[i]] != this.text[this.suffixArray[i - 1]])
                {
                    classesCurrent++;
                }
                this.classes[this.suffixArray[i]] = classesCurrent - 1;
            }

            return classesCurrent;
        }

        private void swapLists(ref List<int> newClasses)
        {
            List<int> copy = new List<int>(this.classes);
            this.classes = new List<int>(newClasses);
            newClasses = new List<int>(copy);
        }

        ///<summary> finds the left most occurrence in the suffix array comparing the value with char at mid + offset as
        /// the offset represents which character from the searched word is being compared </summary>  
        private int leftmostBinarySearch(int left, int right, char value, int offset)
        {
            int result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (this.suffixArray[mid] + offset > this.text.Length - 1)
                {
                    left = mid + 1;
                }
                else if (this.text[this.suffixArray[mid] + offset] > value)
                {
                    right = mid - 1;
                }
                else if (this.text[this.suffixArray[mid] + offset] < value)
                {
                    left = mid + 1;
                }
                else
                {
                    result = mid;
                    right = mid - 1;
                }
            }
            return result;
        }

        ///<summary> finds the right most occurrence in the suffix array comparing the value with char at mid + offset as
        /// the offset represents which character from the searched word is being compared </summary>  
        private int rightmostBinarySearch(int left, int right, char value, int offset)
        {
            int result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (this.suffixArray[mid] + offset > this.text.Length - 1)
                {
                    right = mid - 1;
                }
                else if (this.text[this.suffixArray[mid] + offset] > value)
                {
                    right = mid - 1;
                }
                else if (this.text[this.suffixArray[mid] + offset] < value)
                {
                    left = mid + 1;
                }
                else
                {
                    result = mid;
                    left = mid + 1;
                }
            }
            return result;
        }

        ///<summary> finds the range of starting indexes in the text of the first letter of the searched word </summary>  
        private Tuple<int, int> findRange(string searchedWord)
        {
            int left = 0, right = this.suffixArray.Count - 1;
            for (int i = 0; i < searchedWord.Length; i++)
            {
                left = leftmostBinarySearch(left, right, searchedWord[i], i);
                if (left == -1)
                {
                    return new Tuple<int, int>(-1, -1);
                }
                right = rightmostBinarySearch(left, right, searchedWord[i], i);
                if (right == -1)
                {
                    return new Tuple<int, int>(-1, -1);
                }
            }
            return new Tuple<int, int>(left, right);
        }

        ///<summary> returns the number of  occurrences of the searched word </summary>  
        public int numberOfOccurrences(string searchedWord)
        {
            Tuple<int, int> range = findRange(searchedWord);
            if(range.Item1 == -1)
            {
                return 0;
            }
            return range.Item2 - range.Item1 + 1;
        }

        ///<summary> prints the starting indexes in the text of the first letter of the searched word </summary>  
        public void printOfOccurrences(string searchedWord)
        {
            Tuple<int, int> range = findRange(searchedWord);
            if (range.Item1 == -1)
            {
                Console.WriteLine("No occurrences");
                return;
            }
            for (int i = range.Item1; i <= range.Item2; i++)
            {
                Console.WriteLine(this.suffixArray[i]);
            }
        }

        ///<summary> prints the built suffix array </summary>  
        public void printSuffixArray()
        {
            foreach (int i in this.suffixArray)
            {
                Console.Write(i + " - ");
                for(int j = i; j < this.text.Length; j++)
                {
                    Console.Write(this.text[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
