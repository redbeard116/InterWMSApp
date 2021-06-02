namespace InterWMSApp.Helpers
{
    public static class Tools
    {
        public static string GetCorrectErrorMessage(string message)
        {
            return "{ \"error\": "+message+"}";
        }
    }
}
