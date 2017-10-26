namespace MyGameStoreApp.Services.Contracts
{
   using System;
   using System.Collections.Generic;
   using Data.EntityModels;
   using ViewModels.Games;

   public interface IGameService
   {

      void Create(
         string title, 
         string description,
         string thumbnail, 
         decimal price, 
         double size, 
         string videoId,
         DateTime releaseDate);

      Game GetById(int id);

      IEnumerable<GameListingAdminModel> All();


      void Update(
         int id,
         string title,
         string description,
         string thumbnailUrl,
         decimal price,
         double size,
         string videoId,
         DateTime releaseDate);


      void Delete(int id);
   }
}
