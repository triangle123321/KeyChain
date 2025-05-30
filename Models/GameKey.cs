using System.ComponentModel.DataAnnotations;

public class GameKey
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Key { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string GameTitle { get; set; }
    
    [MaxLength(50)]
    public string Platform { get; set; }
    
    public bool IsUsed { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UsedAt { get; set; }
}