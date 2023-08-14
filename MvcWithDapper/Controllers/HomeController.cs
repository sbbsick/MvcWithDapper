using Microsoft.AspNetCore.Mvc;
using MvcWithDapper.Models;
using MvcWithDapper.Repositories.Interfaces;
using System.Diagnostics;

namespace MvcWithDapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var banks = _unitOfWork.BankRepository.GetAllAsync().Result;

            var getBank = _unitOfWork.BankRepository.GetByIdAsync(Guid.Parse("013e008d-8c61-4873-8ca4-2ba6b3c13ac9")).Result;

            ViewBag.Banks = banks;
            return View(getBank);
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