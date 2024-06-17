using System.Diagnostics;
using System.Text;

var result = ReturnMinDecimals(8971324560);

Console.WriteLine(result.Item1);
foreach (var item in result.Item2)
{
    Console.Write($"{item} ");
}

PrintMinDecimals(828283754998);//actually 6 times faster

(int, List<long>) ReturnMinDecimals(long number)
{
    int len;
    List<long> outNumbers = new();
    int count = 0;
    var numberAsString = "";
    StringBuilder stringBuilder = new();
    for (var i = 9; i > 0; i--)
    {
        if (number.ToString().Contains($"{i}"))//looking for biggest number, if not a current i - skip
        {
            numberAsString = number.ToString();
        
            foreach (var ch in numberAsString)//mask of 01 for number substraction
            {
                if (ch == $"{i}".ToArray()[0])
                    stringBuilder.Append('1');
                else
                    stringBuilder.Append('0');
            }
            
            outNumbers.Add(long.Parse(stringBuilder.ToString()));//add mask to output (needed)
            number -= long.Parse(stringBuilder.ToString()); //decrease input number to cycle further
            count++;//counter of numbers (needed)
        }

        stringBuilder.Clear();
    }

    return (count, outNumbers);
}


void PrintMinDecimals(long number)
{
    int len;
    List<long> outNumbers = new();
    int count = 0;
    var numberAsString = "";
    StringBuilder stringBuilder = new();
    for (var i = 9; i > 0; i--)
    {
        if (number.ToString().Contains($"{i}"))//looking for biggest number, if not a current i - skip
        {
            numberAsString = number.ToString();

            foreach (var ch in numberAsString)//mask of 01 for number substraction
            {
                if (ch == $"{i}".ToArray()[0])
                    stringBuilder.Append('1');
                else
                    stringBuilder.Append('0');
            }

            outNumbers.Add(long.Parse(stringBuilder.ToString()));//add mask to output (needed)
            number -= long.Parse(stringBuilder.ToString()); //decrease input number to cycle further
            count++;//counter of numbers (needed)
        }

        stringBuilder.Clear();
    }

    Console.Write($"{count}; "); //output section
    
    for (int i = 0; i < outNumbers.Count - 2; i++)
    {
        Console.Write($"{outNumbers[i]}, ");
    }
    Console.WriteLine(outNumbers[outNumbers.Count - 1]);
}