# RL web service

## Setup
1. Install [net7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
2. `dotnet run --project WebApp`
3. Open API at browser [--> Swagger <--](http://localhost:5220/swagger)


## For developers

### EF and database
* Install EF tools: `dotnet tool install --global dotnet-ef`
* Set up database connection:
    * Set up [Secrets](#secrets)
    * Create new secret: `dotnet user-secrets set "SqlConnectionStrings" "server=localhost,1433;database=DB_NAME;user=USER_NAME;password=USER_PASSWORD" --project WebApp`
* Create new table:
    1. Create model class in Core/Entities
    2. Add DbSet in Infrastructure/Data/AppDbContext.cs
    3. Add migration Y: `dotnet ef migrations add Y --startup-project WebApp --project Infrastructure -o Migrations`
    4. Remove migration Y: `dotnet ef migrations remove --startup-project WebApp --project Infrastructure`
    5. Generate SQL script from migration X to migration Y: `dotnet ef migrations script X Y --startup-project WebApp --project Infrastructure -o Infrastructure/script.sql -i`
    6. Review and run script.
* List available migrations `dotnet ef migrations list --startup-project WebApp --project Infrastructure`
* Generate idempotent SQL script: `dotnet ef migrations script --startup-project WebApp --project Infrastructure -o Infrastructure/script.sql -i`

### Secrets
* Initialize user secrets: `dotnet user-secrets init --project WebApp`
* Set a secret: `dotnet user-secrets set "ApiKeys:ServiceApiKey" "12345" --project WebApp`
* Remove a secret: `dotnet user-secrets remove "ApiKeys:ServiceApiKey" --project WebApp`
* List the secrets: `dotnet user-secrets list --project WebApp.Core`

Access tokens are stored in IdentityServerClient and updated automatically with token handlers.