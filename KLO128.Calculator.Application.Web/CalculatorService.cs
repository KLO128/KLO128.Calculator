using KLO128.Calculator.Application.Contracts;
using KLO128.Calculator.Application.Contracts.DTOs.Entities;
using KLO128.Calculator.Application.Contracts.DTOs.Results;
using KLO128.Calculator.Application.Contracts.Services;
using KLO128.Calculator.Domain.Models.Entities;
using KLO128.Calculator.Domain.Repositories;
using KLO128.Calculator.Domain.Services;
using KLO128.Calculator.Domain.Services.Impl;
using KLO128.D3ORM.Common.Abstract;
using KLO128.D3ORM.Sample.Domain;
using Newtonsoft.Json;

namespace KLO128.Calculator.Application.Web
{
    public class CalculatorService : ICalculatorService
    {
        private IUnitOfWork UnitOfWork { get; }
        private ICalcEntryRepository CalcEntryRepository { get; }
        private ICalcHistoryRepository CalcHistoryRepository { get; }
        private IComputeDomainService ComputeDomainService { get; }
        private IHistoryDomainService HistoryService { get; }
        private ICryptoDomainService CryptoService { get; }

        public CalculatorService(IUnitOfWork unitOfWork, ICalcEntryRepository calcEntryRepository, ICalcHistoryRepository calcHistoryRepository, IComputeDomainService computeService, IHistoryDomainService historyService, ICryptoDomainService cryptoService)
        {
            UnitOfWork = unitOfWork;
            CalcEntryRepository = calcEntryRepository;
            CalcHistoryRepository = calcHistoryRepository;
            ComputeDomainService = computeService;
            HistoryService = historyService;
            CryptoService = cryptoService;
        }

        public ServiceResult<ComputeResult> GetComputeResult(string? accessToken, string expression, string culture, bool useSeparators)
        {
            var error = ComputeDomainService.TryCompute(expression, culture, out double result);
            var calcHistory = HistoryService.GetCalcHistory(accessToken, false);
            CalcEntry entity;
            string? newAccessToken = null;
            var createNewAccessToken = calcHistory == null;

            return ServiceResult.GetServiceResult(() =>
            {
                return UnitOfWork.Transaction(() =>
                {
                    var now = DateTime.Now;
                    if (calcHistory == null)
                    {
                        calcHistory = new CalcHistory
                        {
                            Guid = Guid.NewGuid().ToString(),
                            CreatedDate = now,
                            UpdatedDate = now
                        };

                        newAccessToken = CryptoService.GetNewAccessToken(calcHistory);

                        calcHistory.AccessToken = newAccessToken;

                        CalcHistoryRepository.AddRoot(calcHistory);
                    }
                    else
                    {
                        CalcHistoryRepository.UpdateProperties(calcHistory, x => x.UpdatedDate, now);
                    }

                    entity = new CalcEntry
                    {
                        CalcHistoryId = calcHistory.CalcHistoryId,
                        CreatedDate = now,
                        Expression = ComputeDomainService.PrintNormalized(expression, culture, throwError: false),
                        Result = result,
                        ErrorCode = error?.Code,
                        ErrorArgs = error?.Args == null ? null : JsonConvert.SerializeObject(error.Args)
                    };

                    CalcEntryRepository.AddAsChild(calcHistory, x => x.CalcEntries, entity);

                    var resultNormalized = entity.Result?.AsNumberString();
                    var dto = entity.ToDTO<CalcEntryDTO>();

                    return new ComputeResult
                    {
                        Culture = culture,
                        UseSeparator = useSeparators,
                        ExpressionNormalized = entity.Expression,
                        Expression = ComputeDomainService.PrettyPrint(entity.Expression, culture, useSeparators, throwError: false),
                        ResultToPrint = ComputeDomainService.PrettyPrint(resultNormalized ?? string.Empty, culture, useSeparators, throwError: false),
                        Result = dto.Result,
                        ResultNormalized = resultNormalized ?? string.Empty,
                        ResultAsInteger = (int)(dto.Result ?? 0),
                        NewAccessToken = newAccessToken,
                        CreatedDate = dto.CreatedDate,
                        Warning = error,
                    };
                });
            });
        }

        public ServiceResult<PrettyPrintResult> PrettyPrint(string expression, bool normalize, string culture, string? expressionResult = null, bool useSeparators = false)
        {
            return ServiceResult.GetServiceResult(() =>
            {
                string ret0;
                string ret1;

                if (normalize)
                {
                    ret0 = ComputeDomainService.PrintNormalized(expression, culture);

                    if (expressionResult == null)
                    {
                        ret1 = string.Empty;
                    }
                    else
                    {
                        ret1 = ComputeDomainService.PrintNormalized(expressionResult, culture);
                    }
                }
                else
                {
                    ret0 = ComputeDomainService.PrettyPrint(expression, culture, useSeparators);

                    if (expressionResult == null)
                    {
                        ret1 = string.Empty;
                    }
                    else
                    {
                        ret1 = ComputeDomainService.PrettyPrint(expressionResult, culture, useSeparators);
                    }
                }

                return new PrettyPrintResult
                {
                    Expression = ret0,
                    Result = ret1
                };
            });
        }
    }
}
