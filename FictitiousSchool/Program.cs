using FictitiousSchool.Context;
using FictitiousSchool.Interfaces;
using FictitiousSchool.Repository;
using FictitiousSchool.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// Register repositories
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();

// Register services
builder.Services.AddScoped<IApplicationService, ApplicationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("OurPolicyNew",
        //builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://fictitiousschool20240131124902.azurewebsites.net/swagger/index.html"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); //new

app.UseCors("OurPolicyNew");

app.UseAuthorization();

app.MapControllers();

app.Run();
