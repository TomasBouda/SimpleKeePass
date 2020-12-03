using System.Linq;
using System.Management.Automation;
using System.Security;

namespace SimpleKeePass.CmdLets
{
	[Cmdlet(VerbsCommon.Get, "KeePassEntry")]
	[OutputType(typeof(KeePassEntry))]
	public class GetKeePassEntryCmdletCommand : PSCmdlet
	{
		[Parameter(
			Mandatory = true,
			Position = 0)]
		public string DatabasePath { get; set; }

		[Parameter(Mandatory = true, Position = 1)]
		public string EntryTitle { get; set; }

		[Parameter(Mandatory = false, Position = 2)]
		public SecureString MasterPassword { get; set; }

		[Parameter(Mandatory = false)]
		public string PasswordMessagePrompt { get; set; } = "Enter KeePass password: ";

		protected override void BeginProcessing()
		{
			if (MasterPassword == null)
			{
				Host.UI.Write(PasswordMessagePrompt);
				MasterPassword = Host.UI.ReadLineAsSecureString();
			}
		}

		protected override void ProcessRecord()
		{
			using (var db = new KeePassDb(DatabasePath, MasterPassword))
			{
				WriteObject(db.GetEntries().FirstOrDefault(d => d.Title == EntryTitle));
			}
		}

		protected override void EndProcessing()
		{
		}
	}
}
