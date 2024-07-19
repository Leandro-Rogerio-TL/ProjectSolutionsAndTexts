using TLbankInfra.ExceptionsFilters;
using TLbankRepositories.MySQLRepository.Configurations;
using TLbankServices.AutoMapper.Configurations;
using TLbankServices.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMyServices();
builder.Services.AddMyRepositories();
builder.Services.AddMyConnection(builder.Configuration);
builder.Services.AddMyAutomapper();

builder.Services.AddControllers(opt => 
    {
        opt.Filters.Add<HttpResponseExceptionFilter>();
    });
builder.Services.AddProblemDetails();
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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
