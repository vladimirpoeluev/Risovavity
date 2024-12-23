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
using DomainModel.Integration.CanvasOperation;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using DataIntegration.RedisDataBase;
using Microsoft.Extensions.DependencyInjection;

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
	})
	.AddJwtBearer("refresh", (options) =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = OptionsJwtTokens.ISSUER,
			ValidateAudience = true,
			ValidAudience = OptionsJwtTokens.AUDIENCE,
			ValidateLifetime = true,
			IssuerSigningKey = OptionsJwtTokens.GetSecurityKeyRefresh(),
			ValidateIssuerSigningKey = true,
		};
	});
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
	options.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor
								| Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
});

#region Contaner
builder.Services.AddControllers();
builder.Services.AddTransient<DatabaseContext, DatabaseContext>();
builder.Services.AddTransient<IEntrance, Entrance>(h
	=> new Entrance(new InputerSystem(new CreaterToken())));
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();
builder.Services.AddTransient<ICreateSaverToken, SingleSaveUserToken>();
builder.Services.AddTransient<IGeneraterHash, GeneraterHash>();
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();

builder.Services.AddTransient<IRuleIntegrationCanvas, IntegrationCanvasesEf>();

builder.Services.AddTransient<IGetUser, GetUsers>();
builder.Services.AddTransient<IGetCanvasAsync, GetCanvas>();
builder.Services.AddTransient<IInputerSystem, InputerSystem>();
builder.Services.AddTransient<IRegistationUser, RegistrationUser>();

builder.Services.AddTransient<IAuthorResultGetter, AuthorGetter>();
builder.Services.AddTransient<IUserAvatarGetter, UserAvatarGetter>();
builder.Services.AddTransient<IPasswordEditer, PasswordEditer>();
builder.Services.AddTransient<IFabricCanvasOperation, FabricCanvasOperation>();
builder.Services.AddTransient<IFabricOperateVersionProject, FabricVersionProjecOperate>();
builder.Services.AddTransient<IGetterImageProject, GetterImageProject>();
builder.Services.AddTransient<IBuilderGetterVerionsByParent, BuilderGetterVerionsByParent>();

builder.Services.AddTransient<ICreaterToken, CreaterToken>();
builder.Services.AddTransient<ICreaterToken, CreaterTokenForRefresh>();
builder.Services.AddTransient<IAutorizeServiceRefresh, AuthorizeServiceRefresh>(h =>
new AuthorizeServiceRefresh(
	new AdderSessionByRefresh(new RedisService("localhost:6379"), new CreaterTokenForRefresh()),
	new InputerSystem(new CreaterToken()),
	new GetterSessionByRefresh(new RedisService("localhost:6379")),
	new DeleterSession(new RedisService("localhost:6379"))));

builder.Services.AddTransient<IEntranceUser, EntranceUser>();
#endregion


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseForwardedHeaders();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();
