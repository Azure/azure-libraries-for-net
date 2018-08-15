# Prepare for Azure Management Libraries for .NET 1.14 #

Steps to migrate code that uses Azure Management Libraries for .NET from 1.13 to 1.14 ...

> If this note missed any breaking changes, please open a pull request.


V1.14 is backwards compatible with V1.10 in the APIs intended for public use that reached the general availability (stable) stage in V1.x with a few exceptions in the SQL management library (though these changes will have minimal impact on the developer). 

Some breaking changes were introduced in APIs that were still in Beta in V1.13, as indicated by their inheritance from the `IBeta` interface.
