using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaAPI.Filters;

public class ExceptionHandlerFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionHandlerFilter> _logger;

    public ExceptionHandlerFilter(ILogger<ExceptionHandlerFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Erro não tratado em {Path}", context.HttpContext.Request.Path);

        context.Result = new ObjectResult(new { error = "Erro interno no servidor" })
        {
            StatusCode = 500
        };

        context.ExceptionHandled = true;
    }
    
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult result && result.Value == null)
        {
            context.Result = new NotFoundResult();
        }
    }
}