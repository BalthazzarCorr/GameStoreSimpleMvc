namespace MyGameStoreApp.Services.Contracts
{
   using System;
   using System.Collections.Generic;
   using ViewModels.Games;

   public interface IGameService
   {

      void Create(string title, string description, string thumbnail, decimal price, double size, string videoId,
         DateTime releaseDate);

      IEnumerable<GameListingAdminModel> All();
   }
}
