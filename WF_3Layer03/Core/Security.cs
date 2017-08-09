using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Security
    {
        public string MaHoa(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                result = (((int)c) + i * 7) + " ";
            }
            return result;
        }

        public string Giaima(string input)
        {
            string result = "";
            string[] lst = input.Split(' ');
            for (int i = 0; i < lst.Length; i++)
            {
                try
                {
                    result += int.Parse(lst[i]) - i * 7;
                }
                catch { }
            }
            return result;
        }
    }
}
