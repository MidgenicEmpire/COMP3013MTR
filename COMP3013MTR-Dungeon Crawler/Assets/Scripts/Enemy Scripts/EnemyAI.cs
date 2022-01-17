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

    public int enemyWeaponDamage;

    Animator enemyAnimator;

<<<<<<< Updated upstream
=======
    //Sound


   

>>>>>>> Stashed changes
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
    public GameObject weapon;

    //States
    public float sightRange, attackRange;
    public bool playerInRange, playerInAttackRange;



    //instatiates a Hitbox Script
    //HitboxScript hitScript;
    //PlayerHealth playerDmg;

   
    private void Start()
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
        Vector3 rotationPoint = new Vector3(player.transform.position.x, 0, player.transform.position.z);

        //Checks to see if the player is within sight of the enemy
        playerInRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

         //chasePlayer(); For testing


        if (!playerInRange && !playerInAttackRange)
        {
            Idle(); 
        }
        if(playerInRange && !playerInAttackRange)
        {
            //Debug.Log("Wwaaawwaaa wweeeewaaaa I'mm seeing a thinggsdf");
            Alert(rotationPoint);
           chasePlayer();
            enemyAnimator.SetBool("isAttack", false);
        }
        if(playerInRange && playerInAttackRange)
        {
            //Debug.Log("Wwaaawwaaa wweeeewaaaa I'mm attacking a thinggsdf");
            attackPlayer(rotationPoint);
        }
    }
    //Enemy Alert
    private void Alert(Vector3 rotP)
    {
        transform.LookAt(rotP);
        enemyAnimator.SetBool("isAlert", true);
    }

    private void Idle()
    {
        enemyAnimator.SetBool("isIdle", true);
        enemyAnimator.SetBool("isWalk", false);
    }

    //-------------------------------------------STRETCH GOAL-----------------------------------//
    //Enemy patroling script
    //private void Patroling()
    //{
    //    Debug.Log("I'm walkin ere");

    //    enemyAnimator.SetBool("isWalk", true);

    //    if (!hasWalkPoint)
    //    {
    //        SearchWalkPoint();
    //    }
    //    if (hasWalkPoint)
    //    {
    //        //enemyAnimator.SetBool("isWalk", true);
    //        agent.SetDestination(walkPoint);
    //    }

    //    Vector3 distanceToPoint = transform.position - walkPoint;

    //    //If the enemy reaches the walk point
    //    if(distanceToPoint.magnitude < 1f)
    //    {
    //        hasWalkPoint = false;
    //    }

    //}
    //private void SearchWalkPoint()
    //{
    //    //Calculates a random point in range
    //    float randomZPoint = Random.Range(-walkRange, walkRange);
    //    float randomXPoint = Random.Range(-walkRange, walkRange);

    //    walkPoint = new Vector3(transform.position.x + randomXPoint,
    //        transform.position.y, transform.position.z + randomZPoint);

    //    //Checks to see if the point is on the ground
    //    if (Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
    //    {
    //        hasWalkPoint = true;
    //    }
    //}



    private void chasePlayer()
    {
        //gets the position of the player and makes it a walk point
        agent.SetDestination(player.position);

        agent.speed = 3.5f;
        enemyAnimator.SetBool("isWalk", true);

        //if (distance <= lookRadius)
        //{
        //    enemyAnimator.SetBool("isWalk", true);
        //    agent.SetDestination(player.position);

        //    if (distance <= agent.stoppingDistance)
        //    {
        //        targetFace();
        //        Debug.Log("detecting player");
        //    }
        //}


    }

    void targetFace()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion look = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, look, Time.deltaTime * 5f);
    }


    private void attackPlayer(Vector3 rotP)
    {
        Debug.Log("is attacking player");
        //ensures that when the enemy attacks the enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(rotP);

        //checks to see if the enemy attacked
        if (!hasAttacked)
        {
            //Test attack code
            enemyAnimator.SetBool("isWalk", false);
            enemyAnimator.SetBool("isAttack", true);

            hasAttacked = true;
            //acts as a deley
            Invoke(nameof(ResetAttack), attackRate);
        }

    }

    private void ResetAttack()
    {
        hasAttacked = false;
        Debug.Log("Resetting attack");
    }
}
