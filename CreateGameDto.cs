namespace GameStore.Api.Dtos;

public record class CreateGameDto(
    string name,
    string genre,
    decimal price,
    DateOnly releaseDate
 );
