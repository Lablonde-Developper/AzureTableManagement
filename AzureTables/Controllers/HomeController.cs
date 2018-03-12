﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AzureTablesDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tablebusiness = new AzureTablesBusiness.AzureTablesBusiness();
            return View(tablebusiness.GetAllCustomers("customer"));
        }

        public async Task<ActionResult> IndexAsync()
        {
            var tablebusiness = new AzureTablesBusiness.AzureTablesBusiness();
            return View("Index",await tablebusiness.GetAllCustomersAsync("customer"));
        }

        public ActionResult AddCustomer()
        {
            ViewBag.Message = "Upload page.";

            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(AzureTablesModel.CustomerEntity customer)
        {
            if (ModelState.IsValid)
            {
                var AzureTable = new AzureTablesBusiness.AzureTablesBusiness();
                AzureTable.InsertCustomer("customer", customer);
            }

            return RedirectToAction("Index");
        }
    }
}