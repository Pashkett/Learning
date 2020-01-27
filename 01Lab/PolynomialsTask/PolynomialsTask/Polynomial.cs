using System.Collections;
using System.Collections.Generic;

namespace PolynomialsTask
{
    class Polynomial<Monomial> : IEnumerable
    {
        public List<Monomial> Elements { get; private set; }
        public Polynomial(params Monomial[] monomials)
        {
            Elements = new List<Monomial>();
            Elements.AddRange(monomials);
            SetToStandartForm();
        }

        private void SetToStandartForm()
        {
            Elements.Sort();
            Elements.Reverse();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Elements).GetEnumerator();
        }
    }
}
