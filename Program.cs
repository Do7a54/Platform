//using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<MessageOptions>(options => {
//    options.CityName = "Albany";
//});  // Modified Page 320

var app = builder.Build();

app.UseMiddleware<Population>();
app.UseMiddleware<Capital>();
app.Run(async (context) => {
    await context.Response.WriteAsync("Terminal Middleware Reached");
});  //Added page 320

app.Run();