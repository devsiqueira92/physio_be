
using Physio.API.Configurations;
using Physio.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services
	.InstallServices(
		builder.Configuration,
		typeof(IServiceInstaller).Assembly);

//builder.Services.AddCors(opt =>
//{
//    opt.AddPolicy("CorsPolicy", builder => builder
//        .WithOrigins("localhost")
//        .AllowCredentials()
//        .AllowAnyMethod()
//        .AllowAnyHeader());
//});
builder.Services.AddCors();

//builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.RegisterEndpointDefinitions();
app.UseHttpsRedirection();

//app.UseCors("CorsPolicy");

app.UseCors(options => options
					.SetIsOriginAllowed((host) => true)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials()
				);

app.UseAuthentication();
app.UseAuthorization();
//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
//app.UseMiddleware<UserIdentificationMiddleware>();

//app.MapHub<UserHub>("/hubs/user");
app.Run();