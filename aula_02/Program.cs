using System;

namespace Aula
{
    class Programa
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            byte[] arr = new byte[6220800];
            rnd.NextBytes(arr);


            var start = DateTime.Now;
            byte[] compactados = compacta(arr);
            byte[] descompactados = descompacta(compactados);
            var end = DateTime.Now;

            Console.WriteLine("\nTempo decorrido: " + (end - start).TotalMilliseconds);
        }

        public static byte[] compacta(byte[] arr)
        {
            byte[] newArr = new byte[arr.Length / 2];
            for (int i = 0, j = 0; i < arr.Length; i += 2, j++ )
            {
                newArr[j] = (byte)( (arr[i] & 240) | (arr[i + 1] >> 4) );
            }
            return newArr;
        }

        public static byte[] descompacta(byte[] arr)
        {
            byte[] newArr = new byte[arr.Length * 2];
            for(int i = 0, j = 0; i < arr.Length; i++, j += 2)
            {
                newArr[j] = (byte)(arr[i] & 240);
                newArr[j + 1] = (byte)(arr[i] << 4);
            }

            return newArr;
        }
    }
}