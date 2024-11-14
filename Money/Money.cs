namespace MoneyClass
{
    public class Money
    {
        private int gryvna, kopiyka;

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
        }

        public override string ToString()
        {
            return $"{Gryvna} gryvnas, {Kopiyka} kopiykas";
        }

        public static Money operator +(Money left, Money right) 
        {
            return new Money(left.Gryvna+right.Gryvna, left.Kopiyka+right.Kopiyka);
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

            return new Money(totalGryvna, totalKopiyka);
        }

        public static Money operator /(Money money, int value)
        {
            double temp = Math.Round((double)(((money.Gryvna * 100) + money.Kopiyka) / value), 2);
            money.Gryvna = (int)(temp / 100);
            money.Kopiyka = (int)(temp % 100);
            return money;
        }

        public static Money operator *(Money money, int value)
        {
            double temp = Math.Round((double)(((money.Gryvna * 100) + money.Kopiyka) * value), 2);
            money.Gryvna = (int)(temp / 100);
            money.Kopiyka = (int)(temp % 100);
            return money;
        }

        public static Money operator *(int value,Money money)
        {
            double temp = Math.Round((double)(((money.Gryvna * 100) + money.Kopiyka) * value), 2);
            money.Gryvna = (int)(temp / 100);
            money.Kopiyka = (int)(temp % 100);
            return money;
        }

        public static Money operator ++(Money money)
        {
            int temp = (money.Gryvna * 100) + money.Kopiyka + 1;
            money.Gryvna = (int)(temp / 100);
            money.Kopiyka = (int)(temp % 100);
            return money;
        }

        public static Money operator-- (Money money)
        {
            int temp = (money.Gryvna * 100) + money.Kopiyka -1;
            money.Gryvna = (int)(temp / 100);
            money.Kopiyka = (int)(temp % 100);
            return money;
        }

        public static bool operator >(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna *100 + right.Kopiyka;

            return tmp1 > tmp2;
        }

        public static bool operator <(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;

            return tmp1 < tmp2;
        }

        public static bool operator >=(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;

            return tmp1 >= tmp2;
        }


        public static bool operator <=(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;

            return tmp1 <= tmp2;
        }


        public static bool operator ==(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;

            return tmp1 == tmp2;
        }

        public static bool operator !=(Money left, Money right)
        {
            int tmp1 = left.Gryvna * 100 + left.Kopiyka;
            int tmp2 = right.Gryvna * 100 + right.Kopiyka;

            return tmp1 != tmp2;
        }
    }
}
