public class GameKey
{
    public int Id { get; set; }
    public required string Key { get; set; }
    public required string GameTitle { get; set; }
    public required string Platform { get; set; }
    public bool IsUsed { get; set; }
    public DateTime CreatedAt { get; set; }
}