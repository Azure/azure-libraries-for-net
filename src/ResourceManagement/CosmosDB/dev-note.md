### 1.27.0

Issue: [Long running operation failed with status 'Unauthorized' error with Microsoft.Azure.Management.CosmosDB.Fluent](https://github.com/azure/azure-libraries-for-net/issues/811)

Solution:
Temporary mitigate by code generated via a customized [autorest.csharp](https://github.com/weidongxu-microsoft/autorest.csharp/commit/a748ed50238f31b1c9d23172c967063b44f22f7a) (with IgnoreRequestUriRedirect=true).

Result:
Modified [Generated/DatabaseAccountsOperations.cs](https://github.com/Azure/azure-libraries-for-net/commit/1ae6916f215a82d73357d76df20b66b9b4cf80bb)

Note:
When re-generate code for CosmosDB, please double check whether the root cause is solved and whether the fix is integrated into [autorest.csharp](https://github.com/Azure/autorest.csharp/tree/newgen)
