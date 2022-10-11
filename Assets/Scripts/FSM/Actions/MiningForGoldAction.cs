using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/MiningForGold")]
    public class MiningForGold : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            stateMachine.minedGold += 1;
        }
    }
}