using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/UnloadingGold")]
    public class UnloadingGold : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            stateMachine._blackboard.IncrementStat(0, 3); //Increases mined gold by three
            stateMachine._blackboard._IncrementStat(0, -3); //Decreases automined gold by three
        }
    }
}