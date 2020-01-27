using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace PolynomialsTask
{
    class Polynomial : IEnumerable, ICloneable
    {
        public List<Monomial> Elements { get; private set; }
        public int Degree { get; private set; }

        public Polynomial(params Monomial[] monomials)
        {
            Elements = new List<Monomial>();
            Elements.AddRange(monomials);
            SetToStandartForm();
            Degree = Elements.Max(x => x.Power) ?? 0;
        }

        private void SetToStandartForm()
        {
            Elements.Sort();
            Elements.Reverse();
            Elements = Elements
                .GroupBy(e => e.Power)
                .Select(m => new Monomial
                            (
                                m.Sum(s => s.Coefficient),
                                m.First().Power
                            )
                        ).ToList();
        }


        // IEnumarable implementation
        public IEnumerator GetEnumerator() => 
            ((IEnumerable)Elements).GetEnumerator();

        public object Clone()
        {
            Monomial[] monomials = null;
            Elements.CopyTo(monomials);
            return new Polynomial(monomials);
        }

        // Indexer implementation
        public Monomial this[int i]
        {
            get => Elements[i];
        }

        public static Polynomial operator -(Polynomial polynomial)
        {
            throw new NotImplementedException();
        }

        public static Polynomial operator +(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException("Polinomial should not be null");
            return polynomial;
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            throw new NotImplementedException();
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            throw new NotImplementedException();
        }

        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            throw new NotImplementedException();
        }
    }
}
