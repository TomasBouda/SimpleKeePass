using System.Management.Automation;
using System.Security;
using KeePassLib;
using SimpleKeePass.Extensions;

namespace SimpleKeePass
{
	public class KeePassEntry
	{
		public string Group { get; set; }
		public string Title { get; set; }
		public string Username { get; set; }
		public SecureString Password { get; set; }
		public string Url { get; set; }
		public string Notes { get; set; }
		public PSCredential Credential { get; set; }

		public KeePassEntry(PwEntry originalEntry)
		{
			Group = originalEntry.ParentGroup.Name;
			Title = originalEntry.Strings.ReadSafe("Title");
			Username = originalEntry.Strings.ReadSafe("UserName");
			Password = originalEntry.Strings.ReadSafe("Password").ToSecureString();
			Url = originalEntry.Strings.ReadSafe("URL");
			Notes = originalEntry.Strings.ReadSafe("Notes");
			Credential = new PSCredential(Title, Password);
		}
	}
}
