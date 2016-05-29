using ClassifierComponent;
using ClassifierComponent.SerializationModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebNLClassifier.Controllers
{
    public class HomeController : Controller
    {


        // GET: Home
        public ActionResult Index(string textInput = "")
        {
            // in a real world project I would make this a view model but for the purposes of this exercise
            // I think I'll just use our existing model. A bit sloppy but I want to get this done quickly.

            var model = new ClassifierClassRootObject()
            {
                top_class = "nothing yet",
                classes = new List<ClassifierResultClass>()

            };

            if (string.IsNullOrWhiteSpace(textInput) == false)
            {
                model = new Classifier()
                     .WithUsername("b4949ffd-0f75-433a-8cda-3e1aaa75b91d") //todo: lose the hard coded strings!
                     .WithPassword("rLVfGY4ttyeh")
                     .GetClassification(textInput);

            }


            return View(model);
        }


    }
}