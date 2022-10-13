using System;

int[] arr = new int[]
{ 8, 4, 2, 3, 9, 12, 11, 1 };

mergeSort(arr);

foreach (var x in arr[..^1])
{
    Console.Write($"{x}, ");
}
Console.Write($"{arr[arr.Length -1]}.");

void mergeSort(int[] arr)
{
    int e = arr.Length;
    int[] arraux = new int[e];
    mergeSortRec(arr, arraux, 0, e);
}

void mergeSortRec(
    int[] arr,
    int[] arraux, 
    int s, int e)
{
    if (e - s < 2)
        return;
    int p = (s + e) / 2;

    mergeSortRec(arr, arraux, s, p);
    mergeSortRec(arr, arraux, p, e);

    merge(arr, arraux, s, p, e);
}

void merge(
    int[] arr,
    int[] arraux, 
    int s, int p, int e)
{
    int i = s, j = p, k = s;
    while (i < p && j < e)
    {
        if (arr[i] < arr[j])
        {
            arraux[k] = arr[i];
            i++;
            k++;
        }
        else
        {
            arraux[k] = arr[j];
            j++;
            k++;
        }
    }

    while (i < p)
    {
        arraux[k] = arr[i];
        i++;
        k++;
    }

    while (j < e)
    {
        arraux[k] = arr[j];
        j++;
        k++;
    }

    for (int t = s; t < e; t++)
    {
        arr[t] = arraux[t];
    }

}

// // Char utiliza '' e String utiliza ""
// char c = 'a';
// string str = "Olá mundo";

// bool b1 = true;
// bool b2 = false;

// // Necessário colocar 'f' depois do número para identificar Float
// float f = 2f;

// // Não necessário colocar 'f' no double.
// double d = 2.0;


// float infinity = float.PositiveInfinity;
// double dInfinity = double.NegativeInfinity;

// // Representa menor valor positivo depois do zero
// float f1 = float.Epsilon;
// double d1 = double.Epsilon;

// //Qualquer coisa operada com NaN retorna NaN
// double d2 = double.NaN;

// decimal m = 5.0m;

// byte  b = 200; // 0 - 255
// short s = short.MaxValue; 
// int   i = int.MaxValue;
// long  l = long.MaxValue;

// sbyte  sb = -100; // -128 - 128
// ushort us = ushort.MaxValue;
// uint   ui = uint.MaxValue;
// ulong  ul = ulong.MaxValue;


// object obj = str;
// string str2 = (string)obj;


// int result = (int)(ui + l); // Typecast

// dynamic dy = 8;
// dy = "Olá Mundo";

// var x = 7;

// int[] arr = new int[10];
// arr[0] = 4;
// arr[^0] = 3;
// var arr3 = arr[0..2];

// int n = 4 ^ 2;

// //dotnet new console
// Console.WriteLine("Hello, World!");


// int i = 3;
// if (i < 10)
// {
//     Console.WriteLine(i);
// }
// else if (i < 15)
// {
//     Console.WriteLine("Muito Forte");
// }
// else
// {
//     Console.WriteLine("...");
// }

// switch(i)
// {
//     case 3:
//         Console.WriteLine(3);
//         goto case 5;
//     case 4:
//         break;
//     case 5:
//         Console.WriteLine("Bom dia");
//         break;
// }

// int[] arr = new int[100];
// for (int i =0; i < arr.Length; i++)
// {   
//     arr[i] = 1;
// }

// foreach (int n in arr)
// {
//     Console.WriteLine(n);
// }