using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace AICore
{
    public class EnemyAI : AIAgentBase
    {
        public EnemyBase EnemyBase;
        public List<GameObject> waypoints;
        [SerializeField] private int waypointIndex;
        [SerializeField] protected float moveSpeed; // patrol speed
        [SerializeField] protected float chaseSpeed;// chasing the player
        [SerializeField] private float waitSec = 1.0f;
        public float chaseTimeSec = 10.0f;
        public float attackRange;// take distance from target
        public bool alerted, chasingPlayer, patrolling;

        protected override void Start()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            _navAgent.speed = moveSpeed;
            waypointIndex = 0;
            patrolling = true;
            if (_curTarget.GetTargetType == TargetType.None )
            {
                NextPoint();
            }

        }
        void Update()
        {
            if (patrolling)
            {
                //Debug.Log(navAgent.remainingDistance);
                Patroling();
            }
            if (chasingPlayer)
            {
                Chase();
            }


        }
        public void Patroling()//patrol from point to point
        {
            if (_visualTarget.GetTargetType != TargetType.Visual)
            {
                if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)
                {
                    StartCoroutine(NextPoint());
                    
                }
            }
            else
            {
                chasingPlayer = true;
                patrolling = false;
               // StartCoroutine(StopChase(10));
            }
        }

        IEnumerator NextPoint()//sets the next patrol point
        {

            //Debug.Log("set dest");
            _curTarget.Set(waypoints[waypointIndex].transform.position, waypoints[waypointIndex].GetComponent<Collider>(),
                        Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position),
                        Time.time, TargetType.Waypoint);
            waypointIndex = (waypointIndex + 1) % waypoints.Count();
            yield return new WaitForSeconds(waitSec);
            _navAgent.SetDestination(_curTarget.GetPosition);
        }

        public void Chase() //chase after the player and attack when they can
        {
            if(_visualTarget.GetTargetType == TargetType.Visual)
            {
                _navAgent.SetDestination(_visualTarget.GetPosition);
                //if close enough to the player attack
                if (Vector3.Distance(_visualTarget.GetPosition, _navAgent.gameObject.transform.position)<= attackRange)
                {
                    EnemyBase.Attack();
                }
                
            }
            else if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)
            {
                StartCoroutine(Looking());
                if(!chasingPlayer)
                {
                    _navAgent.SetDestination(_curTarget.GetPosition);
                    patrolling = true;
                }
                    
                
            }
            
        }

        IEnumerator StopChase(int time)
        {
            _navAgent.speed = chaseSpeed;
            yield return new WaitForSeconds(time);
            chasingPlayer = false;
            yield return StartCoroutine(Looking());
            patrolling = true;
            yield return null;
        }
        IEnumerator Looking()// stops and looks for the player if see player chase, if not patrol
        {
            //animation
            
            Debug.Log("looking one way");
            
            gameObject.transform.Rotate(0, .25f, 0, Space.Self);
            if (_visualTarget.GetTargetType != TargetType.Visual)
            {
                
                Debug.Log("looking the other");
                gameObject.transform.Rotate(0, -.5f, 0, Space.Self);
                if (_visualTarget.GetTargetType != TargetType.Visual)
                {
                   
                   
                    chasingPlayer = false;
                    
                }
                else
                {
                    
                    chasingPlayer = true;
                }
            }
            else
            {
                
                chasingPlayer = true;
            }
                yield return null;
        }
    }
}
