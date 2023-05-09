namespace SDT
{
	public class Task7
	{
        public static string UintToIPv4(uint number)
        {
            return string.Format("{0}.{1}.{2}.{3}",
                (number >> 24) & 0xFF,
                (number >> 16) & 0xFF,
                (number >> 8) & 0xFF,
                number & 0xFF);
        }
    }
}

