namespace Orders.Contract
{
    public interface IOrdersContract
    {
        Task<int> GetIdByOrderAsync(int id);
    }
}
