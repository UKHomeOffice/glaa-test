cd ./GlaaCore.Domain/
dotnet restore

cd ./../GlaaCore/
dotnet restore
dotnet build

dotnet publish -c Release -o ./out 