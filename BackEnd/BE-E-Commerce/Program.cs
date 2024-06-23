using BE_E_Commerce;
using DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Get secret key for password
var contStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("E-Commerce"));
contStrBuilder.Password = builder.Configuration["DbPassword"];
var connection = contStrBuilder.ConnectionString;
#endregion 

#region Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(connection));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();