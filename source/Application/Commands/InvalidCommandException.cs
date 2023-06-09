namespace BuildingBlocks.Application.Commands
{
    public sealed class InvalidCommandException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public InvalidCommandException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
