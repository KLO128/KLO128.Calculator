namespace KLO128.D3ORM.Sample.Domain
{
    public interface IUnitOfWork
    {
        TResult Transaction<TResult>(Func<TResult> func);

        void Transaction(Action action);

        void SaveParticularly();
    }
}
