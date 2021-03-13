using System;
using System.Collections.Generic;
using System.Text;

namespace BranchSystem
{
    public class Util
    {
        const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string GetName(int id)
        {
            if (id < 0)
            {
                return "";
            }
            int numOfLetter = id / 26;
            var mod = id % 26;
            
            var letter = new String('A', numOfLetter);
           
            letter += Letters[mod];
            return letter;
        }
    }
}
