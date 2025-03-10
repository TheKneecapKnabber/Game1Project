using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AICore
{
    public class AIAgentBase : MonoBehaviour
    {
        [SerializeField, Range(0f, 360f)] protected float _fov = 60f;
        [SerializeField, Range(0f, 1f)] protected float _sightRange = 1f;
        
        protected NavMeshAgent _agent;
        protected bool _hasReachedDest = false;
    }
}

