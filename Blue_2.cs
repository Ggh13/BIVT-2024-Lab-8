using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string output;

        public string Output{
        get{
                if (output == null) return null; 

                return output; 
            }
        } 
        private string abc;
        public Blue_2(string input, string abc) : base(input)
        {
            this.abc = abc;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input)) return;
            string[] workto = Input.Split(' ');
            string[] res = new string[0];
            string znPlus = "";
            for (int i = 0; i < workto.Length; i++)
            {
               // Console.Write(workto[i].ToLower());
               // Console.Write(" ");
               // Console.WriteLine(workto[i].ToLower().IndexOf(abc));
                if (workto[i].ToLower().IndexOf(abc) != -1)
                {
                    if (Array.IndexOf(zhnaki, workto[i][0]) != -1)
                    {
                        znPlus = workto[i][0].ToString();
                    }


                    if (Array.IndexOf(zhnaki, workto[i][workto[i].Length - 1] ) != -1)
                    {
                        res[res.Length - 1] = res[res.Length - 1] + workto[i][workto[i].Length - 1];
                    }
                    //Console.WriteLine(workto[i].IndexOf(abc));

                }
                else
                {
                    Array.Resize(ref res, res.Length + 1);
                    res[res.Length - 1] = znPlus + workto[i];
                    znPlus = "";
                }
                
            }
            output = "";
            for (int i = 0; i < res.Length; i++)
            {
                if(i != res.Length-1)
                {
                    output += res[i] + ' ';
                }else
                {
                    output += res[i];
                }
                
            }
            
        }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(output)) return "";
            return output;
        }
    }
}
