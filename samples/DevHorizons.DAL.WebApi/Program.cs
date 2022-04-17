using DevHorizons.DAL.Interfaces;
using DevHorizons.DAL.Sql;
using DevHorizons.DAL.WebApi.Configuration;
using DevHorizons.DAL.WebApi.Services;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var applicationConfiguration = builder.GetApplicationConfiguration();

// Register Redis Cache
//builder.Services.AddStackExchangeRedisCache(options =>
//{
//    //options.ConfigurationOptions.EndPoints
//    options.ConfigurationOptions.Password = "";
//});
//----------------------------------------------------------------------------
// Register the DAL Service
// ------------------------

builder.Services.RegisterSqlDal(applicationConfiguration.DataAccessSettings);

//-------------------------------------------------------------------------------------
// Register the Business Logic Layers (Services):
// ----------------------------------------------
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductService>();
//-------------------------------------------------------------------------------------
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
    {
        NamingStrategy = new CamelCaseNamingStrategy()
        {
            ProcessDictionaryKeys = false
        }
    };
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
    options.SerializerSettings.Converters.Add(new StringEnumConverter
    {
        NamingStrategy = new DefaultNamingStrategy() { ProcessDictionaryKeys = false }
    });
});
//builder.Services.AddMvc(options =>
//{
//    options.AllowEmptyInputInBodyModelBinding = true;
//}).AddNewtonsoftJson().AddNewtonsoftJson(options =>
//                 {
//                     options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()
//                     {
//                         NamingStrategy = new CamelCaseNamingStrategy()
//                         {
//                             ProcessDictionaryKeys = false
//                         }
//                     };
//                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//                     options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
//                     options.SerializerSettings.Converters.Add(new StringEnumConverter
//                     {
//                         NamingStrategy = new DefaultNamingStrategy() { ProcessDictionaryKeys = false }
//                     });
//                 })
//                 .AddControllersAsServices();

var app = builder.Build();

app.UseDeveloperExceptionPage();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Use(async (context, next) =>
{
    using (var scope = app.Services.CreateScope())
    {
        //// We can use the middleware to change the connection string based on some custom logics.
        var reqCmd = scope.ServiceProvider.GetRequiredService<ICommand>();
        var result = reqCmd.ChangeConnectionString("Integrated Security=SSPI;Data Source=.,1433;Initial Catalog=OnlineStore;TrustServerCertificate=True;");
    }

    await next.Invoke();
});

app.Run();
