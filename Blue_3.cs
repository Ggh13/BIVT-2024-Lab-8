using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {

        private (char letter, double percentage)[] output;
        private readonly string _text;

        public Blue_3(string text): base(text)
        {
            output = null;
        }

        public (char letter, double percentage)[] Output => output;

        public override string ToString()
        {
            
            var output = Output;
            if (output == null)
            {
                return "";
            }
            return string.Join(Environment.NewLine, output.Select(x => $"{x.letter} - {(Math.Round(x.percentage, 4)).ToString("0.0000") }"));
        }


        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;
            var words = Input.Split(new[] { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 0)
                return;

            var letterCounts = new Dictionary<char, int>();

            foreach (var word in words)
            {
                if (word == null || word == "")
                    continue;

                char firstChar = char.ToLower(word[0]);
                if(alphabet.IndexOf(firstChar) == -1)
                {
                    continue;
                }
                if (letterCounts.ContainsKey(firstChar))
                {
                    letterCounts[firstChar]++;
                }
                else
                {
                    letterCounts[firstChar] = 1;
                }
                Console.WriteLine(word);
            }
            var totalWords = 0;
            
            foreach (var word in letterCounts)
            {
                totalWords += word.Value;
                //Console.Write(word.Key);
                //Console.Write(" - ");
                //Console.WriteLine(word.Value);
            }
            /*
            Console.WriteLine(totalWords);
            foreach (var word in letterCounts)
            {
                
                Console.Write(word.Key);
                Console.Write(" - ");
                Console.WriteLine(word.Value / ((double)totalWords / 100));
            }
            */
            var result = letterCounts
                .Select(kv => (letter: kv.Key, percentage:  (double)kv.Value / ((double)totalWords / 100)))
                .OrderByDescending(x => x.percentage)
                .ThenBy(x => x.letter)
                .ToArray();

            double totalPercentage = result.Sum(x => x.percentage);
            
            //Console.WriteLine(totalPercentage);

            output = result;
        }
    }
}
