using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float chaseDistance = 20f;
    [SerializeField] float turnSpeed = 5f;
    
    private PlayerStats target;
    private NavMeshAgent navMeshAgent;
    private Animator anim;
    private EnemyHealth enemyHealth;
    
    bool isProvoked = false;
    float distanceBetweenTarget;
    private bool isAttacking = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        target = FindObjectOfType<PlayerStats>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    
    private void OnEnable()
    {
        enemyHealth.OnDamageTaken += Provoke;
    }
    private void OnDisable()
    {
        enemyHealth.OnDamageTaken -= Provoke;
    }
    void Update()
    {
        if(target != null)
            CalculateChase();
    }
    
    private void CalculateChase()
    {
       distanceBetweenTarget = Vector3.Distance(transform.position, target.transform.position);
       
        if (isProvoked)
            EngageTarget();
        else if (chaseDistance >= distanceBetweenTarget)
        {
            isProvoked = true;
        }
            
    }
    
    private void EngageTarget()
    {
        FaceTarget();
        navMeshAgent.stoppingDistance = 3;
        if(navMeshAgent.stoppingDistance < distanceBetweenTarget)
        {
            if (isAttacking) return;
            ChaseTarget();
        }
        else if(navMeshAgent.stoppingDistance >= distanceBetweenTarget)
        {
            AttackTarget();
        }
    }
    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
        anim.SetBool("isMoving", true);
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }
    
    private void AttackTarget()
    {
        if (target != null)
        { 
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            Debug.Log("Attacking!!");
        }
      
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(165, 143, 221, 255f);
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }
    
    private void Provoke()
    {
        isProvoked = true;
    }
    
    private void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void StopAttacking()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", false);
    }
}
