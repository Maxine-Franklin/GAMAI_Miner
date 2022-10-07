using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/Transition")]
    public sealed class Transition : ScriptableObject
    {
        public Decision Decision;
        public BaseState trueState; //A state to transition too if the decision is true
        public BaseState falseState; //A state to transition too if the decision is false

        public void Execute(BaseStateMachine stateMachine)
        {
            if (Decision.Decide(stateMachine) && !(trueState is RemainInState)) //If the decision is true and the true state is not the remain state...
                stateMachine.currentState = trueState; //Transitions to the true state condition
            else if (!(falseState is RemainInState)) //If the decision is false and the false state is not the remain state...
                stateMachine.currentState = falseState; //Transitions to the false state condition
        }
    }
}