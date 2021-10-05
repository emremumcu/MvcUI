using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MvcUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Controllers
{
    // Install-Package Newtonsoft.Json 
    public class AjaxController : Controller
    {
        List<IL> iller;
        List<ILCE> ilceler;
        JsonRootIL objIller;
        
        JsonRootILCE objIlceler;

        public class AjaxResponse<T>
        {
            public int statusCode { get; set; }
            public string statusMessage { get; set; }
            public T responseData { get; set; }
        }

        public AjaxController(IWebHostEnvironment env)
        {
            // Read Json (Array Syntax)
            iller = JsonConvert.DeserializeObject<List<IL>>(
                System.IO.File.ReadAllText(
                    System.IO.Path.Combine(env.WebRootPath, "static", "iller.json")
                    )
                );

            // Read Json (Array Syntax)
            ilceler = JsonConvert.DeserializeObject<List<ILCE>>(
                System.IO.File.ReadAllText(
                    System.IO.Path.Combine(env.WebRootPath, "static", "ilceler.json")
                    )
                );

            // Read Json (Object Syntax)
            objIller = JsonConvert.DeserializeObject<JsonRootIL>(
                                System.IO.File.ReadAllText(
                    System.IO.Path.Combine(env.WebRootPath, "static", "objiller.json")
                    )
                );

            // Read Json (Object Syntax)
            objIlceler = JsonConvert.DeserializeObject<JsonRootILCE>(
                    System.IO.File.ReadAllText(
                System.IO.Path.Combine(env.WebRootPath, "static", "objilceler.json")
                )
            );
        }




        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult JqueryAjax()
        {
            return View();
        }

        [HttpPost]
        [RequireHeader(headerKey: "custom-header", headerValue: "custom-header-value")]        
        public PartialViewResult Index(object model)
        {
            string headerValue = Request.Headers["custom-header"];

            System.Threading.Thread.Sleep(2000);

            return new PartialViewResult()
            {
                ViewName = "AjaxResult",

                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = DateTime.Now
                }
            };
        }

        public IActionResult SehirAraView(string searchParam)
        {
            if (searchParam == null) searchParam = string.Empty;

            List<IL> aramaSonucu = iller.Where(x => x.iladi.ToUpper().StartsWith(searchParam.ToUpper())).ToList();

            return new PartialViewResult
            {
                ViewName = "_SehirAra",

                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = aramaSonucu
                }
            };
        }

        public JsonResult SehirAraJson(string searchParam)
        {
            List<IL> aramaSonucu = iller.Where(x => x.iladi.StartsWith(searchParam)).ToList();
            return Json(aramaSonucu);
        }


        [HttpPost]
        public JsonResult AjaxGetSample(string inputData)
        {
            AjaxResponse<string> res = new AjaxResponse<string>();

            res.statusCode = (int)System.Net.HttpStatusCode.OK;
            res.statusMessage = "OK";
            res.responseData = "AjaxGetSample";

            return Json(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetIller()
        {
            AjaxResponse<List<IL>> res = new AjaxResponse<List<IL>>();

            res.statusCode = (int)System.Net.HttpStatusCode.OK;
            res.statusMessage = "OK";
            res.responseData = iller;

            return Json(res);
        }

        [HttpPost]
        public JsonResult GetIlceler(string ilKodu)
        {
            AjaxResponse<List<ILCE>> res = new AjaxResponse<List<ILCE>>();

            res.statusCode = (int)System.Net.HttpStatusCode.OK;
            res.statusMessage = "OK";
            res.responseData = ilceler.Where(i => i.ilkodu == ilKodu).ToList();

            return Json(res);
        }

    }
}
