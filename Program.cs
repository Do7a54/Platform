//using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(opts => {
    opts.ConstraintMap.Add("countryName",
    typeof(CountryRouteConstraint));
});   //added Page 346 -- Using a Custom Constraint

//builder.Services.Configure<MessageOptions>(options => {
//    options.CityName = "Albany";
//});  // Modified Page 320

var app = builder.Build();

app.Use(async (context, next) => {
    Endpoint? end = context.GetEndpoint();
    if (end != null)
    {
        await context.Response
        .WriteAsync($"{end.DisplayName} Selected \n");
    }
    else
    {
        await context.Response.WriteAsync("No Endpoint Selected \n");
    }
    await next();
});   // Page 349

app.Map("{number:int}", async context => {
    await context.Response.WriteAsync("Routed to the int endpoint");
}).WithDisplayName("Int Endpoint")
.Add(b => ((RouteEndpointBuilder)b).Order = 1);
app.Map("{number:double}", async context => {
    await context.Response
    .WriteAsync("Routed to the double endpoint");
}).WithDisplayName("Double Endpoint")
.Add(b => ((RouteEndpointBuilder)b).Order = 2);   // Page 347  -- 348  --349

//app.MapGet("capital/{country:countryName}", Capital.Endpoint);  // Page 346

//app.MapGet("routing", async context => {
//    await context.Response.WriteAsync("Request Was Routed");
//});

//app.MapGet("{first}/{second}/{third}", async context => {  === Page 335
//app.MapGet("files/{filename}.{ext}", async context => {
//app.MapGet("{first}/{second}/{*catchall}", async context => {  // Applaing Catchcall == Page 339

//app.MapGet("{first:alpha:maxlength(3)}/{second:bool}", async context => {   // Applying Constraints  == Page 340
//    await context.Response.WriteAsync("Request Was Routed\n");
//    foreach (var kvp in context.Request.RouteValues)
//    {
//        await context.Response
//        .WriteAsync($"{kvp.Key}: {kvp.Value}\n");
//    }
//});                              // Modified Page 327   /////// Deleted Page 346//////////

//app.MapGet("capital/{country}", Capital.Endpoint);
//app.MapGet("capital/{country=France}", Capital.Endpoint);  //  Using Default value Page 336
//app.MapGet("capital/{country:regex(^uk|france|monaco$)}", Capital.Endpoint);  // Constraining Matching to a Specific Set of Values  = Page 343

//app.MapGet("size/{city}", Population.Endpoint)

//app.MapGet("size/{city?}", Population.Endpoint)  // After usinf dafault value Page 338
//.WithMetadata(new RouteNameMetadata("population"));  // added after Appling Refactoring Middleware into Endpoint- Page 330 -- and modified second Phrase Generating URLs from Routes  page 332
//app.MapFallback(async context => {
//  await context.Response.WriteAsync("Routed to fallback endpoint");
//});  // Added Page 344

//app.MapGet("capital/uk", new Capital().Invoke);
//app.MapGet("population/paris", new Population().Invoke);   //  Modifed Page 325


//app.UseMiddleware<Population>();
//app.UseMiddleware<Capital>();   -- Modified Page 324

//app.UseRouting();
//app.UseEndpoints(endpoints => {
//    endpoints.MapGet("routing", async context => {
//        await context.Response.WriteAsync("Request Was Routed");
//    });

//    endpoints.MapGet("capital/uk", new Capital().Invoke);
//    endpoints.MapGet("population/paris", new Population().Invoke);   // Added Page 324

//});      // Modified Page 322
//app.Run(async (context) => {
//    await context.Response.WriteAsync("Terminal Middleware Reached");
//});  //added page 320                         ============   Modifed Page 325

app.Run();