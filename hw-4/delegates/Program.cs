using System;

namespace delegates
{
    
    public delegate double Function(double x);
    
    internal class Program
    {
        public static double Integrate(Function f, double a, double b, int segments = 1000000)
        {
            var delta = (b - a) / segments;

            double res = 0;
            
            for (int i = 0; i < segments; i++)
            {
                var leftP = a + i * delta;
                var rightP = leftP + delta;
                var value = (f(leftP) + f(rightP)) / 2;

                res += delta * value;
            }

            return res;
        }
        
        public static void Main(string[] args)
        {
            var sin = new Function(Math.Sin);
            var xSquare = new Function(x => x * x);
            var lnX = new Function(Math.Log);

            var integralOfSin = Integrate(sin, 0, Math.PI);
            Console.Out.WriteLine("integral of sin from 0 to PI: " + integralOfSin);
            
            var integralOfXSquare = Integrate(xSquare, 0, 2);
            Console.Out.WriteLine("integral of xSquare from 0 to 2: " + integralOfXSquare);
            
            var integralOfLnX = Integrate(lnX, 2, 1);
            Console.Out.WriteLine("integral of lnX from 2 to 1: " + integralOfLnX);

        }
    }
}