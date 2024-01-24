namespace Assignment2_WebServerAppDev.Middleware
{
    public static class MiddlewareExtensionMethods
    {
        public static IApplicationBuilder UseAlerts(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AlertMiddleware>();
        }

        public static IApplicationBuilder UseQueryStrings(this IApplicationBuilder app)
        {
            return app.UseMiddleware<QueryStringMiddleware>();
        }
    }
}
