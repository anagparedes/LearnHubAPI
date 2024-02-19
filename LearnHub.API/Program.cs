using LearnHub.API.Config;
using LearnHub.Application;
using LearnHub.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplication()
    .AddRepositories();

//Add AutoMapper service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Configure connection string
builder.Services.ConfigDbConnection(builder.Configuration);


builder.Services.AddControllers();
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 64; 
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
