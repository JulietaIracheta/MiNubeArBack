using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Data
{
    public class NotificacionesHub : Hub
    {
       
    }
    public class NotificacionMsg
    {
        public string Descripcion { get; set; }
        public int Id { get; set; }
        public int IdUsuarioReceptor { get; set; }
    }
}