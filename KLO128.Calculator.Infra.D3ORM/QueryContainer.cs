using KLO128.Calculator.Domain;
using KLO128.Calculator.Domain.Models.Entities;
using KLO128.Calculator.Infra.D3ORM.Specs;
using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Common.Impl;
using System.Reflection;

namespace KLO128.Calculator.Infra.D3ORM
{
    public class QueryContainer : IQueryContainer
    {
        private ID3Context D3Context { get; set; }

        internal static Type? D3ContextType = null;

        public QueryContainer(ID3Context D3Context)
        {
            this.D3Context = D3Context;

            if (D3ContextType != D3Context.GetType())
            {
                InitAllSpecs();

                D3ContextType = D3Context.GetType();
            }
        }

        public void InitAllSpecs()
        {
            var types = GetType().Assembly.GetExportedTypes();

            foreach (var type in types)
            {
                if (type == null || (!type.FullName?.Contains("Specs") ?? false))
                {
                    continue;
                }

                if (type.GetMethod(nameof(D3CalcHistoryByAccessTokenQuery.GetSingleton), BindingFlags.Static | BindingFlags.Public) is MethodInfo method)
                {
                    method.Invoke(null, new object[] { D3Context });
                }
            }
        }

        public ISpecificationWithParams<TEntity> CreateQueryParamized<TEntity>(ISpecification<TEntity> baseQuery, ISpecificationWithParams filterQuery) where TEntity : class
        {
            var spec = baseQuery.And(filterQuery);

            return new D3SpecificationWithParams<TEntity>(spec)
            {
                Parameters = filterQuery.Parameters
            };
        }

        private IDictionary<int, object?> GetFilterParamsGeneral(params object?[] filterParams)
        {
            var ret = new Dictionary<int, object?>();

            for (int i = 0; i < filterParams.Length; i++)
            {
                ret.Add(i, filterParams[i]);
            }

            return ret;
        }

        public ISpecificationWithParams<CalcHistory> GetCalcHistoryByAccessToken(string accessToken, bool includeDependencies)
        {
            return new D3SpecificationWithParams<CalcHistory>(
                includeDependencies ? D3CalcHistoryWithDepByAccessTokenQuery.GetSingleton(D3Context)
                : D3CalcHistoryByAccessTokenQuery.GetSingleton(D3Context))
            {
                Parameters = GetFilterParamsGeneral(accessToken)
            };
        }
    }
}
