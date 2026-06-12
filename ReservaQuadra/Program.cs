using ReservaQuadra.Context;
using ReservaQuadra.Filters;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ReservaQuadra.Services.UserService;
using ReservaQuadra.Repositories.UserRepository;
using ReservaQuadra.Validator.UserValidator;
using ReservaQuadra.Services.CourtService;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Reserva de Quadras API",
        Version = "v1",
        Description = "API para gerenciamento de reservas de quadras esportivas",
        Contact = new()
        {
            Name = "Gustavo Haubrich",
        }
    });
});
builder.Services.AddHttpClient();

//context
var dbPath = Path.Combine(AppContext.BaseDirectory, "Context", "ReservaQuadra.db");
builder.Services.AddDbContext<ReservaQuadraContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

//services, repository and validator
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserValidator, UserValidator>();
builder.Services.AddScoped<ICourtService, CourtService>();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
