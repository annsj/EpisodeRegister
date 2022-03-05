using CultureApp.DataAccess;
using CultureApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CultureApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDAO _dao;

        public HomeController(ILogger<HomeController> logger,
            IDAO dao)
        {
            _logger = logger;
            _dao = dao;
        }

        [BindProperty]
        public string SelectedTitle { get; set; }

        [BindProperty]
        public string NewTitle { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TvShow> shows = await _dao.GetTvShows();
            ViewData["TvShows"] = shows;

            List<string> titles = await _dao.GetTvShowTitles();
            ViewData["Titles"] = titles;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(TvShow postedShow)
        {
            if (SelectedTitle != null)
            {
                var show = await _dao.GetTvShowWithTitle(SelectedTitle);
                ViewData["SelectedShow"] = show;
            }

            if (postedShow.Title != null)
            {
                await _dao.PostTvShow(postedShow);
            }

            if (NewTitle != null)
            {
                postedShow.Title = NewTitle;
                await _dao.PostTvShow(postedShow);
            }

            List<TvShow> shows = await _dao.GetTvShows();
            ViewData["TvShows"] = shows;

            List<string> titles = await _dao.GetTvShowTitles();
            ViewData["Titles"] = titles;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
