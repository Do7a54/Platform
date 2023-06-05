namespace Platform.Services
{
    public class TextResponseFormatter : IResponseFormatter
    {
        private int responseCounter = 0;
        private static TextResponseFormatter? shared;  // Added Page 358
        public async Task Format(HttpContext context, string content)
        {
            await context.Response.
            WriteAsync($"Response {++responseCounter}:\n{content}");
        }

        public static TextResponseFormatter Singleton
        {
            get
            {
                if (shared == null)
                {
                    shared = new TextResponseFormatter();
                }
                return shared;
            }
        }   // Page 358
    }
}