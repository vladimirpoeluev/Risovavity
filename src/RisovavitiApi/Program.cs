using Logic;
using Logic.Interface;
using Logic.Integration;
using DomainModel.Integration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RisovavitiApi.JwtBearerAuthentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication((o => {
	o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}))
	.AddJwtBearer((options) =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = OptionsJwtTokens.ISSUER,
			ValidateAudience = true,
			ValidAudience = OptionsJwtTokens.AUDIENCE,
			ValidateLifetime = true,
			IssuerSigningKey = OptionsJwtTokens.GetSecurityKey(),
			ValidateIssuerSigningKey = true,
		};
	});


builder.Services.AddControllers();
builder.Services.AddTransient<IEntrance, Entrance>(h => new Entrance(new InputerSystem(new CreaterToken())));
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();
builder.Services.AddTransient<ICreateSaverToken, SingleSaveUserToken>();
builder.Services.AddTransient<IGetUser, GetUsers>((h) => new GetUsers(new IntegrationUsersEf()));
builder.Services.AddTransient<IGetCanvasAsync, GetCanvas>(h => new GetCanvas(new IntegrationCanvasesEf()));
builder.Services.AddTransient<IInputerSystem, InputerSystem>(h => new InputerSystem(new CreaterToken()));
builder.Services.AddTransient<IRegistationUser, RegistrationUser>(h => new RegistrationUser(new IntegrationUsersEf()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
