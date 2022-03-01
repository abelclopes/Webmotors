using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Application.Anuncios.Notification
{
    public class AnuncioExcluidoNotification : INotification
    {
        public int Id { get; set; }
    }
}
