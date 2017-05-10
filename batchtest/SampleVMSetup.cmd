cmd /c powershell (New-Object Net.WebClient).DownloadFile('http://dist.nuget.org/win-x86-commandline/latest/nuget.exe', 'nuget.exe')
cmd /c nuget.exe install xunit.runner.console -Source nuget.org -Version 2.1.0 -OutputDirectory %AZ_BATCH_NODE_SHARED_DIR%
