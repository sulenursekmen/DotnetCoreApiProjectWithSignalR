using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly SignalRContext _context;

        public BasketController(IBasketService basketService,SignalRContext context)
        {
            _basketService = basketService;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values =_basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            var values=_context.Baskets.Include(x=>x.Product).Where(y=>y.MenuTableID==id).Select(z=> new ResultBasketListWithProducts
            {
                BasketID=z.BasketID,
                Count=z.Count,
                MenuTableID=z.MenuTableID,
                Price=z.Price,
                ProductID=z.ProductID,
                TotalPrice=z.TotalPrice,
                ProductName=z.Product.Name
            }).ToList();

            return Ok(values);
        }

    }
}
