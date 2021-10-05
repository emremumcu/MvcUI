using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Controllers
{
    public class ModelValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ServerSideValidation()
        {
            return View(new UserModel());
        }


        [HttpPost]
        public IActionResult ServerSideValidation(UserModel model)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                ModelState.AddModelError("MSG", "ModelState has error(s). Please check them.");
            }

            return View(model);
        }



        [HttpGet]
        public IActionResult ClientSideValidation()
        {
            return View(new UserModel());
        }


        [HttpPost]
        public IActionResult ClientSideValidation(UserModel model)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                ModelState.AddModelError("MSG", "ModelState has error(s). Please check them.");
            }

            return View(model);
        }



    }
}
