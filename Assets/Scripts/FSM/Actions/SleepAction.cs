using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/Sleep")]
    public class SleepAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            //stateMachine.tiredness -= 1; //Decreases tiredness by 1

            stateMachine._blackboard.IncrementStat(2, -1); //Decreases tiredness by 1
        }
    }
}