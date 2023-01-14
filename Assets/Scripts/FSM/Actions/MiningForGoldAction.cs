using UnityEngine;
using blackboard;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/MiningForGold")]
    public class MiningForGold : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            //stateMachine.minedGold += 1; //Increases mined gold by one
            //stateMachine.tiredness += 1; //Increases miner tiredness by one

            stateMachine._blackboard.IncrementStat(0, 1); //Increases mined gold by one
            stateMachine._blackboard.IncrementStat(2, 1); //Increases miner tiredness by one

            
        }
    }
}