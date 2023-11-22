using KLO128.Calculator.Application.Contracts;
using KLO128.Calculator.Application.Contracts.DTOs.Entities;
using KLO128.Calculator.Application.Contracts.DTOs.Results;
using KLO128.Calculator.Application.Contracts.Services;
using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.D3ORM.Common.Abstract;

namespace KLO128.Calculator.Application.Web
{
    public class HistoryService : IHistoryService
    {
        private IHistoryDomainService HistoryDomainService { get; }
        private IComputeDomainService ComputeDomainService { get; }

        public HistoryService(IHistoryDomainService historyDomainService, IComputeDomainService computeDomainService)
        {
            HistoryDomainService = historyDomainService;
            ComputeDomainService = computeDomainService;
        }

        public ServiceResult<CalcHistoryResult> GetCalcHistory(string? accessToken, string culture, bool useSeparator)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                return new ServiceResult<CalcHistoryResult>(new CalcHistoryResult(null));
            }

            var result = HistoryDomainService.GetCalcHistory(accessToken, true);

            if (result == null)
            {
                return new ServiceResult<CalcHistoryResult>(new CalcHistoryResult(null));
            }

            return ServiceResult.GetServiceResult(() =>
            {
                var ret = new CalcHistoryResult(result.ToDTO<CalcHistoryDTO>());

                if (ret.CalcEntries == null)
                {
                    ret.CalcEntries = new List<CalcEntryDTO>();
                }

                foreach (var item in ret.CalcEntries)
                {
                    var toAdd = new CalcHistoryResult.Entry(item);
                    toAdd.Expression = ComputeDomainService.PrettyPrint(item.Expression, culture, useSeparator, false);
                    toAdd.ResultToPrint = ComputeDomainService.PrettyPrint(item.Result?.AsNumberString(), culture, useSeparator, false);

                    ret.EntriesToPrint.Add(toAdd);
                }

                return ret;
            });
        }
    }
}
