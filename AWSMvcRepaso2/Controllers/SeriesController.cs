﻿using AWSMvcRepaso2.Models;
using AWSMvcRepaso2.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWSMvcRepaso2.Controllers
{
    public class SeriesController : Controller
    {
        private ServiceSeries service;
        public SeriesController(ServiceSeries service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Serie> series = await this.service.GetSeriesAsync();
            return View(series);
        }

        public async Task<IActionResult> Details(int idserie)
        {
            Serie serie = await this.service.FinSerie(idserie);
            return View(serie);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Serie serie)
        {
            await this.service.CreateSerieAsync(serie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int idserie)
        {
            Serie serie = await this.service.FinSerie(idserie);
            return View(serie);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Serie serie)
        {
            await this.service.UpdateSerieAsync(serie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int idserie)
        {
            await this.service.DeleteSerieAsync(idserie);
            return RedirectToAction("Index");
        }
    }
}
