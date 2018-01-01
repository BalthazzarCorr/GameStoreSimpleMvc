namespace GameStoreApp.ViewModels
{
   using System.ComponentModel.DataAnnotations;
   using Infrastructure;

   public class RegisterModel
   {

      [Required]
      [Email]
      public string Email { get; set; }

      public string Name { get; set; }

      [Required]
      [Password]
      public string Password { get; set; }

      [Required]
      public string ConfirmPassword { get; set; }
   }
}
