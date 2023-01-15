using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepSleeping")]
    public class KeepSleepingDecision : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            if (stateMachine._blackboard.GetStat(2) <= 0) //If the miner has fully slept then...
            {
                stateMachine._blackboard.UpdateStat(2, 0); //Prevents tiredness becomming a negative value
                stateMachine._blackboard.UpdateDestination(0); //Set's agent destination to the mine
                if (stateMachine._blackboard.GetStat(6) == 0){ //If rent has not been payed then...
                    stateMachine._blackboard.IncrementStat(1, -stateMachine._blackboard.GetStat(5)); //Decreases banked gold by rent
                    stateMachine._blackboard.UpdateStat(6, 1); } //Marks rent as payed
                stateMachine._blackboard.UpdateCurrentThought("Returning to Mine"); //Sets current miner thought
                return false; //Return false to cease sleeping
            }
            //Else, if the miner is still tired then...
            stateMachine._blackboard.UpdateCurrentThought("Sleeping. Tiredness -1"); //Sets current miner thought
            return true; //Return true to continue sleeping
        }
    }
}