namespace MyGameStoreApp.Data.EntityModels
{
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;

   public class User
   {
      public int Id { get; set; }

      [Required]
      [MinLength(3)]
      [MaxLength(50)]
      public string Email { get; set; }

      [Required]
      [MinLength(6)]
      [MaxLength(50)]
      public string Password { get; set; }

      [MaxLength(100)]
      public string FullName { get; set; }

      public  bool IsAdmin { get; set; }

      public List<Order> Orders { get; set; } = new List<Order>();
   }
}
