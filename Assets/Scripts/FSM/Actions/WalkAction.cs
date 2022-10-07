using System.Collections;
using System.Collections.Generic;
using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace MyFSM
{
    [CreateAssetMenu(menuName = "FSM/Actions/WalkAction")]
    public class WalkAction : FSMAction
    {
        public string Destination; //The walk destination
        public GameObject[] wayPoints; //The way point(s) taken to reach a destination
        public override void Execute(BaseStateMachine stateMachine)
        {
            if (wayPoints[1] == null)
                Debug.Log("PATHING ERROR: No Final Destination");

            //Add Actual Walking Code
            

            //var navMeshAgent = stateMachine.GetComponent<NavMeshAgent>();
            //var walkPoints = stateMachine.GetComponent<WalkPoints>();

            //if (walkPoints.HasReached(NavMeshAgent))
            //    navMeshAgent.Set
        }
    }
}