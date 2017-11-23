docker build -t glaacore .
docker run -d -p 80:5000 --name glaatest glaacore

