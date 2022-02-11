using Infrastructure.States;
using Player;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField]
        private SceneLoader _sceneLoader;

        [SerializeField] 
        private bool _isBattle;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _sceneLoader);
            _game.StateMachine.Enter<BootstrapState, bool>(_isBattle);

            DontDestroyOnLoad(this);
        }
    }
}
