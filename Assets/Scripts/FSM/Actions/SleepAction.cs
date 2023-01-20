using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Sleep")]
    public class SleepAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            stateMachine._blackboard.IncrementStat(2, -1); //Decreases tiredness by 1
        }
    }
}