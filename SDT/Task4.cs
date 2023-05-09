namespace SDT
{
    public class Task4
    {
        public static int CountPairsSumEqualsTarget(int[] arr, int target)
        {
            return arr.Count(num => arr.Contains(target - num));
        }
    }
}

