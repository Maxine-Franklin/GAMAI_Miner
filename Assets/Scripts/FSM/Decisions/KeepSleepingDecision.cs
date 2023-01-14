using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepSleeping")]
    public class KeepSleepingDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            //if (stateMachine.tiredness <= 0) //If the miner has banked all mined gold then...
            if (stateMachine._blackboard.GetStat(2) <= 0) //If the miner has banked all mined gold then...
            {
                //stateMachine.tiredness = 0; //Prevents tiredness becomming a negative value
                stateMachine._blackboard.UpdateStat(2, 0); //Prevents tiredness becomming a negative value
                //if (stateMachine.minedGold < 5) //If mined gold is less than 5...
                    stateMachine._blackboard.UpdateDestination(0); //Set's agent destination to the mine
                //else //If mined gold is greater than or equal to 5...
                    //stateMachine.UpdateDestination(1); //Set's agent destination to the bank
                return false; //Return false to cease sleeping
            }
            //Else, if the miner is still tired then...
            return true; //Return true to continue sleeping
        }
    }
}