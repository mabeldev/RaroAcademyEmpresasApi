using Academy.Empresas.IoC;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Academy.EmpresaApi");

NativeInjectorBootStrapper.RegisterAppDependencies(builder.Services);
NativeInjectorBootStrapper.RegisterAppDependenciesContext(builder.Services, connectionString);

builder.Services.AddControllers().AddJsonOptions(
        options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                        new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "Academy.EmpresasApi",
                            Version = "v1",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Mabel" },
                            TermsOfService = new Uri("http://raroacademy.com")
                        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    swagger.IncludeXmlComments(xmlPath);
});

var _secretKey = builder.Configuration["SecretKey"];
var secretKey = Encoding.ASCII.GetBytes(_secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swagger =>
    {
        swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Academy EmpresasApi");
    });
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
