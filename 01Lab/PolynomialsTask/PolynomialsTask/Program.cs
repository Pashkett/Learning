using System;

namespace PolynomialsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial polynomial =
                new Polynomial(new Monomial(1, 3),
                               new Monomial(4, 3),
                               new Monomial(1, 1));
            
            foreach (var item in polynomial)
            {
                Console.Write($"{item.ToString()}");
            }
        }
    }
}
