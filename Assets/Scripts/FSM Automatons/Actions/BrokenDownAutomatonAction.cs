using UnityEngine;
using blackboard;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM_A/Actions/BrokenDownAutomatonAction")]
    public class BrokenDownAutomatonAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            if (stateMachine._blackboard.GetStat(2) == 0) //If broken down automaton is a miner type, then...
                stateMachine._blackboard._IncrementStat(2, 1); //Increase automaton lost gold by 1
        }
    }
}