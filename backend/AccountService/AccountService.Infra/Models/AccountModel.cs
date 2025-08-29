using System.ComponentModel.DataAnnotations;

namespace AccountService.Infra.Models;

public class AccountModel
{
    [Key]
    [Required]
    public required Guid Id { get; set; }

    [Required]
    [StringLength(255)]
    public required string Name { get; set; }

    [Required]
    [StringLength(255)]
    public required string Password { get; set; }

    [Required]
    [StringLength(11)]
    public required string Document { get; set; }
}