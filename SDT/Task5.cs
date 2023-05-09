namespace SDT
{
	public class Task5
	{
		public const string InputStringCannotBeNullOrEmpty = "Input string cannot be null or empty.";

		public static string UpperFriendsWithSort(string friends) {
			if (string.IsNullOrEmpty(friends)) {
				throw new ArgumentException(InputStringCannotBeNullOrEmpty);
            }

            List<string> sortedNames = friends.
		        Split(';').
		        Select(name => {
                    string[] parts = name.Split(':');
                    return $"({parts[1]}, {parts[0]})".ToUpper();
                }).
				OrderBy(name => name).
				ToList();

            return string.Join(" ", sortedNames);
        }
	}
}

