using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Decisions/KeepWalking")]
    public class KeepWalkingDecision: Decision
    {
        public override bool Decide(BaseStateMachine stateMachine)
        {
            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>(); //Obtains navMeshAgent of the miner
            //If miner has reached its destination then...
            if (!navMeshAgent.pathPending)
            {
                if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
                {
                    if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
                    {
                        navMeshAgent.ResetPath(); //Removes the miner's destination
                        return false; //Returns false to cease walking and enter next action
                    }
                }
            }
            //Else, if the miner has not arrived at its destination then...
            return true; //Return true to continue pathing
        }
    }
}