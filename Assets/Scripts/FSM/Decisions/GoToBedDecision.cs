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
            /*//NOTE: Change if statement to 'if (state.minedGold >= 5 || state.tiredness >= 6) //If the miner has mined 5 or more gold or has reached 6 or more tiredness then...'
            //if (stateMachine.tiredness >= 7) //If the miner has a tiredness level greater than or equal to 7 then...
            if (stateMachine._blackboard.GetStat(2) >= 7) //If the miner has a tiredness level greater than or equal to 7 then...
            {
                stateMachine._blackboard.UpdateDestination(2); //Updates miner destination to the home
                stateMachine._blackboard.UpdateStat(6, 0); //Marks rent as unpayed
                return true; //Return false to cease mining
            }*/

            int n = Random.Range(0, 101); //Generates a random numerator between 0-100
            Debug.Log(" n Bed: " + n); //Outputs the numerator value to debug log for debugging purposes
            if (n < stateMachine._blackboard.GetStat(4)){ //If numerator is less than sleep desire value then...
                stateMachine._blackboard.UpdateDestination(2); //Updates miner destination to the home
                stateMachine._blackboard.UpdateStat(6, 0); //Marks rent as unpayed

                stateMachine._blackboard.UpdateCurrentThought("Going to Bed"); //Sets current miner thought

                return true; //Return false to cease mining
            }

            //Else, if the miner has still has energy then..
            return false; //Return true to continue mining
        }
    }
}