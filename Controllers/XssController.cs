using Microsoft.AspNetCore.Mvc;

public class XssController: Controller
{
     public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string userInput)
        {
            ViewBag.Output = userInput;
            return View();
        }

}