using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/RunOver")]
    public class RunOverAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            stateMachine.minedGold = 999; //Using 999 essentially acts as an error code to represent that the code has reached the end of execution
        }
    }
}