using Player;

namespace Infrastructure.Services
{
    public class PauseServices : IPauseServices
    {
        private readonly PlayerPause _playerPause;
        
        public PauseServices(PlayerPause playerPause)
        {
            _playerPause = playerPause;
        }

        public void OnPause()
        {
            _playerPause.OnPause();
        }

        public void OffPause()
        {
            _playerPause.OffPause();
        }
    }
}