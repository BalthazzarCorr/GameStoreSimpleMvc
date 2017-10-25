namespace MyGameStoreApp.Services
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Contracts;
   using Data;
   using Data.EntityModels;
   using ViewModels.Games;

   public class GameService : IGameService
   {

      public void Create(string title, string description, string thumbnail, decimal price, double size, string videoId,
         DateTime releaseDate)
      {
         using ( var db = new GameStoreDbContext() )
         {
            var game = new Game
            {
               Title = title,
               Description = description,
               ThumbnailUrl = thumbnail,
               Price = price,
               Size = size,
               VideoId = videoId,
               ReleaseDate = releaseDate
            };
            db.Games.Add(game);
            db.SaveChanges();
         }
      }


      public IEnumerable<GameListingAdminModel> All()
      {
         using (var db = new GameStoreDbContext())
         {
            return db
               .Games
               .Select(g => new GameListingAdminModel
               {
                  Id = g.Id,
                  Name = g.Title,
                  Size = g.Size,
                  Price = g.Price
               }
               ).ToList();
         }
      }
   }
}
