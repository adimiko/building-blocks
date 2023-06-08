namespace BuildingBlocks.Domain.BusinessRules
{
    public abstract class BusinessRuleValidationException : Exception
    {
        internal BusinessRuleValidationException(string message)
            : base(message) { }
    }
}