// Scaffold database
// ConnectionStrings:E-Commerce config in appsetting.json file
dotnet ef dbcontext scaffold Name=ConnectionStrings:E-Commerce Microsoft.EntityFrameworkCore.SqlServer --context-dir DbContext -c ECommerceContext -o Models --context-namespace DbContext