using api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connect Database
builder.Services.AddDbContext<ApplicationDBContext>( options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//dotnet tool install --global dotnet-ef
//dotnet tool update --global dotnet-ef
//dotnet ef migration add init
//dotnet ef database update --connection "Server=GMB-PC-KELNNA;Database=finshark;User Id=sa;Password=SupportAdmin@321;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false"


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
