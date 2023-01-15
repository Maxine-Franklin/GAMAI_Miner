using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepBanking")]
    public class KeepBankingDecision: Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            //if (stateMachine.minedGold <= 0) //If the miner has banked all mined gold then...
            if (stateMachine._blackboard.GetStat(0) <= 0) //If the miner has banked all mined gold then...
            {
                stateMachine._blackboard.UpdateDestination(0); //Updates miner destination to the mine
                stateMachine._blackboard.UpdateCurrentThought("Returning to Mine"); //Sets current miner thought
                return false; //Return false to cease banking
            }
            //Else, if the miner still has gold left to bank then...
            stateMachine._blackboard.UpdateCurrentThought("Banking Gold. Gold Banked +1"); //Sets current miner thought
            return true; //Return true to continue banking
        }
    }
}