using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStoreApp.Data
{
   using System.ComponentModel.DataAnnotations;

   public class User
    {
      public int Id { get; set; }

       [Required]
       [MaxLength(50)]
       public string Email { get; set; }

       [Required]
       [MinLength(6)]
       [MaxLength(50)]
       public string Password { get; set; }

       [MaxLength(100)]
       public string FullName { get; set; }


       public bool IsAdmin { get; set; }

   }
}
