using Infrastructure.Factory;
using OtherLogic;
using Player;
using Screens;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IUIFactory _uiFactory;
        private LoadingCurtain _loadingCurtain;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, IUIFactory uiFactory)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _uiFactory = uiFactory;
        }

        public void Enter(string levelName)
        {
            OnLoaded();
        }

        public void Exit()
        {
        
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitGameWorld();
            InitDialogueWindow();
        }

        private void InitUIRoot() => 
            _uiFactory.CreateMainCanvas();

        //public void OpenDialogueWindow() => 
            //_uiFactory.CreateDialogueWindow();

        private void InitGameWorld()
        {
            //_loadingCurtain = _uiFactory.CreateLoadingCurtain();
            //_loadingCurtain.Show();
            //_loadingCurtain.Hide();
        }

        private void InitDialogueWindow()
        {
            var dialogueWindow = _uiFactory.CreateDialogueWindow();
            var interplays = Object.FindObjectsOfType<InterplayOpenDialogue>();
            
            foreach (var interplay in interplays)
                interplay.Construct(dialogueWindow);
        }
    }
}
