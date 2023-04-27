using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filter
{
    public class FiltroAuth: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.Get("LogSession") == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
