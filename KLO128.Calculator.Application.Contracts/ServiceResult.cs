using KLO128.Calculator.Domain.Shared.Models;

namespace KLO128.Calculator.Application.Contracts
{
    public class ServiceResult
    {
        public bool Succeeded => Error == null;

        public Warning? Error { get; set; }

        public string RequestToken { get; set; } = null!;

        public static ServiceResult<TResult> GetServiceResult<TResult>(Func<TResult> func)
        {
            try
            {
                return new ServiceResult<TResult>
                {
                    Result = func()
                };
            }
            catch (Warning error)
            {
                return new ServiceResult<TResult>
                {
                    Error = error
                };
            }
        }
    }

    public class ServiceResult<TResult> : ServiceResult
    {
        public TResult? Result { get; set; }

        public ServiceResult()
        {

        }

        public ServiceResult(TResult? Result)
        {
            this.Result = Result;
        }
    }
}
