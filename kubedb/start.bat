docker build -t glaadb .
docker run -d  -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=youneedalicencetobepartoftheglaa(!)' -e 'MSSQL_PID=Express' -p 1433:1433 --name glaa-database glaadb