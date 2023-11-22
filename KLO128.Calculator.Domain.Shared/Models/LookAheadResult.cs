namespace KLO128.Calculator.Domain.Shared.Models
{
    public class LookAheadResult<T>
    {
        public T? Value { get; set; }

        public int Index { get; set; }
    }
}
