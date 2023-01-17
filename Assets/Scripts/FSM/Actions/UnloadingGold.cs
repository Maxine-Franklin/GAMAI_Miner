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
            //int x = 0; //Numerator to set a max amount of times the miner can unload during an unloading action
            stateMachine._blackboard.IncrementStat(0, 3); //Increases mined gold by five
            stateMachine._blackboard._IncrementStat(0, -3); //Decreases automined gold by five
        }
    }
}