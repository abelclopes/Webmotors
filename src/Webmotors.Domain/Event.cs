using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webmotors.Domain
{
    public abstract class Event : INotification
    {
        public DateTime DataOcorrencia => DateTime.Now;
    }
}
