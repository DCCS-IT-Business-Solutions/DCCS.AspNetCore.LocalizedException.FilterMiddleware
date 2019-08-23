using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using DCCS.LocalizedString.NetStandard;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DCCS.AspNetCore.LocalizedString
{
    public class LocalizedExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var exceptions = DCCS.LocalizedString.NetStandard.LocalizedException.SearchLocalizedExceptions(context.Exception).ToArray();
                if (exceptions.Length > 0)
                {
                    var errorContracts = LocalizedExceptionContract.CreateArray(exceptions);
                    var errorResult = new ObjectResult(errorContracts);
                    context.ExceptionHandled = true;
                    errorResult.StatusCode = 400;
                    context.Result = errorResult;

                }
            }
        }
    }
}
