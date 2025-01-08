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
using Logic.JwtBearerAuthentication.Interface;
using DataIntegration.RedisDataBase;
using Microsoft.Extensions.DependencyInjection;
using DataIntegration.Interface;
using System.Linq;
using DataIntegration.Interface.InterfaceOfModel;
using RisovavitiApi.Middleware;
using Logic.EmailIntegration.Interface;
using Logic.EmailIntegration;
using Logic.JwtBearerAuthentication;
using Logic.CanvasLogic.VersionProjectOperate;

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
builder.Configuration.AddJsonFile("Configure\\appConfig.json");

#region Contaner
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<DatabaseContext, DatabaseContext>();
builder.Services.AddTransient<IEntrance, Entrance>(h
	=> new Entrance(new InputerSystem(new CreaterToken())));
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();
builder.Services.AddTransient<ICreateSaverToken, SingleSaveUserToken>();
builder.Services.AddTransient<IGeneraterHash, GeneraterHash>();
builder.Services.AddTransient<IRuleIntegrationUser, IntegrationUsersEf>();

builder.Services.AddTransient<IDataBaseModel, DatabaseContext>();

builder.Services.AddTransient<IUserDataBase, DatabaseContext>();
builder.Services.AddTransient<ICanvasDataBase, DatabaseContext>();
builder.Services.AddTransient<IInteractiveCanvasDataBase, DatabaseContext>();
builder.Services.AddTransient<IRoleDataBase, DatabaseContext>();
builder.Services.AddTransient<IStatusesDataBase, DatabaseContext>();

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

builder.Services.AddTransient<IAdderSessionByRefresh, AdderSessionByRefresh>(h => 
new AdderSessionByRefresh(h.GetRequiredService<IRedisService>(),
new CreaterTokenForRefresh()));
builder.Services.AddTransient<IGetterSessionByRefresh, GetterSessionByRefresh>();

builder.Services.AddTransient<IAdderSession, AdderSession>(h =>
	new AdderSession(h.GetRequiredService<IInputerSystem>(), 
	new InputSystemRefresh(	h.GetRequiredService<IAdderSessionByRefresh>(), 
							h.GetRequiredService<IGetterSessionByRefresh>(),
							h.GetRequiredService<IHttpContextAccessor>()))
	);

builder.Services.AddTransient<ICreaterToken, CreaterToken>();
builder.Services.AddTransient<IAutorizeServiceRefresh, AuthorizeServiceRefresh>(h =>
new AuthorizeServiceRefresh(
	new AdderSessionByRefresh(h.GetRequiredService<IRedisService>(), new CreaterTokenForRefresh()),
	new InputerSystem(h.GetRequiredService<ICreaterToken>()),
	new GetterSessionByRefresh(h.GetRequiredService<IRedisService>()),
	new DeleterSession(h.GetRequiredService<IRedisService>()),
	h.GetRequiredService<IAdderSession>(),
	h.GetRequiredService<IUserDataBase>()));

builder.Services.AddTransient<IRedisService, RedisService>(h => new RedisService("localhost:6379"));
builder.Services.AddTransient<IEntranceUser, EntranceUser>();
builder.Services.AddTransient<IDeleterSession, DeleterSession>();
builder.Services.AddTransient<IGetterKeys, RedisService>(h => new RedisService("localhost:6379"));
builder.Services.AddTransient<ISessionService, SessionService>();

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IEmailConfirmaion, EmailConfirmaion>();
builder.Services.AddTransient<IUserConfirmation, UserConfirmation>();
builder.Services.AddTransient<IEditVersionProject, EditerVersitonProject>();
builder.Services.AddTransient<IEditMainVerstionInCanvas, EditMainVersionInCanvas>();
#endregion


var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<AuthorizeAccessToken>();
app.UseStaticFiles();
app.UseForwardedHeaders();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();
