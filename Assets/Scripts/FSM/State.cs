using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : BaseState //Derived class from BaseState
    {
        public List<FSMAction> Action = new List<FSMAction>();
        public List<Transition> Transitions = new List<Transition>();

        public override void Execute(BaseStateMachine machine)
        {
            foreach (var action in Action) //For each action in the Action list...
                action.Execute(machine); //Execute the state's actions

            foreach (var transition in Transitions) //For each transition in the transition list...
                transition.Execute(machine); //Executes a transition between states
        }
    }
}