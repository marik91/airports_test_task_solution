using Airports.Domain.Commands;
using Airports.Domain.ValueObjects;

namespace Airports.Domain.CommandHandler
{
    public interface IAirportsCommandHandler : ICommandHandler<CalculateDistanceCommand, Distance>
    {
    }
}