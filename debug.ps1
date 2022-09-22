Import-Module "$PSScriptRoot\src\bin\Debug\netstandard2.0\SimpleKeePass.dll"
Get-KeePassEntries -DatabasePath 'C:\Data\WORK\Lineup\AdPointTools\Update-AdPointAuto\Resources\db.kdbx'

pause