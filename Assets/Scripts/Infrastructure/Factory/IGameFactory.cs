using Player;
using Screens;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        PlayerPause CreatePlayer();
        TransitionScreen InstantiateTransitionScreen();
    }
}
