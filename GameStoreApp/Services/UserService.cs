namespace GameStoreApp.Services
{
   using System.Linq;
   using Contracts;
   using Data;
   using ViewModels;

   public class UserService : IUserService
   {
      public bool Create(string email, string password, string name)
      {
         using (var db = new TemplateDbContext())
         {

            if (db.Users.Any(u => u.Email == email))
            {
               return false;
            }

            var isAdmin = !db.Users.Any();

            var user = new User
            {
               Email = email,
               Password = password,
               IsAdmin = isAdmin,
               FullName = name


            };
            db.Add(user);
            db.SaveChanges();

            return true;
         }
      }

      public bool UserExists(string email, string password)
      {
         using (var db = new TemplateDbContext())
         {
            return db.Users.Any(u => u.Email == email && u.Password == password);
         }
      }

      public LoginModel GetById(int id)
      {
         using (var db = new TemplateDbContext())
         {
            return null;
         }
      }
   }
}
