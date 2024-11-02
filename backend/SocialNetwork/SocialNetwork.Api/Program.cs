using SocialNetwork.Api.Configurations;
using SocialNetwork.Api.Middleware;
using SocialNetwork.Api.Middleware.Exception;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIOC();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.UseAuthentication();

app.UseMiddleware<JwtUserMiddleware>();

app.MapControllers();

app.UseCors("AllowAllOrigins");

app.Run();
