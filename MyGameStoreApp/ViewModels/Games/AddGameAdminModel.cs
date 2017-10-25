namespace MyGameStoreApp.ViewModels.Games
{
   using System;
   using Infrastructure.Validation;
   using Infrastructure.Validation.Games;
   using SimpleMvc.Framework.Attributes.Validation;


   public class AddGameAdminModel
   {
      public int Id { get; set; }

      [Required]
      [Title]
      public string Title { get; set; }

      [NumberRange(0, double.MaxValue)]
      public decimal Price { get; set; }

      //in GB
      [NumberRange(0, double.MaxValue)]
      public double Size { get; set; }

      [Required]
      [Video]
      public string VideoId { get; set; }

      [Thumbnail]
      public string ThumbnailUrl { get; set; }

      [Required]
      [Description]
      public string Description { get; set; }

      public DateTime ReleaseDate { get; set; }

   }
}
