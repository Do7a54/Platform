using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageOptions>(options => {
    options.CityName = "Albany";
});   // Page 312  -- Change the cityname from "new York"

var app = builder.Build();

app.UseMiddleware<LocationMiddleware>();  // Added Page 315

//app.MapGet("/location", async (HttpContext context,
//IOptions<MessageOptions> msgOpts) => {
//    Platform.MessageOptions opts = msgOpts.Value;
//    await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
//});   // Added Page 312  // Modified Page 315 becouse it added to middleware class



((IApplicationBuilder)app).Map("/branch", branch =>
{
    branch.Run(new Platform.QueryStringMiddleWare().Invoke);
    //branch.UseMiddleware<Platform.QueryStringMiddleWare>();
    ////branch.Use(async (HttpContext context, Func<Task> next) => {  // Page 310
    //branch.Run(async (context) => {
    //    await context.Response.WriteAsync($"Branch Middleware");
    //     });
});    // Creating Pipeline Branches  -- Page 307
// Modefied Page 312



app.Use(async (context, next) =>
{
    await next();
    await context.Response
    .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
});  // Adding new Middleware -- page 304

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/short")
    {
        await context.Response
        .WriteAsync($"Request Short Circuited");
    }
    else
    {
        await next();
    }
});   // Short-Circuiting the Request Pipeline  -- Page 306



app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get
    && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("Custom Middleware \n");
    }
    await next();
});    // Add a custom middleWare Page 299   
/// Modefied Page  307



//app.UseMiddleware<Platform.QueryStringMiddleWare>();  // Connect the MiddleWare Classs  -- Page 304 // Modifeid Page 312

app.MapGet("/", () => "Hello World!");

app.Run();
