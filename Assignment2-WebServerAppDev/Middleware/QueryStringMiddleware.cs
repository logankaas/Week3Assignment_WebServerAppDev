namespace Assignment2_WebServerAppDev.Middleware
{
    public class QueryStringMiddleware
    {
        RequestDelegate next;

        public QueryStringMiddleware(RequestDelegate Next)
        {
            next = Next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var queries = context.Request.QueryString;

            await next(context);
        }
    }
}
