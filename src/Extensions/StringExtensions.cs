using System.Security;

namespace SimpleKeePass.Extensions
{
	public static class StringExtensions
	{
		public static SecureString ToSecureString(this string str)
		{
			var secureString = new SecureString();
			foreach (char ch in str)
			{
				secureString.AppendChar(ch);
			}

			return secureString;
		}
	}
}
