using BuildingBlocks.Domain.BusinessRules;
using BuildingBlocks.Domain.ValueObjects;

namespace BuildingBlocks.Domain.DomainServices
{
    public abstract class DomainService
    {
        protected void CheckRule(IBusinessOperationRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessOperationRuleValidationException(rule);
            }
        }

        protected void CheckNulls(ValueObject valueObject)
        {
            if (valueObject is null)
            {
                throw new ValueObjectCannotBeNullException();
            }
        }

        protected void CheckNulls(params ValueObject[] valueObjects)
        {
            foreach (var valueObject in valueObjects)
            {
                CheckNulls(valueObject);
            }
        }
    }
}
