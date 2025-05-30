public interface IGameKeyService
{
    // Probably will be removed due to security concerns
    Task<List<GameKey>> GetAllKeysAsync();
    Task<GameKey> GetKeyAsync(int id);
    Task<GameKey> AddKeyAsync(string key, string gameTitle, string platform);
    Task<GameKey> MarkAsUsedAsync(int id);
    Task DeleteKeyAsync(int id);
    Task<List<GameKey>> GetUnusedKeysAsync();
    Task<int> GetTotalKeysCountAsync();
}
