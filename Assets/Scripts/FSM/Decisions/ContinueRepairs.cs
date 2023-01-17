using blackboard;
using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/ContinueRepairs")]
    public class ContinueRepairs : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            IndividualAutomatonBB _auto = stateMachine._blackboard.GetCurrentRepairTarget();
            if (_auto.GetStat(1) == 0) //If automaton is not broken down then...
            {
                stateMachine._blackboard.UpdateDestination(0); //Updates miner destination to the mine
                stateMachine._blackboard.UpdateCurrentThought("Returning to Mine"); //Sets current miner thought
                return false; //Return false to cease repairs
            }
            //Else, if the automaton is not repaired then...
            stateMachine._blackboard.UpdateCurrentThought("Repairing " + _auto.gameObject.name); //Sets current miner thought
            return true; //Return true to continue repairs
        }
    }
}