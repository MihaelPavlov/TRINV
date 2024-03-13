using TRINV.Application;
using TRINV.Domain;
using TRINV.Infrastructure;
using TRINV.StartUp.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDomain()
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();
app.UseValidationExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "[TRINT] Invest Track API V1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(options =>
   options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints
        .MapControllers();

});
app.Run();
