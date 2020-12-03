using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using KeePassLib.Keys;
using KeePassLib.Serialization;

namespace SimpleKeePass
{
	public class KeePassDb : IDisposable
	{
		private KeePassLib.PwDatabase _db;

		public KeePassDb(string databasePath, SecureString masterPassword)
		{
			var ioConnInfo = new IOConnectionInfo { Path = databasePath };
			var compKey = new CompositeKey();

			compKey.AddUserKey(new KcpPassword(SecureStringToString(masterPassword)));

			_db = new KeePassLib.PwDatabase();
			_db.Open(ioConnInfo, compKey, null);
		}


		public IEnumerable<KeePassEntry> GetEntries()
		{
			return _db.RootGroup.GetEntries(true).Select(entry => new KeePassEntry(entry));
		}

		private string SecureStringToString(SecureString value)
		{
			IntPtr valuePtr = IntPtr.Zero;
			try
			{
				valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
				return Marshal.PtrToStringUni(valuePtr);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
			}
		}

		public void Dispose()
		{
			_db.Close();
		}
	}
}
