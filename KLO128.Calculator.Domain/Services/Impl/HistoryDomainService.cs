using KLO128.Calculator.Domain.Models.Entities;
using KLO128.Calculator.Domain.Repositories;

namespace KLO128.Calculator.Domain.Services.Impl
{
    public class HistoryDomainService : IHistoryDomainService
    {
        private IQueryContainer QC { get; }
        private ICalcHistoryRepository CalcHistoryRepository { get; }
        private ICalcEntryRepository CalcEntryRepository { get; }
        private ICryptoDomainService CryptoService { get; }

        public HistoryDomainService(IQueryContainer qc, ICalcHistoryRepository calcHistoryRepository, ICalcEntryRepository calcEntryRepository, ICryptoDomainService cryptoService)
        {
            QC = qc;
            CalcHistoryRepository = calcHistoryRepository;
            CalcEntryRepository = calcEntryRepository;
            CryptoService = cryptoService;
        }

        public CalcHistory? GetCalcHistory(string? accessToken, bool includeEntries)
        {
            var ret = accessToken == null ? null : CalcHistoryRepository.FindBy(QC.GetCalcHistoryByAccessToken(accessToken, includeEntries));

            if (ret == null || accessToken != CryptoService.GetNewAccessToken(ret))
            {
                return null;
            }

            return ret;
        }
    }
}
