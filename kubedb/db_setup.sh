usage()
{
	echo "usage: db_setup [[-U username -P password -DBUser dbuser -DBPass dbpass] | [-h]]"
}

echo $#

if [ "$#" != 4 ]; then
	usage
	exit 1
fi

username=
password=
dbuser=
dbpass=

while [ "$1" != "" ]; do
	case $1 in
		-U | --username )	shift
					username=$1
					;;
		-P | --password )	shift
					password=$1
					;;
		-DBUser | --dbuser )	shift
					dbuser=$1
					;;
		-DBPass | --dbpass )	shift
					dbpass=$1
					;;										
		-h | --help )		usage
					exit
					;;
		* )			usage
					exit 1
	esac
	shift
done

/opt/mssql-tools/bin/sqlcmd -S localhost -U $username -P $password -i db_setup.sql -v DB_USER = $dbuser DB_PASS = $dbpass
echo "Done"

