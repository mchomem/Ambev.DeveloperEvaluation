# Ambev Developer Evaluation

Before running the project, make sure dotnet-ef is installed. If not, run the following command in the Visual Studio 2022 terminal:

```
dotnet tool install --global dotnet-ef
```

Then, run the following command in the terminal to apply the migrations to the PostgreSQL database.
You need to be at the root of the directory (in this case backend) where the "src" directory is, to be able to apply the command:

```
dotnet ef database update --project src/Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation.ORM.csproj --startup-project src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj
```
