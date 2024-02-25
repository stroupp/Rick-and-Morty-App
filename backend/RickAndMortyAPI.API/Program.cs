using Microsoft.EntityFrameworkCore;
using RickAndMortyAPI.Infrastructure.Data;
using RickAndMortyAPI.Infrastructure.Seeding;
using RickAndMortyAPI.Infrastructure.Services;
using RickAndMortyAPI.Core.Interfaces;
using AutoMapper;
using RickAndMortyAPI.Infrastructure.Mapping;
using RickAndMortyAPI.API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder => builder.WithOrigins("http://localhost:3000") // The origin of your frontend
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IRickAndMortyService, RickAndMortyService>();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient(); 

builder.Services.AddHttpClient<CharacterService>();
builder.Services.AddHttpClient<RickAndMortyService>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DatabaseInitializer.SeedDatabase(app.Services, clearDatabase:true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseCors("AllowSpecificOrigin"); 
app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthorization();
app.MapControllers();



app.Run();
