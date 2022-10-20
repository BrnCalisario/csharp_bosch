namespace Aula
{
    class Complex
    {
        private double rValue;
        private double iValue;
    
        public Complex(double v, double i)
        {
            this.rValue = v;
            this.iValue = i;
        }

        public static Complex operator + (Complex cp1, Complex cp2)
        {
            double resultReal = cp1.rValue + cp2.rValue;
            double resultImaginary = cp1.iValue + cp2.iValue;

            return new Complex(resultReal, resultImaginary);
        }

        public static Complex operator - (Complex cp1, Complex cp2)
        {
            double resultReal = cp1.rValue - cp2.rValue;
            double resultImaginary = cp1.iValue - cp2.iValue;

            return new Complex(resultReal, resultImaginary);
        }

        public override string ToString() => rValue + " + i" + iValue;
        
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Complex cpx1 = new Complex(18, 20);
            Complex cpx2 = new Complex(4, 3);

            Complex soma = cpx1 - cpx2;
            

            Console.WriteLine(soma);

        }
    }
}