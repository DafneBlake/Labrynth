using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;


    void Start()
    {
        agent.SetDestination(destination.position);
    }
}