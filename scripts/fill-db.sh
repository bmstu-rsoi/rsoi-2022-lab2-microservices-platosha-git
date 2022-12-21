docker ps -a

docker exec -i postgres psql -U program cars < test/cars.dump.sql
docker exec -i postgres psql -U program payments < test/payments.dump.sql
docker exec -i postgres psql -U program rentals < test/rentals.dump.sql