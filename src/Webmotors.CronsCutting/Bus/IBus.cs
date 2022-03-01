using System.Threading.Tasks;
using Webmotors.CronsCutting.Bus.Command;
using Webmotors.CronsCutting.Bus.Event;

namespace Webmotors.CronsCutting.Bus
{
    public interface IBus
    {
        Task SendCommand<T>(ICommand<T> command);
        Task RaiseEvent(IEvent @event);
    }
}
