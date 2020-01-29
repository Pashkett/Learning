using System;

namespace PolynomialsTask
{
    struct Monomial : IComparable<Monomial>, ICloneable
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
                          ? throw new InvalidCoefficientException("Coefficient should not be equal to 0.")
                          : coeff;
            power = pow < 0
                    ? throw new InvalidPowerException("Power should not be less than 0.")
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

        public object Clone() => 
            new Monomial(Power, Coefficient);
    }
}
