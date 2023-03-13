using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace inzynieria_oprogramowania_lab1.Models
{
    class Substring
    {
        public static List<string> DivideBySemicolons(string text)
        {
            List<string> dividedStrings = new List<string>();

            var temp = "";
            for(int index = 0; index < text.Length; index++)
            {
                if (text[index] != ';')
                {
                    temp += text[index];
                }
                else
                {
                    dividedStrings.Add(temp);
                    temp = "";
                }
            }
            return dividedStrings;
        }
    }

    public class SubstringTests
    {
        [Theory]
        [InlineData()]
        public void DivideStringBySemicolonsTest()
        {

        }
    }
}
