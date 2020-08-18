# Using .NET Core

## Building
[https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build)
```
dotnet build 
   -c [release|debug] 
   -r [win10-x64|linux-x64] 
   {solution file}

e.g.
> dotnet build -c release -r win10-x64 AcmeSoda.sln
```
To run locally, look for the .exe in:
_E:\Source\Github\AcmeSoda\VendingMachine\UI\AcmeSodaConsoleApp\bin\Release\netcoreapp3.1\win10-x64_

For runtimes: [https://docs.microsoft.com/en-us/dotnet/core/rid-catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog)

## Publishing

[https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish)
```
dotnet publish 
   -c [release|debug] 
   -r [win10-x64|linux-x64]
   --self-contained [true|false]  
   {solution file}

e.g.
> dotnet publish -c release -r win10-x64 --self-contained true AcmeSoda.sln
```
To run locally, look for the .exe in the 

{\rtf1}