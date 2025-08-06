### Gerson Evaluation
## Steps to run

1 - run the following command to update database schema :
```bash
dotnet ef database update --project ./src/Ambev.DeveloperEvaluation.ORM/Ambev.DeveloperEvaluation.ORM.csproj --startup-project ./src/Ambev.DeveloperEvaluation.WebApi/Ambev.DeveloperEvaluation.WebApi.csproj
```
2 - clear and build the solution:
```bash
dotnet clean
dotnet build
```
3 - run the application with vs or docker-compose:
```bash
docker-compose up
```

## Reach me for any questions
- [Gerson](https://www.linkedin.com/in/gersonrp/)