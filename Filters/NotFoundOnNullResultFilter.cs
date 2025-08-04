using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BibliotecaAPI.Filters;

public class NotFoundOnNullResultFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) {}

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult result && result.Value == null)
        {
            context.Result = new NotFoundResult();
        }
    }
}
