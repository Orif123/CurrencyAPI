using CurrencyAPI.Services.GetAllCurrencies;
using CurrencyAPI.Services.UpdateCurrencies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace CurrencyAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUpdateCurrenciesService _updateService;
        private readonly IGetAllCurrenciesService _getAllService;

        public HomeController(IUpdateCurrenciesService updateService, IGetAllCurrenciesService getAllService)
        {
            _updateService = updateService;
            _getAllService = getAllService;
        }
        /// <summary>
        /// Presents the Data
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_getAllService.GetAllCurrencies());
        }
        /// <summary>
        /// Updates the data
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Update()
        {
            await _updateService.UpdateCurrenciesAsync();
            return RedirectToAction("Index");
        }
    }
}
