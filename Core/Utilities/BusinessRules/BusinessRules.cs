using System.Linq;
using Core.Utilities.GenericResults;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.IsSuccess)
                {
                    return rule;
                }
            }

            return null;
        }
    }
}