// Program.cs
using MongoDB.Driver;
using Generic_MOngo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB Configuration
var mongoSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>()
    ?? new MongoDbSettings();

// Register MongoDB Client as Singleton
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(mongoSettings.ConnectionString));

// Register MongoDB Context
builder.Services.AddSingleton<IMongoDbContext>(sp =>
    new MongoDbContext(mongoSettings));

// Register Repositories
builder.Services.AddScoped<IProductRepository>(sp =>
    new ProductRepository(
        sp.GetRequiredService<IMongoClient>(),
        mongoSettings.DatabaseName,
        "ProductCollection"
    ));

builder.Services.AddScoped<IPersonRepository>(sp =>
    new PersonRepository(
        sp.GetRequiredService<IMongoClient>(),
        mongoSettings.DatabaseName,
        "PersonCollection"
    ));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();