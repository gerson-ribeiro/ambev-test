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
4- create the products and assign their promotions according to the business rules:
```json
{
  "identification": "PROMO001",
  "percent": 10,
  "maxUnit": 10,
  "minUnit": 4,
  "expirationDate": "2025-09-06T02:29:04.802Z"
}
```
and then
```json
{
  "identification": "PROMO002",
  "percent": 20,
  "maxUnit": 20,
  "minUnit": 10,
  "expirationDate": "2025-09-06T02:29:04.802Z"
}
```

## Reach me for any questions
- [Gerson](https://www.linkedin.com/in/gersonrp/)