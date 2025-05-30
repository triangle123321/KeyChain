1. To start application

docker-compose up -d

2. check if running

docker-compose ps

3. create migration

dotnet ef migrations add InitialCreate

4. Apply migration

dotnet ef database update

5. Run the actual thing

dotnet run