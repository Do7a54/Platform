namespace Platform.Services
{
    public static class TypeBroker
    {
        private static IResponseFormatter formatter = new /*TextResponseFormatter();*/ HtmlResponseFormatter();
        public static IResponseFormatter Formatter => formatter;
    }
}