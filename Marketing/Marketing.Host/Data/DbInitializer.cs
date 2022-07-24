namespace Marketing.Host.Data;

using Marketing.Host.Data.Entities;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.MarketingItems.Any())
        {
            await context.MarketingItems.AddRangeAsync(GetPreconfiguredMarketingItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<MarketingItem> GetPreconfiguredMarketingItems()
    {
        return new List<MarketingItem>()
        {
            new MarketingItem
            {
                ProductId = 1,
                UserId = "111111",
                Username = "John23",
                Comment = "My compliant is that the game is too straight forward. I find it hard to believe that the greatest wizard in the land would leave his tower unguarded",
                Rating = 2
            },
            new MarketingItem
            {
                ProductId = 1,
                UserId = "111112",
                Username = "Soaptrail",
                Comment = "It has strategy but it is challenging because someone else can throw a wrench into what you are trying to collect. I will re order for my family",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 1,
                UserId = "111113",
                Username = "Jen Jansen",
                Comment = "Took me longer to learn hoe to play it then it did to play it for the first time. Once you do learn to play it, it really does only take about 10min to play. Awesome little game to start game nights with",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 1,
                UserId = "111114",
                Username = "Lisa",
                Comment = "This game is just great",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 1,
                UserId = "111115",
                Username = "Grim",
                Comment = "Plays fast, teaches easily, has some significant strategy to it. I highly recommend this game to just have a nice time with friends, or between longer games with your game group",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 2,
                UserId = "211111",
                Username = "Michael",
                Comment = "13 Days is a tight, suspenseful, 2-player card-driven game playable in less than an hour",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 2,
                UserId = "211112",
                Username = "JessDoo",
                Comment = "Wow, this is a really cool game for 2 players",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 2,
                UserId = "211113",
                Username = "Sharon",
                Comment = "Tight 2-player game which uses a similar multi-use, historically-inspired card approach and evokes the tense bluffing and strategic tug-of-war of Twilight Struggle, within a much shorter playing time",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 2,
                UserId = "211114",
                Username = "Asmoth",
                Comment = "A wonderful game for 2 players, if you are interested in the historical background even better",
                Rating = 4
            },
            new MarketingItem
            {
                ProductId = 2,
                UserId = "211115",
                Username = "Christiano",
                Comment = "A surprising title that allows you to play in a short time but with great pleasure a key historical event of the Cold War period",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 3,
                UserId = "311111",
                Username = "Matthew",
                Comment = "Great little game",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 4,
                UserId = "411111",
                Username = "Renae",
                Comment = "This is essentially a fast strategy game. If you're someone who likes to really plan and carefully process your moves, you won't enjoy this game unless you play without the timer",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 4,
                UserId = "411112",
                Username = "Cody",
                Comment = "This has become one of our favorite games! The gameplay is quick to learn and fun!",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 4,
                UserId = "411113",
                Username = "Jason",
                Comment = "Fun to play",
                Rating = 4
            },
            new MarketingItem
            {
                ProductId = 4,
                UserId = "411114",
                Username = "IndieBob",
                Comment = "Similar to both Bananagrams and Carcasonne in that Carcasonne like tiles are laid inside a square frame, which must be touching either other tiles or the side of the board on at least 2 sides, but in real-time, without taking turns, like Bananagrams!",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 6,
                UserId = "611111",
                Username = "James",
                Comment = "This is a fun game, but I was disappointed in the length of time and the expansion content. The core game comes with three scenarios",
                Rating = 3
            },
            new MarketingItem
            {
                ProductId = 6,
                UserId = "611112",
                Username = "Robert",
                Comment = "Stand alone this game leaves much to be desired",
                Rating = 2
            },
            new MarketingItem
            {
                ProductId = 6,
                UserId = "611113",
                Username = "Doggtired",
                Comment = "Bought this about a week ago and my wife and I have played it almost every night. The story is great and the challenge is right up there",
                Rating = 5
            },
            new MarketingItem
            {
                ProductId = 6,
                UserId = "611114",
                Username = "Bluecashmere",
                Comment = "Once mastered, and it takes some considerable effort to get to grips with the rules, this is a fascinating game, for either one or two people, and no doubt for more with an expanded set",
                Rating = 4
            },
            new MarketingItem
            {
                ProductId = 6,
                UserId = "611115",
                Username = "Jane",
                Comment = "Too many rules and many of those rules are ambiguous. I found myself referring to the rule book, every turn",
                Rating = 2
            }
        };
    }
}