public class GameKeyService : IGameKeyService
{
    // PRIVATE FIELDS (not in interface)
    private readonly IGameKeyRepository _repository;
    private readonly ILogger<GameKeyService> _logger;
    
    // CONSTRUCTOR (not in interface)
    public GameKeyService(IGameKeyRepository repository, ILogger<GameKeyService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    // PUBLIC METHODS - Must implement ALL methods from interface
    public async Task<List<GameKey>> GetAllKeysAsync()
    {
        _logger.LogInformation("Getting all game keys");
        return await _repository.GetAllAsync();
    }
    
    public async Task<GameKey> GetKeyAsync(int id)
    {
        _logger.LogInformation("Getting game key with ID: {Id}", id);
        
        var gameKey = await _repository.GetByIdAsync(id);
        if (gameKey == null)
        {
            _logger.LogWarning("Game key with ID {Id} not found", id);
            throw new KeyNotFoundException($"Game key with ID {id} not found");
        }
        
        return gameKey;
    }
    
    public async Task<GameKey> AddKeyAsync(string key, string gameTitle, string platform)
    {
        _logger.LogInformation("Adding new game key for {GameTitle}", gameTitle);
        
        // Logic validation
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Game key cannot be empty");
            
        if (await IsKeyDuplicateAsync(key))
            throw new InvalidOperationException("This game key already exists");
        
        var gameKey = new GameKey
        {
            Key = key.Trim(),
            GameTitle = gameTitle?.Trim(),
            Platform = platform?.Trim(),
            IsUsed = false,
            CreatedAt = DateTime.UtcNow
        };
        
        return await _repository.CreateAsync(gameKey);
    }
    
    public async Task<GameKey> MarkAsUsedAsync(int id)
    {
        var gameKey = await GetKeyAsync(id); // Reuse existing method
        
        if (gameKey.IsUsed)
        {
            _logger.LogWarning("Attempt to mark already used key {Id} as used", id);
            throw new InvalidOperationException("Game key is already marked as used");
        }
        
        gameKey.IsUsed = true;
        _logger.LogInformation("Marking game key {Id} as used", id);
        
        return await _repository.UpdateAsync(gameKey);
    }
    
    public async Task DeleteKeyAsync(int id)
    {
        var gameKey = await GetKeyAsync(id); // This will throw if not found
        _logger.LogInformation("Deleting game key {Id}", id);
        await _repository.DeleteAsync(id);
    }
    
    public async Task<List<GameKey>> GetUnusedKeysAsync()
    {
        _logger.LogInformation("Getting all unused game keys");
        return await _repository.GetUnusedAsync();
    }
    
    public async Task<int> GetTotalKeysCountAsync()
    {
        var keys = await _repository.GetAllAsync();
        return keys.Count;
    }
    
    // PRIVATE HELPER METHODS (not in interface)
    private async Task<bool> IsKeyDuplicateAsync(string key)
    {
        var allKeys = await _repository.GetAllAsync();
        return allKeys.Any(k => k.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
    }
    
    // To be implemented later if possible
    private void ValidateGameKey(GameKey gameKey)
    {
        if (gameKey == null)
            throw new ArgumentNullException(nameof(gameKey));
    }
}