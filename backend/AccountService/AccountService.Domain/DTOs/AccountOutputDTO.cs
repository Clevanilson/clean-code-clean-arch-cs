namespace AccountSerivice.Domain.DTOs;

public record AccountOutputDTO
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } 
    public required string Document { get; set; }
}