using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all") && searchTerm != null)
            {
                List<Dictionary<string, string>> jobs = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search for " + searchTerm;
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else if (searchType.Equals("all") && searchTerm == null)
            {
                List<Dictionary<string, string>> jobs = JobData.FindAll();
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search for " + searchTerm;
                ViewBag.jobs = jobs;
                return View("Index");
            }
            else
            {
                List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search for " + searchTerm;
                ViewBag.jobs = jobs;
                return View("Index");
            }
        }
    }
}
