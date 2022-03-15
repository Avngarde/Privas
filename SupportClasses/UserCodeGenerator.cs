using System;

namespace Privas.SupportClasses 
{
    public class UserCodeGenerator 
    {
        public static string Generate()
        {
            char[] letters = new char[26] 
            {
                'A',
                'B',
                'C',
                'D',
                'E',
                'F',
                'G',
                'H',
                'I',
                'J',
                'K',
                'L',
                'M',
                'N',
                'O',
                'P',
                'Q',
                'R',
                'S',
                'T',
                'U',
                'V',
                'W',
                'X',
                'Y',
                'Z'
            };

            char[] digits = new char[10] 
            {
                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
            };

            string code = "";
            Random rnd = new();
            for (int idx = 0; idx < 10; idx++)
            {
                int letterOrNumber = rnd.Next(1,3);
                if (letterOrNumber == 1) 
                {
                    code += letters[rnd.Next(0, 26)];
                }
                else 
                {
                    code += digits[rnd.Next(0,10)];
                }
            }

            return code;
        }
    }
}