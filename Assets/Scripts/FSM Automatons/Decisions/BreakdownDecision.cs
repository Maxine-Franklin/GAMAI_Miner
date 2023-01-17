using System.Collections;
using System.Collections.Generic;
using FSM;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM_A/Decisions/Breakdown")]
    public class Breakdown : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            //If random percentile is less than automaton breakdown chance, and automaton is not broken down, then...
            if (Random.Range(0, 101) < stateMachine._blackboard._GetStat(3) && stateMachine._blackboard.GetStat(1) == 0) {
                stateMachine._blackboard.UpdateStat(1 + stateMachine._blackboard.GetStat(2), 1); //Set's automaton to be broken down
                stateMachine._blackboard._IncrementStat(3, 1); //Increments the tracker of broken down automatons by 1
                stateMachine._blackboard.AddBrokenDownAutomaton(); //Adds automaton to end of breakdown list
                return true; //Return true to breakdown
            }
            //else, if automaton has not brokendown, then...
            return false;
        }
    }
}