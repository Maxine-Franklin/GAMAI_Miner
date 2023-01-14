using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/WalkAction")]
    public class WalkAction : FSMAction
    {
        //public string Destination; //The walk destination
        //public Transform[] wayPoints; //The way point(s) taken to reach a destination

        public override void Execute(BaseStateMachine stateMachine)
        {
            //if (wayPoints[1] == null)
                //Debug.Log("PATHING ERROR: No Final Destination");
                //return to location to resolve error or exit the program

            var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>(); //Obtains miner navMeshAgent
            if (!navMeshAgent.hasPath) //If the agent does not have a destination then...
                navMeshAgent.SetDestination(stateMachine._blackboard.GetDestination()); //Set's miner agent destination to stored destination

            //Add Actual Walking Code


            //var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            //var walkPoints = stateMachine.GetComponent<WalkPoints>();

            //if (walkPoints.HasReached(NavMeshAgent))
            //    navMeshAgent.Set
        }
    }
}