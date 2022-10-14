using System;

namespace Aula
{
    class Programa
    {
        static void Main(string[] args)
        {

            var start = DateTime.Now;

            Random rnd = new Random();
            byte[] arr = new byte[6220800];
            rnd.NextBytes(arr);

            int len = arr.Length;

            byte[] compactados = Compression.compacta(arr);
            byte[] descompactados = Decompression.descompacta(compactados);
            
            var end = DateTime.Now;

            Console.WriteLine("\nTempo decorrido: " + (end - start).TotalMilliseconds);

            // Console.WriteLine("Bytes: ");
            // foreach(var i in arr)
            //     Console.Write(i + " ");
            // Console.Write("\n\n");

            // Console.WriteLine("Compactado: ");
            // foreach(var i in compactados)
            //     Console.Write(i + " ");
            // Console.Write("\n\n");

            // Console.WriteLine("Descompactado: ");
            // foreach(var i in descompactados)
            //     Console.Write(i + " ");
        }
    }

    class Compression
    {
        public static byte[] compacta(byte[] arr)
        {
            byte[] newArr = new byte[arr.Length / 2];
            int i = 0;
            int index = 0;
            while (i < newArr.Length)
            {
                int a = arr[index] >> 4;
                int b = arr[index + 1] >> 4;
                newArr[i] = binToByte( toBin(a) + toBin(b) );
                i++;
                index += 2;
            }

            return newArr;
        }
        
        static string toBin(int value)
        {
            string toBin = Convert.ToString(value, 2);
            while (toBin.Length < 4)
            {
                toBin = "0" + toBin;
            }

            return toBin;
        }

        static byte binToByte(string binary)
        {
            byte result = 0;
            int aux = 0;
            for (int i=0; i < binary.Length; i++)
            {
                result = Convert.ToByte((aux * 2) + (Convert.ToInt16(binary[i]) - 48));
                aux = result;
            }
            return result;
        }
    }

    class Decompression
    {
        public static byte[] descompacta(byte[] arr)
        {
            byte[] newArr = new byte[arr.Length * 2];

            int i = 0;
            int index = 0;
            while(i < arr.Length)
            {
                newArr[index] = (byte)(arr[i] >> 4 << 4);
                newArr[index + 1] = (byte)(arr[i] << 4);

                i++;
                index += 2;
            }

            return newArr;
        }
    }
}