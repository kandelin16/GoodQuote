using GoodQuote.DataAccessLayer;
using GoodQuote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GoodQuote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IQuoteRepository _service;

        public HomeController(ILogger<HomeController> logger, IQuoteRepository repo)
        {
            _logger = logger;
            _service = repo;
        }


        //All the action happens on this page. The visited parameter determines whether or not to display the quote of the day
        public IActionResult Index(string visited = "false")
        {
            ViewBag.quotes = _service.GetQuotes();

            //This is for the quote of the day
            ViewBag.modal = visited == "false" ? "true" : "false";
            ViewBag.rando = _service.GetRandomQuote();
            return View();
        }

        //Post method for adding a new quote.
        public IActionResult AddQuote(IFormCollection form)
        {
            Quote temp = new Quote();
            temp.Author = form["Author"];
            temp.QuoteText = form["QuoteText"];

            if (form["quoteDate"] != "")
            {
                temp.Date = DateTime.Parse(form["quoteDate"]);
            }
            temp.Citation = form["citation"];
            temp.Subject = form["Subject"];

            _service.AddQuote(temp);
            return RedirectToAction("Index", new { visited = "true"});
        }

        //post for editing an existing quote
        public IActionResult EditQuote(IFormCollection form)
        {
            Quote temp = _service.GetQuoteByID(Convert.ToInt32(form["quoteID"]));
            temp.Author = form["Author"];
            temp.QuoteText = form["QuoteText"];

            if (form["quoteDate"] != "")
            {
                temp.Date = DateTime.Parse(form["quoteDate"]);
            }
            temp.Citation = form["citation"];
            temp.Subject = form["Subject"];

            _service.EditQuote(temp);
            return RedirectToAction("Index", new { visited = "true" });
        }

        //post for deleting a quote.
        public IActionResult DeleteQuote(int QuoteID)
        {
            _service.DeleteQuote(QuoteID);
            return RedirectToAction("Index", new { visited = "true" });
        }
    }
}
