using Platform.Services;  //Page 364
namespace Platform
{
    public class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context)
        {
            IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
            await formatter.Format(context,  // Using a Service in an Endpoint  Page 364
            "Endpoint Class: It is cloudy in Milan");
            /* await context.Response
             .WriteAsync("Endpoint Class: It is cloudy in Milan");*/
        }
    }
}