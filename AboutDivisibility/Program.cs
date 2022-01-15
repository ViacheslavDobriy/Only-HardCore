/*
Есть число N. Скольно групп M, можно получить при разбиении всех чисел на группы, так чтобы в одной группе все числа были взаимно просты.
Например для N = 50, M получается 6

Одно из решений :

Группа 1: 1 
Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47 
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49 
Группа 4: 8 12 18 20 27 28 30 42 44 45 50 
Группа 5: 7 16 24 36 40 
Группа 6: 5 32 48
Задача: найти M при заданном N и получить одно из разбиений на группы N ≤ 10²⁰*/

double GetNumber()
{
    Console.WriteLine("Введите число N: ");
    double number = Convert.ToInt32(Console.ReadLine());
    return number;
}
int GetSizeSimpleNumbers(double number)
{
    double i = 3;
    int result = 2;
    while(i<=number)
    {
        bool check = true;
        double s = 2;
        for(s=2; i/2 >= s && check == true; s++)
        {
            if(i%s==0)
            {
                check = false;
            }
        }
        if(check == true && s!=2) result++;
        i++;
    }
    return result;
}
void FillSimpleNumbers(double[] Array, double number)
{
    double i = 3;
    int I = 2;
    while(i<=number)
    {
        bool check = true;
        double s = 2;
        for(s=2; i/2 >= s && check == true; s++)
        {
            if(i%s==0)
            {
                check = false;
            }
        }
        if(check == true && s!=2)
        {
            Array[I]= i;
            I++;
        }
        i++;
    }
    Array[0] = 2;
    Array[1] = 3;
}
void ShowLine(double[] Array)
{
    Console.Write("1 группа: ");
    for(int i = 0; i<Array.Length; i++)
    {
        Console.Write($"{Array[i]} ");
    }
    Console.WriteLine();
}
int NumberGroups(double number)
{
    int k = 1;
    while(Math.Pow(2,k)<=number)
    {
        k++;
    }
    Console.WriteLine($"Количество групп - {k}");
    return k;
}
void CreatingGroups(double[] Array, double number, int M)
{
    int k = 1;
    while(k<M-1)
    {
        Console.Write($"{k+2} группа: ");
        for(int i = 0; i<Array.Length; i++)
        {
            for(int j = i; j<Array.Length && j<number/j; j++)
            {
                if(Math.Pow(Array[i],k)*Array[j]<=number)
                {
                    Console.Write($"{Math.Pow(Array[i],k)*Array[j]} ");
                }
            }
        }
        Console.WriteLine();
        k++;
    }
}
double UserNumber = GetNumber();
int numberGroups = NumberGroups(UserNumber);
int size = GetSizeSimpleNumbers(UserNumber);
double[] SimplesLine = new double[size];
FillSimpleNumbers(SimplesLine, UserNumber);
Console.WriteLine("1 группа: 1");
ShowLine(SimplesLine);
CreatingGroups(SimplesLine, UserNumber, numberGroups);