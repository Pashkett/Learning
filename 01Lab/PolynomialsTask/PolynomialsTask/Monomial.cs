using System;
using System.Diagnostics.CodeAnalysis;

namespace PolynomialsTask
{
    class Monomial : IComparable<Monomial>
    {
        // Baked fields for properties
        private int coefficient;
        private int power;

        // Properties
        public int? Coefficient
        {
            get => coefficient;
            set
            {
                if (value == 0)
                    throw new ArgumentException("Coefficient should be grater than or less than zero");
                if (value == null)
                    coefficient = 1;
                else
                    coefficient = (int)value;
            }
        }
        public int? Power 
        {
            get => power;
            set
            {
                if (value == null)
                    power = 0;
                if (value < 0)
                    throw new ArgumentException("Power should be greater than or equal to zero");
                else
                    power = (int)value;
            }
            
        }

        // Constructor
        public Monomial(int? coefficient, int? power)
        {
            Coefficient = coefficient;
            Power = power;
        }

        // Overridden methods 
        public override string ToString()
        {
            if (Coefficient < 0)
                return $"{Coefficient.ToString()}*x^{Power.ToString()}";
            else
                return $" + {Coefficient.ToString()}*x^{Power.ToString()}";
        }

        //IComparable implementation
        public int CompareTo([AllowNull] Monomial other)
        {
            if (other == null)
                return 1;
            else
                return ((int)(this.Power)).CompareTo(((int)(other.Power)));
        }
    }
}
