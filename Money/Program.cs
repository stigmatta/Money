using MoneyClass;

class Program
{
    static void Main()
    {
        Money m1 = new Money(13, 99);
        Money m2 = new Money(12, 60);
        Console.WriteLine(m1);
        Console.WriteLine(m2);

        Money m3 = m1 - m2;
        Console.WriteLine(m3);

        Money m4 = m2 / 5;
        Console.WriteLine(m4);

        Money m5 = m2 * 5;
        Console.WriteLine(m5);

        m1++;
        Console.WriteLine(m1);

        m1--;
        Console.WriteLine(m1);

        Console.WriteLine(m1 > m2);
        Console.WriteLine(m1 < m2);

        m1.Dispose();
        m2.Dispose();
        m3.Dispose();
        m4.Dispose();
        m5.Dispose();

    }
}
