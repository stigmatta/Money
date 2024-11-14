using MoneyClass;

Money m1 = new Money(13, 99);
Money m2 = new Money(12, 60);
Console.WriteLine(m1);
Console.WriteLine(m2);


Money m3 = m1 - m2;
Console.WriteLine(m3);

m2 = m2 / 5;
Console.WriteLine(m2);

m2 = m2 * 5;
Console.WriteLine(m2);

m1++;
Console.WriteLine(m1);

m1--;
Console.WriteLine(m1);



Console.WriteLine(m1>m2);
Console.WriteLine(m1 < m2);

Money m4 = new Money(0, 0);
m4--;
Console.WriteLine(m4);

