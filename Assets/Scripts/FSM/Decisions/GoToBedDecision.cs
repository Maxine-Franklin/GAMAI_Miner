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
            int n = Random.Range(0, 101); //Generates a random numerator between 0-100
            //Debug.Log(" n Bed: " + n); //Outputs the numerator value to debug log for debugging purposes
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