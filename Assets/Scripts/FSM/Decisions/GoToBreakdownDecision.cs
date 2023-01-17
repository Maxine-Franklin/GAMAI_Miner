using System.Collections;
using System.Collections.Generic;
using blackboard;
using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/GoToBreakdown")]
    public class GoToBreakdownDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            int n = Random.Range(0, 101); //Generates a random numerator between 0-100
            if (n < stateMachine._blackboard.GetStat(9)){ //If numerator is less than repair desire value then...
                IndividualAutomatonBB _auto = stateMachine._blackboard.GetBrokenDownAutomaton();
                stateMachine._blackboard.UpdateDestination(_auto.gameObject.transform.position); //Updates miner destination to the oldest broken down automaton

                stateMachine._blackboard.UpdateCurrentThought("Going to repair " + _auto.gameObject.name); //Sets current miner thought

                return true; //Return false to cease mining
            }

            //Else, if the miner has still has energy then..
            return false; //Return true to continue mining
        }
    }
}