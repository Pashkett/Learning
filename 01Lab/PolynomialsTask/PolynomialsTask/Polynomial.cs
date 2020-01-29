using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PolynomialsTask
{
    partial class Polynomial : IEnumerable, ICloneable
    {
        public List<Monomial> Elements { get; private set; }
        public int Degree { get; private set; }

        public Polynomial() => 
            Elements = new List<Monomial>();

        public Polynomial(params Monomial[] monomials) : this()
        {
            Elements = new List<Monomial>();
            Elements.AddRange(monomials);
            SetToStandartForm();
            Degree = Elements.Max(x => x.Power);
        }

        private void SetToStandartForm()
        {
            Elements = new List<Monomial>(from e in Elements 
                                           orderby e.Power descending
                                          select e);
            AddPolynomialElements();
        }

        private void AddPolynomialElements()
        {
            Elements = Elements
                        .GroupBy(e => e.Power)
                        .Select(m => new Monomial
                                        (
                                            m.Sum(s => s.Coefficient),
                                            m.First().Power
                                        )
                                )
                        .Where(l => l.Coefficient != 0)
                        .ToList();
        }

        public IEnumerator GetEnumerator() => 
            ((IEnumerable)Elements).GetEnumerator();

        public object Clone()
        {
            Monomial[] monomials = null;
            Elements.CopyTo(monomials);

            return new Polynomial(monomials);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (var mon in Elements)
            {
                result.Append(mon.ToString());
            }

            return result.ToString();
        }

        public Monomial this[int i]
        {
            get
            {
                try
                {
                    return Elements[i];
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
