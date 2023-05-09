namespace SDT
{
	public class Task1
    {
        public static List<int> GetIntegersFromList(List<object> list)
        {
            return list.OfType<int>().ToList();
        }
    }
}
