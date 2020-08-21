dotnet build -c debug -r win10-x64 AcmeSoda.sln
dotnet publish -c debug -r win10-x64 --self-contained true /p:PublishSingleFile=true /p:PublishTrimmed=true AcmeSoda.sln

dotnet build -c debug -r linux-x64 AcmeSoda.sln
dotnet publish -c debug -r linux-x64 --self-contained true /p:PublishSingleFile=true /p:PublishTrimmed=true AcmeSoda.sln

