using Code;
using Zenject;

namespace OtherLogic
{
    public class InterplayStartBattle : Interplay
    {
        private StartBattleService _startBattleService;

        [Inject]
        public void Construct(StartBattleService startBattleService)
        {
            _startBattleService = startBattleService;
        }

        public override void Interaction() =>
            _startBattleService.StartBattle();
    }
}
