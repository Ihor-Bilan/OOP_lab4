using System;
using System.Numerics;

public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
{
    public BigInteger Numerator { get; set; }
    public BigInteger Denominator { get; set; }

    // Конструктори
    public MyFrac(BigInteger numerator, BigInteger denominator)
    {
        if (denominator == 0)
        {
            throw new DivideByZeroException("Denominator cannot be zero.");
        }

        Numerator = numerator;
        Denominator = denominator;
        Simplify();
    }

    public MyFrac(int numerator, int denominator)
        : this(new BigInteger(numerator), new BigInteger(denominator))
    {
    }

    private void Simplify()
    {
        BigInteger gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    public MyFrac Add(MyFrac b)
    {
        return new MyFrac(
            this.Numerator * b.Denominator + b.Numerator * this.Denominator,
            this.Denominator * b.Denominator);
    }

    public MyFrac Subtract(MyFrac b)
    {
        return new MyFrac(
            this.Numerator * b.Denominator - b.Numerator * this.Denominator,
            this.Denominator * b.Denominator);
    }

    public MyFrac Multiply(MyFrac b)
    {
        return new MyFrac(
            this.Numerator * b.Numerator,
            this.Denominator * b.Denominator);
    }

    public MyFrac Divide(MyFrac b)
    {
        if (b.Numerator == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        return new MyFrac(
            this.Numerator * b.Denominator,
            this.Denominator * b.Numerator);
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    // Реалізація інтерфейсу IComparable<MyFrac>
    public int CompareTo(MyFrac other)
    {
        if (other == null) return 1;
        BigInteger lhs = this.Numerator * other.Denominator;
        BigInteger rhs = other.Numerator * this.Denominator;
        return lhs.CompareTo(rhs);
    }
}
