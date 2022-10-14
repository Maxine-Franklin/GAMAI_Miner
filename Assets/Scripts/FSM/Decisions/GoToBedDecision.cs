using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/GoToBed")]
    public class GoToBedDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            //NOTE: Change if statement to 'if (state.minedGold >= 5 || state.tiredness >= 6) //If the miner has mined 5 or more gold or has reached 6 or more tiredness then...'
            //if (stateMachine.tiredness >= 7) //If the miner has a tiredness level greater than or equal to 8 then...
            if (stateMachine._blackboard.GetStat(2) >= 7) //If the miner has a tiredness level greater than or equal to 8 then...
            {
                stateMachine.UpdateDestination(2); //Updates miner destination to the home
                return true; //Return false to cease mining
            }
            //Else, if the miner has still has energy then..
            return false; //Return true to continue mining
        }
    }
}