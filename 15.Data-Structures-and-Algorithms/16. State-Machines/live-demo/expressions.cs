using System;

class Program
{
	static void Main()
	{
		var expression = Console.ReadLine();
		var result = Expression.Evaluate(expression);
		Console.WriteLine(result);
	}
}

static class Expression
{
	public static double Evaluate(string expression)
	{
		int index = 0;
		return Sum(expression, ref index);
	}

	private static double Sum(string expression, ref int index)
	{
		double result = Product(expression, ref index);

		while(index < expression.Length)
		{
			if(expression[index] == '+')
			{
				++index;
				result += Product(expression, ref index);
			}
			else if(expression[index] == '-')
			{
				++index;
				result -= Product(expression, ref index);
			}
			else
			{
				break;
			}
		}

		return result;
	}

	private static double Product(string expression, ref int index)
	{
		double result = Power(expression, ref index);

		while(index < expression.Length)
		{
			if(expression[index] == '*' && expression[index + 1] != '*')
			{
				++index;
				result *= Power(expression, ref index);
			}
			else if(expression[index] == '/')
			{
				++index;
				result /= Power(expression, ref index);
			}
			else
			{
				break;
			}
		}

		return result;
	}

	private static double Power(string expression, ref int index)
	{
		double result = Brackets(expression, ref index);

		while(index < expression.Length)
		{
			if(expression[index] == '^')
			{
				++index;
				result = Math.Pow(result, Power(expression, ref index));
			}
			else if(expression[index] == '*' && expression[index + 1] == '*')
			{
				index += 2;
				result = Math.Pow(result, Power(expression, ref index));
			}
			else
			{
				break;
			}
		}

		return result;
	}

	private static double Brackets(string expression, ref int index)
	{
		bool isMinus = false;
		double value;

		if((index == 0 || expression[index - 1] == '(' || expression[index - 1] == '[' || expression[index - 1] == '|') && (expression[index] == '+' || expression[index] == '-'))
		{
			isMinus = expression[index] == '-';
			++index;
		}

		if(expression[index] == '(')
		{
			++index;
			double result = Sum(expression, ref index);
			if(index == expression.Length || expression[index] != ')')
			{
				throw new ArgumentException("Brackets");
			}
			++index;
			value = result;
		}
		else if(expression[index] == '[')
		{
			++index;
			double result = Sum(expression, ref index);
			if(index == expression.Length || expression[index] != ']')
			{
				throw new ArgumentException("Brackets");
			}
			++index;
			value = Math.Floor(result);
		}
		else if(expression[index] == '|')
		{
			++index;
			double result = Sum(expression, ref index);
			if(index == expression.Length || expression[index] != '|')
			{
				throw new ArgumentException("Brackets");
			}
			++index;
			value = Math.Abs(result);
		}
		else
		{
			value = Number(expression, ref index);
		}

		return isMinus ? -value : value;
	}

	private static double Number(string expression, ref int index)
	{
		int endIndex = index;

		while(endIndex < expression.Length && (char.IsDigit(expression[endIndex]) || expression[endIndex] == '.'))
		{
			++endIndex;
		}

		double result = double.Parse(expression.Substring(index, endIndex - index));
		index = endIndex;
		return result;
	}
}
