/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AICore
{
    [RequireComponent(typeof(SphereCollider))]
    public class AITrigger : MonoBehaviour 
    {
        [SerializeField] private AIAgentBase _agent;
        [SerializeField] private SphereCollider _collider;

        private void Awake()
        {
            _collider = GetComponent<SphereCollider>();
            _collider.isTrigger = true;

            //get parent and find component in its children
            if(transform.parent.GetComponentInChildren<AIAgentBase>() != null )
            {
                _agent = transform.parent.GetComponentInChildren<AIAgentBase>();
            }
            else
            {
                Debug.LogError("trigger parent doesn't have an agent in its children");
            }
        }

        public void SetRadius(float r)
        {
            _collider.radius = r;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(_agent == null || other.transform != _agent.transform)
            {
                return; //not my owner
            }

            _agent.HasReachedDest = true;
        }

        private void OnTriggerStay(Collider other) //copied & Pasted
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return; //not my owner
            }

            _agent.HasReachedDest = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (_agent == null || other.transform != _agent.transform)
            {
                return; //not my owner
            }

            _agent.HasReachedDest = false; //false
        }
    }
}*/
