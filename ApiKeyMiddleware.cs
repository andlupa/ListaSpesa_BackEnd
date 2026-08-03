public class ApiKeyMiddleware
{
    private const string API_KEY_HEADER = "X-Api-Key";
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;

    public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Lascia passare Swagger senza richiedere la chiave
        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            await _next(context);
            return;
        }

        if (!context.Request.Headers.TryGetValue(API_KEY_HEADER, out var extractedKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key mancante.");
            return;
        }

        var apiKey = _config["ApiKey"];
        if (string.IsNullOrEmpty(apiKey) || !apiKey.Equals(extractedKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("API Key non valida.");
            return;
        }

        await _next(context);
    }
}