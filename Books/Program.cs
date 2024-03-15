using Books.Data;
using Books.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

string connectionString = config.GetConnectionString("BookConnection");

// Registre o contexto do banco de dados como um serviço na coleção de serviços da aplicação
builder.Services.AddDbContext<BookContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(connectionString)
);
builder.Services.AddScoped<BookService, BookService>();
builder.Services.AddScoped<AddressService, AddressService>();
builder.Services.AddScoped<ManagerService, ManagerService>();
builder.Services.AddScoped<BookstoreService, BookstoreService>();
builder.Services.AddScoped<AutographSessionService, AutographSessionService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "BooksAPI", Version = "v1" });
    var xmlBook = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlBook);
    s.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
