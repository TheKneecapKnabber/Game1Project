using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
public class Guard : EnemyBase, IPatrol, ILook, IChase
{
    //needed for movement
    private NavMeshAgent navAgent;

    //needed patrol variables
    public List<Transform> waypoints;
    [SerializeField] private int waypointIndex;
    private int indexLimit;// how high the index can be before reset to 0
   
    //needed for attack with ranged weapon
    Transform shootPoint;
    

    void Start()
    {
        indexLimit = waypoints.Count();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = moveSpeed;
        waypointIndex = 0;
        patrolling = true;
         
    }
    void Update()
    {
        if (patrolling)
        {
            //Debug.Log(navAgent.remainingDistance);
            Patroling();
        }
        
       
    }
    public void NextPoint()//sets the next patrol point
    {
        waypointIndex = (waypointIndex + 1) % waypoints.Count();
        navAgent.SetDestination(waypoints[waypointIndex].position);
    }
    public void Patroling()//patrol from point to point
    {
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {

            NextPoint();
        }
    }
    public void Chase(Vector3 player) // chase after the player until you can attack
    {
        navAgent.speed = chaseSpeed;
        chasingPlayer = true;
        StartCoroutine(StopChase(10));
        navAgent.SetDestination(player);
        if (navAgent.remainingDistance <= attackRange)
        {
            Attack();
        }
        
    }
    public void LookingForPlayer(Vector3 player) //go to last known location of the player and looks around
    {

    }
    IEnumerator StopChase(int time)
    {
        yield return new WaitForSeconds(time);
        chasingPlayer = false;
        patrolling = true;
        yield return null;
    }
    public override void Attack() 
    {
        Debug.Log("Attack");
    }
}
