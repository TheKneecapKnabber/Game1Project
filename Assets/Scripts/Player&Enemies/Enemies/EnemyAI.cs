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
        [SerializeField] private float waitSec = 2.7f;
        public float chaseTimeSec = 10.0f;
        public float attackRange;// take distance from target
        [SerializeField] private bool foundPlayer, chasingPlayer, patrolling;//state bools
        private bool lookingForPlayer, gettingNextPoint;//bools to prevent multiple corutines from starting
        [SerializeField] private Animator animator;

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
        public Vector3 GetVisualTargetPosition { get { return _visualTarget.GetPosition; } }
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
        #region patrolling
        public void Patroling()//patrol from point to point
        {
            if (_visualTarget.GetTargetType != TargetType.Visual)
            {
                _navAgent.speed = moveSpeed;
                if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)
                {
                    if (!gettingNextPoint)
                    StartCoroutine(NextPoint());
                    
                }

            }
            else
            {
                chasingPlayer = true;
                patrolling = false;
                //remove walk
                animator.SetBool("Walk", false);
                
                // StartCoroutine(StopChase(10)); //enemy tires out
            }
        }

        IEnumerator NextPoint()//sets the next patrol point
        {

            //Debug.Log("set dest");
            _curTarget.Set(waypoints[waypointIndex].transform.position, waypoints[waypointIndex].GetComponent<Collider>(),
                        Vector3.Distance(transform.position, waypoints[waypointIndex].transform.position),
                        Time.time, TargetType.Waypoint);
            waypointIndex = (waypointIndex + 1) % waypoints.Count();
            //remove walk
            animator.SetBool("Walk", false);
            //set idle
            animator.SetBool("Idle", true);

            yield return new WaitForSeconds(waitSec);
            //remove idle
            animator.SetBool("Idle", false);
            //set walk
            animator.SetBool("Walk", true);
            _navAgent.SetDestination(_curTarget.GetPosition);
        }
        #endregion
        
        public void Chase() //chase after the player and attack when they can
        {

            //set run
            animator.SetBool("Run", true);
            _navAgent.speed = chaseSpeed;
            if (_visualTarget.GetTargetType == TargetType.Visual)
            {
                _navAgent.SetDestination(_visualTarget.GetPosition);
                //if close enough to the player attack
                if (Vector3.Distance(_visualTarget.GetPosition, _navAgent.gameObject.transform.position)<= attackRange)
                {
                    EnemyBase.Attack();
                }
                
            }
            else if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)//move to last known player location
            {
                
                if (!lookingForPlayer)//so it doesn't call corutine multiple times
                {
                    //Debug.Log("start looking");
                    lookingForPlayer = true;
                    StartCoroutine(Looking());
                }
                
                if (!chasingPlayer)
                {
                    _navAgent.SetDestination(_curTarget.GetPosition);
                    patrolling = true;
                    _navAgent.speed = moveSpeed;

                }
                
                
            }
            
        }
        
        IEnumerator Looking()// stops and looks for the player if see player chase, if not patrol
        {

            //animation
            

                chasingPlayer = false;
            //set run false
            animator.SetBool("Run", false);
            Vector3 startRot = _navAgent.transform.rotation.eulerAngles;
             Debug.Log("looking one way");

            //trigger turn right
            animator.SetTrigger("LookRight");
            while (!foundPlayer)
            {
                    
                if (_visualTarget.GetTargetType == TargetType.Visual)//check for the player
                {
                    foundPlayer = true;
                    chasingPlayer = true;
                    animator.SetBool("Run", true);
                    break;
                }
                    
  
                gameObject.transform.Rotate(0, 15f * Time.deltaTime, 0);
                Debug.Log("turning");
                
                if ((_navAgent.transform.rotation.eulerAngles - startRot).y >= 90f)
                {
                    //Debug.Log("done first turn");
                    //patrolling = true;
                    break; //move on
                }//rotation compared to starting rotation is 90 degrees
                yield return null;

            }



            //Debug.Log("looking the other");
            //trigger turn left
            //animator.SetTrigger("LookLeft");

            while (!foundPlayer)
            {
                    
                if (_visualTarget.GetTargetType == TargetType.Visual)//check for the player
                {
                    foundPlayer = true;
                    chasingPlayer = true;
                    animator.SetBool("Run", true);
                    break;
                }

                // Debug.Log("turning other");
                gameObject.transform.Rotate(0, -15f * Time.deltaTime, 0); //rotate the other way
                if ((_navAgent.transform.rotation.eulerAngles - startRot).y <= -90f)
                {
                    chasingPlayer = false;
                    patrolling = true;
                    animator.SetBool("Walk", true);
                    break; //move on
                }//rotation compared to starting rotation is 90 degrees
                yield return null;

            }

            //Debug.Log("going back");
            //reset for next call
            foundPlayer = false;
            lookingForPlayer = false;

            


            //Debug.Log("done");
        }

    }
}
