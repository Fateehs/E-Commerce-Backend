using ETradeAPI.Application.Abstractions.Hubs;
using ETradeAPI.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ETradeAPI.SignalR.HubServices
{
    public class OrderHubService : IOrderHubService
    {
        readonly IHubContext<OrderHub> _hubContext;

        public OrderHubService(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task OrderAddedMessageAsync(string message)

            => await _hubContext.Clients.All.SendAsync
                (ReceiveFunctionNames.OrderAddedMessage, message);
    }
}
