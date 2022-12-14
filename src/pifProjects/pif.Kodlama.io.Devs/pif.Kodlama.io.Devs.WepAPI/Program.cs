using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using pif.Core.Application;
using pif.Core.Security.Encryption;
using pif.Core.Security.JWT;
using pif.Kodlama.io.Devs.Application;
using pif.Kodlama.io.Devs.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddAuthorization(x => x.AddPolicy("AdminForUpdate", policy => policy.RequireClaim("role","Admin")));
//builder.Services.AddAuthorization(x => x.AddPolicy("AdminForDelete", policy => policy.RequireClaim("role", "Admin")));
//builder.Services.AddAuthorization(x => x.AddPolicy("AdminForCreate", policy => policy.RequireClaim("role", "Admin")));
//builder.Services.AddAuthorization(x => x.AddPolicy("AdminForGetById", policy => policy.RequireClaim("role", "Admin")));
//builder.Services.AddAuthorization(x => x.AddPolicy("AdminForGetList", policy => policy.RequireClaim("Role", "Admin")));

TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidIssuer = tokenOptions.Issuer,
		ValidAudience = tokenOptions.Audience,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
	};
});

builder.Services.AddSwaggerGen(opt =>
{
	opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description =
			"JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
	});
	opt.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
				{ Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
			new string[] { }
		}
	});
});
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
