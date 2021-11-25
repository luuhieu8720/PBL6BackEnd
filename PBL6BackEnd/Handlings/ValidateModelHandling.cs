using Microsoft.AspNetCore.Mvc.Filters;
using PBL6BackEnd.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PBL6BackEnd.Handlings
{
    public class ValidateModelHandling : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(modelState => modelState.Errors.ToList());

                var errorMessage = errors.Select(x => x.ErrorMessage).FirstOrDefault();

                throw new BadRequestException(errorMessage);
            }
        }
    }
}
