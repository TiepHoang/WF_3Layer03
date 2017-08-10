﻿using System;
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
            if (input!=null)for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                result += (((int)c) + i * 7) + " ";
            }
            return result;
        }

        public string GiaiMa(string input)
        {
            string result = "";
            if (input != null)
            {

                string[] lst = input.Split(' ');
                for (int i = 0; i < lst.Length; i++)
                {
                    try
                    {
                        result += (char)(int.Parse(lst[i]) - i * 7);
                    }
                    catch { }
                }
            }
            return result;
        }
    }
}
