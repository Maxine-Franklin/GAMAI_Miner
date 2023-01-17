using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepUnloading")]
    public class KeepUnloading : Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            stateMachine._blackboard.IncrementStat(6, 1); //Increases unloading numerator by 1
            int _autoMinedGold = stateMachine._blackboard._GetStat(0);
            if (_autoMinedGold <= 0) //If automined gold is less than or equal to 0 then...
            {
                stateMachine._blackboard.IncrementStat(0, _autoMinedGold); //Increment mined gold by automined gold to remove any potential bonus gold
                _autoMinedGold += 3; //Increases automined gold by numerator to represent change of less than numerator
                stateMachine._blackboard.UpdateCurrentThought("Unloading Autominer. Gold +" + _autoMinedGold); //Sets current miner thought
                stateMachine._blackboard._UpdateStat(0, 0); //Set automined gold to 0
                return false; //Stop unloading
            }
            else if (stateMachine._blackboard. GetStat(11) >=5) //If unloading has cycled 5 or more times then...
            {
                stateMachine._blackboard.UpdateStat(9, 0); //Reset numerator
                stateMachine._blackboard.UpdateCurrentThought("Unloading Autominer. Gold +3"); //Sets current miner thought
                return false; //Stop unloading
            }
            //Else, if there is still more to unload and numeration cycles left, then...
            stateMachine._blackboard.UpdateCurrentThought("Unloading Autominer. Gold +3"); //Sets current miner thought
            return true; //Keep unloading
        }
    }
}