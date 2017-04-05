using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutomapperTest.Model;
using AutomapperTest.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AutomapperTest.Controllers
{
    public class HomeController : Controller
    {

        private static readonly IList<User> _dataSource = null;
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper)
        {
            _mapper = mapper;

        }

        static HomeController()
        {
            if (_dataSource == null)
            {
                _dataSource = new List<User>();
                for (int i = 0; i < 10; i++)
                {
                    var str = i.ToString();
                    _dataSource.Add(new User
                    {
                        Id = i,
                        Name = "user name " + str,
                        Email = "user email " + str,
                        Password = str,
                        CreatedOn = DateTime.Now
                    });
                }

            }
        }

        public IActionResult Index()
        {
            var viewModel = _dataSource.Select(x => new UserViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name
            });
            return View(viewModel);
        }


        public IActionResult Details(int id)
        {
            var user = _dataSource.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();

            var viewModel = _mapper.Map<UserViewModel>(user);

            return View(viewModel);
        }


        public IActionResult Delete(int id)
        {
            var user = _dataSource.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();

            _dataSource.Remove(user);

            return RedirectToAction("Index");
        }


        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid && viewModel.AgreedToTerms)
            {
                var user = _mapper.Map<User>(viewModel);

                // save data
                user.CreatedOn = DateTime.Now;
                user.Id = _dataSource.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault() + 1;
                _dataSource.Add(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View(viewModel);
            }
        }        
    }
}