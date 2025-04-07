using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPatrol 
{
    //patrolpoint list
    //patrol index
    IEnumerator Patrol(List<Transform> waypoints, int waypointIndex) 
    {
        yield return null;
    }

}
