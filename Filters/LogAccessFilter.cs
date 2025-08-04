using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaAPI.Filters;

public class LogAccessFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        Console.WriteLine($"[ACESSO] {DateTime.Now}: {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}