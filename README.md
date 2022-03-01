




dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet ef dbcontext scaffold "Server=localhost,11433;Database=SistemaCompraDb;User ID=sa;Password=Testing1122;Trusted_Connection=False; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer