namespace AccountSerivice.Domain.DTOs;

public record AccountInputDTO
{
    public required string Name { get; init; }
    public required string Document { get; init; }
    public required string Password { get; init; }
}