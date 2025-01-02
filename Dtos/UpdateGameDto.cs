namespace GameStore.Api.Dtos;

public record class UpdateGameDto(
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
);
