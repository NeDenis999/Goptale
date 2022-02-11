namespace Infrastructure.Services
{
    public interface IPauseServices : IService
    {
        void OnPause();
        void OffPause();
    }
}