using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator enemyAnimator;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject groundDetector;
    [SerializeField] private float rayDistance;
    private EnemyBehaviour enemyBehaviour;

    private float directionChanger = 1;

    void Awake()
    {
        enemyBehaviour = GetComponent<EnemyBehaviour>();
        enemyAnimator = GetComponent<Animator>();
        enemyBehaviour.enemyState = EnemyState.Patrol;
    }

    void Start()
    {
        Vector3 enemyScale = transform.localScale;
        if (enemyScale.x < Mathf.Epsilon)
        {
            directionChanger = -Mathf.Sign(directionChanger);
        }
    }
    void Update()
    {
        if(enemyBehaviour.enemyState == EnemyState.Patrol)
        {
            PatrolEnemy();
        }
        else if(enemyBehaviour.enemyState == EnemyState.Idle)
        {
            IdleEnemy();
        }
        else if(enemyBehaviour.enemyState == EnemyState.Attack)
        {
            AttackEnemy();
        }
        else if(enemyBehaviour.enemyState == EnemyState.Dead)
        {
            DeadEnemy();
        }
    }

    private void AttackEnemy()
    {
        enemyAnimator.SetBool("IsAttacking", true);
    }

    private void PatrolEnemy()
    {
        enemyAnimator.SetBool("IsWalking", true);
        enemyAnimator.SetBool("IsAttacking", false);
        enemyAnimator.SetBool("IsIdle", false);
        
       
        transform.Translate(directionChanger * Vector2.right * moveSpeed * Time.deltaTime);
       
        

        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistance);

        if (!hit)
        {
            Vector3 scaleVector = transform.localScale;
            scaleVector.x = -Mathf.Sign(scaleVector.x);
            transform.localScale = scaleVector;
            directionChanger = -Mathf.Sign(directionChanger);
        }
    }

    private void IdleEnemy()
    {
        enemyAnimator.SetBool("IsWalking", false);
        enemyAnimator.SetBool("IsIdle", true);
        enemyAnimator.SetBool("IsAttacking", false);
    }

    private void DeadEnemy()
    {
        enemyAnimator.SetBool("IsDead", true);
    }
}
