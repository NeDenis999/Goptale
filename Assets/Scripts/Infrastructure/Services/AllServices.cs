namespace Infrastructure.Services
{
    public class AllServices
    {
        /*
        private AllServices _instance;
        public AllServices Container => _instance ??= new AllServices();
        */
        
        public void RegisterService<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.ServiceInstance = implementation;
        }
        
        public TService Single<TService>() where TService : IService
        {
            return Implementation<TService>.ServiceInstance;
        }

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}