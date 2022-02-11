using Infrastructure.Services;

namespace Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, SceneLoader sceneLoader)
        {
            StateMachine = new GameStateMachine(coroutineRunner, sceneLoader, new AllServices());
        }
    }
}
