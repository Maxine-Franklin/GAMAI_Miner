using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepBanking")]
    public class KeepBankingDecision: Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            if (stateMachine.minedGold <= 0) //If the miner has banked all mined gold then...
            {
                stateMachine.UpdateDestination(0); //Updates miner destination to the mine
                return false; //Return false to cease banking
            }
            //Else, if the miner still has gold left to bank then...
            return true; //Return true to continue banking
        }
    }
}