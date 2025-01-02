using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPoint = "GetGame";

List<GameDto> games = [
    new (
        1,
        "Street Fighter 11",
        "Fighting",
        19.99M,
        new DateOnly(1997, 7, 15)
    ),
    new (
        2,
        "Final Fantasy XIV",
        "Roleplaying",
        59.99M,
        new DateOnly(2010, 9, 30)
    )
];

// GET /games
app.MapGet("games", () => games);

// GET /games/1
app.MapGet("games/{id}", (int id) => games.Find(game => game.id == id)).WithName(GetGameEndPoint);

// POST /games
app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new GameDto(
        games.Count + 1,
        newGame.name,
        newGame.genre,
        newGame.price,
        newGame.releaseDate
    );
    games.Add(game);
    return Results.AcceptedAtRoute(GetGameEndPoint, new { id = game.id }, game);
});

// PUT /games

app.MapDelete("games/{id}", (int id) =>
{
    int index = games.FindIndex(game => game.id == id);
    games.RemoveAt(index);
    return Results.NoContent();
});


// DELETE /games
app.Run();
