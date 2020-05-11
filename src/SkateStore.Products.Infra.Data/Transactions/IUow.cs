namespace SkateStore.Products.Infra.Data.Transactions
{
    public interface IUow
    {
        int Commit();
    }
}
