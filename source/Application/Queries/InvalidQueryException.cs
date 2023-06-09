namespace BuildingBlocks.Application.Queries
{
    public sealed class InvalidQueryException : Exception
    {
        public IEnumerable<string> Errors { get; }

        public InvalidQueryException(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
