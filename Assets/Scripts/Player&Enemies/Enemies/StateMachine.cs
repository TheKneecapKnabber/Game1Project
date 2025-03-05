using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class StateMachine : MonoBehaviour

{

    public enum State
    {
        Idle,
        Chase,
        Patrol
    }

    public State currentState;
    public float moveSpeed;
    public float detectionRange;
    public Transform player;
    private Coroutine activeCoroutine;
    public List<Transform> patrolPoints = new List<Transform>();
    public int currentPoint;
    public int patrolThreshold;

    // Start is called before the first frame update
    void Start()
    {
        currentState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= detectionRange) //distance less than treshold?
        {
            ChangeState(State.Chase);
        }
        else
        {
            ChangeState(State.Chase);
        }
    }

    void ChangeState(State newState)
    {
        if (currentState == newState) return; //

        currentState = newState;

        if(activeCoroutine != null) StopCoroutine(activeCoroutine);
        switch (currentState)
        {
            case State.Idle:
                activeCoroutine = StartCoroutine(DoIdle());
                break;
            case State.Chase:
                activeCoroutine = StartCoroutine(DoChase());
                break;
            case State.Patrol:
                activeCoroutine = StartCoroutine(DoPatrol());
                break;
        }
    }

    public IEnumerator DoIdle()
    {
        //nothing
        yield return null;
    }

    public IEnumerator DoChase()
    {
        while (true)
        {
            Vector3 toPlayer = (player.position - transform.position).normalized;
            transform.position += toPlayer * moveSpeed * Time.deltaTime;
            yield return null;
        }

    }

    public IEnumerator DoPatrol()
    {
        //patrol stuff idk
        while (true)
        {
            Vector3 toTarget = (patrolPoints[currentPoint].position - transform.position).normalized;

            while (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) > patrolThreshold)
            {
                transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            currentPoint = (currentPoint + 1) % patrolPoints.Count;
            yield return null;
        }
        
    }

}
