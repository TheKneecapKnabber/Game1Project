using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AICore
{
    [RequireComponent(typeof(SphereCollider))]
    public class AISensor : MonoBehaviour
    {
        [SerializeField] private AIAgentBase _agent;
        [SerializeField] private SphereCollider _collider;

        public SphereCollider GetSphereCollider { 
            get 
            {
                if (_collider == null)
                {
                    _collider = GetComponent<SphereCollider>();
                }
                return _collider; 
            } 
        }

        //we want to make sure that our collider can be a trigger 
        private void Awake()
        {
            GetSphereCollider.isTrigger = true; //sets as trigger automatically

            if(GetComponentInParent<AIAgentBase>() != null)
            {
                _agent = GetComponentInParent<AIAgentBase>();
            }
            else
            {
                Debug.LogError("AI sensor requires parent with AIAgent");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_agent == null) { return; }

            _agent.OnSensorEvent(TriggerEventType.Enter, other); //fix in AIAgentBase script*
        }

        private void OnTriggerStay(Collider other)
        {
            if (_agent == null) { return; }

            _agent.OnSensorEvent(TriggerEventType.Stay, other); 
        }

        private void OnTriggerExit(Collider other)
        {
            if (_agent == null) { return; }

            _agent.OnSensorEvent(TriggerEventType.Exit, other);
        }
    }

    public enum TriggerEventType
    {
        Enter,
        Stay,
        Exit
    }
}
