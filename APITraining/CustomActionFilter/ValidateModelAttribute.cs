using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APITraining.CustomActionFilter
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }
        }

    }
}



/*instead of using the model state in the controllers
 we can use this class to validate input before method
execution in the controllers by using the 
ActionFilterAttribute and overide the OnAction executing method*/