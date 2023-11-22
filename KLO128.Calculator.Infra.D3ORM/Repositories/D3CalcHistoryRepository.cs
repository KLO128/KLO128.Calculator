
///
/// generated file 24.10.2023 19:04:18
///

using System;
using System.Data;
using KLO128.D3ORM.Common;
using KLO128.D3ORM.Common.Impl;
using KLO128.Calculator.Domain.Models.Entities;
using KLO128.Calculator.Domain.Repositories;

namespace KLO128.Calculator.Infra.D3ORM.Repositories
{
    public class D3CalcHistoryRepository : D3AggRootRepository<CalcHistory>, ICalcHistoryRepository
    {
        public D3CalcHistoryRepository(IDbConnection Connection, ID3Context D3Context) : base(Connection, D3Context)
        {
        }
    }
}
