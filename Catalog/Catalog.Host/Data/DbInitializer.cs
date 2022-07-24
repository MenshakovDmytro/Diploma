namespace Catalog.Host.Data;

using Catalog.Host.Data.Entities;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogCategories.Any())
        {
            await context.CatalogCategories.AddRangeAsync(GetPreconfiguredCatalogCategories());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogMechanics.Any())
        {
            await context.CatalogMechanics.AddRangeAsync(GetPreconfiguredCatalogMechanics());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogCategory> GetPreconfiguredCatalogCategories()
    {
        return new List<CatalogCategory>()
        {
            new CatalogCategory() { Category = "Strategy" },
            new CatalogCategory() { Category = "Thematic" },
            new CatalogCategory() { Category = "Family" },
            new CatalogCategory() { Category = "Party Game" },
            new CatalogCategory() { Category = "Childrens Game" }
        };
    }

    private static IEnumerable<CatalogMechanic> GetPreconfiguredCatalogMechanics()
    {
        return new List<CatalogMechanic>()
        {
            new CatalogMechanic() { Mechanic = "Area Control" },
            new CatalogMechanic() { Mechanic = "Dice Rolling" },
            new CatalogMechanic() { Mechanic = "Memory" },
            new CatalogMechanic() { Mechanic = "Cooperative" }
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>()
        {
            new CatalogItem { CatalogCategoryId = 1, CatalogMechanicId = 2, Description = "In 10 Minute Heist: The Wizard's Tower, players take turns moving their pawns from room to room stealing items. Players compete for most paintings, artifacts, jewels, and fossils.", Name = "10 Minute Heist: The Wizard's Tower", Price = 9.55M, PictureFileName = "1.png" },
            new CatalogItem { CatalogCategoryId = 1, CatalogMechanicId = 1, Description = "13 Days: The Cuban Missile Crisis is a nail-biting, theme saturated two-player strategy game about the Cuban Missile Crisis. Your fate is determined by how well you deal with the inherent dilemmas of the game, and the conflict.", Name = "13 Days: The Cuban Missile Crisis", Price = 20.50M, PictureFileName = "2.png" },
            new CatalogItem { CatalogCategoryId = 1, CatalogMechanicId = 1, Description = "2 de Mayo is an abstract game of the terrible incidents that took place in Madrid on May 2, 1808. On that date, civilians in Madrid and a few Spanish army units rebelled against the French occupation troops of Napoleon.", Name = "2 de Mayo", Price = 50.35M, PictureFileName = "3.png" },
            new CatalogItem { CatalogCategoryId = 1, CatalogMechanicId = 1, Description = "In 4 gods, you and your opponents simultaneously create a world's geography and religious landscape by placing tiles, incarnating prophets, and establishing legendary cities", Name = "4 Gods", Price = 29.99M, PictureFileName = "4.png" },
            new CatalogItem { CatalogCategoryId = 2, CatalogMechanicId = 3, Description = "One of the players controls the Hero, a castaway spacefarer exploring an unknown map full of dangers, trying to complete missions, while up to 3 Evil Masterminds plot in the darkness, trying to kill them", Name = "Alone", Price = 40.59M, PictureFileName = "5.png" },
            new CatalogItem { CatalogCategoryId = 2, CatalogMechanicId = 3, Description = "Arkham Horror is a cooperative adventure game themed around H.P Lovecraft's Cthulhu Mythos. Players can select from 16 unique playable investigator characters, each with unique abilities, and will square off against the diabolical servants of 8 Ancient Ones", Name = "Arkham Horror", Price = 29.39M, PictureFileName = "6.png" },
            new CatalogItem { CatalogCategoryId = 3, CatalogMechanicId = 4, Description = "Choose a Marvel hero and team up with other players to defeat evil Villains, Minions and Goons in just five minutes", Name = "5-Minute Marvel", Price = 12, PictureFileName = "7.png" },
            new CatalogItem { CatalogCategoryId = 4, CatalogMechanicId = 4, Description = "Players take on the role of Caesar and compete for the most prestige points. The challenge is to intelligently allocate your eight rolled dice among the five buildings to acquire the fame you need to win the game", Name = "Alea Iacta Est", Price = 35, PictureFileName = "8.png" },
            new CatalogItem { CatalogCategoryId = 4, CatalogMechanicId = 2, Description = "The game focuses primarily on creating spell combos to blast your foes into the afterlife. Combine spell cards into three-piece combos, creating hundreds of unique and devastating attacks. The chaos is limited only by your thirst for destruction!", Name = "Epic Spell Wars of the Battle Wizards", Price = 226, PictureFileName = "9.png" },
            new CatalogItem { CatalogCategoryId = 4, CatalogMechanicId = 3, Description = "Codenames is a social word game with a simple premise and challenging game play.Two rival spymasters know the secret identities of 25 agents. Their teammates know the agents only by their codenames. The teams compete to see who can make contact with all of their agents first.", Name = "Codenames", Price = 9.79M, PictureFileName = "10.png" },
            new CatalogItem { CatalogCategoryId = 5, CatalogMechanicId = 3, Description = "In Outfoxed, you move around the board to gather clues, then use the special evidence scanner to rule out suspects", Name = "Outfoxed", Price = 14, PictureFileName = "11.png" },
            new CatalogItem { CatalogCategoryId = 5, CatalogMechanicId = 1, Description = "It's a fun board game that you play in the dark, and is a great gift for kids and adults who like board games and want a unique experience", Name = "Shadows in the Forest", Price = 14, PictureFileName = "12.png" }
        };
    }
}