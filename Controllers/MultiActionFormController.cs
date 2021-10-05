using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Controllers
{
    public class MultiActionFormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region SubmitNameValue

        [HttpGet]
        public IActionResult SubmitNameValue()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult SubmitNameValue([FromServices] ILogger<MultiActionFormController> logger, string UserAction)
        {
            // Select => Show output from: [AppName] - ASP.NET Core Web Server in the Output window to see logs.
            logger.LogInformation($"Action: {UserAction}");
            return View("Index");
        }

        #endregion

        #region SubmitFormAction

        [HttpGet]
        public IActionResult SubmitFormAction()
        {
            return View();
        }

        [HttpPost]
        // Passing HomeController as generic type for the ILogger<HomeController>, will be used as a category.
        public IActionResult SubmitFormActionSave([FromServices] ILogger<MultiActionFormController> logger)
        {
            // Select => Show output from: [AppName] - ASP.NET Core Web Server in the Output window to see logs.
            logger.LogInformation("SubmitFormActionSave");
            return View("Index");
        }

        public IActionResult SubmitFormActionCancel([FromServices] ILogger<MultiActionFormController> logger)
        {
            // Select => Show output from: [AppName] - ASP.NET Core Web Server in the Output window to see logs.
            logger.LogInformation("SubmitFormActionCancel");
            return View("Index");
        }

        #endregion

        #region SubmitJQueryAttrib

        [HttpGet]
        public IActionResult SubmitJQueryAttribAction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitJQueryAttribActionSave([FromServices] ILogger<MultiActionFormController> logger)
        {
            // Select => Show output from: [AppName] - ASP.NET Core Web Server in the Output window to see logs.
            logger.LogInformation("SubmitJQueryAttribActionSave");
            return View("Index");
        }

        [HttpPost]
        public IActionResult SubmitJQueryAttribActionCancel([FromServices] ILogger<MultiActionFormController> logger)
        {
            // Select => Show output from: [AppName] - ASP.NET Core Web Server in the Output window to see logs.
            logger.LogInformation("SubmitJQueryAttribActionCancel");
            return View("Index");
        }

        #endregion

        #region SubmitDifferentNames

        [HttpGet]
        public IActionResult SubmitDifferentNames()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitDifferentNames([FromServices] ILogger<MultiActionFormController> logger, string save, string cancel)
        {
            // Select => Show output from: [AppName] - ASP.NET Core Web Server in the Output window to see logs.
            logger.LogInformation($"SubmitDifferentNames: save: {save} cancel: {cancel}");
            return View("Index");
        }

        #endregion

    }
}
