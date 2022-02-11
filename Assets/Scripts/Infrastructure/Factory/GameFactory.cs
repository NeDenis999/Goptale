using Infrastructure.Services;
using Player;
using Screens;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        
        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public PlayerPause CreatePlayer()
        {
            var playerPause = _assetProvider.Instantiate(AssetsPath.Player).GetComponent<PlayerPause>();
            Object.DontDestroyOnLoad(playerPause);
            return playerPause;
        }

        public TransitionScreen InstantiateTransitionScreen()
        {
            var transitionScreen = _assetProvider.Instantiate(AssetsPath.TransitionScreenPath)
                .GetComponent<TransitionScreen>();
            //Object.DontDestroyOnLoad(transitionScreen.gameObject);
            return transitionScreen;
        }
    }
}
