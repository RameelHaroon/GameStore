namespace GameStore.Api.Dtos;

public record class GameDto(
    int id,
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
);
