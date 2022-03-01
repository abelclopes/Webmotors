using MediatR;

namespace Webmotors.CronsCutting.Bus.Command
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
