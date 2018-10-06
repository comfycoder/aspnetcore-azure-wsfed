using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSFedSample.Security
{
    public class CustomIdentityActionFilter : IActionFilter
    {
        private readonly ILogonIdentityService _logonIdentityService;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public CustomIdentityActionFilter(ILogonIdentityService logonIdentityService)
        {
            _logonIdentityService = logonIdentityService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var identity = _logonIdentityService.GetLogonIdentity();

            if (identity != null)
            {
                var controller = context.Controller as Microsoft.AspNetCore.Mvc.Controller;

                controller.ViewBag.Identity = identity;
            }
        }
    }
}
