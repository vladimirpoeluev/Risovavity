using Logic;
using Logic.Interface;
using Logic.Integration;
using DomainModel.Integration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RisovavitiApi.JwtBearerAuthentication;
using Logic.AuthorsIntegration;
using Logic.UsersData;
using Microsoft.OpenApi.Models;
using DataIntegration.Migrations;
using DataIntegration.Model;
using Logic.HashPassword;
using Logic.CanvasLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
	// Include 'SecurityScheme' to use JWT Authentication
	var jwtSecurityScheme = new OpenApiSecurityScheme
	{
		BearerFormat = "JWT",
		Name = "JWT Authentication",
		In = ParameterLocation.Header,
		Type = SecuritySchemeType.Http,
		Scheme = JwtBearerDefaults.AuthenticationScheme,

		Reference = new OpenApiReference
		{
			Id = JwtBearerDefaults.AuthenticationScheme,
			Type = ReferenceType.SecurityScheme
		}
	};

	setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

	setup.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{ jwtSecurityScheme, Array.Empty<string>() }
	});

});
// Add services to the container.
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(o => {
	o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
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
builder.Services.AddTransient<IEntrance, Entrance>(h 
	=> new Entrance(new InputerSystem(new CreaterToken())));
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();
builder.Services.AddTransient<ICreateSaverToken, SingleSaveUserToken>();
builder.Services.AddTransient<IGetUser, GetUsers>((h) 
	=> new GetUsers(new IntegrationUsersEf()));
builder.Services.AddTransient<IGetCanvasAsync, GetCanvas>(h 
	=> new GetCanvas(new IntegrationCanvasesEf()));
builder.Services.AddTransient<IInputerSystem, InputerSystem>(h 
	=> new InputerSystem(new CreaterToken()));
builder.Services.AddTransient<IRegistationUser, RegistrationUser>(h 
	=> new RegistrationUser(new IntegrationUsersEf()));
builder.Services.AddTransient<IAuthorResultGetter, AuthorGetter>(h 
	=> new AuthorGetter(new DataIntegration.Model.DatabaseContext()));
builder.Services.AddTransient<IUserAvatarGetter, UserAvatarGetter>((h)
	=> new UserAvatarGetter(new DataIntegration.Model.DatabaseContext()));
builder.Services.AddTransient<IPasswordEditer, PasswordEditer>((h) => new PasswordEditer(new DatabaseContext(), new GeneraterHash()));
builder.Services.AddTransient<IFabricCanvasOperation, FabricCanvasOperation>((h) => new FabricCanvasOperation(new DatabaseContext()));

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();
