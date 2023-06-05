using Platform.Services; //1

namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        private IResponseFormatter formatter; //1
        public WeatherMiddleware(RequestDelegate nextDelegate,IResponseFormatter respFormatter) //1
        {
         /*   public WeatherMiddleware(RequestDelegate nextDelegate)
        {*/
            next = nextDelegate;
            formatter = respFormatter;  //1
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await formatter.Format(context,"Middleware Class: It is raining in London"); //1--Declaring Dependency P 363
                /*await context.Response.WriteAsync("Middleware Class: It is raining in London");*/
            }
            else
            {
                await next(context);
            }
        }
    }
}