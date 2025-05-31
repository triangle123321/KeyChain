using System.ComponentModel.DataAnnotations;

public class GameKey
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Key is required")]
    [MaxLength(500)]
    public string Key { get; set; }
    
    [Required(ErrorMessage = "Game title is required")]
    [MaxLength(200)]
    public string GameTitle { get; set; }
    
    [MaxLength(50)]
    public string Platform { get; set; } = "Other";
    
    public bool IsUsed { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UsedAt { get; set; }
}