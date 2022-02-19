using Infrastructure.Services;
using Player;
using Screens;
using Text;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly PlayerPause _playerPause;
        private RectTransform _mainCanvas;

        public UIFactory(IAssetProvider assetProvider, PlayerPause playerPause)
        {
            _assetProvider = assetProvider;
            _playerPause = playerPause;
        }

        public void CreateMainCanvas() => 
            _mainCanvas = _assetProvider.Instantiate(AssetsPath.MainCanvasPath).GetComponent<RectTransform>();

        public DialogueWindow CreateDialogueWindow()
        {
            var dialogueWindow = _assetProvider.Instantiate(AssetsPath.DialogueWindowPath, _mainCanvas)
                .GetComponent<DialogueWindow>();
            
            dialogueWindow.Construct(_playerPause);
            return dialogueWindow;
        }

        public LoadingCurtain CreateLoadingCurtain() => 
            _assetProvider.Instantiate(AssetsPath.TransitionScreenPath).GetComponent<LoadingCurtain>();
    }
}
