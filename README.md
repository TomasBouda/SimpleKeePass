# SimpleKeePass

[![psgallery](https://img.shields.io/powershellgallery/v/SimpleKeePass.svg)](https://www.powershellgallery.com/packages/SimpleKeePass/) [![psgallery](https://img.shields.io/powershellgallery/dt/SimpleKeePass.svg)](https://www.powershellgallery.com/packages/SimpleKeePass/) [![Discord](https://img.shields.io/discord/382982965585510402?color=orange&label=discord)](https://discord.gg/GdqKvWQ66j) [![Support](https://img.shields.io/badge/%24-Support-blueviolet)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=GRARVRTVNEUHS)

SwissKnife is PowerShell module for quick and easy reading KeePass databases.

## Installation

To install SimpleKeePass, run following snippet from powershell:

```ps1
Install-Module SimpleKeePass
```

## Usage

### Get single KeePass entry

Get entry from database, with master password prompt:

```ps1
> Get-KeePassEntry -DatabasePath 'C:\Data\keepassdb.kdbx' -EntryTitle 'FTP'
Enter KeePass password: **********
```

or you can pass master password as secure string:

```ps1
> Get-KeePassEntry -DatabasePath 'C:\Data\keepassdb.kdbx' -EntryTitle 'FTP' -MasterPassword (ConvertTo-SecureString -AsPlainText 'mypassword')
```

Both returns KeePass entry:

```txt
Group      : default
Title      : FTP
Username   : someusername
Password   : System.Security.SecureString
Url        :
Notes      :
Credential : System.Management.Automation.PSCredential
```

### Get all KeePass entries

Get entries from database, with master password prompt:

```ps1
> Get-KeePassEntries -DatabasePath 'C:\Data\keepassdb.kdbx'
Enter KeePass password: **********
```

or you can pass master password as secure string:

```ps1
> Get-KeePassEntry -DatabasePath 'C:\Data\keepassdb.kdbx' -MasterPassword (ConvertTo-SecureString -AsPlainText 'mypassword')
```

Both returns collection of entries:

```txt
Group      : default
Title      : FTP
Username   : someusername
Password   : System.Security.SecureString
Url        :
Notes      :
Credential : System.Management.Automation.PSCredential

Group      : default
Title      : test
Username   : testusername
Password   : System.Security.SecureString
Url        :
Notes      :
Credential : System.Management.Automation.PSCredential

...
```

### Documentation

For more detailed documentation please check [wiki](https://github.com/TomasBouda/SimpleKeePass/wiki).

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

### Show your support

* :star: Star the SimpleKeePass repository. This is the least you can do to support this project.
* :thumbsup: Give us some feedback or suggest features on [discord](https://discord.gg/GdqKvWQ66j)
* :mag_right: Test SimpleKeePass and raise [issues](https://github.com/TomasBouda/SimpleKeePass/issues)
* Contribute :rocket: you can start with [good first issues](https://github.com/TomasBouda/PowerShell.SimpleKeePass/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22)

## Authors

* [**Tomáš Bouda**](http://tomasbouda.cz)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Credits

* Icon made by [Smashicons](https://smashicons.com/) from [www.flaticon.com](https://www.flaticon.com/).
