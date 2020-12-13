using Microsoft.AspNetCore.Mvc;
using Wsei.ExchangeThings.Web.Filters;
using Wsei.ExchangeThings.Web.Models;
using Wsei.ExchangeThings.Web.Database;
using Wsei.ExchangeThings.Web.Entities;

namespace Wsei.ExchangeThings.Web.Controllers
{
    public class ExchangesController : Controller
    {
        private readonly ExchangesDbContext _dbContext;

        public ExchangesController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ServiceFilter(typeof(MyCustomActionFilter))]
        public IActionResult Show(string id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            return RedirectToAction("AddConfirmation", new { itemId = entity.Id });
        }

        [HttpGet]
        public IActionResult AddConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowAll()
        {
            var items = _dbContext.Items;
            return Ok(items);
        }
    }
}