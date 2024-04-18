var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//  Adds All validators that reside in the same assembly as the LogValidator
builder.Services.AddValidatorsFromAssemblyContaining<LogValidator>();

//  Add Database Contexts
//  To Add additional databases copy the line below - Remember to change the context & connection string parameters
builder.Services.AddDbContext<LogContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddDataEndpoints();

app.UseHttpsRedirection();

app.Run();