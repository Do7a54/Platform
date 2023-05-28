using Microsoft.Extensions.Options;

namespace Platform
{
    public class QueryStringMiddleWare
    {
        private RequestDelegate? next;    // new Constructor
        public QueryStringMiddleWare()
        {
            // do nothing
        }   // Page 310

        public QueryStringMiddleWare(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }
        public async Task Invoke(HttpContext context)   // Invke Method
        {
            if (context.Request.Method == HttpMethods.Get
            && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)   // ??????
                {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class-based Middleware \n");
            }
            if (next != null)
            {
                await next(context);
            }    // Page 310
        }
    }

    public class LocationMiddleware
    {
        private RequestDelegate next;
        private MessageOptions options;
        public LocationMiddleware(RequestDelegate nextDelegate,
        IOptions<MessageOptions> opts)
        {
            next = nextDelegate;
            options = opts.Value;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
            {
                await context.Response
                .WriteAsync($"{options.CityName}, {options.CountryName}");
            }
            else
            {
                await next(context);
            }
        }
    }   // LocationMiddleware Class Added Page 314
}
// Defining Middleware Using a Class  -- Page 302
