wd=$(pwd)

cd $wd/GlaaCore.Domain/
dotnet restore

cd $wd/GlaaCore/
dotnet restore
dotnet build

dotnet publish -c Release -o ./out

