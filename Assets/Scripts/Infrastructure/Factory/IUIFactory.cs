using Screens;
using Text;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IUIFactory : IService
    {
        void CreateMainCanvas();
        DialogueWindow CreateDialogueWindow();
        LoadingCurtain CreateLoadingCurtain();
    }
}
