using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IMC.Testing.TDD
{
    public class StringCalulator
    {
        public int Add(string numbersString)
        {
            if (numbersString == "")
            {
                return 0;
            }

            var delimiters = new List<string>()
            {
                @"\n"
            };
            var differentDelimiterRegex = new Regex(@"\\\\(.*?)\\n");
            var multipleDifferentDelimiterRegex = new Regex(@"\\\\(\[(.*?)\])*?\\n");
            var matchMultuple = multipleDifferentDelimiterRegex.Match(numbersString);
            var match = differentDelimiterRegex.Match(numbersString);

            if (matchMultuple.Success)
            {
                var multipleDelimiterRegex = new Regex(@"\[(.*?)\]");
                var multipleDelimiters = multipleDelimiterRegex.Matches(matchMultuple.Value);
                numbersString = numbersString.Replace(matchMultuple.Value, "");
                if (multipleDelimiters.Count>0)
                {
                    foreach (Match delimiter in multipleDelimiters)
                    {
                        var del = delimiter.Value.Replace("[", "").Replace("]", "");
                        delimiters.Add(del);
                    }
                }

            }
            else if (match.Success)
            {
                var delimiter = match.Value.Replace(@"\\", "").Replace(@"\n", "");
                numbersString=numbersString.Replace(match.Value, "");
                delimiters.Add(delimiter);
            }
            else
            {
                delimiters.Add(",");
            }
            var numbers = numbersString.Split(delimiters.ToArray(), StringSplitOptions.None);

            var total = 0;
            var hasNegativeNumbers = false;
            var negativeNumbers = new List<int>();
            foreach (var number in numbers)
            {
                var isNumber = int.TryParse(number, out var value);
                if (isNumber)
                {
                    if (value < 0)
                    {
                        hasNegativeNumbers = true;
                        negativeNumbers.Add(value);
                    } else if (value > 1000)
                    {
                        //Nothing
                    }
                    else
                    {
                        total += value;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid number");
                }
            }
            if (hasNegativeNumbers)
            {
                throw new Exception("negatives not allowed - " + string.Join(",", negativeNumbers));
            }
            return total;
        }
    }
}
