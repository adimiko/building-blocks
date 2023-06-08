namespace BuildingBlocks.Domain.BusinessRules
{
    public sealed class BusinessDataRuleValidationException : BusinessRuleValidationException
    {
        public IBusinessDataRule BrokenRule { get; }

        public string Details { get; }

        internal BusinessDataRuleValidationException(IBusinessDataRule brokenRule)
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