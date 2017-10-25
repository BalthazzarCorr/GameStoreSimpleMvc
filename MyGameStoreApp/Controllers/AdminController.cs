namespace MyGameStoreApp.Controllers
{
   using System;
   using System.Linq;
   using Services;
   using Services.Contracts;
   using SimpleMvc.Framework.Attributes.Methods;
   using SimpleMvc.Framework.Contracts;
   using ViewModels.Games;

   public class AdminController : BaseController
   {

      public const string AddGameError =
            @"<p>Title – has to begin with uppercase letter and has length between 3 and 100 symbols (inclusive)</p>.<p>	Price –  must be a positive number with precision up to 2 digits after floating point</p>.<p>Size – must be a positive number with precision up to 1 digit after floating point</p>.<p>Trailer– only videos from YouTube are allowed and only their ID should be saved to the database which is a string of exactly 11 characters. 
      For example, if the URL to
         the trailer is https: //www.youtube.com/watch?v=edYCtaNueQY, the required part that must be saved into the database is edYCtaNueQY. That would be always the last 11 characters from the provided URL.
      </p>.<p>Thumbnail URL – it should be a plain text starting with http://, https:// or null</p>.<p>Description – must be at least 20 symbols</p>."
         ;
      private readonly IGameService games;

      public AdminController()
      {
         this.games = new GameService();
      }

      public IActionResult Add()
      {
         if (!this.Profile.IsAdmin)
         {
            return this.Redirect("/");
         }
         return this.View();
      }

      [HttpPost]
      public IActionResult Add(AddGameAdminModel model)
      {
         if (!this.Profile.IsAdmin)
         {
            return this.Redirect("/");
         }
         if (!this.IsValidModel(model))
         {
         this.ShowError(AddGameError);
            return this.View();;
         }
         this.games.Create(model.Title,
            model.Description,
            model.ThumbnailUrl,
            model.Price,
            model.Size,
            model.VideoId,
            model.ReleaseDate);
         return this.Redirect("/admin/all");
      }

      public IActionResult All()
      {
         if (!this.Profile.IsAdmin)
         {
            return this.Redirect("/");
         }
         var allGames = this.games.All()
           .Select(g => $@"<tr>
                                             <td>{g.Id}</td>   
                                             <td>{g.Name}</td>   
                                             <td>{g.Size} GB</td>   
                                             <td>{g.Price} &euro;</td>   
                                             <td>
                                                      <a class="" btn  btn-warning btn-sm"" href="" /admin/edit?id={g.Id}"">Edit</a>
                                                      <a class="" btn  btn-danger btn-sm"" href="" /admin/delete?id={g.Id}"">Delete</a>
                                              </td>
                                             </tr>");
         this.ViewModel["games"] = string.Join(String.Empty, allGames);

         return this.View();
      }
   }
}
