#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd14="netstandard1.4"
netstd16="netstandard1.6"
#netcore11='netcoreapp1.1'
netcore20='netcoreapp2.0'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"

dotnet --info

getBuildTools() {
    copyFromRootDir="."
    printf "Updating Build tools .....\n"
    
    if [ ! -d ./tools/SdkBuildTools ]; then
        mkdir ./tools/SdkBuildTools
    fi
    if [ ! -d ./tools/SdkBuildTools/targets ]; then
        mkdir ./tools/SdkBuildTools/targets
    fi

    if [ ! -d ./tools/SdkBuildTools/targets/core ]; then
        mkdir ./tools/SdkBuildTools/targets/core
    fi

    if [ ! -d ./tools/SdkBuildTools/tasks ]; then
        mkdir ./tools/SdkBuildTools/tasks
    fi

    if [ ! -d ./tools/SdkBuildTools/tasks/net46 ]; then
        mkdir ./tools/SdkBuildTools/tasks/net46
    fi

    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/additional.targets ./tools/SdkBuildTools/targets/additional.targets
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/common.Build.props ./tools/SdkBuildTools/targets/common.Build.props
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/common.NugetPackage.props ./tools/SdkBuildTools/targets/common.NugetPackage.props
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/common.targets ./tools/SdkBuildTools/targets/common.targets
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/signing.targets ./tools/SdkBuildTools/targets/signing.targets
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/ideCmd.targets ./tools/SdkBuildTools/targets/ideCmd.targets
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/utility.targets ./tools/SdkBuildTools/targets/utility.targets
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/core/_AzSdk.props ./tools/SdkBuildTools/targets/core/_AzSdk.props
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/core/_build.proj ./tools/SdkBuildTools/targets/core/_build.proj
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/core/_Directory.Build.props ./tools/SdkBuildTools/targets/core/_Directory.Build.props
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/core/_Directory.Build.targets ./tools/SdkBuildTools/targets/core/_Directory.Build.targets
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/targets/core/_test.props ./tools/SdkBuildTools/targets/core/_test.props
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/common.tasks ./tools/SdkBuildTools/tasks/common.tasks
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.dll ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/Microsoft.Build.dll ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/Microsoft.Build.Framework.dll ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.Framework.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/Microsoft.Build.Tasks.Core.dll ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.Tasks.Core.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/Microsoft.Build.Utilities.Core.dll ./tools/SdkBuildTools/tasks/net46Microsoft.Build.Utilities.Core.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/System.Collections.Immutable.dll ./tools/SdkBuildTools/tasks/net46/System.Collections.Immutable.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/System.Reflection.Metadata.dll ./tools/SdkBuildTools/tasks/net46/System.Reflection.Metadata.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/System.Runtime.InteropServices.RuntimeInformation.dll ./tools/SdkBuildTools/tasks/net46/System.Runtime.InteropServices.RuntimeInformation.dll
    cp $copyFromRootDir/tools/BuildToolsForSdk/BuildAssets/tasks/net46/System.Threading.Thread.dll ./tools/SdkBuildTools/tasks/net46/System.Threading.Thread.dll
}



getBuildTools
echo Restoring... $ubuntu1404
dotnet restore Fluent.Tests.sln -r $ubuntu1404
echo Building... $netcore20

dotnet build src/ResourceManagement/ResourceManager/Microsoft.Azure.Management.ResourceManager.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Storage/Microsoft.Azure.Management.Storage.Fluent.csproj -f $netstd14 

dotnet build src/ResourceManagement/Graph.RBAC/Microsoft.Azure.Management.Graph.RBAC.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Network/Microsoft.Azure.Management.Network.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/AppService/Microsoft.Azure.Management.AppService.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Cdn/Microsoft.Azure.Management.Cdn.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Compute/Microsoft.Azure.Management.Compute.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/ContainerRegistry/Microsoft.Azure.Management.ContainerRegistry.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Dns/Microsoft.Azure.Management.Dns.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/CosmosDB/Microsoft.Azure.Management.CosmosDB.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/KeyVault/Microsoft.Azure.Management.KeyVault.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/PrivateDns/Microsoft.Azure.Management.PrivateDns.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/RedisCache/Microsoft.Azure.Management.Redis.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Search/Microsoft.Azure.Management.Search.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/ServiceBus/Microsoft.Azure.Management.ServiceBus.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Sql/Microsoft.Azure.Management.Sql.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/TrafficManager/Microsoft.Azure.Management.TrafficManager.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/ContainerService/Microsoft.Azure.Management.ContainerService.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/ContainerInstance/Microsoft.Azure.Management.ContainerInstance.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Locks/Microsoft.Azure.Management.Locks.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Azure.Fluent/Microsoft.Azure.Management.Fluent.csproj -f $netstd14
dotnet build Samples/Samples.csproj  -f $netstd16
dotnet build Tests/Fluent.Tests/Fluent.Tests.csproj -f $netcore20
dotnet build Tests/Samples.Tests/Samples.Tests.csproj -f $netcore20

echo Running Fluent Tests
cd $rootdir/Tests/Fluent.Tests
dotnet test Fluent.Tests.csproj -f $netcore20

echo Running Samples Tests
cd $rootdir/Tests/Samples.Tests
dotnet test Samples.Tests.csproj -f $netcore20

