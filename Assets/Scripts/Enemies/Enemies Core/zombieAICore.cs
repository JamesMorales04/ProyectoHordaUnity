using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieAICore : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform playerCharacter;

    public LayerMask whatIsGround, whatIsPlayer;

    //Atacando
    public float timeBetweenAttacks;
    private bool isAttacked;

    //Estados
    public float attackRange;
    public bool playerInAttackRange;


    private void Awake()
    {
        playerCharacter = GameObject.Find("ThirdPersonController").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInAttackRange)
        {
            chasePlayer();
        }
        else{
            attackPlayer();
        }
    }

    private void chasePlayer()
    {
        agent.SetDestination(playerCharacter.position);
    }

    private void attackPlayer()
    {
        //Evitar que se mueva al atacar (aunque no si se quedara quieto o no aun)
        agent.SetDestination(transform.position);

        transform.LookAt(playerCharacter);

        if (!isAttacked)
        {
            isAttacked = true;

            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }
    }
    
    private void resetAttack()
    {

        isAttacked = false;
    }

}
