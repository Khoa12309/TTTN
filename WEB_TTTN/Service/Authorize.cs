using System.Web.Mvc;

namespace WEB_TTTN.Service
{

    public class Authorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            throw new NotImplementedException();
        }
    }
}
