using System.Web.Mvc;

namespace Apolo.Web.Areas.Therapist
{
    public class TherapistAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Therapist";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Therapist_default",
                "Therapist/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}