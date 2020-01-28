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

            polynomial1.DisplayPolynomial();

            Polynomial polynomial2 = new Polynomial(new Monomial(1, 3),
                                new Monomial(4, 3),
                                new Monomial(1, 1));

            polynomial2.DisplayPolynomial();

            Polynomial polynomial3 = polynomial1 * polynomial2;
            polynomial3.DisplayPolynomial();
        }
    }
}
