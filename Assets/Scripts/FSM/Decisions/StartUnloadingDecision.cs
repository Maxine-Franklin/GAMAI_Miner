using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/StartUnloading")]
    public class StartUnloading : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            int n = Random.Range(0, 101); //Generates a random numerator between 0-100
            //Debug.Log(" n Bed: " + n); //Outputs the numerator value to debug log for debugging purposes
            if (n < stateMachine._blackboard.GetStat(8)){ //If numerator is less than unloading desire value then...
                stateMachine._blackboard.UpdateCurrentThought("Unloading Autominer"); //Sets current miner thought
                return true; //Return true to go to unload autominer
            }

            //Else
            return false; //Return true to continue mining
        }
    }
}