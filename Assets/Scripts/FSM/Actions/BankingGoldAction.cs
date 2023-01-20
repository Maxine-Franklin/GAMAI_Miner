using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/BankingGold")]
    public class BankingGoldAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            stateMachine._blackboard.IncrementStat(0, -1); //Increases mined gold by one
            stateMachine._blackboard.IncrementStat(1, 1); //Increases 'banks' gold by one
        }
    }
}