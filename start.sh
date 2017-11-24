docker build -t glaacore .
docker run -d --read-only -p 80:5000 --name glaatest glaacore

