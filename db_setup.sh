usage()
{
	echo "usage: db_setup [[-U username -P password] | [-h]]"
}

echo $#

if [ "$#" != 4 ]; then
	usage
	exit 1
fi

username=
password=

while [ "$1" != "" ]; do
	case $1 in
		-U | --username )	shift
					username=$1
					;;
		-P | --password )	shift
					password=$1
					;;
		-h | --help )		usage
					exit
					;;
		* )			usage
					exit 1
	esac
	shift
done

sqlcmd -S glaatest.c5r6wqn6fr00.eu-west-2.rds.amazonaws.com -U $username -P $password -i db_setup.sql
echo "Done"

