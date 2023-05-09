namespace SDT
{
	public class Task2
	{
        public static char FirstNonRepeatingLetter(string str) {
			string strLower = str.ToLower();
		
			char ch = strLower.FirstOrDefault(
		        ch => strLower.IndexOf(ch) == strLower.LastIndexOf(ch)
		    );

			return str[strLower.IndexOf(ch)];
        }
    }
}

