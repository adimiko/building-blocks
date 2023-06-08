namespace BuildingBlocks.Domain.BusinessRules
{
    public sealed class BusinessOperationRuleValidationException : BusinessRuleValidationException
    {
        public IBusinessOperationRule BrokenRule { get; }

        public string Details { get; }

        internal BusinessOperationRuleValidationException(IBusinessOperationRule brokenRule)
            : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            Details = brokenRule.Message;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}