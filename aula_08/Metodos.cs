// Métodos de Extensão
using System;

double num = 8.0;
num.Sqrt().Sqrt().Print();


public static class MyExtensionMethods
{
    public static double Sqrt(this double x)
    {
        return Math.Sqrt(x);
    }

    public static void Print<T>(this T obj)
    {
        Console.WriteLine(obj);
    }
}