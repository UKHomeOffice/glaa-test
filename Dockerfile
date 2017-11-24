FROM microsoft/dotnet:latest

WORKDIR /app

COPY ./GlaaCore/out . 

EXPOSE 5000

ENTRYPOINT ["dotnet", "GlaaCore.Web.dll"]

