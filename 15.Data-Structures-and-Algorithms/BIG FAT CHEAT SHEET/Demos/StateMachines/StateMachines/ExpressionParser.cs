using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    public class ExpressionParser
    {
        private string currentLine;
        private string program;
        private int index;
        private Dictionary<string, double> variables;

        public ExpressionParser(string program)
        {
            this.program = program;
            this.index = 0;
            this.variables = new Dictionary<string, double>();
        }

        public double ParseExpression()
        {
            Func<double> parseFunc = this.ParseAsignment;
            var result = parseFunc();

            if (this.index == this.currentLine.Length)
            {
                return result;
            }

            throw new ArgumentException("Invalid expression!");
        }

        public void Eval()
        {
            try
            {
                this.program
                    .Split('\n')
                    .Select(line => line.Trim())
                    .ToList()
                    .ForEach((line) =>
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            return;
                        }

                        this.index = 0;
                        this.currentLine = line;

                        var result = this.ParseExpression();
                    //Console.WriteLine(result);
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public double ParsePower()
        {
            Func<double> parseFunc = this.ParseParentheses;

            var result = parseFunc();

            if (index < currentLine.Length)
            {
                if (currentLine[index] == '^')
                {
                    index++;
                    result = Math.Pow(result, ParsePower());
                }
            }
            else if (index + 1 < currentLine.Length && currentLine[index] == '*' && currentLine[index + 1] == '*')
            {
                index += 2;
                result = Math.Pow(result, ParsePower());
            }

            return result;
        }

        public double ParseParentheses()
        {
            Func<double> parseFunc = this.ParseAsignment;

            if (currentLine[index] == '(')
            {
                index++;
                var result = parseFunc();

                if (currentLine[index] != ')')
                {
                    throw new ArgumentException("No matching )!");
                }

                index++;

                return result;
            }
            else if (currentLine[index] == '[')
            {
                index++;
                var result = parseFunc();

                if (currentLine[index] != ']')
                {
                    throw new ArgumentException("No matching ]!");
                }

                index++;

                return Math.Floor(result);
            }
            else if (currentLine[index] == '|')
            {
                index++;
                var result = parseFunc();

                if (currentLine[index] != '|')
                {
                    throw new ArgumentException("No matching ]");
                }

                index++;
                return Math.Abs(result);
            }
            // functions
            else if (index + 10 < currentLine.Length && currentLine.Substring(index, 10) == "readNumber")
            {
                index += 10;
                if (currentLine[index] == '(')
                {
                    ++index;
                    if (currentLine[index] != ')')
                    {
                        throw new ArgumentException("No matching )");
                    }

                    ++index;

                    var number = double.Parse(Console.ReadLine());
                    return number;
                }
            }
            else if (index + 5 < currentLine.Length && currentLine.Substring(index, 5) == "print")
            {
                index += 5;
                if (currentLine[index] == '(')
                {
                    var paramList = new List<string>();
                    do
                    {
                        index++;
                        var stringValue = this.ParseString() ?? parseFunc().ToString();
                        paramList.Add(stringValue);
                    }
                    while (this.currentLine[index] == ',');

                    if (currentLine[index] != ')')
                    {
                        throw new ArgumentException("No matching )!");
                    }

                    index++;
                    if (paramList.Count == 0)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine(string.Join(" ", paramList));
                    }

                    return 0;
                }
            }
            else if (index + 4 < currentLine.Length && currentLine.Substring(index, 4) == "sqrt")
            {
                index += 4;
                if (currentLine[index] == '(')
                {
                    index++;
                    var parameter = parseFunc();

                    if (currentLine[index] != ')')
                    {
                        throw new ArgumentException("No matching )!");
                    }

                    index++;
                    parameter = Math.Sqrt(parameter);

                    return parameter;
                }
            }
            else if (index + 3 < currentLine.Length && currentLine.Substring(index, 3) == "log")
            {
                index += 3;
                if (currentLine[index] == '(')
                {
                    index++;
                    var a = parseFunc();
                    if (currentLine[index] != ',')
                    {
                        if (currentLine[index] != ')')
                        {
                            throw new ArgumentException("Expected, ");
                        }

                        index++;
                        return Math.Log(a, 10);
                    }

                    index++;
                    var newBase = parseFunc();

                    if (currentLine[index] != ')')
                    {
                        throw new ArgumentException("No matching )!");
                    }

                    index++;

                    return Math.Log(a, newBase);
                }
            }

            var variable = this.ParseVariable();
            int startIndex = this.index;
            if (variable == null)
            {
                this.index = startIndex;
                return this.ParseNumber();
            }

            return this.variables[variable];
        }

        public double ParseMultiplication()
        {
            Func<double> parseFunc = this.ParsePower;

            var result = this.ParsePower();

            while (index < currentLine.Length)
            {
                if (currentLine[index] == '*')
                {
                    index++;
                    result *= parseFunc();
                }
                else if (currentLine[index] == '/')
                {
                    index++;
                    result /= parseFunc();
                }
                else if (currentLine[index] == ' ')
                {
                    index++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public double ParseSum()
        {
            Func<double> parseFunc = this.ParseMultiplication;

            double result = this.ParseMultiplication();

            while (index < currentLine.Length)
            {
                if (currentLine[index] == '+')
                {
                    index++;
                    result += parseFunc();
                }
                else if (currentLine[index] == '-')
                {
                    index++;
                    result -= parseFunc();
                }
                else if (currentLine[index] == ' ')
                {
                    index++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public double ParseNumber()
        {
            SkipWhiteSpaces();

            double result = 0;
            double significance = 0.1;

            bool isDecimalPointReached = false;
            bool isNegative = false;

            if (currentLine[index] == '-')
            {
                index++;
                isNegative = true;
            }

            if (currentLine[index] == '+')
            {
                index++;
            }

            for (; index < currentLine.Length; index++)
            {
                char currentSymbol = currentLine[index];

                if (currentSymbol == '.')
                {
                    isDecimalPointReached = true;
                    continue;
                }

                if (!char.IsDigit(currentSymbol))
                {
                    break;
                }

                if (!isDecimalPointReached)
                {
                    result = result * 10 + (currentSymbol - '0');
                }
                else
                {
                    result = result + ((currentSymbol - '0') * significance);
                    significance /= 10;
                }
            }

            if (isNegative)
            {
                result *= -1;
            }

            return result;
        }

        public double ParseAsignment()
        {
            this.SkipWhiteSpaces();
            var startIndex = this.index;

            var variable = this.ParseVariable();

            if (variable == null)
            {
                return this.ParseSum();
            }

            if (index >= this.currentLine.Length || this.currentLine[this.index] != '=')
            {
                this.index = startIndex;
                return this.ParseSum();
            }

            ++index;
            var value = this.ParseAsignment();
            this.variables[variable] = value;

            return value;
        }

        public string ParseVariable()
        {
            this.SkipWhiteSpaces();

            if (index < this.currentLine.Length && !char.IsDigit(this.currentLine[index]) && char.IsLetter(this.currentLine[index]))
            {
                var startIndex = index;
                index++;
                while (index < this.currentLine.Length && char.IsLetterOrDigit(currentLine[index]))
                {
                    ++index;
                }

                return currentLine.Substring(startIndex, index - startIndex);
            }

            return null;
        }

        private void SkipWhiteSpaces()
        {
            while (index < currentLine.Length && currentLine[index] == ' ')
            {
                index++;
            }
        }

        private string ParseString()
        {
            this.SkipWhiteSpaces();
            if (this.currentLine[index] == '"')
            {
                var endIndex = index;
                ++index;
                do
                {
                    ++endIndex;
                    endIndex = this.currentLine.IndexOf('"', endIndex);
                }
                while (this.currentLine[endIndex - 1] == '\\');

                var stringValue = this.currentLine.Substring(index, endIndex - index);
                index = endIndex + 1;
                return stringValue;
            }

            return null;
        }
    }
}
