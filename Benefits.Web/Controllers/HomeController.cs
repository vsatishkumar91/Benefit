﻿using Benefit.Services.Interfaces;
using Benefits.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Benefits.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IBenefitService _benefitService;
        public readonly ILogger<HomeController> _logger;

        public HomeController(IBenefitService benefitService, ILogger<HomeController> logger)
        {
            _benefitService = benefitService;
            _logger = logger;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            var result = _benefitService.GetAllBenefits();
            return View(result);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            var item = _benefitService.GetBenefitById(id);
            return View(item);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BenefitModel benefit)
        {
            try
            {
                _benefitService.CreateBenefit(benefit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _benefitService.GetBenefitById(id);
            return View(item);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BenefitModel benefit)
        {
            try
            {
                var item = _benefitService.GetBenefitById(benefit.Id);
                if(item == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                item.Name = benefit.Name;
                item.Id = benefit.Id;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _benefitService.GetBenefitById(id);
            return View(item);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(BenefitModel benefit)
        {
            try
            {
                _benefitService.DeleteBenefitById(benefit.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
