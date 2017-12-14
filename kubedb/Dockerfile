FROM microsoft/mssql-server-linux:latest

WORKDIR /app

COPY ./db_setup.sql . 

COPY ./db_setup.sh .

RUN chmod +x /app/db_setup.sh

