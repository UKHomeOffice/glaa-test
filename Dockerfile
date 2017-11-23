FROM microsoft/dotnet:latest

COPY . /app
WORKDIR /app/GlaaCore
RUN ["dotnet", "restore"]
# Ideally we want to do dotnet build -c Release -o out and run from the dll for prod

EXPOSE 5000

ENTRYPOINT ["dotnet", "run"]

