# Ambev Developer Evaluation

Before running the project, make sure dotnet-ef is installed. If not, run the following command in the Visual Studio 2022 terminal:

```
dotnet tool install --global dotnet-ef
```

Then, run the following command in the terminal to apply the migrations to the PostgreSQL database:

```
dotnet ef database update --project ../Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation.ORM.csproj --startup-project ../Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj
```
