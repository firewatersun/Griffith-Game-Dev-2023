using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Vector3 playerPosition;

    public GameObject player;

    public float detectionRadius;
    public float alertRadius;
    private bool alert;
    public float alertTimer;
    public float idleSpeed;
    public float chaseSpeed;
    
    private float distanceBetweenMeAndPlayer;
    private int positionNumber;

    public Transform[] patrolPoints;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        positionNumber = Random.Range(0, patrolPoints.Length);
        agent.SetDestination(patrolPoints[positionNumber].transform.position);
        alert = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        distanceBetweenMeAndPlayer = Vector3.Distance(playerPosition, gameObject.transform.position);
            
        if ( distanceBetweenMeAndPlayer <= detectionRadius && alert == false)
        {
            Debug.Log("Found Player");
            agent.speed = chaseSpeed;
            agent.SetDestination(playerPosition);
            alert = true;
            StopCoroutine(AlertTimer());
        }

        if (distanceBetweenMeAndPlayer <= alertRadius && alert == true)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(playerPosition);
            StopCoroutine(AlertTimer());
        }

        if (distanceBetweenMeAndPlayer > alertRadius && distanceBetweenMeAndPlayer > detectionRadius && alert == true)
        {
            agent.speed = idleSpeed;
            StartCoroutine(AlertTimer());
        }

        if (alert == false && agent.remainingDistance<0.1f)
        {

                positionNumber = Random.Range(0, patrolPoints.Length);
                agent.SetDestination(patrolPoints[positionNumber].transform.position);

        }
    }

    IEnumerator AlertTimer()
    {
        yield return new WaitForSeconds(alertTimer);
        alert = false;
        Debug.Log("Lost Player");
    }
}
