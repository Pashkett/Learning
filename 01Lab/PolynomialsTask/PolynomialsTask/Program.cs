using System;

namespace PolynomialsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial polynomial1 = new Polynomial(new Monomial(1, 3),
                                new Monomial(4, 3),
                                new Monomial(1, 1),
                                new Monomial(1, 4));
            Console.WriteLine(polynomial1.ToString());

            Polynomial polynomial2 = new Polynomial(new Monomial(1, 3),
                                new Monomial(4, 3),
                                new Monomial(1, 1));
            Console.WriteLine(polynomial2.ToString());

            Polynomial polynomial3 = polynomial1 * polynomial2;
            Console.WriteLine(polynomial3.ToString());
        }
    }
}
