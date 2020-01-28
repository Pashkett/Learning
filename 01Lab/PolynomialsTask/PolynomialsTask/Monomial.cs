using System;

namespace PolynomialsTask
{
    struct Monomial : IComparable<Monomial>
    {
        private int coefficient;
        private int power;

        public int Coefficient
        {
            get => coefficient;
            set => coefficient = value;
        }
        public int Power
        {
            get => power;
            set => power = value;
        }

        public Monomial(int coeff, int pow)
        {
            coefficient = coeff == 0
                          ? throw new Exception() //TODO
                          : coeff;
            power = pow < 0
                    ? throw new Exception() //TODO
                    : pow;
        }

        public override string ToString()
        {
            if (Coefficient < 0)
                return $"{Coefficient.ToString()}*x^{Power.ToString()}";
            else
                return $" + {Coefficient.ToString()}*x^{Power.ToString()}";
        }

        public int CompareTo(Monomial other) => 
            (this.Power).CompareTo((int)(other.Power));
    }
}
