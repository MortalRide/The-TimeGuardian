using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 25f;
    private Animator animat;  //*
    public float idleSpeed;
    public float walkSpeed; //*
                            // private bool isAware = false;
    public Slider healthbar;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animat = GetComponentInChildren<Animator>();
    }
    

    void Update()
    {
        if(healthbar.value <= 0)
        {
            return;
        }

        float distance = Vector3.Distance(target.position, transform.position);
        agent.SetDestination(target.position);
        if (distance <= lookRadius)
        {        
          Walk();
         

            if (distance <= 5f)
            {
                Attack();
            }
            else
            {
                animat.SetBool("enemyAttack", false);
            }
        }
        else
        {
            Idle();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void Idle()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = true;
        animat.SetBool("Aware", false);
    }
    public void Walk()
    {
        gameObject.GetComponent<NavMeshAgent>().isStopped = false;
        animat.SetBool("Aware", true);
    }
    public void Attack()
    {
        animat.SetBool("enemyAttack", true);
    }
}
