using blackboard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/RepairingAutomaton")]
    public class RepairingAutomaton : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            IndividualAutomatonBB _auto = stateMachine._blackboard.GetCurrentRepairTarget(); //Obtains current repair target
            _auto.UpdateStat(1, 0); //Sets automaton to not be broken down anymore
            _auto._IncrementStat(3, -1); //Decreases amount of logged breakdowns by one
            stateMachine._blackboard.RemoveBrokenDownAutomaton(); //Remove repair target from list of broken down automatons
        }
    }
}