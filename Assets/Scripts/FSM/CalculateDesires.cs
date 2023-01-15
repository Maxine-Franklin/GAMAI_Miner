using UnityEngine;
using blackboard;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/CalculateDesires")]
    public class CalculateDesires : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            int goldMined = stateMachine._blackboard.GetStat(0); //Obtains Gold Mined
            int goldBanked = stateMachine._blackboard.GetStat(1); //Obtains Gold Banked
            int tiredness = stateMachine._blackboard.GetStat(2); //Obtains Tiredness
            int rent = stateMachine._blackboard.GetStat(5); //Obtains Rent

            int overworked = 0; //Overworked state

            float rentProximity = (goldBanked / rent); //Calculates how close the miner is to being able to pay rent
            if (rentProximity > 2f) //If proximity to rent is over 2, then sets proximity to 2
                rentProximity = 2f;
            if (tiredness >= 7) //If tiredness is equal to or greater than 7 then...
                overworked = 1; //Sets overworked to true

            //Debug.Log("goldMined: " + goldMined + "\ngoldBanked: " + goldBanked + "\ntiredness: " + tiredness + "\nrent: " + rent + "\nrentProximity: " + rentProximity + "\nbankDesire: " + Mathf.RoundToInt((goldMined + 0.5f) * 4f * (2.25f - rentProximity) - (1 + tiredness * 1.8f)));

            //Calculates and updates banking desire
            stateMachine._blackboard.UpdateStat(3, Mathf.RoundToInt((goldMined + 0.5f) * 4f * (2.25f - rentProximity) - (1 + tiredness* 1.8f)));
            //Calculates and updates sleeping desire
            stateMachine._blackboard.UpdateStat(4, Mathf.RoundToInt((tiredness + 0.5f) * 3f * rentProximity * (overworked + 0.5f)));
            
            stateMachine._blackboard.UpdateStat(5, overworked); //Updates overworked status

            return; //Returns code execution to caller
        }
    }
}