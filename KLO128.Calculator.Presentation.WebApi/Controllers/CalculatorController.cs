using KLO128.Calculator.Application.Contracts.Services;
using KLO128.Calculator.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KLO128.Calculator.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private IConfiguration Configuration { get; }

        private ICalculatorService CalculatorService { get; }

        private IHistoryService HistoryService { get; }

        private IStringLocalizer Localizer { get; }

        private ILogger Logger { get; }

        public CalculatorController(IStringLocalizer localizer, ILogger logger, IConfiguration configuration, ICalculatorService calculatorService, IHistoryService historyService)
        {
            Localizer = localizer;
            Logger = logger;
            Configuration = configuration;
            CalculatorService = calculatorService;
            HistoryService = historyService;
        }

        [HttpGet]
        public IActionResult Get(string culture = Constants.DefaultCulture, bool useSeparators = false)
        {
            var ret = HistoryService.GetCalcHistory(Request.Cookies[Constants.WebApi.AccessToken], this.GetSetCultureStringOrDefault(culture), useSeparators);

            return this.GetApiResult(ret);
        }

        [HttpGet]
        [Route(nameof(Compute))]
        public IActionResult Compute(string expression, string culture = Constants.DefaultCulture, bool useSeparators = false)
        {
            var ret = CalculatorService.GetComputeResult(Request.Cookies[Constants.WebApi.AccessToken], expression, this.GetSetCultureStringOrDefault(culture), useSeparators);

            return this.GetApiResult(ret);
        }

        [HttpGet]
        [Route(nameof(PrettyPrint))]
        public IActionResult PrettyPrint(string expression, string? result = null, bool normalize = false, string culture = Constants.DefaultCulture, bool useSeparators = false)
        {
            var ret = CalculatorService.PrettyPrint(expression, normalize, this.GetSetCultureStringOrDefault(culture), result, useSeparators);

            return this.GetApiResult(ret);
        }
    }
}
