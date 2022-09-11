/*
Задача 27: Напишите программу, которая принимает на вход число и выдаёт сумму цифр в числе.
452 -> 11
82 -> 10
9012 -> 12
*/

decimal number = 0;
int tryCount = 3;
string inputStr = string.Empty;
bool resInputCheck = false;
int result = 0;

while (!resInputCheck)
{
    Console.WriteLine($"\r\nВведите число (количество попыток: {tryCount}):");
    inputStr = Console.ReadLine() ?? string.Empty;

    resInputCheck = decimal.TryParse(inputStr, out number);

    if (!resInputCheck)
    {
        tryCount--;

        if (tryCount == 0)
        {
            Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
            return;
        }
    }
}

result = GetSumNumbersOfString(number);

Console.WriteLine($"{inputStr} -> {result}");


int GetSumNumbersOfString(decimal number)
{
    int result = 0;
    decimal tmp = Math.Abs(number);
    int wholePart = (int)Math.Floor(tmp);
    int fractialPart = GetFractialPartAsNumber(tmp - wholePart);

    while (wholePart > 0)
    {
        result += (int)wholePart % 10;
        wholePart /= 10;        
    }

    while (fractialPart > 0)
    {
        result += (int)fractialPart % 10;
        fractialPart /= 10;        
    }

    return result;
}

int GetFractialPartAsNumber(decimal fractial)
{    
    if (fractial == 0)
        return 0;

    string tmp = fractial.ToString();
    Console.WriteLine(tmp);
        
    bool resCheck = int.TryParse(tmp.Substring(2, tmp.Length-2), out int result);

    return resCheck ? result : 0;
}