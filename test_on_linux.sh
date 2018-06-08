#!/bin/sh

set -e
base=`dirname {BASH_SOURCE[0]}`
rootdir="$( cd "$base" && pwd )"
netstd14="netstandard1.4"
netstd16="netstandard1.6"
netcore11='netcoreapp1.1'
ubuntu1404="ubuntu.14.04-x64"
nugetOrgSource="https://api.nuget.org/v3/index.json"

dotnet --info

getBuildTools() {
    copyFromRootDir="https://raw.githubusercontent.com/Azure/azure-sdk-for-net/NetSdkBuild"
    printf "Updating Build tools .....\n"
    
    if [ ! -d ./tools/SdkBuildTools ]; then
        mkdir ./tools/SdkBuildTools
    fi
    if [ ! -d ./tools/SdkBuildTools/targets ]; then
        mkdir ./tools/SdkBuildTools/targets
    fi

    if [ ! -d ./tools/SdkBuildTools/tasks ]; then
        mkdir ./tools/SdkBuildTools/tasks
    fi

    if [ ! -d ./tools/SdkBuildTools/tasks/net46 ]; then
        mkdir ./tools/SdkBuildTools/tasks/net46
    fi

    curl -s $copyFromRootDir/tools/BuildAssets/targets/additional.targets > ./tools/SdkBuildTools/targets/additional.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/common.Build.props > ./tools/SdkBuildTools/targets/common.Build.props
    curl -s $copyFromRootDir/tools/BuildAssets/targets/common.NugetPackage.props > ./tools/SdkBuildTools/targets/common.NugetPackage.props
    curl -s $copyFromRootDir/tools/BuildAssets/targets/common.targets > ./tools/SdkBuildTools/targets/common.targets
    curl -s $copyFromRootDir/tools/BuildAssets/targets/signing.targets > ./tools/SdkBuildTools/targets/signing.targets
	curl -s $copyFromRootDir/tools/BuildAssets/targets/ideCmd.targets > ./tools/SdkBuildTools/targets/ideCmd.targets
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/common.tasks > ./tools/SdkBuildTools/tasks/common.tasks
    #curl $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Azure.Build.BootstrapTasks.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Build.BootstrapTasks.dll
    #curl $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Azure.Build.BootstrapTasks.runtimeconfig.dev.json > ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Build.BootstrapTasks.runtimeconfig.dev.json
    #curl $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Azure.Build.BootstrapTasks.runtimeconfig.json > ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Build.BootstrapTasks.runtimeconfig.json
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.dll
    #curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.runtimeconfig.dev.json > ./tools/SdkBuildTools/tasks/net46/Microsoft.Azure.Sdk.Build.Tasks.runtimeconfig.dev.json
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.Framework.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.Framework.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.Tasks.Core.dll > ./tools/SdkBuildTools/tasks/net46/Microsoft.Build.Tasks.Core.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/Microsoft.Build.Utilities.Core.dll > ./tools/SdkBuildTools/tasks/net46Microsoft.Build.Utilities.Core.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Collections.Immutable.dll > ./tools/SdkBuildTools/tasks/net46/System.Collections.Immutable.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Reflection.Metadata.dll > ./tools/SdkBuildTools/tasks/net46/System.Reflection.Metadata.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Runtime.InteropServices.RuntimeInformation.dll > ./tools/SdkBuildTools/tasks/net46/System.Runtime.InteropServices.RuntimeInformation.dll
    curl -s $copyFromRootDir/tools/BuildAssets/tasks/net46/System.Threading.Thread.dll > ./tools/SdkBuildTools/tasks/net46/System.Threading.Thread.dll
    
}


getBuildTools

echo Restoring... $ubuntu1404
dotnet restore Fluent.Tests.sln -r $ubuntu1404
echo Building... $netcore11

dotnet build src/ResourceManagement/ResourceManager/Microsoft.Azure.Management.ResourceManager.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Storage/Microsoft.Azure.Management.Storage.Fluent.csproj -f $netstd14 

dotnet build src/ResourceManagement/Graph.RBAC/Microsoft.Azure.Management.Graph.RBAC.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Network/Microsoft.Azure.Management.Network.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/AppService/Microsoft.Azure.Management.AppService.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Batch/Microsoft.Azure.Management.Batch.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Cdn/Microsoft.Azure.Management.Cdn.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Compute/Microsoft.Azure.Management.Compute.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/ContainerRegistry/Microsoft.Azure.Management.ContainerRegistry.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/Dns/Microsoft.Azure.Management.Dns.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/CosmosDB/Microsoft.Azure.Management.CosmosDB.Fluent.csproj -f $netstd14
dotnet build src/ResourceManagement/KeyVault/Microsoft.Azure.Management.KeyVault.Fluent.csproj -f $netstd14
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
dotnet build Tests/Fluent.Tests/Fluent.Tests.csproj -f $netcore11
dotnet build Tests/Samples.Tests/Samples.Tests.csproj -f $netcore11

echo Running Samples Tests
cd $rootdir/Tests/Samples.Tests
dotnet test Samples.Tests.csproj -f $netcore11

echo Running Fluent Tests
cd $rootdir/Tests/Fluent.Tests
dotnet test Fluent.Tests.csproj -f $netcore11
