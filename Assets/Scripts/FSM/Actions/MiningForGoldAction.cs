using UnityEngine;
using blackboard;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/MiningForGold")]
    public class MiningForGold : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            int x = 1; //Gold mined
            if (stateMachine._blackboard.GetStat(7) == 1) //If miner is overworked then...
                x = Random.Range(0, 2); //50% chance that miner will mine gold
            if (x == 0)
                stateMachine._blackboard.IncrementStat(5, 1); //Increases gold lost by 0-1
            stateMachine._blackboard.IncrementStat(0, x); //Increases mined gold by 0-1
            stateMachine._blackboard.IncrementStat(2, 1); //Increases miner tiredness by one

            stateMachine._blackboard.UpdateCurrentThought("Mining Gold. Gold +" + x); //Sets current miner thought
            
        }
    }
}