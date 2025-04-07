using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI; //navmesh

namespace AICore 
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class AIAgentBase : MonoBehaviour
    {
        //protected = can only be accessed by children of this class
        [SerializeField, Range (0f, 360f)] protected float _fov = 60f;
        //percentage of sphereCollider
        [SerializeField, Range(0f, 1f)] protected float _sightRange = 1f;

        [SerializeField] protected AISensor _sensor;
        [SerializeField] private AITrigger _trigger;
        //shell we can adapt as neccessary
        [SerializeField] protected Target _curTarget = new Target();
        [SerializeField] protected Target _visualTarget = new Target();

        protected NavMeshAgent _navAgent;
        protected bool _hasReachedDestination = false;

        public AITrigger GetAITrigger { get { return _trigger; }  }
        public NavMeshAgent GetNavAgent { get { return _navAgent; } }
        public bool HasReachedDest { get { return _hasReachedDestination; }
            set { _hasReachedDestination = value; } }
        public Target GetCurrTarget { get { return _curTarget; } }

        public Vector3 GetSensorPosition
        {
            get
            {
                if(_sensor == null) //can't return null vor V3s
                {
                    return Vector3.zero;
                }

                Vector3 pos = _sensor.transform.position;
                pos.x += _sensor.GetSphereCollider.center.x 
                    * _sensor.transform.lossyScale.x;
                //lossyscale? - true scale in regard to local/parent adjustments

                pos.y += _sensor.GetSphereCollider.center.y
                    * _sensor.transform.lossyScale.y;
                pos.z += _sensor.GetSphereCollider.center.z
                    * _sensor.transform.lossyScale.z;

                return pos;
            }
        }

        public float GetSensorRadius
        {
            get
            {
                if( _sensor == null) return 0f;

                float sensorRadius = _sensor.GetSphereCollider.radius;

                float radius = Mathf.Max(sensorRadius * _sensor.transform.lossyScale.x,
                    sensorRadius * _sensor.transform.lossyScale.y);

                return Mathf.Max(radius, sensorRadius * _sensor.transform.lossyScale.z);
            }
        }

        protected virtual void Start()
        {
            _navAgent = GetComponent<NavMeshAgent>();
        }

        public void OnSensorEvent(TriggerEventType tet, Collider other)
        {
            if(other == null || tet == TriggerEventType.Exit) //ignore/not seen
            {
                return;
            }

            if (other.CompareTag("Player"))
            {
                if (IsColliderVisible(other))
                {
                    Debug.Log("I see the player");
                    _visualTarget.Set(other.transform.position, other,
                        Vector3.Distance(transform.position, other.transform.position),
                        Time.time, TargetType.Visual);
                }
            }
        }

        public void AssessTargets()
        {
            //visual target takes precedence
            if(_visualTarget != null && _visualTarget.GetTargetType == TargetType.Visual)
            {
                SetTarget(_visualTarget.GetPosition, _visualTarget.GetCollider,
                    _visualTarget.Distance, _visualTarget.GetTime, _visualTarget.GetTargetType);
            }
            else if (_curTarget.GetTargetType != TargetType.Waypoint) //keep waypoint
            {
                _curTarget.Clear();
            }
        }

        protected virtual void FixedUpdate()
        {
            ClearTargets();
        }

        protected void ClearTargets()
        {
            _visualTarget.Clear();
        }

        public void SetTarget(Vector3 p, Collider c, float d, float t, TargetType tt)
        {
            _curTarget.Set(p, c, d, t, tt);
            _trigger.transform.position = _curTarget.GetPosition;
        }

        //Can we see the thing
        protected bool IsColliderVisible(Collider other)
        {
            Vector3 dir = other.transform.position - GetSensorPosition; //eye pos
            float angle = Vector3.Angle(transform.forward, dir);

            if(angle > _fov * 0.5f) //outside fov
            {
                return false;
            }

            RaycastHit hit;
            if (Physics.Raycast(GetSensorPosition, dir.normalized, out hit, 
                _sightRange * GetSensorRadius))
            {
                if(hit.collider == other)
                {
                    return true;
                }
            }

            return false;
        }
        //VVVcomment this part out for building purposesVVV
        private void OnDrawGizmos()
        {
            if(_sensor == null) return;

            Color color = new Color(1f, 0f, 0f, 0.7f);
            Handles.color = color;

            //get forward direction, and use fov angle for an arc
            Vector3 rotatedForward = Quaternion.Euler(0f, -_fov * 0.5f, 0f) * transform.forward;
            Handles.DrawSolidArc(GetSensorPosition, Vector3.up,
                rotatedForward, _fov, GetSensorRadius * _sightRange);
        }
    }
}
