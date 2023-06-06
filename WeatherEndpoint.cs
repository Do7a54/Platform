using Platform.Services;  //Page 364
namespace Platform
{
    public class WeatherEndpoint
    {
        private IResponseFormatter formatter;
        public WeatherEndpoint(IResponseFormatter responseFormatter)
        {
            formatter = responseFormatter;
        }
        public async Task Endpoint(HttpContext context)   //// Page 368 /// Using the Activation Utility Class
        {
            /*public static async Task Endpoint(HttpContext context,IResponseFormatter formatter) //Using Adapter P366
             {
                 public static async Task Endpoint(HttpContext context)
             {
                 IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();*/  //P366
            await formatter.Format(context,  // Using a Service in an Endpoint  Page 364
            "Endpoint Class: It is cloudy in Milan");
            /* await context.Response
             .WriteAsync("Endpoint Class: It is cloudy in Milan");*/     
        }
    }
}