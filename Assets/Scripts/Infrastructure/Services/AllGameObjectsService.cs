using Infrastructure.Factory;
using Infrastructure.States;
using OtherLogic;
using Player;
using Screens;
using UnityEngine;

namespace Infrastructure.Services
{
    public class AllGameObjectsService : IAllGameObjectsService
    {
        private readonly ITransitionLevelService _transitionLevelService;
        private GameObject[] _allObjects;
        private PlayerPause _playerPause;
        private readonly IGameFactory _gameFactory;
        private TransitionScreen _transitionScreen;

        public TransitionScreen TransitionScreen()
        {
            if (_transitionScreen)
                return _transitionScreen;
            
            var transitionScreen = _gameFactory.InstantiateTransitionScreen();
            _transitionScreen = transitionScreen;
            return transitionScreen;
        }

        public AllGameObjectsService(ITransitionLevelService transitionLevelService, IGameFactory gameFactory)
        {
            _transitionLevelService = transitionLevelService;
            _gameFactory = gameFactory;
            
            Initialization();
        }

        public void Initialization()
        {
            _allObjects = Object.FindObjectsOfType<GameObject>();

            foreach (var currentObject in _allObjects)
            {
                if (currentObject.GetComponent<PlayerPause>())
                {
                    _playerPause = currentObject.GetComponent<PlayerPause>();
                    Object.DontDestroyOnLoad(_playerPause);
                }

                if (currentObject.GetComponent<TransitionLevelWhiteScreenTrigger>())
                    currentObject.GetComponent<TransitionLevelWhiteScreenTrigger>().Construct(_transitionLevelService);
                
                if (currentObject.GetComponent<TransitionLevelTrigger>())
                    currentObject.GetComponent<TransitionLevelTrigger>().Construct(_transitionLevelService, TransitionScreen());
            }
        }

        public GameObject[] Container() => 
            _allObjects;

        public PlayerPause PlayerPause() => 
            _playerPause;
    }
}