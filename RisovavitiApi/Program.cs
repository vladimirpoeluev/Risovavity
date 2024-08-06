using Logic;
using Logic.Interface;
using Logic.Integration;
using DomainModel.Integration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IEntrance, Entrance>();
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();
builder.Services.AddTransient<ICreateSaverToken, SingleSaveUserToken>();
builder.Services.AddTransient<IGetUser, GetUsers>((h) => new GetUsers(new IntegrationUsersEf()));
builder.Services.AddTransient<IGetCanvasAsync, GetCanvas>(h => new GetCanvas(new IntegrationCanvasesEf()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();
