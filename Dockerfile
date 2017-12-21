FROM microsoft/dotnet:sdk as builder
WORKDIR /app
COPY . .
WORKDIR /app/GlaaCore.Domain
RUN dotnet restore
WORKDIR /app/GlaaCore
RUN dotnet restore && dotnet build && dotnet publish -c Release -o ./out

FROM microsoft/dotnet:latest
WORKDIR /app
COPY --from=builder /app/GlaaCore/out .
ENTRYPOINT ["dotnet", "GlaaCore.Web.dll"]

