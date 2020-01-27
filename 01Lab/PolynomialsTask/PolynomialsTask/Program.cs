using System;

namespace PolynomialsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial<Monomial> polynomial =
                new Polynomial<Monomial>(new Monomial(1, 3),
                                         new Monomial(4, 5),
                                         new Monomial(1, 1));
            foreach (var item in polynomial)
            {
                Console.Write($"{item.ToString()}");
            }
        }
    }
}
