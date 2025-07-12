using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalks.Api.CustomActionFilter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments == null || !context.ActionArguments.Any())
            {
                context.Result = new BadRequestObjectResult("No parameters provided.");
                return;
            }

            foreach (var argument in context.ActionArguments)
            {
                if (argument.Value == null)
                {
                    context.Result = new BadRequestObjectResult($"Parameter '{argument.Key}' cannot be null.");
                    return;
                }
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
