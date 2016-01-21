using System.Web.Mvc;

namespace FluentProjections.Examples.TodoMVC.Web.Controllers
{
    /// <summary>
    ///     Create an ActionResult and PartialView for each angular partial view you want to attatch to a route in the angular
    ///     app.js file.
    /// </summary>
    public class AppController : Controller
    {
        public ActionResult Home()
        {
            return PartialView();
        }
    }
}