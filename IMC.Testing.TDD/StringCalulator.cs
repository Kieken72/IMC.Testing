using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IMC.Testing.TDD
{
    public class StringCalulator
    {
        private readonly List<string> _delimiters;

        public StringCalulator()
        {
            _delimiters = new List<string>()
            {
                ",",
                @"\n"
            };
        }

        public int Add(string numbersString)
        {
            if (numbersString == "")
            {
                return 0;
            }

            numbersString = ExtractCustomerDelimiters(numbersString);

            var numbers = numbersString.Split(_delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

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

        private string ExtractCustomerDelimiters(string inputString)
        {
            var numerStringWithoutDelimiters = inputString;
            //Multiple
            var multipleDifferentDelimiterRegex = new Regex(@"\\\\(\[(.*?)\])*?\\n");
            var matchMultuple = multipleDifferentDelimiterRegex.Match(inputString);
            if (matchMultuple.Success)
            {
                var multipleDelimiterRegex = new Regex(@"\[(.*?)\]");
                var multipleDelimiters = multipleDelimiterRegex.Matches(matchMultuple.Value);
                numerStringWithoutDelimiters = inputString.Replace(matchMultuple.Value, "");
                if (multipleDelimiters.Count > 0)
                {
                    foreach (Match delimiter in multipleDelimiters)
                    {
                        var del = delimiter.Value.Replace("[", "").Replace("]", "");
                        _delimiters.Add(del);
                    }
                }
            }
            else
            {
                //Single
                var differentDelimiterRegex = new Regex(@"\\\\(.*?)\\n");
                var match = differentDelimiterRegex.Match(inputString);
                if (match.Success)
                {
                    var delimiter = match.Value.Replace(@"\\", "").Replace(@"\n", "");
                    numerStringWithoutDelimiters = inputString.Replace(match.Value, "");
                    _delimiters.Add(delimiter);
                }
            }
            return numerStringWithoutDelimiters;
        }
    }
}
