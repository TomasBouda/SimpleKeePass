$moduleName = 'SimpleKeePass'

Copy-Item "$PSScriptRoot\src\Metadata\*" "$PSScriptRoot\output\$moduleName" -Recurse -Force

Get-ChildItem "$PSScriptRoot\output\$moduleName\bin\*" | Remove-Item -Recurse -Force
dotnet build "$PSScriptRoot\src" -o "$PSScriptRoot\output\$moduleName\bin" -c Release
Get-ChildItem "$PSScriptRoot\output\$moduleName\bin\*" -Include '*.pdb', '*.json' | Remove-Item -Force