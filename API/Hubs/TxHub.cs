using API.DTO.WebSocket;
using API.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public class TxHub : Hub<ITxHub>
    {
        private readonly IHubContext<TxHub> _context;

        public TxHub(IHubContext<TxHub> context)
        {
            _context = context;
        }

        public async Task SendUpdate(AssetUpdate update) => await _context.Clients.All.SendAsync("SendUpdate", update);
    }
}
