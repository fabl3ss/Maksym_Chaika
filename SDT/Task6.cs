namespace SDT
{
    public class Task6
    {
        public static int NextBigger(int num)
        {
            char[] digits = num.ToString().ToCharArray();
            int i = digits.Length - 2;

            while (i >= 0 && digits[i] >= digits[i + 1])
            {
                i--;
            }

            if (i < 0)
            {
                return -1;
            }

            Array.Sort(digits, i + 1, digits.Length - i - 1);

            for (int j = i + 1; j < digits.Length; j++)
            {
                if (digits[j] > digits[i])
                {
                    (digits[i], digits[j]) = (digits[j], digits[i]);
                    break;
                }
            }

            return int.Parse(new string(digits));;
        }
    }
}

