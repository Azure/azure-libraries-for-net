# e.g. .\PrepareFluentRelease.ps1 1.11.0
# 
[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$newVersion,
[Parameter(Mandatory=$False, Position=1)]
[String]$Folder
)

function IncrementAssemblyInfoVersion([string]$infoFolder)
{ 
    $assemblyInfos = Get-ChildItem -Path $infoFolder -Filter AssemblyInfo.cs -Recurse
    ForEach ($assemblyInfo in $assemblyInfos)
    {
        $content = Get-Content $assemblyInfo.FullName
        $content = $content -replace "\[assembly: AssemblyFileVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyFileVersion(`"$($newVersion).0`")]"
        Write-Output "Updating assembly version in $($assemblyInfo.FullName)"
        Set-Content -Path $assemblyInfo.FullName -Value $content -Encoding UTF8
    }   
}

function ReplaceVersion([string]$key, [string]$line)
{
    $matches = ([regex]::matches($line, "$key([\d\.]+)"))
    if($matches.Count -eq 1)
        {
            $packageVersion = $matches.Groups[1].Value
            $version = $packageVersion.Split(".")
            
            $cMajor = $Major
            $cMinor = $Minor
            $cPatch = $Patch
               
            if ($version[0] -eq 0)
            {
                if ($cMajor -eq $true)
                {
                    $version[1] = 1 + $version[1]
                    $version[2] = "0"
                }
                
                if ($cMinor -eq $true -or $cPatch -eq $true)
                {
                    $version[2] = 1 + $version[2]
                }
            }
            else
            {
                if ($cMajor -eq $true)
                {
                    $version[0] = 1 + $version[0]
                    $version[1] = "0"
                    $version[2] = "0"
                }
                
                if ($cMinor -eq $true)
                {
                    $version[1] = 1 + $version[1]
                    $version[2] = "0"
                }
                
                if ($cPatch -eq $true)
                {
                    $version[2] = 1 + $version[2]
                }    
            }
            
            $version = [String]::Join(".", $version)
            $line -Replace "$key$packageVersion", ($key.Replace("\","") + $newVersion)
        } else {
            $line
        }
}

function IncrementCsprojVersion([string]$FilePath)
{
    Write-Output "Updating File: $FilePath"   
    (Get-Content $FilePath) | 
    ForEach-Object {
        $temp = ReplaceVersion "\<Version\>" $_
        ReplaceVersion '\.Fluent\" Version=\"' $temp
    } | Set-Content -Path $FilePath -Encoding UTF8
}

if ([string]::IsNullOrWhiteSpace($Folder))
{
    $Folder = "$($PSScriptRoot)\..\src\ResourceManagement"
}

Write-Output "Updating projects in $($Folder)"

$modules = Get-ChildItem -Path $Folder -Filter *.csproj -Recurse
ForEach ($module in $modules)
{
    IncrementCsprojVersion($module.FullName)
}

IncrementAssemblyInfoVersion($Folder)