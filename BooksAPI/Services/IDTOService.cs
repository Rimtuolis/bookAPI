namespace BooksAPI.Services
{
    public interface IDTOService
    {
        Task ExecuteAsync(string query);

        Task<List<T>> ReadListAsync<T>(string query);

        Task<T?> ReadItemAsync<T>(string query);
    }
}
