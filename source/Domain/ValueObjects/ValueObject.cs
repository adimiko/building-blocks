using BuildingBlocks.Domain.BusinessRules;

namespace BuildingBlocks.Domain.ValueObjects
{
    public abstract record ValueObject
    {
        protected static void CheckRule(IBusinessDataRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessDataRuleValidationException(rule);
            }
        }

        protected static void CheckNulls(ValueObject valueObject)
        {
            if (valueObject is null)
            {
                throw new ValueObjectCannotBeNullException();
            }
        }

        protected static void CheckNulls(params ValueObject[] valueObjects)
        {
            foreach (var valueObject in valueObjects)
            {
                CheckNulls(valueObject);
            }
        }
    }
}