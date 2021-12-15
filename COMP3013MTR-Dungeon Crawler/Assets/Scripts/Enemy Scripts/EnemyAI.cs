using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public float lookRadius = 10f;

    public LayerMask isGround, isPlayer;

    Animator enemyAnimator;

    //Holds the distance between the object and the player
    float distance;

    //Patroling
    public Vector3 walkPoint;
    bool hasWalkPoint;
    public float walkRange;

    //Alert
    bool isAlert;

    //Enemy Attack
    public float attackRate = 0.1f;
    bool hasAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInRange, playerInAttackRange;


    //instatiates a Hitbox Script
    HitboxScript hitScript;
    PlayerHealth playerDmg;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void getLocation()
    {
        distance = Vector3.Distance(player.position, transform.position);
    }


    //Updates each frame
    private void Update()
    {
        

        //Checks to see if the player is within sight of the enemy
        playerInRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

         //chasePlayer();


        if (!playerInRange && !playerInAttackRange)
        {
            Debug.Log("Wwaaawwaaa wweeeewaaaa I'mm searching for a tthing");
            //Idle();
            //Patroling();
        }
        if(playerInRange && !playerInAttackRange)
        {
            Alert();
        }
        if(playerInRange && playerInAttackRange)
        {
            attackPlayer();
        }
    }
    //Enemy Alert
    private void Alert()
    {
        transform.LookAt(player);
        enemyAnimator.SetBool("isAlert", true);
    }

    //private void Idle()
    //{
    //    enemyAnimator.SetBool("isIdle", true);
    //}

    //Enemy patroling script
    private void Patroling()
    {
        if (!hasWalkPoint)
        {
            SearchWalkPoint();
        }
        if (hasWalkPoint)
        {
            enemyAnimator.SetBool("isWalk", true);
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToPoint = transform.position - walkPoint;

        //If the enemy reaches the walk point
        if(distanceToPoint.magnitude < 1f)
        {
            hasWalkPoint = false;
        }



    }
    private void SearchWalkPoint()
    {
        //Calculates a random point in range
        float randomZPoint = Random.Range(-walkRange, walkRange);
        float randomXPoint = Random.Range(-walkRange, walkRange);

        walkPoint = new Vector3(transform.position.x + randomXPoint, 
            transform.position.y, transform.position.z + randomZPoint);

        //Checks to see if the point is on the ground
        if(Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            hasWalkPoint = true;
        }
    }



    private void chasePlayer()
    {
        //gets the position of the player and makes it a walk point
        //agent.SetDestination(player.position);

        if (distance <= lookRadius)
        {
            enemyAnimator.SetBool("isWalk", true);      
            agent.SetDestination(player.position);

            if (distance <= agent.stoppingDistance)
            {
                targetFace();
                Debug.Log("detecting player");
            }
        }

    }

    void targetFace()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 5f);
    }


    private void attackPlayer()
    {
        //ensures that when the enemy attacks the enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        //checks to see if the enemy attacked
        if (!hasAttacked)
        {

            //Test attack code
            enemyAnimator.SetBool("isAttack", true);           
            this.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);       

            hasAttacked = true;
            //acts as a deley
            Invoke(nameof(ResetAttack), attackRate);
        }

    }



    private void ResetAttack()
    {
        hasAttacked = false;
    }
}
