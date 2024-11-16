
namespace MoneyClass
{
    public class Money : IDisposable
    {
        private int gryvna, kopiyka;
        static int objCounter = 0;
        private int thisCount;
        static FileStream fs;

        static Money()
        {
            fs = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write);
        }

        private static void Log(string message)
        {
            StreamWriter logWriter = new StreamWriter(fs);
            logWriter.WriteLine(message);
            logWriter.Flush();
            logWriter.Close();
        }

        public void Dispose()
        {
            Log($"{thisCount} stream is closed");
            objCounter--;
            if (objCounter== 0)
            {
                Log($"All streams are closed");
                fs.Close();

            }
        }

        public int Gryvna
        {
            get => gryvna;
            set
            {
                if (value < 0)
                    throw new Exception("Field Gryvna cannot contain a negative value.");
                gryvna = value;
            }
        }

        public int Kopiyka
        {
            get => kopiyka;
            set
            {
                if (value < 0)
                    throw new Exception("Field Kopiyka cannot contain a negative value.");
                else if (value >= 100)
                {
                    Gryvna += value / 100;
                    kopiyka = value % 100;
                }
                else
                    kopiyka = value;
            }
        }

        public Money(int gryvna, int kopiyka)
        {
            Gryvna = gryvna;
            Kopiyka = kopiyka;
            thisCount = objCounter;

            Log($"{objCounter} has been created or modified: {this}");
            objCounter++;
        }


        public override string ToString()
        {
            return $"{Gryvna} gryvnas, {Kopiyka} kopiykas";
        }

        public static Money operator +(Money left, Money right)
        {
            Money result = new Money(left.Gryvna + right.Gryvna, left.Kopiyka + right.Kopiyka);
            Log($"Added: {left} + {right} = {result}");
            return result;
        }

        public static Money operator -(Money left, Money right)
        {
            int totalKopiyka = left.Kopiyka - right.Kopiyka;
            int totalGryvna = left.Gryvna - right.Gryvna;

            if (totalKopiyka < 0)
            {
                totalGryvna -= 1;
                totalKopiyka += 100;
            }

            if (totalGryvna < 0)
            {
                throw new Exception("Resulting money amount cannot be negative.");
            }

            Money result = new Money(totalGryvna, totalKopiyka);
            Log($"Subtracted: {left} - {right} = {result}");
            return result;
        }

        public static Money operator /(Money money, int value)
        {
            double temp = Math.Round((double)(((money.Gryvna * 100) + money.Kopiyka) / value), 2);
            Money result = new Money((int)(temp / 100), (int)(temp % 100));
            Log($"Divided: {money} / {value} = {result}");
            return result;
        }

        public static Money operator *(Money money, int value)
        {
            double temp = Math.Round((double)(((money.Gryvna * 100) + money.Kopiyka) * value), 2);
            Money result = new Money((int)(temp / 100), (int)(temp % 100));
            Log($"Multiplied: {money} * {value} = {result}");
            return result;
        }

        public static Money operator ++(Money money)
        {
            int temp = (money.Gryvna * 100) + money.Kopiyka + 1;
            Money result = new Money((int)(temp / 100), (int)(temp % 100));
            Log($"Incremented: {result}");
            return result;
        }

        public static Money operator --(Money money)
        {
            int temp = (money.Gryvna * 100) + money.Kopiyka - 1;
            Money result = new Money((int)(temp / 100), (int)(temp % 100));
            Log($"Decremented: {result}");
            return result;
        }

        public static bool operator >(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;
            bool result = tmp1 > tmp2;
            Log($"{left} > {right} = {result}");
            return result;
        }

        public static bool operator <(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;
            bool result = tmp1 < tmp2;
            Log($"{left} < {right} = {result}");
            return result;
        }

        public static bool operator >=(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;
            bool result = tmp1 >= tmp2;
            Log($"{left} >= {right} = {result}");
            return result;
        }

        public static bool operator <=(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;
            bool result = tmp1 <= tmp2;
            Log($"{left} <= {right} = {result}");
            return result;
        }

        public static bool operator ==(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;
            bool result = tmp1 == tmp2;
            Log($"{left} == {right} = {result}");
            return result;
        }

        public static bool operator !=(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;
            bool result = tmp1 != tmp2;
            Log($"{left} != {right} = {result}");
            return result;
        }
    }
}

