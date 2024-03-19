using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyBoxesController : ControllerBase
	{
		private readonly IMoneyBoxService _moneyBoxService;

		public MoneyBoxesController(IMoneyBoxService moneyBoxService)
		{
			_moneyBoxService = moneyBoxService;
		}


		[HttpGet("TotalMoneyBoxAmount")]
		public IActionResult TotalMoneyBoxAmount()
		{
			return Ok(_moneyBoxService.TTotalMoneyBoxAmount());
		}
	}
}
