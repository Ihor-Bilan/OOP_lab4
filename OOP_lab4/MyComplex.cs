public class MyComplex : IMyNumber<MyComplex>
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    // Конструктор
    public MyComplex(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public MyComplex Add(MyComplex that)
    {
        return new MyComplex(this.Real + that.Real, this.Imaginary + that.Imaginary);
    }

    public MyComplex Subtract(MyComplex that)
    {
        return new MyComplex(this.Real - that.Real, this.Imaginary - that.Imaginary);
    }

    public MyComplex Multiply(MyComplex that)
    {
        double real = Real * that.Real - Imaginary * that.Imaginary;
        double imaginary = Real * that.Imaginary + Imaginary * that.Real;
        return new MyComplex(real, imaginary);
    }

    public MyComplex Divide(MyComplex that)
    {
        if (that.Real == 0 && that.Imaginary == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }

        double denom = that.Real * that.Real + that.Imaginary * that.Imaginary;
        double real = (Real * that.Real + Imaginary * that.Imaginary) / denom;
        double imaginary = (Imaginary * that.Real - Real * that.Imaginary) / denom;
        return new MyComplex(real, imaginary);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}
