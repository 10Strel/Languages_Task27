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

result = GetTotalSumDigitsAsString(number);

Console.WriteLine($"{inputStr} -> {result}");


int GetTotalSumDigitsAsString(decimal number)
{    
    decimal tmp = Math.Abs(number);
    int wholePart = (int)Math.Floor(tmp);
    int fractialPart = GetFractialPartAsNumber(tmp - wholePart);
    
    return GetSumDigitsOfNumber(wholePart) + GetSumDigitsOfNumber(fractialPart);
}

int GetFractialPartAsNumber(decimal fractial)
{    
    if (fractial == 0)
        return 0;

    string tmp = fractial.ToString();
            
    bool resCheck = int.TryParse(tmp.Substring(2, tmp.Length-2), out int result);

    return resCheck ? result : 0;
}

int GetSumDigitsOfNumber(int number)
{
    int result = 0;

    if (number == 0)
        return result;

    int tmp = Math.Abs(number);
    
    while (tmp > 0)
    {
        result += (int)tmp % 10;
        tmp /= 10;        
    }

    return result;
}