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
            stateMachine.minedGold -= 1; //Decreases mined gold by one
            stateMachine.bankedGold += 1; //Increases 'banks' gold by one
        }
    }
}