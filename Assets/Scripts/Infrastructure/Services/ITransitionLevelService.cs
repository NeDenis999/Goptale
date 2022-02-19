using System;

namespace Infrastructure.Services
{
    public interface ITransitionLevelService : IService
    {
        void TransitLevel(string scene);
        void TransitLevel(string scene, Action action);
        void SetNumberPoint(int numberSpawnPoint);
        int GetNumberSpawnPoint();
    }
}