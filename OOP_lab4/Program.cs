using System;

public class Program
{
    static void testAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b); // ab
        curr = curr.Add(curr); // ab + ab = 2ab
        Console.WriteLine("2*a*b = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===\n");
    }

    static void testSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a-b)(a+b)=a^2-b^2 with a = " + a + ", b = " + b + " ===");
        T aMinusB = a.Subtract(b);
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a - b) = " + aMinusB);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a-b)(a+b) = " + aMinusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T aSquared = a.Multiply(a);
        Console.WriteLine("a^2 = " + aSquared);
        T bSquared = b.Multiply(b);
        Console.WriteLine("b^2 = " + bSquared);
        T difference = aSquared.Subtract(bSquared);
        Console.WriteLine("a^2 - b^2 = " + difference);

        // Перевірка ділення
        try
        {
            T division = difference.Divide(aPlusB);
            Console.WriteLine("(a^2 - b^2) / (a + b) = " + division);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Division by zero detected: " + ex.Message);
        }

        Console.WriteLine("=== Finishing testing (a-b)(a+b)=a^2-b^2 with a = " + a + ", b = " + b + " ===\n");
    }


    static void Main(string[] args)
    {
        testAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        testAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
        testSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
        testSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));

        // Сортування масиву MyFrac
        var fractions = new MyFrac[]
        {
        new MyFrac(1, 2),
        new MyFrac(3, 4),
        new MyFrac(1, 3),
        new MyFrac(2, 5)
        };
        Array.Sort(fractions);
        Console.WriteLine("Sorted fractions:");
        foreach (var frac in fractions)
        {
            Console.WriteLine(frac);
        }

        Console.ReadKey();
    }
}
