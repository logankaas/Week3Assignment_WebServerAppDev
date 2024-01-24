using Assignment2_WebServerAppDev.Data;
using Assignment2_WebServerAppDev.Interfaces;
using Assignment2_WebServerAppDev.Middleware;
using Assignment2_WebServerAppDev.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext"));
});

//builder.Services.AddSingleton<IValidator, Validator>();
//builder.Services.AddScoped<IValidator, Validator>();
//builder.Services.AddTransient<IValidator, Validator>();
builder.Services.AddTransient<IValidator>(validator => new Validator(true));

#region JWT VALIDATION
/*******************************************
             *  Start JWT Security Configuration
             *  ****************************************/
var secret = "MyVerySuperSecureSecretSharedKey";
var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
var issuer = "http://www.uc.edu/IT3047C";
var audience = "WebServerApplicationDevelopment";

builder.Services.AddAuthentication(OptionsBuilderConfigurationExtensions =>
{
    OptionsBuilderConfigurationExtensions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = secretKey,

        ValidateIssuer = true,
        ValidIssuer = issuer,

        ValidateAudience = true,
        ValidAudience = audience,

        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

/*****************************************
 *  End JWT Security Configuration
 *  **************************************/
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseMiddleware<QueryStringMiddleware>();

app.UseQueryStrings();


app.UseWhen((context) => context.Request.Query.Count > 0, (appBuilder) =>
{
    app.UseMiddleware<AlertMiddleware>();
});


app.Use(async (context, next) =>
{
    Console.WriteLine("Hello from Inline middleware!");

    await next(context);

    Console.WriteLine("Responding to request...");
});


app.Map("/api/hobbies", async (context) =>
{
    await context.Response.WriteAsync("Hello from Hobbies...");
});


app.Use(async (context, next) =>
{
    Console.WriteLine("Hello from Inline middleware!");

    await next(context);

    Console.WriteLine("Responding to request...");
});


app.Map("/api/TestMap2", HandleTestMap);



app.UseAuthorization();

app.MapControllers();

app.Run();

static void HandleTestMap(IApplicationBuilder app)
{
    app.UseAlerts();

    app.Run(async context =>
    {
        await context.Response.WriteAsync("Hello from TestMap2");
    });
}
