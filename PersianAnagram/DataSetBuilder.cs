using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
    public class DataSetBuilder
    {
        private static int primeNum = 2;
        private string persianLetter = "آابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی";
        public Dictionary<char, int> LetterPrimeMap;
        public Dictionary<string, int> WordPrimeMap;

        public DataSetBuilder()
        {
            this.WordPrimeMap = new Dictionary<string, int>();
            this.LetterPrimeMap = new Dictionary<char, int>();
            PrepareLetterPrimeMap();
            PrepareWordPrimeMap();
        }

        public List<string> GetAnagramOf(string input)
        {
            int mul = this.GenaratePrimeForWord(input);
            var q = from m in this.WordPrimeMap where m.Value == mul select m.Key;
            return q.ToList();
        }

        public void PrepareWordPrimeMap()
        {
            // reading from file
            var fileName =  Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "/words.csv";
//            Console.WriteLine(fileName);
            using (var sr = new System.IO.StreamReader(fileName))
            {
                string word;
                while ((word = sr.ReadLine()) != null)
                {
                    WordPrimeMap[word] = GenaratePrimeForWord(word);
                }
            }
        }

        private int GenaratePrimeForWord(string word)
        {
            int mul = 1;
            foreach (char c in word)
            {
                if (!LetterPrimeMap.ContainsKey(c))
                {
                    LetterPrimeMap[c] = GetNextPrimeNum();
                }
                mul = mul * LetterPrimeMap[c];
            }

            return mul;
        }

        private void PrepareLetterPrimeMap()
        {
            foreach (char c in persianLetter)
            {
                LetterPrimeMap.Add(c, GetNextPrimeNum());
            }
        }

        private int GetNextPrimeNum()
        {
            if (primeNum == 2)
            {
                primeNum++;
                return 2;
            }

            while (!IsPrime(primeNum))
            {
                ++primeNum;
            }

            return primeNum++;
        }
        
        private bool IsPrime(int num)
        {
            double squaredNumber = Math.Sqrt(Convert.ToDouble(num));
            for (var i = 2; i <= squaredNumber; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}