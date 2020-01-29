using System;

namespace PolynomialsTask
{
    partial class Polynomial
    {
        public static Polynomial operator -(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException("Polynomial should not be null");

            Polynomial result = new Polynomial();
            foreach (var mo in polynomial.Elements)
            {
                result.Elements.Add(new Monomial(-mo.Coefficient, mo.Power));
            }
            result.SetToStandartForm();
            
            if (result.Elements.Count == 0)
            {
                Console.WriteLine("There are no elements in your polynomial.");
                return result;
            }
            else
                return result;
        }

        public static Polynomial operator +(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException("Polynomial should not be null");

            return polynomial;
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null || polynomial2 == null)
                throw new ArgumentNullException("Polynomial should not be null");

            polynomial2 = -polynomial2;
            Polynomial result = polynomial1 + polynomial2;

            return result;
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null || polynomial2 == null)
                throw new ArgumentNullException("Polynomial should not be null");

            Polynomial result = new Polynomial();
            result.Elements.AddRange(polynomial1.Elements.ToArray());
            result.Elements.AddRange(polynomial2.Elements.ToArray());
            result.SetToStandartForm();

            return result;
        }

        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            if (polynomial1 == null || polynomial2 == null)
                throw new ArgumentNullException("Polynomial should not be null");

            Polynomial result = new Polynomial();

            foreach (var po1 in polynomial1.Elements)
            {
                foreach (var po2 in polynomial2.Elements)
                {
                    result.Elements.Add(new Monomial(po1.Coefficient * po2.Coefficient, po1.Power + po2.Power));
                }
            }
            result.SetToStandartForm();

            return result;
        }
    }
}
