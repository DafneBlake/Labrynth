using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NPCFollower : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform transformToFollow;
    [SerializeField] Vector3 sizeOfView;
    [SerializeField] LayerMask whatIsCharacter;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
    }

    void Update()
    {
        FindCharacterToFollow();

        if (transformToFollow == null) { return; }
        
        agent.SetDestination(transformToFollow.position);
    }

    void FindCharacterToFollow()
    {
        if (transformToFollow != null) { return; }

        var characters = Physics.OverlapBox(transform.position, sizeOfView, Quaternion.identity, whatIsCharacter);
        
        if (characters.Length > 0)
        {
            transformToFollow = characters[0].transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, sizeOfView);
    }
}
