using Buttons;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    public class FirstButtonInstaller : MonoInstaller
    {
        [SerializeField] 
        private Button _firstButton;
        
        public override void InstallBindings()
        {
            Container
                .Bind<Button>()
                .FromInstance(_firstButton)
                .AsSingle();
        }
    }
}