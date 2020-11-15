using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wsei.ExchangeThings.Web.Models;

namespace Wsei.ExchangeThings.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public AddNewItemResponseModel Post(ItemModel item)
        {
            bool s = !string.IsNullOrEmpty(item.Description) && !string.IsNullOrEmpty(item.Name);
            var res = new AddNewItemResponseModel
            {
                success = s,
                message = s ? "" : "Input fields cannot be empty"
            };
            return res;
        }
    }
}