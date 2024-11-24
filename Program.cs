using Business.Handlers.Lottery.Commands;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ILotteryRepository, LotteryRepository>();
builder.Services.AddScoped<IWineRepository, WineRepository>();


builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(CreateLotteryCommand).Assembly);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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