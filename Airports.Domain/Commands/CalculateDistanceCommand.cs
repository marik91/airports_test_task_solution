namespace Airports.Domain.Commands
{
    public class CalculateDistanceCommand : ICommand
    {
        public string IataA { get; set; }

        public string IataB { get; set; }
    }
}