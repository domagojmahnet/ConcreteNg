cd in api project (ConcreteNg)
dotnet ef migrations add Initial --project ..\ConcreteNg.Data\ConcreteNg.Data.csproj --context DataContext - add migration
dotnet ef database update

repository and unit of work design pattern
https://dev.to/1001binary/implement-repository-base-and-unit-of-work-in-c-2ncg