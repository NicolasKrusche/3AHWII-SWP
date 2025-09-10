using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Bitte zwei Brüche eingeben, z.B.: dotnet run \"2 3/8\" \"1 5/6\"");
            return;
        }

        Fraction f1 = ParseMixedFraction(args[0]);
        Fraction f2 = ParseMixedFraction(args[1]);

        Fraction sum = f1 + f2;

        // Ausgabe als gemischter Bruch
        Console.WriteLine(sum.ToMixedString());
    }

    // Zerlegen von Eingaben wie "2 3/8" oder "3/4"
    static Fraction ParseMixedFraction(string input)
    {
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 2)
        {
            int whole = int.Parse(parts[0]);
            Fraction frac = ParseSimpleFraction(parts[1]);
            return new Fraction(whole * frac.Denominator + frac.Numerator, frac.Denominator);
        }
        else if (parts.Length == 1 && parts[0].Contains("/"))
        {
            return ParseSimpleFraction(parts[0]);
        }
        else
        {
            // nur ganze Zahl
            return new Fraction(int.Parse(parts[0]), 1);
        }
    }

    static Fraction ParseSimpleFraction(string input)
    {
        string[] nums = input.Split('/');
        int num = int.Parse(nums[0]);
        int den = int.Parse(nums[1]);
        return new Fraction(num, den);
    }
}

// Klasse für Brüche
class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0) throw new DivideByZeroException("Nenner darf nicht 0 sein.");
        Numerator = numerator;
        Denominator = denominator;
        Simplify();
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int den = a.Denominator * b.Denominator;
        return new Fraction(num, den);
    }

    private void Simplify()
    {
        int g = Gcd(Math.Abs(Numerator), Denominator);
        Numerator /= g;
        Denominator /= g;
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    public string ToMixedString()
    {
        int whole = Numerator / Denominator;
        int rest = Math.Abs(Numerator % Denominator);

        if (rest == 0)
            return whole.ToString();
        else if (whole == 0)
            return $"{rest}/{Denominator}";
        else
            return $"{whole} {rest}/{Denominator}";
    }
}
