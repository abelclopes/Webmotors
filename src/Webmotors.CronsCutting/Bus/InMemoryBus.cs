using MediatR;
using System.Threading.Tasks;
using Webmotors.CronsCutting.Bus.Command;
using Webmotors.CronsCutting.Bus.Event;

namespace Webmotors.CronsCutting.Bus
{
    public class InMemoryBus : IBus
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public Task RaiseEvent(IEvent @event)
        {
            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(ICommand<T> command)
        {
            return _mediator.Send(command);
        }
    }
}
