using System.Web.Mvc;

namespace SmartMenuAPIs.Areas.CRUD
{
    public class CRUDAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "CRUD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CRUD_default",
                "CRUD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
