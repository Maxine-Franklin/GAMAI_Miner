using System.Collections;
using System.Collections.Generic;
using FSM;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM_A/Decisions/RepairedMiner")]
    public class RepairedMiner : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            //If random percentile is less than autominer breakdown chance, then...
            if (stateMachine._blackboard.GetStat(1) == 1 && stateMachine._blackboard.GetStat(2) == 0) {
                stateMachine._blackboard._IncrementStat(3, -1); //Increments the tracker of broken down automatons by -1
                return true; //Return autominer to mining
            }
            //else, if automaton has not been repaired, then...
            return false;
        }
    }
}