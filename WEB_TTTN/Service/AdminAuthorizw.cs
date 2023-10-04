



using DataTTTN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WEB_TTTN.Service
{
    public class AdminAuthorizw : AuthorizeFilter
    {
        private Getapi<User> Getapi;
        public AdminAuthorizw()
        {
            Getapi = new Getapi<User>();
        }

        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var list = Getapi.GetApi("User");

            context.Result= new RedirectToRouteResult( new RouteValueDictionary(
                ));

            return base.OnAuthorizationAsync(context);
        }
    }
}
