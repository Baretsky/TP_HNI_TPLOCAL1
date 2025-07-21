using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        OpinionList opinionList = new OpinionList();
                        var opinions = opinionList.GetAvis("XlmFile/DataAvis.xml");
                        return View(id, opinions);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id, new PersonalInfo());
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationForm(PersonalInfo model)
        {
            // address validation
            if (model.Address == null || model.Address.Length < 5)
            {
                ModelState.AddModelError("", "Address too short");
            }

            // date validation
            if (model.StartDateTraining >= new DateTime(2021, 1, 1))
            {
                ModelState.AddModelError("", "Training start date must be before 2021-01-01");
            }

            // gender validation
            if (model.Gender == "Select a gender")
            {
                ModelState.AddModelError("", "Please select a valid gender");
            }

            // course selection validation
            if (model.TypeOfTraining == "Select a course")
            {
                ModelState.AddModelError("", "Please select a valid training type");
            }

            // On error, return to the form view with validation errors
            if (!ModelState.IsValid)
            {
                return View("Form", model);
            }

            // On success, redirect to the validation view
            return View("ValidationForm", model);
        }
    }
}