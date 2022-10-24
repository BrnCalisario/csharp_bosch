// using System;
// using System.Collections.Generic;

// List<string> list = new List<string>();
// list.Add("A");
// list.Add("B");
// list.Add("C");

// foreach(var n in list)
// {
//     Console.WriteLine(n);
// }


// public class List<T> : IEnumerable<T>
// {
//     private T[] values = new T[10];
//     private int count = 0;

//     public T this[int index]
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

//     public void Add(T num)
//     {
//         if (count == values.Length)
//         {
//             T[] newArr = new T[2 * values.Length];
//             for (int i = 0; i < values.Length; i++)
//                 newArr[i] = values[i];
//             this.values = newArr;
//         }

//         values[count] = num;
//         count++;
//     }

//     public IEnumerator<T> GetEnumerator()
//     {
//         ListIterator<T> it = new ListIterator<T>(this);
//         return it;
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         throw new NotImplementedException();
//     }
// }

// public class ListIterator<T> : IEnumerator<T>
// {
//     private List<T> list;
//     int index = -1;

//     public ListIterator(List<T> list)
//     {
//         this.list = list;
//     }

//     public T Current => list[index];

//     T IEnumerator<T>.Current => list[index];

//     object System.Collections.IEnumerator.Current => this.Current;

//     public void Dispose()
//     {
//         // throw new NotImplementedException();
//     }

//     public bool MoveNext()
//     {
//         index++;
//         return index < list.Count;
//     }

//     public void Reset() => index = -1;
// }

