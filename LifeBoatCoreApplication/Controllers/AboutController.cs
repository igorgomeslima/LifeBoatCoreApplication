using Microsoft.AspNetCore.Mvc;

namespace LifeBoatCoreApplication.Controllers
{
    //[Route("about")]
    //[Route("[controller]")] //= AboutController(In this way, set the driver name).
    [Route("company/[controller]/[action]")] 
    public class AboutController
    {
        //[Route("")]
        public string Phone()
        {
            return "+55 111-111";
        }

        //[Route("address")]
        //[Route("[action]")] //= In this way the MVC framework will use the method name.
        public string Address()
        {
            return "Brazil";
        }
    }
}
