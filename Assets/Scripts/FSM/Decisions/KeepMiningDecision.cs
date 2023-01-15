using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepMining")]
    public class KeepMiningDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            /*//NOTE: Change if statement to 'if (state.minedGold >= 5 || state.tiredness >= 6) //If the miner has mined 5 or more gold or has reached 6 or more tiredness then...'
            //if (stateMachine.minedGold >= 5) //If the miner has mined 5 or more gold then...
            if (stateMachine._blackboard.GetStat(0) >= 5) //If the miner has mined 5 or more gold then...
            {
                stateMachine._blackboard.UpdateDestination(1); //Updates miner destination to the bank
                return false; //Return false to cease mining
            }*/

            int n = Random.Range(0, 101); //Generates a random numerator between 0-100
            Debug.Log("n Bank: " + n); //Outputs the numerator value to debug log for debugging purposes
            if (n < stateMachine._blackboard.GetStat(3))
            { //If numerator is less than banking desire value then...
                stateMachine._blackboard.UpdateDestination(1); //Updates miner destination to the home
                stateMachine._blackboard.UpdateCurrentThought("Heading to Bank"); //Sets current miner thought
                return false; //Return false to cease mining
            }

            //Else, if the miner has mined less than 5 gold then...
            return true; //Return true to continue mining
        }
    }
}