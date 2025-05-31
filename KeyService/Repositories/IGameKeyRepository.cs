public interface IGameKeyRepository
{
    // Database operations contract
    Task<List<GameKey>> GetAllAsync();
    Task<GameKey> GetByIdAsync(int id);
    Task<GameKey> CreateAsync(GameKey gameKey);
    Task<GameKey> UpdateAsync(GameKey gameKey);
    Task DeleteAsync(int id);
    Task<List<GameKey>> GetByPlatformAsync(string platform);
    Task<List<GameKey>> GetUnusedAsync();
}