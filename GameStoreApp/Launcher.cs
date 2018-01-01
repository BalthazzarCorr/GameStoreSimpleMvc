namespace GameStoreApp
{
   using SimpleMvc.Framework;
   using SimpleMvc.Framework.Routers;
   using WebServer;

   class Launcher
    {
       static void Main(string[] args)
       {
          MvcEngine.Run(new WebServer(3232, new ControllerRouter(), new ResourceRouter()));
       }
   }
}
