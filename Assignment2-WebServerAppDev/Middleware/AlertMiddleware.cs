namespace Assignment2_WebServerAppDev.Middleware
{
    public class AlertMiddleware
    {
        RequestDelegate next;

        public AlertMiddleware(RequestDelegate Next)
        {
            next = Next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next(context);
        }
    }
}
