namespace SDT
{
	public class Task3
	{
        public static int DigitalRoot(int n)
        {
            if (n < 10)
            {
                return n;
            }

            return DigitalRoot(CalcSum(n));
        }

        private static int CalcSum(int n)
        {
            int sum = 0;

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }
    }
}

