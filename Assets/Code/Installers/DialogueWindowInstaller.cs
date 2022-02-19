using Player;
using Text;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class DialogueWindowInstaller : MonoInstaller
    {
        [SerializeField] 
        private DialogueWindow _dialogueWindow;

        [SerializeField] 
        private Canvas _canvas;

        [Inject] 
        private PlayerPause _playerPause;
        
        public override void InstallBindings()
        {
            var dialogueWindowInstaller = Container.InstantiatePrefabForComponent<DialogueWindow>(
                _dialogueWindow,
                _canvas.transform
                );
            
            dialogueWindowInstaller.gameObject.SetActive(false);
            dialogueWindowInstaller.Construct(_playerPause);

            Container
                .Bind<DialogueWindow>()
                .FromInstance(dialogueWindowInstaller)
                .AsSingle();
        }
    }
}