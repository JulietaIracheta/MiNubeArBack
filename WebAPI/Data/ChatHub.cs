using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class ChatHub : Hub
    {
        public async Task Message(MessageModel message)
        {
            await Clients.Others.SendAsync("message", message);
        }
    }

    public class MessageModel
    {
        public string UserName { get; set; }
        public string Message { get; set; }
    }
}
