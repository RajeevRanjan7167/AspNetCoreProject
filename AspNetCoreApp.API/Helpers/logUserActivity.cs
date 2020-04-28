using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreApp.API.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreApp.API.Helpers
{
    public class logUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var repo = resultContext.HttpContext.RequestServices.GetService<IResourceRepository>();
            var resource = await repo.GetResource(userId);
            resource.rm_LastActive = DateTime.Now;
            await repo.SaveAll();
        }
    }
}