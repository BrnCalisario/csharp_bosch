// using System;
// using System.Collections;

// IntList list = new IntList();
// list.Add(4);
// list.Add(2);
// list.Add(1);

// foreach(var i in list)
//     Console.WriteLine(i);


// void mergeSort(IComparable[] arr)
// {
//     int e = arr.Length;
//     IComparable[] arraux = new IComparable[e];
//     mergeSortRec(arr, arraux, 0, e);
// }

// void mergeSortRec(
//     IComparable[] arr,
//     IComparable[] arraux, 
//     int s, int e)
// {
//     if (e - s < 2)
//         return;
//     int p = (s + e) / 2;

//     mergeSortRec(arr, arraux, s, p);
//     mergeSortRec(arr, arraux, p, e);

//     merge(arr, arraux, s, p, e);
// }

// void merge(
//     IComparable[] arr,
//     IComparable[] arraux, 
//     int s, int p, int e)
// {
//     int i = s, j = p, k = s;
//     while (i < p && j < e)
//     {
//         if (arr[i].CompareTo(arr[j]) < 0)
//         {
//             arraux[k] = arr[i];
//             i++;
//             k++;
//         }
//         else
//         {
//             arraux[k] = arr[j];
//             j++;
//             k++;
//         }
//     }

//     while (i < p)
//     {
//         arraux[k] = arr[i];
//         i++;
//         k++;
//     }

//     while (j < e)
//     {
//         arraux[k] = arr[j];
//         j++;
//         k++;
//     }

//     for (int t = s; t < e; t++)
//     {
//         arr[t] = arraux[t];
//     }

// }


// public class BigNatural : IComparable, IDisposable
// {
//     private ulong a; // Menos signficativo
//     private ulong b; // Mais signficativo

//     public int CompareTo(object? obj)
//     {
//         if (obj == null)
//             throw new InvalidOperationException();

//         if (obj is BigNatural bn)
//         {
//             if (this.b > bn.b)
//                 return 1;
//             else if (this.b < bn.b)
//                 return -1;
//             else
//             {
//                 return (int)(this.a - bn.a);
//             }
//         }

//         else if (obj is int i)
//         {
//             if(this.b > 0)
//                 return 1;
//             if (i < 0)
//                 return 1;
//             return (int)(a - (ulong)i);
//         }
//         else if ( obj is ulong u)
//         {
//             if (this.b > 0)
//                 return 1;
//             return (int)(a - u);
//         }
//         throw new InvalidOperationException();
//     }

//     public override string ToString() => b.ToString("0000000000000000000") + a.ToString("00000000000000000000");
    
//     public static BigNatural Parse(string str)
//     {
//         int splitCharacter = str.Length - 19;
//         if (splitCharacter < 0)
//             splitCharacter = 0;
//         var parta = str.Substring(splitCharacter, str.Length - splitCharacter); 
        
//         var partb = str.Substring(0, splitCharacter);

//         BigNatural bg = new BigNatural();
//         bg.a = ulong.Parse(parta);
//         if (partb.Length > 0)
//             bg.b = ulong.Parse(partb);

//         return bg;
//     }


//     public static BigNatural operator + (BigNatural n1, BigNatural n2)
//     {
//         BigNatural result = new BigNatural();

//         result.b = n1.b + n2.b;
//         result.a = n1.a + n2.a;

//         return result;
//     }


//     public static BigNatural operator * (BigNatural n1, BigNatural n2)
//     {
//         BigNatural result = new BigNatural();

//         // Diabo aqui
        
//         return result;
//     }


//     public void Dispose()
//     {
//         // Limpar alguma coisa aqui
//     }

//     public static explicit operator BigNatural(int i)
//     {
//         BigNatural n = new BigNatural();
//         n.a = (ulong)i;
//         return n;
//     }

//     public static bool operator == (BigNatural n1, BigNatural n2)
//         => n1.CompareTo(n2) == 0;

        
//     public static bool operator != (BigNatural n1, BigNatural n2)
//         => n1.CompareTo(n2) != 0;


// }


// public class IntList : IEnumerable
// {
//     private int[] values = new int[10];
//     private int count = 0;

//     public int this[int index]
//     {
//         get
//         {
//             if (index < 0 || index >= count)
//                 throw new IndexOutOfRangeException();
//             return values[index];
//         }
//         set
//         {
//             if (index < 0 || index >= count)
//                 throw new IndexOutOfRangeException();
//             values[index] = value;
//         }
//     }

//     public int Count => count;

//     public void Add(int num)
//     {
//         if (count == values.Length)
//         {
//             int[] newArr = new int[2 * values.Length];
//             for (int i = 0; i < values.Length; i++)            
//                 newArr[i] = values[i];
//             this.values = newArr;
//         }

//         values[count] = num;
//         count++;
//     }

//     public IEnumerator GetEnumerator()
//     {
//         IntListInterator it = new IntListInterator(this);
//         return it;
//     }

// }

// public class IntListInterator : IEnumerator
// {
//     private IntList list;
//     int index = -1;
//     public IntListInterator(IntList list)
//     {
//         this.list = list;
//     }

//     public object Current => list[index];

//     public bool MoveNext()
//     {
//         index++;
//         return index < list.Count;
//     }

//     public void Reset() => index = -1;
// }