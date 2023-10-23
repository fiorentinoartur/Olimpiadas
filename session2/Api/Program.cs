using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de Controller
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informa��es sobre  API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Participantes",
        Description = "API para filtrar participantes - Backend API ",
        Contact = new OpenApiContact
        {
            Name = "Senai de Inform�tica - Ol�mpiadas",
            Url = new Uri("https://github.com/fiorentinoartur")
        },
    });
    // Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";


});
//Adiciona mapeamento dos COntrollers
var app = builder.Build();

//Aqui come�a a configura��o do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Aqui finaliza a configura��o do swagger
app.MapControllers();

//Adiciona  a autentica��o 
app.UseAuthentication();

//Adicione autoriza��o
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
