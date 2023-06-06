using Platform;
using Platform.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>(); // Using DI P 362
var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", async (HttpContext context,
IResponseFormatter formatter) => {
    await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
});  //Added Using DI P 362

//IResponseFormatter formatter = new TextResponseFormatter();
/*app.MapGet("middleware/function", async (context) => {
    // await formatter.Format(context, "Middleware Function: It is snowing in Chicago");

    // await TextResponseFormatter.Singleton.Format(context, "Middleware Function: It is snowing in Chicago");  // P 359
    await TypeBroker.Formatter.Format(context,"Middleware Function: It is snowing in Chicago"); // P 360
});*/ //  ---- Using DI P 362

//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);
//app.MapWeather("endpoint/class");  // Page 367
app.MapEndpoint<WeatherEndpoint>("endpoint/class");  // Page 369

app.MapGet("endpoint/function", async (HttpContext context,
IResponseFormatter formatter) => {
    await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});   //Added Using DI P 362

/*app.MapGet("endpoint/function", async context => {
    //await context.Response.WriteAsync("Endpoint Function: It is sunny in LA"); 
    // await TextResponseFormatter.Singleton.Format(context,"Endpoint Function: It is sunny in LA"); // P 359
    await TypeBroker.Formatter.Format(context,"Endpoint Function: It is sunny in LA");    // P 360
});*/ //  ---- Using DI P 362
app.Run();