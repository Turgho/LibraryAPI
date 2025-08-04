using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaAPI.Filters;

public class ResponseTimeFilter : IActionFilter
{
    private Stopwatch _timer = null!;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _timer = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _timer.Stop();
        
        Console.WriteLine($"[PERFORMANCE] {context.HttpContext.Request.Path} levou {_timer.ElapsedMilliseconds} ms");
    }
}