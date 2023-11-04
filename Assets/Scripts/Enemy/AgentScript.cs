using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform destinationPoint;

    private void Update()
    {
        agent.SetDestination(destinationPoint.position);
    }
}
