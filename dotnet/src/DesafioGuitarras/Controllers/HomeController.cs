using System.Web.Mvc;

namespace DesafioGuitarras.Controllers
{
    public class HomeController : MvcController
    {
        public ActionResult Index() => View();
    }
}