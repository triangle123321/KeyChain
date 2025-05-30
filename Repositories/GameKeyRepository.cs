using Microsoft.EntityFrameworkCore;

public class GameKeyRepository : IGameKeyRepository
{
    private readonly AppDbContext _context;
    
    public GameKeyRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<GameKey>> GetAllAsync()
    {
        return await _context.GameKeys
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<GameKey> GetByIdAsync(int id)
    {
        return await _context.GameKeys.FindAsync(id);
    }
    
    public async Task<GameKey> CreateAsync(GameKey gameKey)
    {
        gameKey.CreatedAt = DateTime.UtcNow;
        _context.GameKeys.Add(gameKey);
        await _context.SaveChangesAsync();
        return gameKey;
    }
    
    public async Task<GameKey> UpdateAsync(GameKey gameKey)
    {
        _context.GameKeys.Update(gameKey);
        await _context.SaveChangesAsync();
        return gameKey;
    }
    
    public async Task DeleteAsync(int id)
    {
        var gameKey = await _context.GameKeys.FindAsync(id);
        if (gameKey != null)
        {
            _context.GameKeys.Remove(gameKey);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<List<GameKey>> GetByPlatformAsync(string platform)
    {
        return await _context.GameKeys
            .Where(k => k.Platform == platform)
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }
    
    public async Task<List<GameKey>> GetUnusedAsync()
    {
        return await _context.GameKeys
            .Where(k => !k.IsUsed)
            .OrderByDescending(k => k.CreatedAt)
            .ToListAsync();
    }
}