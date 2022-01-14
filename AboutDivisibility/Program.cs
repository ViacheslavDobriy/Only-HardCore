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
double GetSizeSimpleNumbers(double number)
{
    double i = 3;
    double result = 2;
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
double UserNumber = GetNumber();
double size = GetSizeSimpleNumbers(UserNumber);
Console.WriteLine($"Размер массива будет равен {size}");