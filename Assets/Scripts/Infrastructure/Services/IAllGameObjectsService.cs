using Player;
using Screens;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IAllGameObjectsService : IService
    {
        GameObject[] Container();

        void Initialization();
        PlayerPause PlayerPause();
        TransitionScreen TransitionScreen();
    }
}