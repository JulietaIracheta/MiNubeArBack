using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Data
{
    public class ChatHub : Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;

        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _botUser = "My chat bot";
            _connections = connections;
        }

        public async Task SendMessage(string message)
        {
            if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                await Clients.Groups(userConnection.Room).SendAsync("ReceiveMessage", userConnection.User, message);
            }
        }
        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
            _connections[Context.ConnectionId] = userConnection;
            await Clients.Groups(userConnection.Room).SendAsync("ReceiveMessage", _botUser, $"{userConnection.User} se ha unido a la sala.");
            await SendConnectedUsers(userConnection.Room);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                _connections.Remove(Context.ConnectionId);
                Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", _botUser,
                    $"{userConnection.User} ha abandonado la sala.");
                SendConnectedUsers(userConnection.Room);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public Task SendConnectedUsers(string room)
        {
            var usuarios = _connections.Values.Where(c => c.Room == room).Select(c => c.User);
            return Clients.Group(room).SendAsync("UsersInRoom", usuarios);
        }
    }

    public class UserConnection
    {
        public string User { get; set; }
        public string Room { get; set; }
    }
}
