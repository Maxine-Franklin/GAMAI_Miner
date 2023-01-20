using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/WalkAction")]
    public class WalkAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>(); //Obtains miner navMeshAgent
            if (!navMeshAgent.hasPath) //If the agent does not have a destination then...
                navMeshAgent.SetDestination(stateMachine._blackboard.GetDestination()); //Set's miner agent destination to stored destination
        }
    }
}