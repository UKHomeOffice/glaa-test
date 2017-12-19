/opt/mssql-tools/bin/sqlcmd -S localhost -U "sa" -P $SA_PASSWORD -i db_setup.sql -v DB_USER = $DB_USER DB_PASS = $DB_PASS
echo "Done"