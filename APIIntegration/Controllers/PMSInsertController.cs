using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APIIntegration.Models;
using System.Net.Http;

namespace APIIntegration.Controllers
{
    public class PMSInsertController : Controller
    {
        // GET: PMSInsert
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(personnelDataClass pdataInsert)
        {
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44364/api/pms");

            var insertrec = hc.PostAsJsonAsync<personnelDataClass>("pms", pdataInsert);
            insertrec.Wait();

            ViewBag.Message = "Personnel Records were inserted Successfully";
            return View();
        }
    }
}