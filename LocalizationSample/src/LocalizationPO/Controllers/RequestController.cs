using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalizationSample.Filters;
using LocalizationSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationSample.Controllers
{
    public class RequestController : Controller
    {
        private readonly IStringLocalizer<RequestController> _localizer;

        private static List<RequestModel> _db = new List<RequestModel>();

        public RequestController(IStringLocalizer<RequestController> stringLocalizer)
        {
            _localizer = stringLocalizer;
        }


        [Route("[controller]")]
        // GET: Request
        public ActionResult Index()
        {
            return View(_db);
        }

        // GET: Request
        [Route("[controller]/create")]
        public ActionResult Create()
        {
            return View(new RequestModel { Text = _localizer["some message from controller"]});
        }

        // POST: Request/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/create")]
        public ActionResult Create(RequestModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                _db.Add(model);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }
        }
    }
}