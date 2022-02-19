cd in api project (ConcreteNg)
dotnet ef migrations add Initial --project ..\ConcreteNg.Data\ConcreteNg.Data.csproj --context DataContext - add migration
dotnet ef database update