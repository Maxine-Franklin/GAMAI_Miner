using UnityEngine;
using blackboard;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM_A/Actions/AutoMiningForGold")]
    public class AutoMiningForGold : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            if (Random.Range(0, 101) < stateMachine._blackboard._GetStat(1)) //If random percentile is less than autominer failure chance, then...
                stateMachine._blackboard._IncrementStat(2, 1); //Increase Automaton Lost Gold by 1
            else //If random percentile is greater than or equal to autominer failure chance, then...
                stateMachine._blackboard._IncrementStat(0, 1); //Increase automined gold by 1
        }
    }
}