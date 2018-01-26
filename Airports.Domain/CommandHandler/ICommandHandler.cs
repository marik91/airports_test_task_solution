using System.Threading.Tasks;
using Airports.Domain.Commands;

namespace Airports.Domain.CommandHandler
{
    public interface ICommandHandler<in T, TF>
        where T : ICommand where TF : class
    {
        Task<TF> HandleAsync(T command);
    }
}