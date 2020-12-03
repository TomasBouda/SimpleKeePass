using System.Management.Automation;
using System.Security;

namespace SimpleKeePass.CmdLets
{
	[Cmdlet(VerbsCommon.Get, "KeePassEntries")]
	[OutputType(typeof(KeePassEntry))]
	public class GetKeePassEntriesCmdletCommand : PSCmdlet
	{
		[Parameter(
			Mandatory = true,
			Position = 0)]
		public string DatabasePath { get; set; }

		[Parameter(Mandatory = false, Position = 1)]
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
				WriteObject(db.GetEntries());
			}
		}

		protected override void EndProcessing()
		{
		}
	}
}
