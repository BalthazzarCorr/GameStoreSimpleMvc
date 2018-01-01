namespace GameStoreApp.Services.Contracts
{
   using ViewModels;

   public interface IUserService
    {
      bool Create(string email, string password, string name);

       bool UserExists(string email, string password);

       LoginModel GetById(int id);
   }
}
