using KLO128.Calculator.Domain.Models.Entities;
using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;

namespace KLO128.Calculator.Infra.D3ORM.Specs
{
    public static class D3CalcHistoryWithDepByAccessTokenQuery
    {
        private static ISpecification<CalcHistory>? that = null;

        public static ISpecification<CalcHistory> GetSingleton(ID3Context d3Context)
        {
            if (that == null || d3Context.GetType() != QueryContainer.D3ContextType)
            {
                that = D3Specification.Create<CalcHistory>(d3Context).OrderBy(x => x.CalcHistoryId) // sort order 0 + 10
                        .And(D3Specification.Create<CalcEntry>(d3Context)
                            .OrderBy(x => x.CreatedDate, true))
                        .CompareFormat(x => x.AccessToken, ComparisonOp.EQUALS, 0); // sort order 1

                D3Specification.PreBuild(that);
            }

            return that;
        }
    }
}
