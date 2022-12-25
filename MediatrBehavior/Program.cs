using MediatR;
using MediatrBehavior;
using MediatrBehavior.CQRS.User.Behaviors;
using MediatrBehavior.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CheckEmailExistsBehavior<,>));

builder.Services.AddSingleton<DbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.Run();