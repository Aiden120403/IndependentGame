using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBackup : MonoBehaviour
    //just a heads up this code may be incomplete or have parts of it that are incomplete, that can be removed
{
    public GameObject player;
    NavMeshAgent myNavMeshAgent;
    public Transform[] waypoints;
    int currentWaypoint = 0;
    public float ChaseDistance = 10.0f;
    bool isChasing = false;
    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.SetDestination(waypoints[0].position);
        if (myNavMeshAgent.remainingDistance < 0.5f)
        {
            GoToNextWaypoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < ChaseDistance)
        {
            myNavMeshAgent.SetDestination(player.transform.position);
            isChasing = true;
        }
        else if (isChasing)
        {
            myNavMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
        myNavMeshAgent.SetDestination(player.transform.position);
    }
    void GoToNextWaypoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        myNavMeshAgent.SetDestination(waypoints[currentWaypoint].position);
    }

}