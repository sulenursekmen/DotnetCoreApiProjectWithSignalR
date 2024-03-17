using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly SignalRContext _context;

        public SignalRHub(SignalRContext context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            var value = await _context.Categories.CountAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }

    }
}
