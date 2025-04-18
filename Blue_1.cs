using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        string[] output;
        public string[] Output
        {
            get
            {
                if(output == null) return null;
                return output;
            }
        }

        public Blue_1(string input) : base(input)
        {
            output = new string[0];
        }


        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input)) return;
            var words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var result = new List<string>();

            if (words.Count == 0)
            {
                output = result.ToArray();
                return;
            }

            string currentLine = words[0];
            foreach (var word in words.Skip(1))
            {
                int possibleLength = currentLine.Length + 1 + word.Length;
                if (possibleLength <= 50)
                {
                    currentLine += " " + word;
                }
                else
                {
                    result.Add(currentLine);
                    currentLine = word;
                }
            }

            result.Add(currentLine);
            output = result.ToArray();
        }
    




        public override string ToString()
        {
            if (output == null) return "" ;
            string result = "";
            for(int i = 0; i < output.Length; i++)
            {
                if(i == output.Length - 1)
                {
                    result += output[i];
                }
                else
                {
                    result += output[i] + Environment.NewLine;
                }
                

            }
            return result;
        }
    }
}
