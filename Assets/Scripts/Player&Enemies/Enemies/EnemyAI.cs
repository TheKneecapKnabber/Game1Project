using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AICore
{
    public class EnemyAI : AIAgentBase
    {
        public EnemyBase EnemyBase;
        public List<Transform> waypoints;
        [SerializeField] private int waypointIndex;
    }
}
