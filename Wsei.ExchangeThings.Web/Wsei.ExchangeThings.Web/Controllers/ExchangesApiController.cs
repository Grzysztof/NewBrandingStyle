using Microsoft.AspNetCore.Mvc;
using Wsei.ExchangeThings.Web.Models;
using Wsei.ExchangeThings.Web.Database;
using Wsei.ExchangeThings.Web.Entities;

namespace Wsei.ExchangeThings.Web.Controllers
{
    [ApiController]
    [Route("api/exchanges")]
    public class ExchangesApiController : ControllerBase
    {
        private ExchangesDbContext _dbContext;

        public ExchangesApiController(ExchangesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AddNewItemResponse Post(ItemModel item)
        {
            var entity = new ItemEntity
            {
                Name = item.Name,
                Description = item.Description,
                IsVisible = item.IsVisible,
            };

            _dbContext.Items.Add(entity);
            _dbContext.SaveChanges();

            var response = new AddNewItemResponse()
            {
                Success = true,
            };


            return response;
        }
    }
}