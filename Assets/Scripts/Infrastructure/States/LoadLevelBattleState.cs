using Infrastructure.Factory;

namespace Infrastructure.States
{
    public class LoadLevelBattleState : IState
    {
        private readonly IUIFactory _uiFactory;
        
        public LoadLevelBattleState(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Enter()
        {
            Load();
        }

        public void Exit()
        {
            
        }

        private void Load()
        {
            
        }
    }
}