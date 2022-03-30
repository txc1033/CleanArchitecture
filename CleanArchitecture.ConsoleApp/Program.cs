
using CleanArchitecture.Data;
using CleanArchitecture.Domain;

StreamerDbContext dbContext = new();

Streamer streamer = new()
{
    Nombre = "Amazon Prime",
    Url = "https://www.amazonprime.com"
};

dbContext!.Streamers!.Add(streamer);
await dbContext!.SaveChangesAsync();


var movies = new List<Video>
{
    new Video { Nombre = "Mad Max", StreamerId = 1 },
    new Video { Nombre = "Batman", StreamerId = streamer.Id },
    new Video { Nombre = "Amazin Spiderman", StreamerId = streamer.Id },
    new Video { Nombre = "La Casa de Papel", StreamerId = 1 },

};

await dbContext.AddRangeAsync(movies);
await dbContext!.SaveChangesAsync();