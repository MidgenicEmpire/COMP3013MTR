using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask isGround, isPlayer;

    public Animator enemyAnimator;

    //Patroling
    public Vector3 walkPoint;
    bool hasWalkPoint;
    public float walkRange;

    //Enemy Attack
    public float attackRate;
    bool hasAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }


    //Updates each 
    private void Update()
    {
        //Checks to see if the player is within sight of the enemy
        playerInRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);


        if(!playerInRange && !playerInAttackRange)
        {
            Patroling();
        }



    }

    private void Patroling()
    {

    }


    private void chasePlayer()
    {

    }

    private void attackPlayer()
    {

    }





}
